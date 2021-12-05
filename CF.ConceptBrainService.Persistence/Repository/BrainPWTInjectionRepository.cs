using CF.ConceptBrainService.Application.Common.Interfaces.IRepositories;
using CF.ConceptBrainService.Application.Entities;

namespace CF.ConceptBrainService.Persistence.Repository
{
    public class BrainPWTInjectionRepository : BaseRepository<BrainPWTInjection>, IBrainPWTInjectionRepository
    {
        ApplicationDbContext _dbContext;
        public BrainPWTInjectionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
