using StackExchange.Redis;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public class DataBaseConfig
    {
        #region SqlServer链接配置

        
        //private static string DefaultSqlConnectionString = @"Data Source = 10.102.41.147; Initial Catalog = his; User ID = sa; Password=gx@2019;";
        private static string DefaultSqlConnectionString = Helpers.ConfigHelper.GetConnectionString("ConnectionString");
        //private static string DefaultSqlConnectionString = ConfigurationManager.AppSettings.Get("ConnString");
        private static string DefaultRedisString = "localhost, abortConnect=false";
        private static ConnectionMultiplexer redis;

        public static IDbConnection GetSqlConnection(string sqlConnectionString = null)
        {
            if (string.IsNullOrWhiteSpace(sqlConnectionString))
            {
                sqlConnectionString = DefaultSqlConnectionString;
            }
            IDbConnection conn = new SqlConnection(sqlConnectionString);
            conn.Open();
            return conn;
        }

        #endregion

        
        #region Redis链接配置

        private static ConnectionMultiplexer GetRedis(string redisString = null)
        {
            if (string.IsNullOrWhiteSpace(redisString))
            {
                redisString = DefaultRedisString;
            }
            if (redis == null || redis.IsConnected)
            {
                redis = ConnectionMultiplexer.Connect(redisString);
            }
            return redis;
        }

        #endregion
    }
}
