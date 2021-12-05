using CF.ConceptBrainService.Application.Common.Interfaces.IRepositories;
using CF.ConceptBrainService.Application.Entities;

namespace CF.ConceptBrainService.Persistence.Repository
{
    public class BrainWaterDisposalRepository : BaseRepository<BrainWaterDisposal>, IBrainWaterDisposalRepository
    {
        ApplicationDbContext _dbContext;
        public BrainWaterDisposalRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
