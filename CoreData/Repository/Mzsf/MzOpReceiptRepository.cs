using Dapper;
using Data.Entities;
using Data.IRepository.Mzsf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Data.Repository.Mzsf
{
    public class MzOpReceiptRepository : RepositoryBase<GhOpReceipt>, IMzOpReceiptRepository
    {

        public List<GhOpReceipt> GetCurrentReceiptNo(string operate)
        {
            string ghsql = GetSqlByTag("mzsf_mzopreceipt_get");
             
            var para = new DynamicParameters();
            para.Add("@operator", operate);
            para.Add("@receipt_type", 1);

            return  Select(ghsql,para); 

        }
 
    }
}
