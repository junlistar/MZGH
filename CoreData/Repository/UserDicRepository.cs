using Dapper;
using Data.Entities;
using Data.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Data.Repository
{
    public class UserDicRepository : RepositoryBase<UserDic>, IUserDicRepository
    {

        public List<UserDic> GetUserDic()
        {
            string sql = GetSqlByTag("zd_employee_get");

            return Select(sql);

        }
        public List<RelativeCode> GetRelativeCodes()
        {

            using IDbConnection connection = DataBaseConfig.GetSqlConnection();

            try
            {
                string sql = GetSqlByTag("zd_relative_get");

                return connection.Query<RelativeCode>(sql).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
