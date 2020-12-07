using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using blogBack.DB;
using LinqToDB;
using LinqToDB.Data;

namespace blogBack.Repositories
{
    public class Repository<T> : AbsRepository<T> where T : class
    {
        private readonly Database _database;

        public Repository(Database database)
        {
            _database = database;
        }
        protected override async Task<bool> _insertAsync(T item)
        {
            var method = typeof(DataExtensions).GetMethod("Insert");
            return false;

        }

        protected override Task<T> _removeAsync(object item)
        {
            throw new NotImplementedException();
        }

        protected override Task<IEnumerable<T>> _removeRangeAsync(object[] items)
        {
            throw new NotImplementedException();
        }

        protected override async Task<T> _getAsync(object item)
        {
            try
            {
                await using var db = new Database();
                var itemIdProperty = item.GetType().GetProperty("id");
                var type = typeof(T);
                var typeId = type.GetProperty(type.Name + "Id");

                var method = typeof(Database).GetMethods()
                    .FirstOrDefault(m => m.Name == nameof(DataConnection.GetTable));

                var genericMethod = method.MakeGenericMethod(type);
                var list = await ((ITable<T>)genericMethod.Invoke(db, parameters:null)).ToListAsync();
                var itemFmDb = list.Where(elem => (int)typeId.GetValue(elem) == (int)itemIdProperty.GetValue(item));
                return itemFmDb.FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        protected override Task<IEnumerable<T>> _getAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
