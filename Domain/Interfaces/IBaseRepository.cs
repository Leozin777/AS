using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IBaseRepository<T>
    where T:class
    {
        Task<T> GetyIdAsync(int id);
        Task<List<T>> GetAllAsync();
        void Save(T t);
        bool Delete(int idT);
        void Update(T t);
    }
}