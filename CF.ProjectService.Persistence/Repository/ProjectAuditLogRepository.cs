using CF.ProjectService.Application.Common.Interfaces.IRepositories;
using CF.ProjectService.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Persistence.Repository
{
    public class ProjectAuditLogRepository : BaseRepository<ProjectAuditLog>, IProjectAuditLogRepository
    {
        public ApplicationDbContext _dbContext;
        public ProjectAuditLogRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
