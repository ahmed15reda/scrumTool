using AutoMapper;
using Core.Dto;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<TFSUser, TFSUserDto>().ReverseMap();
            CreateMap<Squad, SquadDto>().ReverseMap();
            CreateMap<SystemConfig, SystemConfigDto>().ReverseMap();
            CreateMap<AbsenceTypes, AbsenceTypesDto>().ReverseMap();
        }
    }
}
