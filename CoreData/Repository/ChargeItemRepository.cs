using Dapper;
using Data.Entities;
using Data.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ChargeItemRepository : RepositoryBase<ChargeItem>, IChargeItemRepository
    {
   
        public List<ChargeItem> GetChargeItemsByCode(string code)
        {

            string ghsql = GetSqlByTag("zd_chargeitem_getbycode");
            var para = new DynamicParameters();

            para.Add("@code", code);
            return  Select(ghsql,para);


        }
        public List<ChargeItem> GetChargeItemsByRecordSN(string record_sn)
        {
            string chargesql = GetSqlByTag("mzgh_chargeitem_getbyrequestsn");

            var para = new DynamicParameters();

            para.Add("@record_sn", record_sn);

            return Select(chargesql, para);


        }
    }
}
