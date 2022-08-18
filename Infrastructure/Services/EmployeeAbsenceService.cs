using Core.Dto;
using Core.Entities;
using Core.Enum;
using Core.Interfaces;
using Infrastructure.IServices;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class EmployeeAbsenceService : IEmployeeAbsenceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeAbsenceRepository _employeeAbsenceRepository;
        private readonly IAbsenceTypesRepository _absenceTypesRepository;

        public EmployeeAbsenceService(IUnitOfWork unitOfWork, IEmployeeAbsenceRepository employeeAbsenceRepository, IAbsenceTypesRepository absenceTypesRepository)
        {
            _unitOfWork = unitOfWork;
            _employeeAbsenceRepository = employeeAbsenceRepository;
            _absenceTypesRepository = absenceTypesRepository;
        }

        public async Task<int> CreateVacation(EmployeeAbsence employeeAbsence)
        {
            var empLast = await _employeeAbsenceRepository.GetLastByUserId(employeeAbsence.TFSUserId);

            int duration = await GetDuration(empLast);

            int AnnualVacationsCount = 0;
            int CasualVacationsCount = 0;
            int WorkFromHomeCount = 0;
            int MaternityleaveCount = 0;
            int SickLeaveCount = 0;

            if (empLast == null)
            {
                if (employeeAbsence.AbsenceTypeId == (int)AbsenceType.Annual)
                {
                    AnnualVacationsCount = duration + 1;
                }
                else if (employeeAbsence.AbsenceTypeId == (int)AbsenceType.Casual)
                {
                    CasualVacationsCount = duration + 1;
                }
                else if (employeeAbsence.AbsenceTypeId == (int)AbsenceType.Home)
                {
                    WorkFromHomeCount = duration + 1;
                }
                else if (employeeAbsence.AbsenceTypeId == (int)AbsenceType.Sick)
                {
                    SickLeaveCount = duration + 1;
                }
                else if (employeeAbsence.AbsenceTypeId == (int)AbsenceType.Maternity)
                {
                    MaternityleaveCount = duration + 1;
                }
            }
            else
            {
                AnnualVacationsCount = empLast.AnnualVacationsCount + duration + 1;
                CasualVacationsCount = empLast.CasualVacationsCount;
                WorkFromHomeCount = empLast.WorkFromHomeCount;
                MaternityleaveCount = empLast.MaternityLeaveCount;
                SickLeaveCount = empLast.SickLeaveCount;

                if (empLast.AbsenceTypeId == (int)AbsenceType.Casual)
                {
                    CasualVacationsCount = empLast.CasualVacationsCount + duration + 1;
                }
                else if (empLast.AbsenceTypeId == (int)AbsenceType.Home)
                {
                    WorkFromHomeCount = empLast.WorkFromHomeCount + duration + 1;
                }
                else if (empLast.AbsenceTypeId == (int)AbsenceType.Maternity)
                {
                    MaternityleaveCount = empLast.MaternityLeaveCount + duration + 1;
                }
                else if (empLast.AbsenceTypeId == (int)AbsenceType.Sick)
                {
                    SickLeaveCount = empLast.SickLeaveCount + duration + 1;
                }
            }

            var employeeAbsent = await GetEmployeeAbsence(employeeAbsence, AnnualVacationsCount,
                CasualVacationsCount, MaternityleaveCount, SickLeaveCount, WorkFromHomeCount);

            return await _unitOfWork.Repository<EmployeeAbsence>().Create(employeeAbsent);
        }
        public async Task<int> UpdateVacation(EmployeeAbsence employeeAbsence)
        {
            var empAbsent = await _unitOfWork.Repository<EmployeeAbsence>().GetById(employeeAbsence.Id);

            if (empAbsent == null) throw new Exception("Employee Absence not found");

            if (employeeAbsence.AbsenceStatus == AbsenceStatus.Approved)
            {
                empAbsent.AbsenceStatus = AbsenceStatus.Approved;
            }
            else if (employeeAbsence.AbsenceStatus == AbsenceStatus.Rejected)
            {
                if (empAbsent.AbsenceTypeId == (int)AbsenceType.Annual)
                {
                    empAbsent.AnnualVacationsCount = empAbsent.AnnualVacationsCount - ((employeeAbsence.EndDate.Day - employeeAbsence.StartDate.Day) + 1);
                }
                else if (empAbsent.AbsenceTypeId == (int)AbsenceType.Casual)
                {
                    empAbsent.CasualVacationsCount = empAbsent.CasualVacationsCount - ((employeeAbsence.EndDate.Day - employeeAbsence.StartDate.Day) + 1);
                }
                else if (empAbsent.AbsenceTypeId == (int)AbsenceType.Home)
                {
                    empAbsent.WorkFromHomeCount = empAbsent.WorkFromHomeCount - ((employeeAbsence.EndDate.Day - employeeAbsence.StartDate.Day) + 1);
                }
                else if (empAbsent.AbsenceTypeId == (int)AbsenceType.Maternity)
                {
                    empAbsent.MaternityLeaveCount = empAbsent.MaternityLeaveCount - ((employeeAbsence.EndDate.Day - employeeAbsence.StartDate.Day) + 1);
                }
                else if (empAbsent.AbsenceTypeId == (int)AbsenceType.Sick)
                {
                    empAbsent.SickLeaveCount = empAbsent.SickLeaveCount - ((employeeAbsence.EndDate.Day - employeeAbsence.StartDate.Day) + 1);
                }
                empAbsent.AbsenceStatus = AbsenceStatus.Rejected;
            }
            return await _unitOfWork.Repository<EmployeeAbsence>().Update(empAbsent);
        }
        public async Task<List<EmployeeAbsenceDto>> GetAll()
        {
            var absents = await _employeeAbsenceRepository.GetAbsenceByCurrentMonth();

            var employeeAbsenceDto = new List<EmployeeAbsenceDto>();

            foreach (var item in absents)
            {
                var user = await _unitOfWork.Repository<TFSUser>().GetById(item.TFSUserId);

                if (user == null) throw new Exception("User Not Found");

                var absentType = await _unitOfWork.Repository<AbsenceTypes>().GetById(item.AbsenceTypeId);

                if (absentType == null) throw new Exception("Absence Type Not Found");

                int duration = await GetDuration(item);

                AbsenceStatus status = new AbsenceStatus();

                if (!await IsValidAbsenceStatus(item)) throw new Exception("Invalid AbsentStatusId");

                status = item.AbsenceStatus;

                var empAbsenceDto = new EmployeeAbsenceDto()
                {
                    EmployeeName = user.Name,
                    AbsentTypeName = absentType.Name.ToString(),
                    AbsentStatusName = status.ToString(),
                    StartDate = item.StartDate,
                    EndDate = item.EndDate,
                    DaysCount = duration + 1,
                    SquadId = user.SquadId
                };

                employeeAbsenceDto.Add(empAbsenceDto);
            }
            return employeeAbsenceDto;
        }
        public async Task<VacationDto> GetById(int id)
        {
            var empAbsent = await _unitOfWork.Repository<EmployeeAbsence>().GetById(id);
            if (empAbsent == null) throw new Exception("Not Found");

            AbsenceStatus status = new AbsenceStatus();

            if (!await IsValidAbsenceStatus(empAbsent)) throw new Exception("Invalid AbsentStatusId");

            status = empAbsent.AbsenceStatus;

            var vacation = new VacationDto()
            {
                Id = empAbsent.Id,
                AbsenceTypeId = empAbsent.AbsenceTypeId,
                StartDate = empAbsent.StartDate,
                EndDate = empAbsent.EndDate,
                TFSUserId = empAbsent.TFSUserId,
                WorkYearId = empAbsent.WorkYearId,
                AbsenceStatus = status
            };
            return vacation;
        }
        public async Task<List<EmployeeAbsenceDto>> GetPendingRequests()
        {
            var pendingAbsents = await _employeeAbsenceRepository.GetPending();

            var employeeAbsenceDto = new List<EmployeeAbsenceDto>();

            foreach (var item in pendingAbsents)
            {
                int duration = await GetDuration(item);

                var user = await _unitOfWork.Repository<TFSUser>().GetById(item.TFSUserId);

                var absentType = await _unitOfWork.Repository<AbsenceTypes>().GetById(item.AbsenceTypeId);

                var empAbsenceDto = new EmployeeAbsenceDto()
                {
                    EmployeeName = user.Name,
                    AbsentTypeName = absentType.Name.ToString(),
                    StartDate = item.StartDate,
                    EndDate = item.EndDate,
                    DaysCount = duration + 1,
                    SquadId = user.SquadId
                };

                employeeAbsenceDto.Add(empAbsenceDto);
            }
            return employeeAbsenceDto;
        }
        public async Task<VacationBalanceDto> GetVacationBalance(int id)
        {
            var vacation = await _employeeAbsenceRepository.GetVacationBalance(id);

            var casualDays = (await _absenceTypesRepository.GetByName("casual")).DaysCount;

            var annualDays = (await _absenceTypesRepository.GetByName("annual")).DaysCount;

            int AnnualVacationsCount = annualDays;
            int CasualVacationsCount = casualDays;
            int CasualVacationsRemainingDays = casualDays;
            int AnnualVacationsRemainingDays = annualDays;

            if (vacation != null)
            {
                AnnualVacationsCount = annualDays;
                AnnualVacationsRemainingDays = annualDays - vacation.AnnualVacationsCount;
                CasualVacationsCount = casualDays;
                CasualVacationsRemainingDays = casualDays - vacation.CasualVacationsCount;
            }

            return await GetVacationBalanceDto(AnnualVacationsCount, CasualVacationsCount, AnnualVacationsRemainingDays, CasualVacationsRemainingDays);
        }

        public async Task<EmployeeAbsence> GetLastByUserId(int id)
        {
            var absent = await _employeeAbsenceRepository.GetLastByUserId(id);

            if (absent == null) throw new Exception("Not Found");
            return absent;
        }

        public Task<List<EmployeeAbsence>> GetUserMonthlyVacations(int id, int month, WorkYear year)
        {
            throw new NotImplementedException();
        }

        public async Task<List<VacationSummaryDto>> GetVacationSummary(int id)
        {
            var absentTypes = await _unitOfWork.Repository<AbsenceTypes>().GetAll();

            var empLast = await _employeeAbsenceRepository.GetLastByUserId(id);

            var vacationSummary = new List<VacationSummaryDto>();

            foreach (var item in absentTypes)
            {
                var summary = await CalculateVacation(item, empLast);

                vacationSummary.Add(summary);
            }

            var absents = await _employeeAbsenceRepository.GetAbsenceByCurrentMonth();

            foreach (var item in absents)
            {
                var user = await _unitOfWork.Repository<TFSUser>().GetById(item.TFSUserId);

                if (user == null) throw new Exception("User Not Found");

                var absentType = await _unitOfWork.Repository<AbsenceTypes>().GetById(item.AbsenceTypeId);

                if (absentType == null) throw new Exception("Absence Type Not Found");

                AbsenceStatus status = new AbsenceStatus();

                if (!await IsValidAbsenceStatus(item)) throw new Exception("Invalid AbsentStatusId");

                status = item.AbsenceStatus;

                var summary = new VacationSummaryDto();

                var empAbsenceDto = new EmployeeAbsenceDto()
                {
                    EmployeeName = user.Name,
                    AbsentTypeName = absentType.Name.ToString(),
                    AbsentStatusName = status.ToString(),
                    StartDate = item.StartDate,
                    EndDate = item.EndDate
                };

                if (empAbsenceDto.EndDate.Year == DateTime.Now.Year)
                {
                    summary.Vacations = empAbsenceDto;
                    vacationSummary.Add(summary);
                }
            }
            return vacationSummary;
        }


        public Task<bool> ApproveAll()
        {
            throw new NotImplementedException();
        }
        public Task<bool> RejectAll()
        {
            throw new NotImplementedException();
        }

        private Task<bool> IsValidAbsenceStatus(EmployeeAbsence item)
        {
            switch (item.AbsenceStatus)
            {
                case AbsenceStatus.Pending:
                case AbsenceStatus.Approved:
                case AbsenceStatus.Rejected:
                    return Task.FromResult(true);
                default:
                    return Task.FromResult(false);
            }
        }
        private Task<List<DateTime>> GetDates(EmployeeAbsence item)
        {
            var dates = new List<DateTime>();
            for (DateTime date = item.StartDate; date <= item.EndDate; date = date.AddDays(1))
            {
                dates.Add(date);
            }
            return Task.FromResult(dates);
        }
        private async Task<int> GetDuration(EmployeeAbsence item)
        {
            var dates = await GetDates(item);
            int duration = (item.EndDate - item.StartDate).Days;

            foreach (var date in dates)
            {
                DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(date);
                duration = (day == DayOfWeek.Friday || day == DayOfWeek.Saturday) ? duration - 1 : duration;
            }
            return duration;
        }
        private Task<EmployeeAbsence> GetEmployeeAbsence(EmployeeAbsence employeeAbsence, int annualVacationsCount,
                                            int casualVacationsCount, int maternityleaveCount, int sickLeaveCount, int workFromHomeCount)
        {
            return Task.FromResult(new EmployeeAbsence()
            {
                TFSUserId = employeeAbsence.TFSUserId,
                AbsenceStatus = AbsenceStatus.Pending,
                AbsenceTypeId = employeeAbsence.AbsenceTypeId,
                StartDate = employeeAbsence.StartDate,
                EndDate = employeeAbsence.EndDate,
                WorkYearId = employeeAbsence.WorkYearId,
                AnnualVacationsCount = annualVacationsCount,
                CasualVacationsCount = casualVacationsCount,
                MaternityLeaveCount = maternityleaveCount,
                WorkFromHomeCount = workFromHomeCount,
                SickLeaveCount = sickLeaveCount
            });
        }
        private Task<VacationSummaryDto> CalculateVacation(AbsenceTypes absenceTypes, EmployeeAbsence employeeAbsence)
        {
            var summary = new VacationSummaryDto();

            summary.VacationType = absenceTypes.Name.ToString();
            summary.TotalDays = absenceTypes.DaysCount;

            int takenDays = 0;
            int remainingDays = absenceTypes.DaysCount;

            if (employeeAbsence != null)
            {
                switch (absenceTypes.Name)
                {
                    case AbsenceType.Annual:
                        takenDays = employeeAbsence.AnnualVacationsCount;
                        remainingDays = absenceTypes.DaysCount - employeeAbsence.AnnualVacationsCount;
                        break;
                    case AbsenceType.Casual:
                        takenDays = employeeAbsence.CasualVacationsCount;
                        remainingDays = absenceTypes.DaysCount - employeeAbsence.CasualVacationsCount;
                        break;
                    case AbsenceType.Home:
                        takenDays = employeeAbsence.WorkFromHomeCount;
                        remainingDays = absenceTypes.DaysCount - employeeAbsence.WorkFromHomeCount;
                        break;
                    case AbsenceType.Sick:
                        takenDays = employeeAbsence.SickLeaveCount;
                        remainingDays = absenceTypes.DaysCount - employeeAbsence.SickLeaveCount;
                        break;
                    case AbsenceType.Maternity:
                        takenDays = employeeAbsence.MaternityLeaveCount;
                        remainingDays = absenceTypes.DaysCount - employeeAbsence.MaternityLeaveCount;
                        break;
                    default:
                        throw new Exception("Invalid AbsenceType");
                }
            }
            UpdateVacationSummary(summary, takenDays, remainingDays);
            return Task.FromResult(summary);
        }
        private void UpdateVacationSummary(VacationSummaryDto summary, int takenDays, int remainingDays)
        {
            summary.TakenDays = takenDays;
            summary.RemainingDays = remainingDays;
        }
        private Task<VacationBalanceDto> GetVacationBalanceDto(int annualCount, int casualCount, int annualRemaining, int casualRemaining)
        {
            return Task.FromResult(new VacationBalanceDto()
            {
                AnnualVacationsCount = annualCount,
                CasualVacationsCount = casualCount,
                AnnualVacationsRemainingDays = annualRemaining,
                CasualVacationsRemainingDays = casualRemaining
            });
        }

    }
}
