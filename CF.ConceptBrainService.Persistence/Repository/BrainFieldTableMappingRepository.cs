using CF.ConceptBrainService.Application.Common.Interfaces.IRepositories;
using CF.ConceptBrainService.Application.Entities;

namespace CF.ConceptBrainService.Persistence.Repository
{
    public class BrainFieldTableMappingRepository : BaseRepository<BrainFieldTableMapping>, IBrainFieldTableMappingRepository
    {
        ApplicationDbContext _dbContext;
        public BrainFieldTableMappingRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
