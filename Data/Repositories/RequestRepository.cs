using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            throw new NotImplementedException();
        }

        public Task<List<Request>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Request> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Request t)
        {
            throw new NotImplementedException();
        }

        public void Update(Request t)
        {
            throw new NotImplementedException();
        }
    }
}