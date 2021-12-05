using CF.CostBrainService.Application.Common.Interfaces.IRepositories;
using CF.CostBrainService.Application.Entities;

namespace CF.CostBrainService.Persistence.Repository
{
    public class MasterProjectTypeRepository : BaseRepository<MasterProjectType>, IMasterProjectTypeRepository
    {
        ApplicationDbContext _dbContext;
        public MasterProjectTypeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
