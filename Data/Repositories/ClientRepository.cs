using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataContext context;
        public ClientRepository(DataContext context)
        {
            this.context = context;
        }
        
        public bool Delete(int idT)
        {
            var client = context.Clients.FirstOrDefault(i => i.Id == idT);

            if (client == null)
                return false;
            else
            {
                context.Clients.Remove(client);
                return true;
            }
        }

        public async Task<List<Client>> GetAllAsync()
        {
            return await context.Clients.ToListAsync();
        }

        public async Task<Client> GetByIdAsync(int id)
        {
            return await context.Clients.SingleOrDefaultAsync(i => i.Id == id);
        }

        public void Save(Client t)
        {
            context.Clients.Add(t);
        }

        public void Update(Client t)
        {
            context.Entry(t).State = EntityState.Modified;

        }
    }
}