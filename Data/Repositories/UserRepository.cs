using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext context;
        public UserRepository(DataContext context)
        {
            this.context = context;
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

        public async Task<List<User>> GetAllAsync()
        {
            return await context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
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