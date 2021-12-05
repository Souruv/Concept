using CF.CostBrainService.Application.Common.Interfaces.IRepositories;
using CF.CostBrainService.Application.Entities;

namespace CF.CostBrainService.Persistence.Repository
{
    public class MaterialsCostRepository : BaseRepository<MaterialsCost>, IMaterialsCostRepository
    {
        ApplicationDbContext _dbContext;
        public MaterialsCostRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
