using Core.Dto;
using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.IServices
{
    public interface ISquadService
    {
        public Task<int> AddSquad(Squad squad);
        public Task<int> DeleteSquad(int id);
        public Task<int> UpdateSquad(Squad squad);
        public Task<List<SquadDto>> GetAll();
        public Task<SquadDto> GetSquadById(int id);
    }
}
