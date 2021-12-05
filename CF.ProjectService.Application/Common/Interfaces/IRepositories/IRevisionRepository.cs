using CF.ProjectService.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF.ProjectService.Application.Common.Interfaces.IRepositories
{
    public interface IRevisionRepository : IBaseRepository<ProjectRevision>
    {       
        public Task<int?> GetMaxRevisionNo(Guid projectId);
        public Task<ProjectRevision?> GetMaxRevision(Guid projectId);
        public Task<ProjectRevision?> GetMaxDeletedRevision(Guid projectId);
    }
}
