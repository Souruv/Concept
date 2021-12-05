using CF.ProjectService.Application.Common.Enums;
using CF.ProjectService.Application.Entities;
using CF.ProjectService.Application.Features.ProjectFeatures.Dto;
using CF.ProjectService.Application.Features.UserFeatures.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CF.ProjectService.Application.Services.Interfaces
{
    public interface IProjectDService
    {
        public Task<string> GetNextUniqueProjectName(string baseProjectName);
        public Task<int> GetNextRevisionNo(Guid projectid);
        public Task<List<ApproverDto>> GetApprovers(ProjectRevision revision);
        public Task<bool> UpdateProjectEntity(ProjectRevision projectRevision);
        public Task<bool> IsProjectNameExist(string projectName, Guid? projectId = null);
        public Task<string> GetNextPid();

        /*public Task<bool> UpdateProjectInformation(
            Guid? RevisionId,
            ProjectInfoPostDto ProjectInfo,
            EnviromentalDto Environmental,
            InfrastructureDto Infrastructure,
            RevisionStatus revisionStatus,
            string responsedRemarks = null,
            TeamMembersDto TeamMembers = null
        );*/

        public Task<ProjectRevision> UpdateProjectInforAsync(ProjectRevision revisionFromDb, ProjectInfoPostDto projectInfoDto, ProjectTrigger? projectTrigger = null);
        public Task UpdateProjectEnviromentAsync(ProjectRevision revisionFromDb, EnviromentalDto environmental);
        public Task UpdateProjectInfrastructureAsync(ProjectRevision revisionFromDb, InfrastructureDto infrastructure);
        public Task UpdateProjectStatus(ProjectRevision revisionFromDb, ProjectTrigger projectTrigger, string responsedRemarks = null);
        public Task UpdateProjectTeamMembers(ProjectRevision revisionFromDb, TeamMembersDto TeamMembers);
        public Task<bool> CheckPermissionUserTrigger(ProjectRevision revision, ProjectTrigger action);
    }
}
