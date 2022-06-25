using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories{
    public class RequestHistoryRepository: IRequestHistoryRepository{
        private readonly DataContext context;

    public RequestHistoryRepository(DataContext context)
        {
            this.context = context;
        }

        public bool Delete(int idT)
        {
            var requestHistory = context.RequestsHistory.FirstOrDefault(i => i.Id == idT);
            if (requestHistory == null)
                return false;
            else
            {
                context.RequestsHistory.Remove(requestHistory);
                return true;
            }
        }

        public async Task<List<RequestHistory>> GetAllAsync()
        {
           return await context.RequestsHistory.ToListAsync();
        }

        public async Task<RequestHistory> GetByIdAsync(int id)
        {
           return await context.RequestsHistory.SingleOrDefaultAsync(i => i.Id == id);
        }

       public void Save(RequestHistory t) => context.Add(t);

        public void Update(RequestHistory t)
        {
            context.Entry(t).State = EntityState.Modified;
        }

    }
}