using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace blogBack.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<bool> Insert(T item);
        Task<T> Remove(params object[] args);
        Task<IEnumerable<T>> RemoveRange(params object[] args);
        Task<T> Get(params object[] args);
        Task<IEnumerable<T>> GetAll();
    }
}
