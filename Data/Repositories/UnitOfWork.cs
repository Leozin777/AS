using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using Domain.Interfaces;

namespace Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public UnitOfWork(DataContext context)
        {
            this._context = context;
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        private IUserRepository _userRepository;

        public IUserRepository UserRepository
        {
            get{ return _userRepository ??= new UserRepository(_context);}
        }
    }
}