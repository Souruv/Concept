
using CF.AuthService.Application.Common.Interfaces.IRepositories;
using CF.AuthService.Application.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.AuthService.Persistence.Repository
{
    public class UserRepository: BaseRepository<AppUser>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            

        }
    }
}
