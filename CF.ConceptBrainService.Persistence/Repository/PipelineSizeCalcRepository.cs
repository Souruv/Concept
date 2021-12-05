using CF.ConceptBrainService.Application.Common.Interfaces.IRepositories;
using CF.ConceptBrainService.Application.Entities;

namespace CF.ConceptBrainService.Persistence.Repository
{
    public class PipelineSizeCalcRepository : BaseRepository<PipelineSizeCalc>, IPipelineSizeCalcRepository
    {
        ApplicationDbContext _dbContext;
        public PipelineSizeCalcRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
