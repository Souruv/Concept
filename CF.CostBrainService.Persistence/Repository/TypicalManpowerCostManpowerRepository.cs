using CF.CostBrainService.Application.Common.Interfaces.IRepositories;
using CF.CostBrainService.Application.Entities;

namespace CF.CostBrainService.Persistence.Repository
{
    public class TypicalManpowerCostRepository : BaseRepository<TypicalManpowerCost>, ITypicalManpowerCostRepository
    {
        ApplicationDbContext _dbContext;
        public TypicalManpowerCostRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
