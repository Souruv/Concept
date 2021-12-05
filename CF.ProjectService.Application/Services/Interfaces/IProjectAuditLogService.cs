using CF.ProjectService.Application.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CF.ProjectService.Application.Services.Interfaces
{
    public interface IProjectAuditLogService
    {
        Task AddLogProjectAsync(Guid revisionId, AuditLogStatus status, string remarks = null);
    }
}
