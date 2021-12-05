using CF.CostBrainService.Application.Common.Interfaces.IRepositories;
using CF.CostBrainService.Application.Entities;

namespace CF.CostBrainService.Persistence.Repository
{
    public class EquipmentRepository : BaseRepository<Equipment>, IEquipmentRepository
    {
        ApplicationDbContext _dbContext;
        public EquipmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
