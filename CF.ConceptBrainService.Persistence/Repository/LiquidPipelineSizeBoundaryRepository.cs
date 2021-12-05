using CF.ConceptBrainService.Application.Common.Interfaces.IRepositories;
using CF.ConceptBrainService.Application.Entities;

namespace CF.ConceptBrainService.Persistence.Repository
{
    public class LiquidPipelineSizeBoundaryRepository : BaseRepository<LiquidPipelineSizeBoundary>, ILiquidPipelineSizeBoundaryRepository
    {
        ApplicationDbContext _dbContext;
        public LiquidPipelineSizeBoundaryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
