using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IStatusRepository<t>
    where t:class
    {
        Task<t> GetByIdAsync(int id);
        Task<List<t>> GetAllAsync();
    }
}