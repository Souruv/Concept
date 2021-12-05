using CF.ProjectService.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF.ProjectService.Application.Common.Interfaces.IRepositories
{
    public interface IProjectRepository : IBaseRepository<Project>
    {
        //public Task<string> GetUniqueFileName(string baseName);
        //public IQueryable<Project> GetFilteredProjects();
        public  Task<bool> IsFileNameExist(string fileName);
    }
}
