using CF.ConceptBrainService.Application.Common.Interfaces.IRepositories;
using CF.ConceptBrainService.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ConceptBrainService.Persistence.Repository
{
    public class EquimentRepository : BaseRepository<Equipment>, IEquipmentRepository
    {
        public EquimentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
