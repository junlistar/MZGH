using Dapper;
using Data.Entities.Mzsf;
using Data.IRepository.Mzsf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Data.Repository.Mzsf
{
    public class MzOrderReceiptRepository : RepositoryBase<MzOrderReceipt>, IMzOrderReceiptRepository
    {
        CprChargesRepository chargesRepository = new CprChargesRepository();
        public List<MzOrderReceipt> GetReceipts(string cash_opera, string begin_date, string end_date,string bar_code,string status)
        {
            var sql = GetSqlByTag(221021);
             
            var para = new DynamicParameters();

            para.Add("@cash_opera", cash_opera);
            para.Add("@begin_date", begin_date);
            para.Add("@end_date", end_date);

            if (string.IsNullOrWhiteSpace(bar_code))
            {
                bar_code = "%";
            }
            para.Add("@bar_code", bar_code);
            para.Add("@status", status);
            //return ExecQuerySP("mzsf_GetReceipts", para);
            return Select(sql, para);
        } 

    }
}
