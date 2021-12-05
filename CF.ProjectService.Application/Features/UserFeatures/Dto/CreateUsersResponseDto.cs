using CF.ProjectService.Application.Common.Mappings;
using CF.ProjectService.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Features.UserFeatures.Dto
{
    public class CreateUsersResponseDto 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }        
        public bool IsExist { get; set; }
    }
}
