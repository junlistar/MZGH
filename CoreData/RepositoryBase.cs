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

        public DateTime GetServerDateTime()
        {
            return Convert.ToDateTime(ExcuteScalar("select GetDate()",null));
        }

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
        public string GetSqlByTag(string tag)
        {
            if (!CacheHelper.Exsits(tag))
            {
                try
                {
                    string str = File.ReadAllText(Environment.CurrentDirectory + $"/sqls/{tag}.sql", System.Text.Encoding.GetEncoding("GB2312"));
                    CacheHelper.Add(tag.ToString(), str);
                    return str;
                }
                catch (ArgumentException ex)
                {
                    string str = File.ReadAllText(Environment.CurrentDirectory + $"/sqls/{tag}.sql", System.Text.Encoding.GetEncoding("UTF-8"));
                    CacheHelper.Add(tag.ToString(), str);
                    return str;
                }
                catch (Exception)
                {
                    throw;
                }

                //string str = File.ReadAllText(Environment.CurrentDirectory + $"/sqls/{tag}.sql", System.Text.Encoding.GetEncoding("GB2312"));

            }
            else
            {
                return CacheHelper.Get<string>(tag.ToString());
            }
        }
        public DataTable ExecuteTable(string sql, DBConnectionEnum db_model = DBConnectionEnum.Read)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(db_model))
            {
                DataTable table = new DataTable();
                var reader = conn.ExecuteReader(sql);
                table.Load(reader);
                return table;
            }
        }
        // sql语句
        public DataSet ExecuteDataSet(string sql, string tbname, object param, CommandType commandType, string db_model = "")
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(DBConnectionEnum.Write))
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

        public DataTable ExecuteTable(string sql, object param, CommandType commandType, DBConnectionEnum db_model = DBConnectionEnum.Read)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(db_model))
            {
                DataTable table = new DataTable();
                var reader = conn.ExecuteReader(sql, param, null, null, commandType);
                table.Load(reader);
                return table;
            }

        }




        public int Delete(Guid Id, string deleteSql, DBConnectionEnum db_model =  DBConnectionEnum.Write)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(db_model))
            {
                return conn.Execute(deleteSql, new { Id = Id });
            }
        }

        public T Detail(Guid Id, string detailSql, DBConnectionEnum db_model = DBConnectionEnum.Read)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(db_model))
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
        public List<T> ExecQuerySP(string SPName, DBConnectionEnum db_model = DBConnectionEnum.Read)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(db_model))
            {
                return conn.Query<T>(SPName, null, null, true, null, CommandType.StoredProcedure).ToList();
            }
        }
        public List<T> ExecQuerySP(string SPName, DynamicParameters param, DBConnectionEnum db_model = DBConnectionEnum.Read)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(db_model))
            {
                return conn.Query<T>(SPName, param, null, true, null, CommandType.StoredProcedure).ToList();

            }
        }
        public int ExecuteSP(string SPName, DynamicParameters param, DBConnectionEnum db_model = DBConnectionEnum.Read)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(db_model))
            {
                return conn.Execute(SPName, param, null, null, CommandType.StoredProcedure);
            }
        }

        public int Insert(T entity, string insertSql, DBConnectionEnum db_model = DBConnectionEnum.Read)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(db_model))
            {
                return conn.Execute(insertSql, entity);
            }
        }

        public List<T> Select(string selectSql, DBConnectionEnum db_model = DBConnectionEnum.Read)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(db_model))
            {
                return conn.Query<T>(selectSql).ToList();
            }
        }
        public List<T> Select(string selectSql, DynamicParameters param, DBConnectionEnum db_model =  DBConnectionEnum.Read)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(db_model))
            {
                return conn.Query<T>(selectSql, param).ToList();
            }
        }
        public List<string> SelectStringList(string selectSql, DynamicParameters param, DBConnectionEnum db_model = DBConnectionEnum.Read)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(db_model))
            {
                return conn.Query<string>(selectSql, param).ToList();
            }
        }


        public object ExcuteScalar(string selectSql, DynamicParameters param, DBConnectionEnum db_model = DBConnectionEnum.Read)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(db_model))
            {
                return conn.ExecuteScalar(selectSql, param);
            }
        }

        public int Update(string updateSql, DynamicParameters param, DBConnectionEnum db_model = DBConnectionEnum.Write)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(db_model))
            {
                return conn.Execute(updateSql, param);
            }
        }

        public int Update(T entity, string updateSql, DBConnectionEnum db_model = DBConnectionEnum.Write)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(db_model))
            {
                return conn.Execute(updateSql, entity);
            }
        }
    }
}
