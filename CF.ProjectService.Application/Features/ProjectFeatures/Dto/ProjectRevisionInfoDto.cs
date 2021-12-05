using CF.ProjectService.Application.Common.Enums;
using CF.ProjectService.Application.Common.Mappings;
using CF.ProjectService.Application.Entities;
using CF.ProjectService.Application.Features.UserFeatures.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Features.ProjectFeatures.Dto
{
    public class ProjectRevisionInfoDto: IMapFrom<ProjectRevision>
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public int No { get; set; }
        public string Tag { get; set; }

        public bool IsDeleted { get; set; }

        public ProjectStageDto Stage { get; set; }
        public Guid SubmittedByUserId { get; set; }
        public AppUserDto SubmittedByUser { get; set; }
        public RevisionStatus RevisionStatus { get; set; }

        public AppUserDto CreatedByUser { get; set; }
        public AppUserDto ModifiedByUser { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsAcknowledged { get; set; }

    }
}
