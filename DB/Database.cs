using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinqToDB;
using LinqToDB.Data;

namespace blogBack.DB
{
    public class test
    {
        public int id { get; set; }
        public string testing{ get; set; }  
    }
    public class Database : DataConnection
    {
        public Database() : base("local")
        {
            
        }

        public ITable<test> Tests => GetTable<test>();
    }
}
