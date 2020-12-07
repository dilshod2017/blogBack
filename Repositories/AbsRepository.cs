using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogBack.DB;

namespace blogBack.Repositories
{
    public abstract class AbsRepository<T> : IRepository<T> where T : class
    {
        protected abstract Task<bool> _insertAsync(T item);
        protected abstract Task<T> _removeAsync(object item);
        protected abstract Task<IEnumerable<T>> _removeRangeAsync(object[] items);
        protected abstract Task<T> _getAsync(object item);
        protected abstract Task<IEnumerable<T>> _getAllAsync();

        public async Task<bool> Insert(T item) => await _insertAsync(item);

        public async Task<T> Remove(params object[] args) => await _removeAsync(args[0]);

        public async Task<IEnumerable<T>> RemoveRange(params object[] args) => await _removeRangeAsync(args);

        public async Task<T> Get(params object[] args) => await _getAsync(args[0]);

        public async Task<IEnumerable<T>> GetAll() => await  _getAllAsync();
    }
}
