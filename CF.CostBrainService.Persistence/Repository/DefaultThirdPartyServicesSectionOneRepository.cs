using CF.CostBrainService.Application.Common.Interfaces.IRepositories;
using CF.CostBrainService.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.CostBrainService.Persistence.Repository
{
    public class DefaultThirdPartyServicesSectionOneRepository : BaseRepository<DefaultThirdPartyServicesSectionOne>, IDefaultThirdPartyServicesSectionOneRepository
    {
        ApplicationDbContext _dbContext;
        public DefaultThirdPartyServicesSectionOneRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

            _dbContext = dbContext;
        }
    }
}
