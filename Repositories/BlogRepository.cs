using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogBack.DB;
using LinqToDB;

namespace blogBack.Repositories
{
    public class BlogRepository<Blog> : Repository<Blog> where Blog : DB.Blog
    {
        
        
    }
}
