using CF.CostBrainService.Application.Common.Interfaces.IRepositories;
using CF.CostBrainService.Application.Entities;

namespace CF.CostBrainService.Persistence.Repository
{
    public class MasterScheduleRepository : BaseRepository<MasterSchedule>, IMasterScheduleRepository
    {
        ApplicationDbContext _dbContext;
        public MasterScheduleRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
