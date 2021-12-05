using CF.ConceptBrainService.Application.Common.Interfaces.IRepositories;
using CF.ConceptBrainService.Application.Entities;

namespace CF.ConceptBrainService.Persistence.Repository
{
    public class BrainAccommodationRepository : BaseRepository<BrainAccommodation>, IBrainAccommodationRepository
    {
        ApplicationDbContext _dbContext;
        public BrainAccommodationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
