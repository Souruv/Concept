using CF.ConceptBrainService.Application.Common.Interfaces.IRepositories;
using CF.ConceptBrainService.Application.Entities;


namespace CF.ConceptBrainService.Persistence.Repository
{
    public class BrainGasExportRepository : BaseRepository<BrainGasExport>, IBrainGasExportRepository
    {
        ApplicationDbContext _dbContext;
        public BrainGasExportRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
