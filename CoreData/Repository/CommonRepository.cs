using Dapper;
using Data.Entities;
using Data.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class CommonRepository : RepositoryBase<BaseModel>, ICommonRepository
    {
        public List<PageChequeCompare> GetPageChequeCompares()
        {
            using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
            {
                //IDbTransaction transaction = connection.BeginTransaction();

                string sql = GetSqlByTag("zd_pagechequecompare_get");

                return connection.Query<PageChequeCompare>(sql).AsList();

            }
        }
    }


}
