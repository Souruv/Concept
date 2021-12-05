using CF.ProjectService.Application.Common.Enums;
using CF.ProjectService.Application.Common.Mappings;
using CF.ProjectService.Application.Features.UserFeatures.Dto;
using CF.ProjectService.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace CF.ProjectService.Application.Features.ProjectFeatures.Dto
{
    public class ProjectRevisionDto : IMapFrom<ProjectRevision>
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public int RevisionNo { get; set; }

        public DateTime? ExpecedFirstResponseBy { get; set; }
        public string? Remarks { get; set; }
        public decimal? TargetUnitTechnicalCost { get; set; }
        public string? Utc { get; set; }
        public string? ServiecRequestNUmber { get; set; }

        public bool IsDeleted { get; set; }
        public ProjectStageDto ProjectStage { get; set; }
        public Guid? SubmittedByUserId { get; set; }
        public AppUserDto SubmittedByUser { get; set; }
        public RevisionStatus RevisionStatus { get; set; }

        public AppUserDto CreatedByUser { get; set; }
        public AppUserDto ModifiedByUser { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public string RespondedRemarks { get; set; }

        public DateTime? SubmittedOn { get; set; }

        public bool IsAcknowledged { get; set; }
        public DateTime? RespondedOn { get; internal set; }
        public AppUser RespondedByUser { get; internal set; }

        public List<RevisionTeamMemberDto> RevisionTeamMembers { get; set; }
    }
}
