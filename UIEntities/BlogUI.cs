
using System.Collections.Generic;
using blogBack.DB;

namespace blogBack.UIEntities
{
    public class BlogUI : IBlog
    {
        public IEnumerable<IPost> Posts { get; set; }
        public int BlogId { get; set; }
        public string BlogName { get; set; }
    }
}
