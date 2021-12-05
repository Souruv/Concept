using CF.ConceptBrainService.Application.Common.Interfaces.IRepositories;
using CF.ConceptBrainService.Application.Entities;

namespace CF.ConceptBrainService.Persistence.Repository
{
    public class BrainCondensateHandlingRepository : BaseRepository<BrainCondensateHandling>, IBrainCondensateHandlingRepository
    {
        ApplicationDbContext _dbContext;
        public BrainCondensateHandlingRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
