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
        //private static string WriteSqlConnectionString = @"Data Source = 10.102.41.147; Initial Catalog = his; User ID = sa; Password=gx@2019;";
        private static string DefaultSqlConnectionString = Helpers.ConfigHelper.GetConnectionString("ConnectionString"); 
        private static string WriteSqlConnectionString = Helpers.ConfigHelper.GetConnectionString("ConnectionString_write"); 
        private static string DefaultRedisString = "localhost, abortConnect=false";
        private static ConnectionMultiplexer redis;

        public static IDbConnection GetSqlConnection(DBConnectionEnum db_model = DBConnectionEnum.Read)
        {
            string sqlConnectionString = "";
            if (db_model == DBConnectionEnum.Read)
            {
                sqlConnectionString = DefaultSqlConnectionString;
            }
            else
            {
                sqlConnectionString = WriteSqlConnectionString;
            }
            IDbConnection conn = new SqlConnection(sqlConnectionString);
            conn.Open();
            return conn;
        }
        //public static IDbConnection GetSqlConnection(string sqlConnectionString = null, string db_model = "")
        //{
        //    if (string.IsNullOrWhiteSpace(sqlConnectionString) && db_model.ToUpper() != "WRITE")
        //    {
        //        sqlConnectionString = DefaultSqlConnectionString;
        //    }
        //    else
        //    {
        //        sqlConnectionString = WriteSqlConnectionString;
        //    }
        //    IDbConnection conn = new SqlConnection(sqlConnectionString);
        //    conn.Open();
        //    return conn;
        //}


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
    public enum DBConnectionEnum
    {
        Read = 0,
        Write = 1
    }
}
