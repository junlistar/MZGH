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
    public class CommonBase
    { 
         
        public List<T> Select<T>(string selectSql, DynamicParameters param)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection())
            {
                return conn.Query<T>(selectSql, param).ToList();
            }
        } 
    }
}
