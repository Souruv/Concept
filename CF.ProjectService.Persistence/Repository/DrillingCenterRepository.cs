using CF.ProjectService.Application.Common.Interfaces.IRepositories;
using CF.ProjectService.Application.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Persistence.Repository
{
    public class DrillingCenterRepository : BaseRepository<DrillingCenterData>, IDrillingCenterRepository
    {
        ApplicationDbContext _dbContext;
        public DrillingCenterRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
