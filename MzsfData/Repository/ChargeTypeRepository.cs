using Dapper;
using MzsfData.Entities;
using MzsfData.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MzsfData.Repository
{
    public class ChargeTypeRepository : RepositoryBase<ChargeType>, IChargeTypeRepository
    {
   
        public List<ChargeType> GetChargeTypes()
        {
            
            string ghsql = GetSqlByTag(220031);
             
            return  Select(ghsql);


        }
         
    }
}
