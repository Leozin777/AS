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
        
        public bool Delete(int idT)
        {
            var user = context.Users.FirstOrDefault(i => i.Id == idT);

            if (user == null)
                return false;
            else
            {
                context.Users.Remove(user);
                return true;
            }
        }

        public Task<List<User>> GetAllAsync()
        {
            return await context.Users.ToListAsync();
        }

        public Task<User> GetByIdAsync(int id)
        {
            return await context.Users.SingleOrDefaultAsync(i => i.Id == id);
        }

        public void Save(User t)
        {
            context.Add(t);
        }

        public void Update(User t)
        {
            context.Entry(t).State = EntityState.Modified;
        }
    }
}