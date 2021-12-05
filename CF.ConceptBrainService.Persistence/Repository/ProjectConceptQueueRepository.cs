using CF.ConceptBrainService.Application.Common.Interfaces.IRepositories;
using CF.ConceptBrainService.Application.Entities;

namespace CF.ConceptBrainService.Persistence.Repository
{
    public class ProjectConceptQueueRepository : BaseRepository<ProjectConceptQueue>, IProjectConceptQueueRepository
    {
        ApplicationDbContext _dbContext;
        public ProjectConceptQueueRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
