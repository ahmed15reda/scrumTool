using Core.Entities;
using Core.Enum;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EmployeeAbsenceRepository: GenericRepository<EmployeeAbsence>, IEmployeeAbsenceRepository
    {
        private readonly ScrumDbContext _context;

        public EmployeeAbsenceRepository(ScrumDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<EmployeeAbsence>> GetByUserId(int id)
            => await _context.EmployeeAbsences.Where(x => x.TFSUserId == id).ToListAsync();

        public async Task<EmployeeAbsence> GetVacationBalance(int id)
            => await _context.EmployeeAbsences.OrderByDescending(x=> x.Id).FirstOrDefaultAsync(x => x.TFSUserId == id);
        public async Task<EmployeeAbsence> GetLastByUserId(int id)
            => await _context.EmployeeAbsences.OrderByDescending(x => x.Id).FirstOrDefaultAsync(x => x.TFSUserId == id);

        public async Task<List<EmployeeAbsence>> GetLast3RecordsByUserId(int id)
            => await _context.EmployeeAbsences.Where(x=> x.TFSUserId == id).OrderByDescending(x=> x.Id).Take(3).ToListAsync();
        public async Task<List<EmployeeAbsence>> GetPending()
            => await _context.EmployeeAbsences.Where(x => x.AbsenceStatus == (AbsenceStatus)1).ToListAsync();

        public async Task<List<EmployeeAbsence>> GetUserMonthlyVacations(int id, int month, WorkYear year)
            => await _context.EmployeeAbsences.Where(x=> ((x.StartDate.Month == month && x.StartDate.Year == Convert.ToInt32(year.Name))
                                                   || (x.EndDate.Month == month && x.EndDate.Year == Convert.ToInt32(year.Name))) && x.TFSUserId == id).ToListAsync();

        public async Task<List<EmployeeAbsence>> GetAbsenceByCurrentMonth()
            => await _context.EmployeeAbsences.Where(x => x.StartDate.Month == DateTime.Now.Month || x.EndDate.Month == DateTime.Now.Month).ToListAsync();
    }
}
