using Core.Dto;
using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.IServices
{
    public interface IEmployeeAbsenceService
    {
        Task<List<EmployeeAbsenceDto>> GetAll();
        Task<VacationDto> GetById(int id);
        Task<EmployeeAbsence> GetLastByUserId(int id);
        Task<int> CreateVacation(EmployeeAbsence employeeAbsence);
        Task<int> UpdateVacation(EmployeeAbsence employeeAbsence);
        Task<List<EmployeeAbsenceDto>> GetPendingRequests();
        Task<List<EmployeeAbsence>> GetUserMonthlyVacations(int id, int month, WorkYear year);
        Task<List<VacationSummaryDto>> GetVacationSummary(int id);
        Task<bool> ApproveAll();
        Task<bool> RejectAll();
        Task<VacationBalanceDto> GetVacationBalance(int id);
    }
}
