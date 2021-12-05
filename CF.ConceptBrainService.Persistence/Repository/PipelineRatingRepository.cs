using CF.ConceptBrainService.Application.Common.Interfaces.IRepositories;
using CF.ConceptBrainService.Application.Entities;

namespace CF.ConceptBrainService.Persistence.Repository
{
    public class PipelineRatingRepository : BaseRepository<PipelineRatingBoundary>, IPipelineRatingRepository
    {
        ApplicationDbContext _dbContext;
        public PipelineRatingRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
