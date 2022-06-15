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
            //string ghsql = GetSqlByTag(220039);

            string ghsql = @"SELECT top 1 *
    FROM mz_op_receipt  
   WHERE ( mz_op_receipt.operator = @operator ) AND
         (mz_op_receipt.receipt_type=@receipt_type ) and
         ( mz_op_receipt.deleted_flag = '0' ) AND  
         ( mz_op_receipt.current_no <= mz_op_receipt.end_no )";

            var para = new DynamicParameters();
            para.Add("@operator", operate);
            para.Add("@receipt_type", 1);

            return  Select(ghsql,para); 

        }
 
    }
}
