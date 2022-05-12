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
            string ghsql = "select * from zd_charge_item where code = '" + code + "' ";
             
            return  Select(ghsql);


        }
        public List<ChargeItem> GetChargeItemsByRecordSN(string record_sn)
        {
            string chargesql = @"select b.*,c.name,c.charge_price,c.charge_price,c.effective_price,c.audit_code,c.mz_bill_item,mz_charge_group from gh_zd_clinic_type a 
left join gh_zd_clinic_charge b on a.code = b.code
left join zd_charge_item c on b.charge_code = c.code
left join mz_bill_item d on d.code=c.mz_bill_item
where a.code=(select clinic_type from gh_request where record_sn=@record_sn)";

           var para = new DynamicParameters();

            para.Add("@record_sn", record_sn);

            return Select(chargesql, para);


        }
    }
}
