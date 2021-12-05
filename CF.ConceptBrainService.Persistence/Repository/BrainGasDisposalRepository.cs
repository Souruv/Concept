using CF.ConceptBrainService.Application.Common.Interfaces.IRepositories;
using CF.ConceptBrainService.Application.Entities;


namespace CF.ConceptBrainService.Persistence.Repository
{
    public class BrainGasDisposalRepository : BaseRepository<BrainGasDisposal>, IBrainGasDisposalRepository
    {
        ApplicationDbContext _dbContext;
        public BrainGasDisposalRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
