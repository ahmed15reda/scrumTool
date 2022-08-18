using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AbsenceTypesRepository : GenericRepository<AbsenceTypes>, IAbsenceTypesRepository
    {
        private readonly ScrumDbContext _context;

        public AbsenceTypesRepository(ScrumDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<AbsenceTypes> GetByName(string Name)
        {
            return await _context.AbsentTypes.Where(u => u.Name.ToString().ToLower().Trim().Contains(Name)).FirstOrDefaultAsync();
        }
    }
}
