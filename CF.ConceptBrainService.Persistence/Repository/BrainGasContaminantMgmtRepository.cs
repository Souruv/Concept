using CF.ConceptBrainService.Application.Common.Interfaces.IRepositories;
using CF.ConceptBrainService.Application.Entities;

namespace CF.ConceptBrainService.Persistence.Repository
{
    public class BrainGasContaminantMgmtRepository : BaseRepository<BrainGasContaminantMgmt>, IBrainGasContaminantMgmtRepository
    {
        ApplicationDbContext _dbContext;
        public BrainGasContaminantMgmtRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
