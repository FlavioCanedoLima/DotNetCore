using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;

namespace MVCCoreData.Data
{
    public class DataDapper
    {
        private readonly IDbConnection _dbConnection;

        public DataDapper(string connectionString)
        {
            var connection = new SqlConnection(connectionString);

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            _dbConnection = connection;
        }

        public IDbConnection GetDapperConnection()
        {
            return _dbConnection;
        }
    }

    public static class DataDapperServiceCollectionExtensions
    {
        public static IServiceCollection AddDapperConnection(this IServiceCollection serviceCollection, string connectionString = null)
        {
            serviceCollection.AddScoped(d => new DataDapper(connectionString));

            return serviceCollection;
        }
    }
}
