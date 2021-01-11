using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinqToDB.Configuration;

namespace blogBack.DB
{
    public class DbSetting : ILinqToDBSettings
    {
        private string ConnectionString { get; }

        public DbSetting(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public IEnumerable<IDataProviderSettings> DataProviders { get { yield break;} }
        public string? DefaultConfiguration => "SqlServer";
        public string? DefaultDataProvider => "SqlServer";

        public IEnumerable<IConnectionStringSettings> ConnectionStrings
        {
            get
            {
                yield return new ConnectionStringSettings()
                {
                    Name = "local",
                    ProviderName = "SqlServer",
                    ConnectionString = ConnectionString
                };
            }
        }
    }
}
