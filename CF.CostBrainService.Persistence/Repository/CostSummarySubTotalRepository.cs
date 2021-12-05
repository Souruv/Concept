using CF.CostBrainService.Application.Common.Interfaces.IRepositories;
using CF.CostBrainService.Application.Entities;


namespace CF.CostBrainService.Persistence.Repository
{
    public class CostSummarySubTotalRepository : BaseRepository<CostSummarySubTotal>, ICostSummarySubTotalRepository
    {
        ApplicationDbContext _dbContext;
        public CostSummarySubTotalRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

            _dbContext = dbContext;
        }
    }
}
