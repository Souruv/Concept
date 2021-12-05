using CF.ConceptBrainService.Application.Common.Interfaces.IRepositories;
using CF.ConceptBrainService.Application.Entities;

namespace CF.ConceptBrainService.Persistence.Repository
{
    public class FlowlineBoundaryRepository : BaseRepository<FlowlineBoundary>, IFlowlineBoundaryRepository
    {
        ApplicationDbContext _dbContext;
        public FlowlineBoundaryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
