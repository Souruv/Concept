using CF.ProjectService.Application.Features.UserFeatures.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Features.ProjectFeatures.Dto
{
    public class ProjectNotificationDto
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public Guid RevisionId { get; set; }
        public string ProjectName { get; set; }
        public DateTime? ActionOn { get; set; }
        public AppUserDto ActionBy { get; set; }
        public int RevisionStatus { get; set; }
        public bool IsRead { get; set; }
    }
}
