using Ass01Solution.BusinessObject;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Ass01Solution.DataAccess
{
    public class BaseDAL
    {
        public StockDataProvider dataProvider { get; set; }
        public SqlConnection connection = null;

        public BaseDAL()
        {
            string connectionString = GetConnectionString();
            dataProvider = new StockDataProvider(connectionString);
        }

        private string GetConnectionString()
        {
            string connectionString;
            IConfiguration config = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json", true, true)
                                        .Build();
            connectionString = config["ConnectionString:FStoreDB"];
            return connectionString;
        }
    }
}
