using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;

namespace Data
{
    public interface IRepositoryBase<T>
    {
        int Insert(T entity, string insertSql, string db_model = "");

        int Update(T entity, string updateSql, string db_model = "");

        int Update(string updateSql, DynamicParameters param, string db_model = "");

        object ExcuteScalar(string selectSql, DynamicParameters param, string db_model = "");

        int Delete(Guid Id, string deleteSql, string db_model = "");

        List<T> Select(string selectSql, string db_model = "");

        List<T> Select(string selectSql, DynamicParameters param, string db_model = "");

        T Detail(Guid Id, string detailSql, string db_model = "");

        /// <summary>
        /// 无参存储过程
        /// </summary>
        /// <param name="SPName"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        List<T> ExecQuerySP(string SPName, string db_model = "");

        List<T> ExecQuerySP(string SPName, DynamicParameters param, string db_model = "");
    }
}
