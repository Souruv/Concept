using CF.ProjectService.Application.Common.Enums;
using CF.ProjectService.Application.Features.UserFeatures.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Features.ProjectFeatures.Dto
{
    public class AuditLogDto
    {
        public AuditLogStatus AuditLogStatus { get; set; }
        public Guid RevisionId { get; set; }
        public DateTime ActionOn { get; set; }
        public Guid ActionByUserId { get; set; }
        public string RespondedRemarks { get; set; }
        public string Message { get; set; }

        //public ProjectRevisionDto ProjectRevision { get; set; }
        public AppUserDto ActionByUser { get; set; }
    }
}
