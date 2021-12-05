using CF.ProjectService.Application.Common.Mappings;
using CF.ProjectService.Application.Entities;
using CF.ProjectService.Application.Features.ProjectFeatures.Dto;
using CF.ProjectService.Application.Features.UserFeatures.Dto;
using System;
using System.Collections.Generic;

namespace Costimator.Application.Features.ProjectFeatures.Dto
{
    public class ProjectInfoDto : IMapFrom<Project>
    {
        public Guid Id { get; set; }
        public string Pid { get; set; }
        public string Name { get; set; }
        public string ProjectType { get; set; }

        public string FileName { get; set; }
        public AppUserDto CreatedByUser { get; set; }
        public AppUserDto ModifiedByUser { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string Business { get; set; }
        public string Area { get; set; }
        public string Asset { get; set; }

        public List<ProjectUserDto> ProjectUsers { get; set; }

        public List<ProjectNatureDto> Natures { get; set; }

        public ProjectRevisionDto ProjectRevisions { get; set; }

        public EnviromentalDto Environmental { get; set; }

        public InfrastructureDto Infrastructure { get; set; }

        public GroupWellCostDto WellCosts { get; set; }

        public List<ApproverDto> Approvers { get; set; }

    }
}
