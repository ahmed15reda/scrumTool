using Core.Dto;
using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ISystemConfigsRepository
    {
        Task<List<SystemConfig>> GetSystemConfig();
        Task<SystemConfig> GetSystemConfigByIdAsync(int id);
        Task<int> Update(SystemConfig systemConfig);
    }
}
