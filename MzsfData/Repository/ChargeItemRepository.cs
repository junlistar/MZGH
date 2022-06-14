using Dapper;
using MzsfData.Entities;
using MzsfData.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MzsfData.Repository
{
    public class ChargeItemRepository : RepositoryBase<ChargeItem>, IChargeItemRepository
    {
   
        public List<ChargeItem> GetChargeItemsByCode(string code)
        {

            string ghsql = GetSqlByTag(220041);
            var para = new DynamicParameters();

            para.Add("@code", code);
            return  Select(ghsql,para);


        }
        public List<ChargeItem> GetChargeItemsByRecordSN(string record_sn)
        {
            string chargesql = GetSqlByTag(220042);

            var para = new DynamicParameters();

            para.Add("@record_sn", record_sn);

            return Select(chargesql, para);


        }
    }
}
