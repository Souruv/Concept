
using CF.AuthService.Application.Common.Interfaces;
using CF.AuthService.Application.Common.Interfaces.IRepositories;
using CF.AuthService.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CF.AuthService.Persistence
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private ApplicationDbContext _context;
        private IUserRepository _userRepository;

        private IRoleRepository _roleRepository;
        private IFelStageRepository _felStageRepository;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
      

        public IUserRepository UserRepository
        {
            get
            {
                if (this._userRepository == null)
                {
                    this._userRepository = new UserRepository(_context);
                }
                return _userRepository;
            }
        }

        public IRoleRepository RoleRepository
        {
            get
            {
                if (this._roleRepository == null)
                {
                    this._roleRepository = new RoleRepository(_context);
                }
                return _roleRepository;
            }
        }

        public IFelStageRepository FelStageRepository
        {
            get
            {
                if (this._felStageRepository == null)
                {
                    this._felStageRepository = new FelStageRepository(_context);
                }
                return _felStageRepository;
            }
        }
        public Task<int> CommitAsync()
        {
            return _context.SaveChangesAsync();
        }
        public int Commit()
        {
            return _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
