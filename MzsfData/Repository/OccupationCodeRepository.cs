using Dapper;
using MzsfData.Entities;
using MzsfData.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MzsfData.Repository
{
    public class OccupationCodeRepository : RepositoryBase<OccupationCode>, IOccupationCodeRepository
    {
   
        public List<OccupationCode> GetOccupationCodes()
        {
            string ghsql = GetSqlByTag(220026);
             
            return  Select(ghsql); 
        }
         
    }
}
