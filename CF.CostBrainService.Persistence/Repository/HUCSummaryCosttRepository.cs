using CF.CostBrainService.Application.Common.Interfaces.IRepositories;
using CF.CostBrainService.Application.Entities;

namespace CF.CostBrainService.Persistence.Repository
{
    public class HUCSummaryCostRepository : BaseRepository<HUCSummaryCost>, IHUCSummaryCostRepository
    {
        ApplicationDbContext _dbContext;
        public HUCSummaryCostRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
