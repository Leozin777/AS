using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories{
    public class StatusRepository: IStatusRepository{
        private readonly DataContext context;

    public StatusRepository(DataContext context)
        {
            this.context = context;
        }

        public bool Delete(int idT)
        {
            var status = context.Status.FirstOrDefault(i => i.Id == idT);
            if (status == null)
                return false;
            else
            {
                context.Status.Remove(status);
                return true;
            }
        }

        public async Task<List<Status>> GetAllAsync()
        {
           return await context.Status.ToListAsync();
        }

        public async Task<Status> GetByIdAsync(int id)
        {
           return await context.Status.SingleOrDefaultAsync(i => i.Id == id);
        }

       public void Save(Status t) => context.Add(t);

        public void Update(Status t)
        {
            context.Entry(t).State = EntityState.Modified;
        }

    }
}