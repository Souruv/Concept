using CF.CostBrainService.Application.Common.Interfaces.IRepositories;
using CF.CostBrainService.Application.Entities;

namespace CF.CostBrainService.Persistence.Repository
{
    public class EquipmentToolsConstCostRepository : BaseRepository<EquipmentToolsConsCost>, IEquipmentToolsConsCostRepository
    {
        ApplicationDbContext _dbContext;
        public EquipmentToolsConstCostRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
