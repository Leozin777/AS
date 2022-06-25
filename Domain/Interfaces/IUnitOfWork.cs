
namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task CommitAsync();

        IClientRepository ClientRepository {get;}
        IItemRepository ItemRepository {get;}
        IRequestRepository RequestRepository {get;}
        IProductRepository ProductRepository {get;}
    }
}