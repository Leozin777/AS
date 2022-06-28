using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories{
    public class StatusRepository: IStatusRepository<Status>
    {
        private readonly DataContext context;

        public StatusRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<List<Status>> GetAllAsync()
        {
           return await context.Status.ToListAsync();
        }

        public async Task<Status> GetByIdAsync(int id)
        {
           return await context.Status.SingleOrDefaultAsync(i => i.Id == id);
        }

    }
}