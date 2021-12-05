using CF.ConceptBrainService.Application.Common.Interfaces.IRepositories;
using CF.ConceptBrainService.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ConceptBrainService.Persistence.Repository
{
    public class EquimentMasterRepository : BaseRepository<EquipmentMaster>, IEquipmentMasterRepository
    {
        public EquimentMasterRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
