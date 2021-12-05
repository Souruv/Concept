using CF.CostBrainService.Application.Common.Interfaces.IRepositories;
using CF.CostBrainService.Application.Entities;


namespace CF.CostBrainService.Persistence.Repository
{
   public class FabricationRepository : BaseRepository<Fabrication>, IFabricationRepository
    {
        ApplicationDbContext _dbContext;
        public FabricationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

            _dbContext = dbContext;
        }
    }
}
