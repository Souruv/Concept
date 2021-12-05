using CF.ProjectService.Application.Common.Interfaces.IRepositories;
using CF.ProjectService.Application.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF.ProjectService.Persistence.Repository
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        ApplicationDbContext _dbContext;
        public ProjectRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;

        }

        //public IQueryable<Project> GetFilteredProjects()
        //{

        //    var query = from p in this._dbContext.Projects
        //                join pr in _dbContext.ProjectRevisions on p.Id equals pr.ProjectId
        //                //join c in _dbContext.Clubs on pc.ClubID equals c.ClubID
        //                orderby pr.ModifiedOn,pr.No descending
        //                select p;

        //    return query;
        //}

        public async Task<bool> IsFileNameExist(string fileName)
        {
            return   await this.Filter(x => x.Name == fileName).AnyAsync();
        }


            //    return fileNameToTry;
            //}
            //public async Task<string> GetUniqueFileName(string baseName)
            //{
            //    var counter = 1;
            //    var fileNameToTry = baseName;// + $" ({counter})";
            //    var isExist = true;

            //    while(isExist)
            //    {
            //        isExist = await this.Filter(x => x.Name == fileNameToTry).AnyAsync();
            //        if(isExist)
            //        {
            //            fileNameToTry= baseName + $" ({counter++})";
            //        }
            //    }


            //    return fileNameToTry;
            //}


        }
}
