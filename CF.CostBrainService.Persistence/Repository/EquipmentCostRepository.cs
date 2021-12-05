using CF.CostBrainService.Application.Common.Interfaces.IRepositories;
using CF.CostBrainService.Application.Entities;

namespace CF.CostBrainService.Persistence.Repository
{
    public class EquipmentCostRepository : BaseRepository<EquipmentCost>, IEquipmentCostRepository
    {
        ApplicationDbContext _dbContext;
        public EquipmentCostRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

            _dbContext = dbContext;
        }
    }
}
