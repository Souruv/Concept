using CF.CostBrainService.Application.Common.Interfaces.IRepositories;
using CF.CostBrainService.Application.Entities;

namespace CF.CostBrainService.Persistence.Repository
{
    public class MasterPercentManPowerRepository : BaseRepository<MasterPercentManPower>, IMasterPercentManPowerRepository
    {
        ApplicationDbContext _dbContext;
        public MasterPercentManPowerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
