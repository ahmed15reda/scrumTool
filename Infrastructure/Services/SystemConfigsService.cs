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
    public class SystemConfigsService: ISystemConfigsService
    {
        private readonly ISystemConfigsRepository _systemConfigsRepository;
        private readonly IMapper _mapper;

        public SystemConfigsService(ISystemConfigsRepository systemConfigsRepository, IMapper mapper)
        {
            _systemConfigsRepository = systemConfigsRepository;
            _mapper = mapper;
        }

        public async Task<List<SystemConfig>> GetSystemConfig()
            => await _systemConfigsRepository.GetSystemConfig();

        public async Task<int> Update(SystemConfig systemConfig)
        {
            var config = await _systemConfigsRepository.GetSystemConfigByIdAsync(systemConfig.Id);

            if (config == null) throw new ConfigurationNotFoundException();

            //_mapper.Map<SystemConfig>(config);
            return await _systemConfigsRepository.Update(config);
        }
    }
}
