using System;
using System.Collections.Generic;
using System.Text;
using CF.ProjectService.Application.Entities.Base;

namespace CF.ProjectService.Application.Entities
{
    public class ProjectUser : BaseEntity
    {
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
        public Guid UserId { get; set; }
        public AppUser User { get; set; }

        public int? Type {get;set;}
        public bool CanEdit { get; set; }
    }
}
