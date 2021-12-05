using CF.ProjectService.Application.Common.Interfaces.IRepositories;
using CF.ProjectService.Application.Entities;

namespace CF.ProjectService.Persistence.Repository
{
    public class InfrastructureRepository : BaseRepository<InfrastructureData>, IInfrastructureDataReporitory
    {
        ApplicationDbContext _dbContext;
        public InfrastructureRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
