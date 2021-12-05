using CF.CostBrainService.Application.Common.Interfaces.IRepositories;
using CF.CostBrainService.Application.Entities;

namespace CF.CostBrainService.Persistence.Repository
{
    public class MasterOffShoreAccomodationRepository : BaseRepository<MasterOffShoreAccomodation>, IMasterOffShoreAccomodationRepository
    {
        ApplicationDbContext _dbContext;
        public MasterOffShoreAccomodationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
