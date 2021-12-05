using CF.ProjectService.Application.Common.Mappings;
using CF.ProjectService.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Features.ProjectFeatures.Dto
{
    public class ProjectStageDto : IMapFrom<ProjectStage>
    {
        //public ProjectStage ProjectStage { get; set; }
        public Guid Id { get; set; }
        public string Stage { get; set; }
    }
}
