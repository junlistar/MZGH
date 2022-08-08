using Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface IMzThridPayRepository : IRepositoryBase<MzThridPay> 
    {
        #region 扩展的dapper操作
         

        List<MzThridPay> GetMzThridPays();

        int AddMzThridPay(string patient_id, string cheque_type, string cheque_no, string mdtrt_id, string ipt_otp_no, string psn_no, string yb_insuplc_admdvs, string charge, string price_date, string opera);

        int RefundMzThridPay(string patient_id, string cheque_type, string cheque_no, string charge, string price_date);
        #endregion
    }
}
