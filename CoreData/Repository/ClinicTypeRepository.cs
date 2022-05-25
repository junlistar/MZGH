using Dapper;
using Data.Entities;
using Data.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ClinicTypeRepository : RepositoryBase<ClinicType>, IClinicTypeRepository
    {
   
        public List<ClinicType> GetClinicTypes()
        {
            string ghsql = GetSqlByTag(220029);

            return  Select(ghsql); 
        }

        public List<ClinicType> GetRequestTypes()
        {
            string ghsql = GetSqlByTag(220030);

            return Select(ghsql); 
        }
    }
}
