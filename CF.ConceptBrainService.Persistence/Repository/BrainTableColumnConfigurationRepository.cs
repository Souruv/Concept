using CF.ConceptBrainService.Application.Common.Interfaces.IRepositories;
using CF.ConceptBrainService.Application.Entities;

namespace CF.ConceptBrainService.Persistence.Repository
{
    public class BrainTableColumnConfigurationRepository : BaseRepository<BrainTableColumnConfiguration>, IBrainTableColumnConfigurationRepository
    {
        ApplicationDbContext _dbContext;
        public BrainTableColumnConfigurationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
