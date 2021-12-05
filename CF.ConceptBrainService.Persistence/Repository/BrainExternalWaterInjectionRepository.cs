using CF.ConceptBrainService.Application.Common.Interfaces.IRepositories;
using CF.ConceptBrainService.Application.Entities;

namespace CF.ConceptBrainService.Persistence.Repository
{
    public class BrainExternalWaterInjectionRepository : BaseRepository<BrainExternalWaterInjection>, IBrainExternalWaterInjectionRepository
    {
        ApplicationDbContext _dbContext;
        public BrainExternalWaterInjectionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
