
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CF.AuthService.Application.Common.Interfaces.IRepositories;

namespace CF.AuthService.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        public IUserRepository UserRepository { get;}
        public IFelStageRepository FelStageRepository { get; }
        public IRoleRepository RoleRepository { get; }

        public int Commit();
        public Task<int> CommitAsync();
    }
}
