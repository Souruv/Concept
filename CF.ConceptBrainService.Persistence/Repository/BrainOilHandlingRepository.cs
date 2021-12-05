using CF.ConceptBrainService.Application.Common.Interfaces.IRepositories;
using CF.ConceptBrainService.Application.Entities;

namespace CF.ConceptBrainService.Persistence.Repository
{
   public class BrainOilHandlingRepository : BaseRepository<BrainOilHandling>, IBrainOilHandlingRepository
    {
        ApplicationDbContext _dbContext;
        public BrainOilHandlingRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
