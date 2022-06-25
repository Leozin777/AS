using Data.Context;
using Domain.Entities;
using Domain.Interfaces;

namespace Data.Repositories
{
    public class RequestRepository: IRequestRepository
    {
        private readonly DataContext context;
        public RequestRepository(DataContext context)
        {
            this.context = context;
        }

        public bool Delete(int idT)
        {
            var request = context.Requests.FirstOrDefault(i => i.Id == idT);

            if (request == null)
                return false;
            else
            {
                context.Requests.Remove(request);
                return true;
            }
        }

        public async Task<List<Request>> GetAllAsync()
        {
            return await context.Requests.ToListAsync();
        }

        public async Task<Request> GetByIdAsync(int id)
        {
            return await context.Requests.SingleOrDefaultAsync(i => i.Id == id);
        }

        public void Save(Request t)
        {
            context.Requests.Add(t);        }

        public void Update(Request t)
        {
            context.Entry(t).State = EntityState.Modified;
        }
    }
}