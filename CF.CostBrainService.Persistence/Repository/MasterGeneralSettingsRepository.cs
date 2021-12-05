using CF.CostBrainService.Application.Common.Interfaces.IRepositories;
using CF.CostBrainService.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.CostBrainService.Persistence.Repository
{
    class MasterGeneralSettingsRepository : BaseRepository<MasterGeneralSettings>, IMasterGeneralSettingsRepository
    {
        ApplicationDbContext _dbContext;
        public MasterGeneralSettingsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

            _dbContext = dbContext;
        }
    }
}
