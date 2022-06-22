using MzsfData.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MzsfData.IRepository
{
    public interface IMzOrderRepository : IRepositoryBase<MzOrder> 
    {
        #region 扩展的dapper操作


        List<MzOrder> GetMzOrdersByPatientId(string patient_id,int times);


        bool Pay(string patient_id, int times, string pay_string, string opera);

        bool BackFee(string opera, string pid, int ledger_sn, string receipt_sn, string receipt_no, string cheque_cash, string isall = "1");

        bool SaveOrder(string patient_id, int times, string order_string, string opera);

        #endregion
    }
}
