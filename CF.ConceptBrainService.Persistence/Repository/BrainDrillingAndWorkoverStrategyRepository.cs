using CF.ConceptBrainService.Application.Common.Interfaces.IRepositories;
using CF.ConceptBrainService.Application.Entities;

namespace CF.ConceptBrainService.Persistence.Repository
{
    public class BrainDrillingAndWorkoverStrategyRepository : BaseRepository<BrainDrillingAndWorkoverStrategy>, IBrainDrillingAndWorkoverStrategyRepository
    {
        ApplicationDbContext _dbContext;
        public BrainDrillingAndWorkoverStrategyRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
