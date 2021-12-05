using CF.CostBrainService.Application.Common.Interfaces.IRepositories;
using CF.CostBrainService.Application.Entities;


namespace CF.CostBrainService.Persistence.Repository
{
    public class CostSummaryStructureRepository : BaseRepository<CostSummaryStructure>, ICostSummaryStructureRepository
    {
        ApplicationDbContext _dbContext;
        public CostSummaryStructureRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

            _dbContext = dbContext;
        }
    }
}
