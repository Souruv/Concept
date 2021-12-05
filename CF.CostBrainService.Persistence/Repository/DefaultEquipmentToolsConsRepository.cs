using CF.CostBrainService.Application.Common.Interfaces.IRepositories;
using CF.CostBrainService.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.CostBrainService.Persistence.Repository
{
    public class DefaultEquipmentToolsConsRepository : BaseRepository<DefaultEquipmentToolsCons>, IDefaultEquipmentToolsConsRepository
    {
        ApplicationDbContext _dbContext;
        public DefaultEquipmentToolsConsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

            _dbContext = dbContext;
        }
    }
}
