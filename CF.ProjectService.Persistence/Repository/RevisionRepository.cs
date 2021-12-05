using CF.ProjectService.Application.Common.Interfaces.IRepositories;
using CF.ProjectService.Application.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CF.ProjectService.Persistence.Repository
{
    public class RevisionRepository : BaseRepository<ProjectRevision>, IRevisionRepository
    {
        ApplicationDbContext _dbContext;
        public RevisionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;

        }

        public async Task<int?> GetMaxRevisionNo(Guid projectId)
        {
            return  await _dbContext.ProjectRevisions.Where(x =>!x.IsDeleted && x.ProjectId == projectId ).MaxAsync(p => (int?)p.RevisionNo);
        }

        public async Task<ProjectRevision?> GetMaxRevision(Guid projectId)
        {
            return await _dbContext.ProjectRevisions.Where(x => !x.IsDeleted && x.ProjectId == projectId).OrderByDescending(x => x.RevisionNo).FirstOrDefaultAsync(); 
        }

        public async Task<ProjectRevision?> GetMaxDeletedRevision(Guid projectId)
        {
            return await _dbContext.ProjectRevisions.Where(x => x.IsDeleted && x.ProjectId == projectId).OrderByDescending(x => x.RevisionNo).FirstOrDefaultAsync();
        }




    }
}
