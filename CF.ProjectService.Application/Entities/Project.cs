using System;
using System.Collections.Generic;
using System.Text;
using CF.ProjectService.Application.Entities.Base;

namespace CF.ProjectService.Application.Entities
{
    public class Project : BaseEntity
    {
        public string Name { get; set; }
        public string Pid { get; set; }
        public string ProjectType { get; set; }
        public string Business { get; set; }
        public string Area{ get; set; }
        public string Asset { get; set; }

        public string FileName {get;set;}

       
        public int? LastRevisionNo { get; set; }
        public int? LastRevisionStatus { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public DateTime? LastCreatedOn { get; set; }
        public DateTime? LatestDeletedOn {get;set;}
        public DateTime? LastSubmittedOn { get; set; }
        public Guid? LastSubmittedBy { get; set; }



        public IList<ProjectRevision> ProjectRevisions { get; private set; } = new List<ProjectRevision>();
        public AppUser LastSubmittedByUser { get; set; }
        public IList<ProjectUser> ProjectUsers { get; private set; } = new List<ProjectUser>();

        public IList<ProjectNatureDetail> ProjectNatureDetails {get;set;}
    }
}
