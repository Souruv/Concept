using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Features.UserFeatures.Dto
{
    public class ApproverDto
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

    }

}
