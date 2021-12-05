using CF.ConceptBrainService.Application.Common.Interfaces.IRepositories;
using CF.ConceptBrainService.Application.Entities;


namespace CF.ConceptBrainService.Persistence.Repository
{
    public class BrainSubstructureRepository : BaseRepository<BrainSubstructure>, IBrainSubstructureRepository
    {
        ApplicationDbContext _dbContext;
        public BrainSubstructureRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
