using CF.CostBrainService.Application.Common.Interfaces.IRepositories;
using CF.CostBrainService.Application.Entities;

namespace CF.CostBrainService.Persistence.Repository
{
    public class MasterSubScheduleRepository : BaseRepository<MasterSubSchedule>, IMasterSubScheduleRepository
    {
        ApplicationDbContext _dbContext;
        public MasterSubScheduleRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
