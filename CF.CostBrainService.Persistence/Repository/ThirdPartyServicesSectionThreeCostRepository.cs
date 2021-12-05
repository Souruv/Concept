using CF.CostBrainService.Application.Common.Interfaces.IRepositories;
using CF.CostBrainService.Application.Entities;

namespace CF.CostBrainService.Persistence.Repository
{
    public class ThirdPartyServicesSectionThreeCostRepository : BaseRepository<ThirdPartyServicesSectionThreeCost>, IThirdPartyServicesSectionThreeCostRepository
    {
        ApplicationDbContext _dbContext;
        public ThirdPartyServicesSectionThreeCostRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
