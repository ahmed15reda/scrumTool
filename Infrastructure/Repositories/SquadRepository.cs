using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class SquadRepository : GenericRepository<Squad>, ISquadRepository
    {
        private readonly ScrumDbContext _context;

        public SquadRepository(ScrumDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Squad> GetByName(string name)
            => await _context.Squads.FirstOrDefaultAsync(u => u.Name == name);

    }
}
