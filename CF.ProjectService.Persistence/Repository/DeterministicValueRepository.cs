using CF.ProjectService.Application.Common.Interfaces.IRepositories;
using CF.ProjectService.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Persistence.Repository
{
    public class DeterministicValueRepository : BaseRepository<DeterministicValue>, IDeterministicValueRepository
    {
        ApplicationDbContext _dbContext;
        public DeterministicValueRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
