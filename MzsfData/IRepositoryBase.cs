using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;

namespace MzsfData
{
    public interface IRepositoryBase<T>
    {
        int Insert(T entity, string insertSql);

        int Update(T entity, string updateSql);

        int Update(string updateSql, DynamicParameters param);

        object ExcuteScalar(string selectSql, DynamicParameters param);

        int Delete(Guid Id, string deleteSql);

        List<T> Select(string selectSql);

        List<T> Select(string selectSql, DynamicParameters param);

        T Detail(Guid Id, string detailSql);

        /// <summary>
        /// 无参存储过程
        /// </summary>
        /// <param name="SPName"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        List<T> ExecQuerySP(string SPName);

        List<T> ExecQuerySP(string SPName, DynamicParameters param);
    }
}
