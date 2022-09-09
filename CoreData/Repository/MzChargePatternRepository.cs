﻿using Dapper;
using Data.Entities;
using Data.Entities.Mzsf;
using Data.IRepository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Data.Repository
{
    public class MzChargePatternRepository : RepositoryBase<BaseModel>, IMzChargePatternRepository
    {
        public List<MzChargePattern> GetMzChargePatterns()
        {
            using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
            {
                //IDbTransaction transaction = connection.BeginTransaction();

                string sql = GetSqlByTag("mz_charge_pattern_get"); 

                return connection.Query<MzChargePattern>(sql).AsList();

            }
        }

        public List<MzChargePatternDetail> GetMzPatternDetails()
        {
            using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
            {
                string sql = "mzsf_PatternDetail";
                 
                return connection.Query<MzChargePatternDetail>(sql,null,null,true,null, CommandType.StoredProcedure).AsList();
            }
        }
         
    }


}
