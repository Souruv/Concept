using CF.ProjectService.Application.Common.Mappings;
using CF.ProjectService.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Features.ProjectFeatures.Dto
{
    public class ProjectNatureDto : IMapFrom<ProjectNature>
    {
        public Guid Id {get;set;}

        public string Nature {get;set;}
    }
}
