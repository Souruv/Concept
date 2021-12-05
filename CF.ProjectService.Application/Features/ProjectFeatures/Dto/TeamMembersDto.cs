using CF.ProjectService.Application.Features.UserFeatures.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Features.ProjectFeatures.Dto
{
    public class TeamMembersDto
    {
        public Guid? FrontEndEngineerTechnical { get; set; }
        public Guid[] FrontEndEngineers { get; set; }
        public Guid? CostEngineerTechnical { get; set; }
        public Guid[] CostEngineers { get; set; }
    }
}
