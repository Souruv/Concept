using CF.ProjectService.Application.Common.Mappings;
using CF.ProjectService.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Features.UserFeatures.Dto
{
    //this dtos to hold the logged in users information only. not to use in any request/response
    public class AuthUserDto 
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
    public class RoleDto 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    public class FelStageDto 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }



    }
}
