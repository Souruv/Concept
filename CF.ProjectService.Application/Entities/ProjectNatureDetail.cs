using CF.ProjectService.Application.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Entities
{
    public class ProjectNatureDetail : BaseEntity  
    {
        public Guid ProjectId {get;set;}
        public Guid ProjectNatureId {get;set;}

        public Project Project {get;set;}

        public ProjectNature ProjectNature {get;set;}
    }
}
