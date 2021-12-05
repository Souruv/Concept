using CF.ConceptBrainService.Application.Common.Interfaces.IRepositories;
using CF.ConceptBrainService.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ConceptBrainService.Persistence.Repository
{
    public class ConceptDCDetailsRepository : BaseRepository<ConceptDCDetails>, IConceptDCDetailsRepository
    {
        ApplicationDbContext _dbContext;
        public ConceptDCDetailsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
