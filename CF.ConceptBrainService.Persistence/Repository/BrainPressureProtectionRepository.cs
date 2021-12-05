using CF.ConceptBrainService.Application.Common.Interfaces.IRepositories;
using CF.ConceptBrainService.Application.Entities;

namespace CF.ConceptBrainService.Persistence.Repository
{
    public class BrainPressureProtectionRepository : BaseRepository<BrainPressureProtection>, IBrainPressureProtectionRepository
    {
        ApplicationDbContext _dbContext;
        public BrainPressureProtectionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
