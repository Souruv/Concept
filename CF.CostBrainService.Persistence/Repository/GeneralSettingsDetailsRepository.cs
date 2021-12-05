using CF.CostBrainService.Application.Common.Interfaces.IRepositories;
using CF.CostBrainService.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.CostBrainService.Persistence.Repository
{
    class GeneralSettingsDetailsRepository : BaseRepository<GeneralSettingsDetails>, IGeneralSettingsDetailsRepository
    {
        ApplicationDbContext _dbContext;
        public GeneralSettingsDetailsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

            _dbContext = dbContext;
        }
    }
}
