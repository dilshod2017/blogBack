using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogBack.DB;
using LinqToDB;

namespace blogBack.Repositories
{
    public class Service<T>
    {
        public IEnumerable<T> Invokation(string methodName, object args)
        {
            var method = typeof(DataExtensions);
            return null;

        }
    }
    public class BlogRepository<Blog> : AbsRepository<Blog> where Blog : DB.Blog
    {
        
        protected override async Task<bool> _insertAsync(Blog item)
        {

            return false;
        }

        protected override Task<Blog> _removeAsync(object item)
        {
            throw new NotImplementedException();
        }

        protected override Task<IEnumerable<Blog>> _removeRangeAsync(object[] items)
        {
            throw new NotImplementedException();
        }

        protected override Task<Blog> _getAsync(object item)
        {
            throw new NotImplementedException();
        }

        protected override Task<IEnumerable<Blog>> _getAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
