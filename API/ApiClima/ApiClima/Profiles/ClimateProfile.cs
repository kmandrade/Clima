using ApiClima.Models;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiClima.Profiles
{
    public class ClimateProfile : Profile
    {
        public ClimateProfile()
        {
            CreateMap<Climate, DTOClimate>()
                .ForMember(dto => dto.Name, opt => opt.MapFrom(c => c.NomeCidade))
                .ForMember(dto => dto.Temp, opt => opt.MapFrom(c => c.Temp.FirstOrDefault())).ReverseMap();

            CreateMap<Temp, DTOtemp>()
                .ForMember(dto => dto.temp_min, opt => opt.MapFrom(t => t.temp_min))
                .ForMember(dto => dto.temp_min, opt => opt.MapFrom(t => t.temp_max)).ReverseMap();

                
        }
    }
}
