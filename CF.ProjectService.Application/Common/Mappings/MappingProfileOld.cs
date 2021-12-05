using AutoMapper;
using CF.ProjectService.Application.Features.UserFeatures.Dto;
using System;
using System.Linq;
using System.Reflection;
using CF.ProjectService.Application.Entities;

namespace CF.ProjectService.Application.Common.Mappings
{
    public class MappingProfileOld : Profile
    {
        public MappingProfileOld()
        {
            //CreateMap<AppUser, AppUserDto>().ReverseMap();
        }

      
    }
}