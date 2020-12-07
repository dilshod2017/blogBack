using System.Collections.Generic;
using blogBack.DB;

namespace blogBack.UIEntities
{
    public class PostUI : IPost
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string TimeStamp { get; set; }
        public int BlogId { get; set; }
        public IEnumerable<IRow> Rows { get; set; }
    }
}