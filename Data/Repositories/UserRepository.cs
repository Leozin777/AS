using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using Domain.Entities;
using Domain.Interfaces;

namespace Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            this._context = context;
        }
        
        public void Delete(int idT)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetyIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(User t)
        {
            throw new NotImplementedException();
        }

        public void Update(User t)
        {
            throw new NotImplementedException();
        }
    }
}