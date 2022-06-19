using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            var user = _context.Users.FirstOrDefault(x => x.Id == idT);

            if(user == null)
                return false;
            else
            {
                _context.Users.Remove(user);
                return true;
            }    
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetyIdAsync(int id)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.Id == id);
           
        }

        public void Save(User t)
        {
            _context.Users.Add(t);
        }

        public void Update(User t)
        {
            _context.Entry(t).State = EntityState.Modified;
        }
    }
}