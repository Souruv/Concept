using CF.CostBrainService.Application.Common.Interfaces.IRepositories;
using CF.CostBrainService.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.CostBrainService.Persistence.Repository
{
    public class DefaultMaterialsRepository : BaseRepository<DefaultMaterials>, IDefaultDefaultMaterialsRepository
    {
        ApplicationDbContext _dbContext;
        public DefaultMaterialsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

            _dbContext = dbContext;
        }
    }
}
