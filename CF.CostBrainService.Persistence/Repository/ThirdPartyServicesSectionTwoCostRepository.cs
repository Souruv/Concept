using CF.CostBrainService.Application.Common.Interfaces.IRepositories;
using CF.CostBrainService.Application.Entities;

namespace CF.CostBrainService.Persistence.Repository
{
    public class ThirdPartyServicesSectionTwoCostRepository : BaseRepository<ThirdPartyServicesSectionTwoCost>, IThirdPartyServicesSectionTwoCostRepository
    {
        ApplicationDbContext _dbContext;
        public ThirdPartyServicesSectionTwoCostRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
