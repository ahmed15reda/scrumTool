using Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IEmployeeAbsenceRepository
    {
        Task<List<EmployeeAbsence>> GetPending();
        Task<EmployeeAbsence> GetLastByUserId(int id);
        Task<List<EmployeeAbsence>> GetByUserId(int id);
        Task<List<EmployeeAbsence>> GetUserMonthlyVacations(int id, int month, WorkYear year);
        Task<List<EmployeeAbsence>> GetLast3RecordsByUserId(int id);
        Task<EmployeeAbsence> GetVacationBalance(int id);
        Task<List<EmployeeAbsence>> GetAbsenceByCurrentMonth();
    }
}
