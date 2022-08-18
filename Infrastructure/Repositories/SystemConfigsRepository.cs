using Core.Dto;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class SystemConfigsRepository : ISystemConfigsRepository
    {
        private readonly ScrumDbContext _context;

        public SystemConfigsRepository(ScrumDbContext context)
        {
            _context = context;
        }
        public async Task<List<SystemConfig>> GetSystemConfig()
            => await _context.SystemConfigs.ToListAsync();

        public async Task<SystemConfig> GetSystemConfigByIdAsync(int id)
            => await _context.SystemConfigs.FirstOrDefaultAsync(c => c.Id == id);

        public async Task<int> Update(SystemConfig systemConfig)
        {
            _context.SystemConfigs.Update(systemConfig);
            return await _context.SaveChangesAsync();
        }
    }
}
