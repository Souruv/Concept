using CF.CostBrainService.Application.Common.Interfaces.IRepositories;
using CF.CostBrainService.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.CostBrainService.Persistence.Repository
{
    public class DefaultManpowerRepository : BaseRepository<DefaultManpower>, IDefaultManpowerRepository
    {
        ApplicationDbContext _dbContext;
        public DefaultManpowerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
