using CF.CostBrainService.Application.Common.Interfaces.IRepositories;
using CF.CostBrainService.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.CostBrainService.Persistence.Repository
{
    public class DefaultThirdPartyServicesSectionTwoRepository : BaseRepository<DefaultThirdPartyServicesSectionTwo>, IDefaultThirdPartyServicesSectionTwoRepository
    {
        ApplicationDbContext _dbContext;
        public DefaultThirdPartyServicesSectionTwoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

            _dbContext = dbContext;
        }
    }
}
