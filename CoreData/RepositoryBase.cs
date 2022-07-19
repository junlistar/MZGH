using CoreData.Helpers;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    public class RepositoryBase<T> : IRepositoryBase<T>
    { 

        public string GetSqlByTag(int tag)
        {
            //string tag_sql = "select [sql] from wh_tag_sql  where tag = @tag ";

            //var para = new DynamicParameters();
            //para.Add("@tag", tag);

            //return Convert.ToString(ExcuteScalar(tag_sql, para));

            if (!CacheHelper.Exsits(tag.ToString()))
            {
                string str = File.ReadAllText(System.Environment.CurrentDirectory + $"/sqls/{tag}.sql", System.Text.Encoding.GetEncoding("GB2312"));
                //  string str = File.ReadAllText(System.Environment.CurrentDirectory + $"/sqls/{tag}.sql", System.Text.Encoding.GetEncoding("UTF-8"));
                CacheHelper.Add(tag.ToString(), str);
                return str;
            }
            else
            {
                return CacheHelper.Get<string>(tag.ToString());
            }
        }

        // sql语句
        public DataTable ExecuteTable(string sql)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection())
            {
                DataTable table = new DataTable();
                var reader = conn.ExecuteReader(sql);
                table.Load(reader);
                return table;
            }
        }
        // sql语句
        public DataSet ExecuteDataSet(string sql, string tbname, object param, CommandType commandType)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection())
            {
                //DataTable table = new DataTable();
                var reader = conn.ExecuteReader(sql, param, null, null, commandType);
                //table.Load(reader);
                DataSet ds = new DataSet();
                ds.Tables.Add(tbname);
                ds.Tables[0].Load(reader);
                return ds;
            }
        }

        //执行存储过程，返回DT

        public DataTable ExecuteTable(string sql, object param, CommandType commandType)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection())
            {
                DataTable table = new DataTable();
                var reader = conn.ExecuteReader(sql, param, null, null, commandType);
                table.Load(reader);
                return table;
            }

        }




        public int Delete(Guid Id, string deleteSql)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection())
            {
                return conn.Execute(deleteSql, new { Id = Id });
            }
        }

        public T Detail(Guid Id, string detailSql)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection())
            {
                //string querySql = @"SELECT Id, UserName, Password, Gender, Birthday, CreateDate, IsDelete FROM dbo.Users WHERE Id=@Id";
                return conn.QueryFirstOrDefault<T>(detailSql, new { Id = Id });
            }
        }

        /// <summary>
        /// 无参存储过程
        /// </summary>
        /// <param name="SPName"></param>
        /// <returns></returns>
        public List<T> ExecQuerySP(string SPName)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection())
            {
                return conn.Query<T>(SPName, null, null, true, null, CommandType.StoredProcedure).ToList();
            }
        }
        public List<T> ExecQuerySP(string SPName, DynamicParameters param)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection())
            {
                return conn.Query<T>(SPName, param, null, true, null, CommandType.StoredProcedure).ToList();
                 
            }
        }
        public int ExecuteSP(string SPName, DynamicParameters param)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection())
            {
                return conn.Execute(SPName, param, null, null, CommandType.StoredProcedure); 
            }
        }

        public int Insert(T entity, string insertSql)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection())
            {
                return conn.Execute(insertSql, entity);
            }
        } 

        public List<T> Select(string selectSql)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection())
            {
                return conn.Query<T>(selectSql).ToList();
            }
        }
        public List<T> Select(string selectSql, DynamicParameters param)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection())
            {
                return conn.Query<T>(selectSql, param).ToList();
            }
        }
        public List<string> SelectStringList(string selectSql, DynamicParameters param)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection())
            {
                return conn.Query<string>(selectSql, param).ToList();
            }
        }


        public object ExcuteScalar(string selectSql, DynamicParameters param)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection())
            {
                return conn.ExecuteScalar(selectSql, param);
            }
        }

        public int Update(string updateSql, DynamicParameters param)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection())
            {
                return conn.Execute(updateSql, param);
            }
        }

        public int Update(T entity, string updateSql)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection())
            {
                return conn.Execute(updateSql, entity);
            }
        }
    }
}
