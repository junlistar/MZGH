using Dapper;
using MzsfData.Entities;
using MzsfData.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MzsfData.Repository
{
    public class DistrictCodeRepository : RepositoryBase<DistrictCode>, IDistrictCodeRepository
    {
   
        public List<DistrictCode> GetDistrictCodes()
        {
            string ghsql = GetSqlByTag(220028);
             
            return  Select(ghsql);


        }
         
    }
}
