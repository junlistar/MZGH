using Dapper;
using Data.Entities;
using Data.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class OccupationCodeRepository : RepositoryBase<OccupationCode>, IOccupationCodeRepository
    {
   
        public List<OccupationCode> GetOccupationCodes()
        {
            string ghsql = GetSqlByTag("zd_occupation_get");
             
            return  Select(ghsql); 
        }
         
    }
}
