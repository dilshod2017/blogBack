using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinqToDB;
using LinqToDB.Data;

namespace blogBack.DB
{
    public class Database : DataConnection
    {
        public Database() : base("local")
        {
            
        }

        public ITable<Blog> Blog => GetTable<Blog>();
        public ITable<Post> Posts => GetTable<Post>();
        public ITable<Text> Texts => GetTable<Text>();
        public ITable<Image> Images => GetTable<Image>();
        public ITable<Style> Styles => GetTable<Style>();
        public ITable<Data> DataList => GetTable<Data>();
     }
}
