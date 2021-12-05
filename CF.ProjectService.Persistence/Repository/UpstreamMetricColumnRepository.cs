using CF.ProjectService.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using CF.ProjectService.Application.Common.Interfaces.IRepositories;

namespace CF.ProjectService.Persistence.Repository
{
    public class UpstreamMetricColumnRepository : BaseRepository<UpstreamMetricColumn>, IUpstreamMetricColumnRepository
    {
        public UpstreamMetricColumnRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
