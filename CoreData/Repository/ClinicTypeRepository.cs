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
            string ghsql = GetSqlByTag("zd_clinictype_get");

            return  Select(ghsql); 
        }

        public List<ClinicType> GetRequestTypes()
        {
            string ghsql = GetSqlByTag("zd_requesttype_get");

            return Select(ghsql); 
        }
    }
}
