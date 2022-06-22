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
    public class ItemRepository: IItemRepository
    {
        private readonly DataContext context;
        public ItemRepository(DataContext context)
        {
            this.context = context;
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

        public async Task<List<Item>> GetAllAsync()
        {
            return await context.Items.ToListAsync();
        }

        public async Task<Item> GetByIdAsync(int id)
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