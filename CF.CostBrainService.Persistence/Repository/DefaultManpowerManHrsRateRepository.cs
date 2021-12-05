using CF.CostBrainService.Application.Common.Interfaces.IRepositories;
using CF.CostBrainService.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.CostBrainService.Persistence.Repository
{
    public class DefaultManpowerManHrsRateRepository : BaseRepository<DefaultManpowerManHrsRate>, IDefaultManpowerManHrsRateRepository
    {
        ApplicationDbContext _dbContext;
        public DefaultManpowerManHrsRateRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
