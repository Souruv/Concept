using CF.ProjectService.Application.Common.Interfaces.IRepositories;
using CF.ProjectService.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Persistence.Repository
{
    public class EvacuationOptionProducedWaterRepository : BaseRepository<EvacuationOptionProducedWater>, IEvacuationOptionProducedWaterRepository
    {
        ApplicationDbContext _dbContext;
        public EvacuationOptionProducedWaterRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
