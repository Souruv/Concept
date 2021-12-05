using CF.CostBrainService.Application.Common.Interfaces.IRepositories;
using CF.CostBrainService.Application.Entities;

namespace CF.CostBrainService.Persistence.Repository
{
    public class MarineSpreadCostRepository : BaseRepository<MarineSpreadCost>, IMarineSpreadCostRepository
    {
        ApplicationDbContext _dbContext;
        public MarineSpreadCostRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
