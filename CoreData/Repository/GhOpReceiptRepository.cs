using Dapper;
using Data.Entities;
using Data.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class GhOpReceiptRepository : RepositoryBase<GhOpReceipt>, IGhOpReceiptRepository
    {

        public List<GhOpReceipt> GetCurrentReceiptNo(string opera)
        {
            //string ghsql = "select top 1 * from gh_op_receipt order by happen_date desc ";
            string ghsql = GetSqlByTag("mzgh_ghopreceipt_getnew");

            var param = new DynamicParameters();
            var para = new DynamicParameters();
            para.Add("@operator", opera==""?"00000": opera);
            return  Select(ghsql,para);


        }
 
    }
}
