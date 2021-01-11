using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace blogBack.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<int> Insert(T item);
        Task InsertMany(IEnumerable<T> itemList);
        Task<int> Update(T item);
        Task UpdateMany(IEnumerable<T> itemList);
        Task<bool> Remove(Func<T, bool> expression);
        Task RemoveMany(IReadOnlyCollection<T> ist);
        Task<T> Get(Func<T, bool> expression);
        Task<IEnumerable<T>> GetMany(Func<T, bool> expression = null);
    }
}
