using Dapper;
using MzsfData.Entities;
using MzsfData.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MzsfData.Repository
{
    public class GhOpReceiptRepository : RepositoryBase<GhOpReceipt>, IGhOpReceiptRepository
    {

        public List<GhOpReceipt> GetCurrentReceiptNo(string operate)
        {
            string ghsql = GetSqlByTag(221007);
             
            var para = new DynamicParameters();
            para.Add("@operator", operate);
            para.Add("@receipt_type", 1);

            return  Select(ghsql,para); 

        }
 
    }
}
