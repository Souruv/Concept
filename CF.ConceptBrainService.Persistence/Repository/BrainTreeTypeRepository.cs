using CF.ConceptBrainService.Application.Common.Interfaces.IRepositories;
using CF.ConceptBrainService.Application.Entities;

namespace CF.ConceptBrainService.Persistence.Repository
{
    public class BrainTreeTypeRepository : BaseRepository<BrainTreeType>, IBrainTreeTypeRepository
    {
        ApplicationDbContext _dbContext;
        public BrainTreeTypeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
