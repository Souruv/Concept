using CF.ConceptBrainService.Application.Common.Interfaces.IRepositories;
using CF.ConceptBrainService.Application.Entities;

namespace CF.ConceptBrainService.Persistence.Repository
{
    public class BrainGasInjectionRepository : BaseRepository<BrainGasInjection>, IBrainGasInjectionRepository
    {
        ApplicationDbContext _dbContext;
        public BrainGasInjectionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
