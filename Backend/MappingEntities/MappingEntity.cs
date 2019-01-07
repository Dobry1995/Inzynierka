using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.ViewModels;
using Backend.Models;
using Backend.DTOs;
using Backend.DTOs.UpdateProfileDtos;

namespace Backend.MappingEntities
{
    public class MappingEntity : Profile
    {
        public MappingEntity()
        {
            CreateMap<DzokejDTO, Dzokej>().ReverseMap();
            CreateMap<GraczDTO, Gracz>().ReverseMap();
            CreateMap<ProfileUpdatesDTO.GraczProfil, Gracz>().ReverseMap();
            CreateMap<ProfileUpdatesDTO.GraczHaslo, Gracz>().ReverseMap();
            
        }
    }
}
