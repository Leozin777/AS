using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using Domain.Entities;
using Domain.Interfaces;

namespace Data.Repositories
{
    public class ItemRepository: IItemRepository
    {
        private readonly DataContext _context;
        public ItemRepository(DataContext context)
        {
            this._context = context;
        }

        public bool Delete(int idT)
        {
            var item = context.Items.FirstOrDefault(i => i.Id == idT);

            if (item == null)
                return false;
            else
            {
                context.Items.Remove(item);
                return true;
            }
        }

        public Task<List<Item>> GetAllAsync()
        {
            return await context.Items.ToListAsync();
        }

        public Task<Item> GetByIdAsync(int id)
        {
            return await context.Items.SingleOrDefaultAsync(i => i.Id == id);
        }

        public void Save(Item t)
        {
            context.Add(t);
        }

        public void Update(Item t)
        {
            context.Entry(t).State = EntityState.Modified;
        }
    }
}