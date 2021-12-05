
using System;
using AutoMapper;
using System.Collections.Generic;
using System.Text;
using CF.AuthService.Application.Entities;
using CF.AuthService.Application.Common.Mappings;

namespace CF.AuthService.Application.Features.UserFeatures.Dto
{
    public class AppUserDto : IMapFrom<AppUser>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }        
        public string DepartmentName { get; set; }
        public string Area { get; set; }
        public string UserPrincipal { get; set; }
        public bool IsAdmin { get; set; }

        public Guid? RoleId { get; set; }
        public Guid? FelStageId { get; set; }

        public RoleDto? Role { get; set; }
        public FelStageDto? FelStage { get; set; }


    }
}
