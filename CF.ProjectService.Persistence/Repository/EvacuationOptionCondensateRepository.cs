using CF.ProjectService.Application.Common.Interfaces.IRepositories;
using CF.ProjectService.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Persistence.Repository
{
    public class EvacuationOptionCondensateRepository : BaseRepository<EvacuationOptionCondensate>, IEvacuationOptionCondensateRepository
    {
        ApplicationDbContext _dbContext;
        public EvacuationOptionCondensateRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
