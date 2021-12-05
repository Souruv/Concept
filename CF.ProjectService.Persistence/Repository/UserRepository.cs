using CF.ProjectService.Application.Common.Interfaces;
using CF.ProjectService.Application.Common.Interfaces.IRepositories;
using CF.ProjectService.Application.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Persistence.Repository
{
    public class UserRepository: BaseRepository<AppUser>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            

        }
    }
}
