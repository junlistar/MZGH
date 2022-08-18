using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;

namespace Data
{
    public interface IRepositoryBase<T>
    {
        int Insert(T entity, string insertSql, DBConnectionEnum db_model = DBConnectionEnum.Read);

        int Update(T entity, string updateSql, DBConnectionEnum db_model = DBConnectionEnum.Read);

        int Update(string updateSql, DynamicParameters param, DBConnectionEnum db_model = DBConnectionEnum.Read);

        object ExcuteScalar(string selectSql, DynamicParameters param, DBConnectionEnum db_model = DBConnectionEnum.Read);

        int Delete(Guid Id, string deleteSql, DBConnectionEnum db_model = DBConnectionEnum.Read);

        List<T> Select(string selectSql, DBConnectionEnum db_model = DBConnectionEnum.Read);

        List<T> Select(string selectSql, DynamicParameters param, DBConnectionEnum db_model = DBConnectionEnum.Read);

        T Detail(Guid Id, string detailSql, DBConnectionEnum db_model = DBConnectionEnum.Read);

        /// <summary>
        /// 无参存储过程
        /// </summary>
        /// <param name="SPName"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        List<T> ExecQuerySP(string SPName, DBConnectionEnum db_model =  DBConnectionEnum.Read);

        List<T> ExecQuerySP(string SPName, DynamicParameters param, DBConnectionEnum db_model = DBConnectionEnum.Read);
    }
}
