using Data.Context;
using Domain.Interfaces;

namespace Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public UnitOfWork(DataContext context)
        {
            this._context = context;
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        private IClientRepository _clientRepository;

        public IClientRepository ClientRepository
        {
            get{ return _clientRepository ??= new ClientRepository(_context);}
        }

        private IItemRepository _itemRepository;

        public IItemRepository ItemRepository
        {
            get{ return _itemRepository ??= new ItemRepository(_context);}
        }

        private IRequestRepository _requestRepository;

        public IRequestRepository RequestRepository
        {
            get{ return _requestRepository ??= new RequestRepository(_context);}
        }
    }
}