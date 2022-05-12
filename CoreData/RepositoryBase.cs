﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    public class RepositoryBase<T> : IRepositoryBase<T>
    {
        //public async Task Delete(Guid Id, string deleteSql)
        //{
        //    using (IDbConnection conn = DataBaseConfig.GetSqlConnection())
        //    {
        //        await conn.ExecuteAsync(deleteSql, new { Id = Id });
        //    }
        //}

        //public async Task<T> Detail(Guid Id, string detailSql)
        //{
        //    using (IDbConnection conn = DataBaseConfig.GetSqlConnection())
        //    {
        //        //string querySql = @"SELECT Id, UserName, Password, Gender, Birthday, CreateDate, IsDelete FROM dbo.Users WHERE Id=@Id";
        //        return await conn.QueryFirstOrDefaultAsync<T>(detailSql, new { Id = Id });
        //    }
        //}

        ///// <summary>
        ///// 无参存储过程
        ///// </summary>
        ///// <param name="SPName"></param>
        ///// <returns></returns>
        //public async Task<List<T>> ExecQuerySP(string SPName)
        //{
        //    using (IDbConnection conn = DataBaseConfig.GetSqlConnection())
        //    {
        //        return await Task.Run(() => conn.Query<T>(SPName, null, null, true, null, CommandType.StoredProcedure).ToList());
        //    }
        //}

        //public async Task Insert(T entity, string insertSql)
        //{
        //    using (IDbConnection conn = DataBaseConfig.GetSqlConnection())
        //    {
        //        await conn.ExecuteAsync(insertSql, entity);
        //    }
        //}

        //public async Task<List<T>> Select(string selectSql)
        //{
        //    using (IDbConnection conn = DataBaseConfig.GetSqlConnection())
        //    {
        //        //string selectSql = @"SELECT Id, UserName, Password, Gender, Birthday, CreateDate, IsDelete FROM dbo.Users";
        //        return await Task.Run(()=>conn.Query<T>(selectSql).ToList());
        //    }
        //}

        //public async Task Update(T entity, string updateSql)
        //{
        //    using (IDbConnection conn = DataBaseConfig.GetSqlConnection())
        //    {
        //        await conn.ExecuteAsync(updateSql, entity);
        //    }
        //}

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
