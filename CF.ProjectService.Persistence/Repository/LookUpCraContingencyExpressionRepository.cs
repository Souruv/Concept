using CF.ProjectService.Application.Common.Interfaces.IRepositories;
using CF.ProjectService.Application.Entities;
using CF.ProjectService.Application.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Persistence.Repository
{
    public class LookUpCraContingencyExpressionRepository : BaseRepository<LookUpCraContingencyExpression>, ILookUpCraContingencyExpressionRepository
    {
        ApplicationDbContext _dbContext;
        public LookUpCraContingencyExpressionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
