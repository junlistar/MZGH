using Data.Entities.Mzsf;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.IRepository.Mzsf
{
    public interface IMzOrderReceiptRepository : IRepositoryBase<MzOrderReceipt> 
    {
        #region 扩展的dapper操作


        List<MzOrderReceipt> GetReceipts(string cash_opera, string begin_date,string end_date, string bar_code,string status);

         
        #endregion
    }
}
