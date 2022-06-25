
namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task CommitAsync();

        IClientRepository ClientRepository {get;}
        IItemRepository ItemRepository {get;}
        IStoreRepository StoreRepository { get;}
        IRequestRepository RequestRepository {get;}
        IProductRepository ProductRepository {get;}
        
        IRequestHistoryRepository RequestHistoryRepository {get;}
    }
}