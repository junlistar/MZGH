using Dapper;
using MzsfData.Entities;
using MzsfData.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MzsfData.Repository
{
    public class MzOrderReceiptRepository : RepositoryBase<MzOrderReceipt>, IMzOrderReceiptRepository
    {
        CprChargesRepository chargesRepository = new CprChargesRepository();
        public List<MzOrderReceipt> GetReceipts(string cash_opera, string begin_date, string end_date)
        { 
            var para = new DynamicParameters();

            para.Add("@cash_opera", cash_opera);
            para.Add("@begin_date", begin_date);
            para.Add("@end_date", end_date);
            return ExecQuerySP("mzsf_GetReceipts", para);
        } 

    }
}
