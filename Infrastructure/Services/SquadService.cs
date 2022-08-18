using AutoMapper;
using Core.Dto;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Exceptions;
using Infrastructure.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class SquadService: ISquadService
    {
        private readonly ISquadRepository _squadRepository;
        private readonly IGenericRepository<Squad> _genericRepository;
        private readonly IMapper _mapper;

        public SquadService(ISquadRepository squadRepository,IGenericRepository<Squad> genericRepository, IMapper mapper)
        {
            _squadRepository = squadRepository;
            _genericRepository = genericRepository;
            _mapper = mapper;
        }
        public async Task<List<SquadDto>> GetAll()
        {
            var result = await _genericRepository.GetAll();

            return _mapper.Map<List<SquadDto>>(result);
        }
        public async Task<int> AddSquad(Squad squad)
        {
            return await _genericRepository.Create(squad);
        }
        public async Task<int> UpdateSquad(Squad squad)
        {
            if (! IsSquadExist(squad.Id)) throw new SquadNotFoundException();

            return await _genericRepository.Update(squad);
        }
        public async Task<SquadDto> GetSquadById(int id)
        {
            if (! IsSquadExist(id)) throw new SquadNotFoundException();
            var squad = await _genericRepository.GetById(id);

            return _mapper.Map<SquadDto>(squad);
        }
        public async Task<int> DeleteSquad(int id)
        {
            if (! IsSquadExist(id)) throw new SquadNotFoundException();

            return await _genericRepository.Delete(id);
        }
        private bool IsSquadExist(int id)
        {
            return _genericRepository.GetById(id) != null;
        }
    }
}
