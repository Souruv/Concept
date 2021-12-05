using CF.CostBrainService.Application.Common.Interfaces.IRepositories;
using CF.CostBrainService.Application.Entities;

namespace CF.CostBrainService.Persistence.Repository
{
    public class MasterMarineSpreadOptionRepository : BaseRepository<MasterMarineSpreadOption>, IMasterMarineSpreadOptionRepository
    {
        ApplicationDbContext _dbContext;
        public MasterMarineSpreadOptionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
