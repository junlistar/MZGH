using Dapper;
using Data.Entities;
using Data.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class MzThridPayRepository : RepositoryBase<MzThridPay>, IMzThridPayRepository
    {
   
        public List<MzThridPay> GetMzThridPays()
        {
            string selectSql = GetSqlByTag("zd_MzThridPay_get");
             
            return  Select(selectSql); 

        }
        public int AddMzThridPay(string patient_id, string cheque_type, string cheque_no, string mdtrt_id, string setl_id,string ipt_otp_no, string psn_no, string yb_insuplc_admdvs,string charge,string price_date, string opera)
        {
            string insert_sql = GetSqlByTag("mzsf_mzthirdpay_add");
             
            var para = new DynamicParameters();
            para.Add("@patient_id", patient_id);
            para.Add("@cheque_type", cheque_type);
            para.Add("@cheque_no", cheque_no);
            para.Add("@mdtrt_id", mdtrt_id);
            para.Add("@setl_id", setl_id);
            para.Add("@ipt_otp_no", ipt_otp_no);
            para.Add("@psn_no", psn_no);
            para.Add("@yb_insuplc_admdvs", yb_insuplc_admdvs);
            para.Add("@charge", charge);
            //para.Add("@refund_date", refund_date);
            para.Add("@price_date", price_date);
            para.Add("@opera", opera);
            
            return Update(insert_sql, para);
        }
        public int RefundMzThridPay(string patient_id, string cheque_type, string cheque_no,  string charge, string price_date)
        {
            string update_sql = GetSqlByTag("mzsf_mzthirdpay_refund");

            var para = new DynamicParameters();
            para.Add("@patient_id", patient_id);
            para.Add("@cheque_type", cheque_type);
            para.Add("@cheque_no", cheque_no);  
            para.Add("@charge", charge);
            para.Add("@refund_date", GetServerDateTime().ToString("yyyy-MM-dd HH:mm:ss"));
            para.Add("@price_date", price_date); 

            return Update(update_sql, para);
        }
    }
}
