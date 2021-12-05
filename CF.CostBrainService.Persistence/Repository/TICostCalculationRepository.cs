using CF.CostBrainService.Application.Common.Interfaces.IRepositories;
using CF.CostBrainService.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace CF.CostBrainService.Persistence.Repository
{
    class TICostCalculationRepository : BaseRepository<TICostCalculation>, ITICostCalculationRepository
    {
        ApplicationDbContext _dbContext;
        public TICostCalculationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

            _dbContext = dbContext;
        }
    }
}
