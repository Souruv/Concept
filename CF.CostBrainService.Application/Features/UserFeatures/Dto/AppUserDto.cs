using CF.CostBrainService.Application.Common.Mappings;
using CF.CostBrainService.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.CostBrainService.Application.Features.UserFeatures.Dto
{
    public class AppUserDto : IMapFrom<AppUser>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }        
        public string DepartmentName { get; set; }
        public string UserPrincipal { get; set; }
        public int Role { get; set; }
        public bool IsAdmin { get; set; }
    }
}
