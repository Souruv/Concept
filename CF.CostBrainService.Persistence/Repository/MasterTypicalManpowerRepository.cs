using CF.CostBrainService.Application.Common.Interfaces.IRepositories;
using CF.CostBrainService.Application.Entities;

namespace CF.CostBrainService.Persistence.Repository
{
    public class MasterTypicalManpowerRepository : BaseRepository<MasterTypicalManpower>, IMasterTypicalManpowerRepository
    {
        ApplicationDbContext _dbContext;
        public MasterTypicalManpowerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
