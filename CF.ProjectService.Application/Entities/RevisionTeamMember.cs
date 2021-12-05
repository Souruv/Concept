using System;
using System.Collections.Generic;
using System.Text;
using CF.ProjectService.Application.Entities.Base;

namespace CF.ProjectService.Application.Entities
{
    public class RevisionTeamMember : BaseEntity
    {
        public Guid RevisionId { get; set; }
        public ProjectRevision Revision { get; set; }
        public Guid UserId { get; set; }
        public AppUser User { get; set; }

        public int Type {get;set;}
    }
}
