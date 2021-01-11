using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogBack.DB;
using LinqToDB;
using LinqToDB.Data;
using LinqToDB.Extensions;

namespace blogBack.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private readonly Type _type = typeof(T);
        public async Task<int> Insert(T item) => await InsertOrUpdateAsync(item);

        protected async Task<int> InsertOrUpdateAsync(T item, bool update=false)
        {
            using var db = new Database();
           
            var element = await GetAsync(x => Getelement(x, item));
            if (element is not null)
            {
                if (update)
                {
                    var updateMethod = typeof(DataExtensions).GetMethods()
                        .FirstOrDefault(m => m.Name == nameof(DataExtensions.Update));
                    var genericUpdate = updateMethod.MakeGenericMethod(_type);
                    return (int) genericUpdate
                        .Invoke(null, new object[] {db, item, null, null, null, null});
                }
                throw new Exception("Duplicated element");
            }
            var method = typeof(DataExtensions).GetMethods()
                .FirstOrDefault(m => m.Name == nameof(DataExtensions.InsertWithInt32Identity));
            var genericMethod = method.MakeGenericMethod(_type);
            return (int)genericMethod
                .Invoke(null, new object[] {db, item,null,null,null,null});
         }

        private bool Getelement(T x, T item)
        {
            var p = _type.GetProperties();
            var pId = p.FirstOrDefault(x => x.Name.EndsWith("Id"));
            if (pId is null) throw new Exception("missing field");
            var xId = (int)pId.GetValue(x);
            var itemId = (int)pId.GetValue(item);
            var pp = xId == itemId;
            return pp;
        }
        public async Task InsertMany(IEnumerable<T> itemList) => await InserManyAsync(itemList);

        private async Task InserManyAsync(IEnumerable<T> itemList)
        {
            foreach (var item in itemList)
            {
                await InsertOrUpdateAsync(item);
            }
        }

        public async Task<int> Update(T item) => await UpdateAsync(item);
        protected async Task<int> UpdateAsync(T item)
        { 
           var returnResult = await InsertOrUpdateAsync(item, true);
           return returnResult;
        }

        public Task UpdateMany(IEnumerable<T> itemList)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Remove(Func<T, bool> expression) => await RemoveAsync(expression);

        protected async Task<bool> RemoveAsync(Func<T, bool> expression)
        {
            var item = await GetAsync(expression);
            if (item is null) throw new Exception("Item not found");
            using var db = new Database();
            var method = typeof(DataExtensions).GetMethods()
                .FirstOrDefault(m => m.Name == nameof(DataExtensions.Delete));
            var genericMethod = method.MakeGenericMethod(_type);
            var p = (int) genericMethod
                .Invoke(null, new object[] {db, item, null, null, null, null});
            return p == 1;
        }

        public async Task RemoveMany(IReadOnlyCollection<T> list) => await RemoveManyAsync(list);
        protected async Task RemoveManyAsync(IReadOnlyCollection<T> list)
        {
            foreach (var item in list)
            {
                var name = item.GetType().Name + "Id";
                await RemoveAsync(x=>x.GetType().Name+"Id" == name);
            }
        }

        public async Task<T> Get(Func<T, bool> expression) => await GetAsync(expression);
        protected async Task<T> GetAsync(Func<T, bool> expression)
        {
            var p = await GetManyAsync(expression);
            return p.FirstOrDefault();
        }

        public async Task<IEnumerable<T>> GetMany(Func<T, bool> expression = null) => await GetManyAsync(expression);

        protected async Task<IEnumerable<T>> GetManyAsync(Func<T, bool> expression)
        {
            using var db = new Database();
            var method = typeof(DataExtensions).GetMethods()
                .FirstOrDefault(m => m.Name == nameof(DataExtensions.GetTable));
            var genericMethod = method.MakeGenericMethod(_type);
            var list = await ((ITable<T>) genericMethod.Invoke(null, new object[] {db})).ToListAsync();
            return from item in list
                where expression == null || expression(item)
                select item;
        }
    }
}
