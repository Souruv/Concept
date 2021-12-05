using CF.CostBrainService.Application.Common.Interfaces.IRepositories;
using CF.CostBrainService.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.CostBrainService.Persistence.Repository
{
    class GeneralSettingsValuesRepository : BaseRepository<GeneralSettingsValues>, IGeneralSettingsValuesRepository
    {
        ApplicationDbContext _dbContext;
        public GeneralSettingsValuesRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

            _dbContext = dbContext;
        }
    }
}
