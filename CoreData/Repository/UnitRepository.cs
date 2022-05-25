using Dapper;
using Data.Entities;
using Data.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class UnitRepository : RepositoryBase<Unit>, IUnitRepository
    {
   
        public List<Unit> GetUnits()
        {
            string selectSql = GetSqlByTag(220023);
             
            return  Select(selectSql); 

        }
 
    }
}
