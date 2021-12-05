using CF.CostBrainService.Application.Common.Interfaces.IRepositories;
using CF.CostBrainService.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.CostBrainService.Persistence.Repository
{
    public class DefaultEquipmentManPowerPercentageRepository : BaseRepository<DefaultEquipmentManPowerPercentage>, IDefaultEquipmentManPowerPercentageRepository
    {
        ApplicationDbContext _dbContext;
        public DefaultEquipmentManPowerPercentageRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

            _dbContext = dbContext;
        }
    }
}
