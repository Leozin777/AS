using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly DataContext context;

        public StoreRepository(DataContext context)
        {
            this.context = context;
        }
        public async Task<Store> GetByIdAsync(int id)
        {
            return await context.Stores.SingleOrDefaultAsync(i => i.Id == id);;
        }

        public async Task<List<Store>> GetAllAsync()
        {
            return await context.Stores.ToListAsync();
        }

        public void Save(Store t)
        {
            context.Add(t);
        }

        public bool Delete(int idT)
        {
            var store = context.Stores.FirstOrDefault(i => i.Id == idT);

            if (store == null)
                return false;
            else
            {
                context.Stores.Remove(store);
                return true;
            }
        }

        public void Update(Store t)
        {
            context.Entry(t).State = EntityState.Modified;
        }
    }
}