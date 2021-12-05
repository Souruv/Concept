using CF.ProjectService.Application.Common.Enums;
using CF.ProjectService.Application.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Entities
{
    public class ProjectNotification : BaseEntity
    {
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public Guid RevisionId { get; set; }
        public string Message { get; set; }
        public DateTime ActionOn { get; set; }
        public bool IsRead { get; set; } = false;
        public DateTime? ReadOn { get; set; }
        public RevisionStatus RevisionStatus { get; set; }

        public ProjectRevision ProjectRevision { get; set; }
        public AppUser Sender { get; set; }
        public AppUser Receiver { get; set; }
    }
}
