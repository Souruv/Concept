using CF.ProjectService.Application.Common.Interfaces.IRepositories;
using CF.ProjectService.Application.Entities;

namespace CF.ProjectService.Persistence.Repository
{
    public class LookUpCraPdfYValueRepository : BaseRepository<LookUpCraPdfYValue>, ILookUpCraPdfYValueRepository
    {
        ApplicationDbContext _dbContext;
        public LookUpCraPdfYValueRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
