using CF.ProjectService.Application.Common.Interfaces.IRepositories;
using CF.ProjectService.Application.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CF.ProjectService.Persistence.Repository
{
    public class ProjectNotificationRepository : BaseRepository<ProjectNotification>, IProjectNotificationRepository
    {
        public ApplicationDbContext _dbContext;
        public ProjectNotificationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
