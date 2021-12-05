using CF.ProjectService.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CF.ProjectService.Application.Services.Interfaces
{
    public interface IProjectNotificationService
    {
        Task CoeSubmitProjectAsync(Guid revisionId);
        Task COEAssignOtherCOEAsync(ProjectRevision projectRevision, IEnumerable<Guid> listUserId);
        Task TMAssignProjectAsync(ProjectRevision projectRevision, IEnumerable<Guid> listUserId);
        Task TMReturnProjectAsync(Guid revisionId);
        Task UpdateReadingNotificationAsync(Guid notificationId);
    }
}
