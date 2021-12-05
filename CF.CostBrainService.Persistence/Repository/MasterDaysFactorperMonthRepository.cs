using CF.CostBrainService.Application.Common.Interfaces.IRepositories;
using CF.CostBrainService.Application.Entities;

namespace CF.CostBrainService.Persistence.Repository
{
    public class MasterDaysFactorperMonthRepository : BaseRepository<MasterDaysFactorperMonth>, IMasterDaysFactorperMonthRepository
    {
        ApplicationDbContext _dbContext;
        public MasterDaysFactorperMonthRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
