using CF.ProjectService.Application.Common.Mappings;
using CF.ProjectService.Application.Features.UserFeatures.Dto;
using CF.ProjectService.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Features.ProjectFeatures.Dto
{
    public class ProjectBasicDto : IMapFrom<Project>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Pid { get; set; }
        public string Business { get; set; }
        public string ProjectType { get; set; }
        public string Author { get; set; }
        public string CreatedByUserName { get; set; }
        public AppUserDto CreatedByUser{ get; set; }
        public AppUserDto ModifiedByUser { get; set; }
        public AppUserDto TechicalManagerConceptor { get; set; }
        //public AppUserDto SpecialistsAlternateUser { get; set; }
        public DateTime? CreatedOn{ get; set; }
        public DateTime? ModifiedOn { get; set; }

        public ProjectRevisionDto ProjectRevisionInfo { get; set; }
        public List<ProjectRevisionDto> ProjectRevisions { get; set; }

         public string? SubmittedBy { get; set; }
        public DateTime? LatestModifiedOn { get; set; }
        public DateTime? LatestCreatedOn { get; set; }
        public DateTime? LatestSubmittedOn { get; set; }

        public DateTime? LatestDeletedOn {get;set;}

        public string LatestSubmittedBy { get; set; }
        public AppUserDto SpeciaListUserConceptor { get; set; }
        public AppUserDto SpecialistAlternateUserConceptor { get; set; }

        public bool IsQuestorFileUploaded { get; set; }
        public AppUserDto SpeciaListUserCostimator { get; set; }

        public AppUserDto SpecialistAlternateUserCostimator { get; set; }

        public AppUserDto TechicalManagerCostimator { get; set; }

    

        public List<ProjectUserDto> ProjectUsers { get; set; }


    }
}
