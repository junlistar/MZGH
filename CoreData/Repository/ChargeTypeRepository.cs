using Dapper;
using Data.Entities;
using Data.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ChargeTypeRepository : RepositoryBase<ChargeType>, IChargeTypeRepository
    {
   
        public List<ChargeType> GetChargeTypes()
        {
            string ghsql = "select * from zd_charge_type";
             
            return  Select(ghsql);


        }
         
    }
}
