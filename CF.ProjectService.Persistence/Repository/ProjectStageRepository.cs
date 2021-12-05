using CF.ProjectService.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using CF.ProjectService.Application.Common.Interfaces.IRepositories;

namespace CF.ProjectService.Persistence.Repository
{
    public class ProjectStageRepository : BaseRepository<ProjectStage>,IProjectStageRepository
    {
        public ProjectStageRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
