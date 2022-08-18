using AutoMapper;
using Core.Dto;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Exceptions;
using Infrastructure.IServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class AbsenceTypesService : IAbsenceTypesService, IDisposable
    {
        private readonly IGenericRepository<AbsenceTypes> _genericRepository;
        private readonly IAbsenceTypesRepository _absentTypesRepository;
        private readonly IMapper _mapper;

        public AbsenceTypesService(IGenericRepository<AbsenceTypes> genericRepository,IAbsenceTypesRepository absentTypesRepository, IMapper mapper )
        {
            _genericRepository = genericRepository;
            _absentTypesRepository = absentTypesRepository;
            _mapper = mapper;
        }

        public async Task<int> AddAbsentType(AbsenceTypes absentTypes)
        {
            var type = await _absentTypesRepository.GetByName(absentTypes.Name.ToString());
            if (type != null)
                throw new Exception("Faild to add new Absent Type as name already exist");

            return await _genericRepository.Create(absentTypes);
        }

        public async Task<int> DeleteAbsentType(int id)
        {
            if (!await IsTypeExist(id)) throw new AbsentTypeNotFoundException();

            return await _genericRepository.Delete(id);
        }


        public async Task<AbsenceTypesDto> GetAbsentTypeById(int id)
        {
            if (!await IsTypeExist(id)) throw new AbsentTypeNotFoundException();
            var type = await _genericRepository.GetById(id);
            return _mapper.Map<AbsenceTypesDto>(type);
        }

        public async Task<List<AbsenceTypesDto>> GetAll()
        {
            var types = await _genericRepository.GetAll();

            return _mapper.Map<List<AbsenceTypesDto>>(types);
        }

        public async Task<int> UpdateAbsentType(AbsenceTypes absentTypes)
        {
            if (!await IsTypeExist(absentTypes.Id)) throw new AbsentTypeNotFoundException();

            return await _genericRepository.Update(absentTypes);
        }
        private async Task<bool> IsTypeExist(int id)
        {
            return await _genericRepository.GetById(id) != null;
        }
        public void Dispose()
        {
            
        }
    }
}
