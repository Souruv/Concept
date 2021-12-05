using CF.CostBrainService.Application.Common.Interfaces.IRepositories;
using CF.CostBrainService.Application.Entities;

namespace CF.CostBrainService.Persistence.Repository
{
    public class FuelAndPWCostRepository : BaseRepository<FuelAndPWCost>, IFuelAndPWCostRepository
    {
        ApplicationDbContext _dbContext;
        public FuelAndPWCostRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

            _dbContext = dbContext;
        }
    }
}
