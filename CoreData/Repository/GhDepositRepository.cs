using Dapper;
using Data.Entities;
using Data.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Data.Repository
{
    public class GhDepositRepository : RepositoryBase<GhDeposit>, IGhDepositRepository
    {

        public List<GhDeposit> GetGhDeposit(string patient_id)
        {
            string selectSql =GetSqlByTag(220043);

            var para = new DynamicParameters();
            para.Add("@patient_id", patient_id);

            return Select(selectSql, para);
        }
        public List<GhDeposit> GetGhDepositByStatus(string pid, int times, int status, int cheque_type, int item_no)
        {
            string selectSql = GetSqlByTag(220044);

            var para = new DynamicParameters();
            para.Add("@patient_id", pid);
            para.Add("@times", times);
            para.Add("@status", status);
            //para.Add("@cheque_type", cheque_type);//
            para.Add("@item_no", item_no);

            return Select(selectSql, para);
        }

        /// <summary>
        /// 退号
        /// </summary>
        /// <param name="vm"></param>
        /// <returns></returns>
        //public int Refund(string patient_id, int ledger_sn, string cheque_type, string item_no, decimal charge, string opera, int manual = 0)
        public int Refund(string patient_id, int times, string opera, int manual = 0)
        {
            var para = new DynamicParameters();
            int depo_refund_status = 7;

            //判断挂号数据是否存在
            //string seldeposit = @"select * from gh_deposit where patient_id=@patient_id and times =@times and depo_status=@depo_status";
            string seldeposit =GetSqlByTag(220045);
            para.Add("@patient_id", patient_id);
            para.Add("@times", times); 
            para.Add("@depo_status", 4);
             
            var depolist = Select(seldeposit, para);

            if (depolist == null || depolist.Count == 0)
            {
                throw new Exception("数据错误，没有找到匹配的退号数据");
            }
            //判断是否已经退号了
            //seldeposit = @"select * from gh_deposit where patient_id=@patient_id and times =@times and depo_status=@depo_status";
            para = new DynamicParameters();
            para.Add("@patient_id", patient_id);
            para.Add("@times", times);
            //// para.Add("@cheque_type", cheque_type); 这个不是必要条件 有item_no 就够了，用于区分退款失败，手工现金退款
            //para.Add("@item_no", item_no);
            //para.Add("@charge", -charge);
            para.Add("@depo_status", depo_refund_status);
            var refundlist = Select(seldeposit, para);

            if (refundlist != null && refundlist.Count == 1)
            {
                throw new Exception("操作失败，该数据已经退号了！");
            }

            using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
            {
                IDbTransaction transaction = connection.BeginTransaction();


                try
                {
                    if (depolist.Count > 0)
                    {
                        var vm = depolist[0];
                        foreach (var item in depolist)
                        {
                            //写入一条反向记录到现金流表
                            //                            string sql = @"insert into gh_deposit(patient_id, item_no, ledger_sn, times, charge, 
                            //cheque_type, cheque_no,depo_status, price_opera, price_date, mz_dept_no)
                            //values(@patient_id,@item_no,@ledger_sn,@times,@charge,@cheque_type,@cheque_no,
                            //@depo_status,@price_opera,@price_date,@mz_dept_no)";
                            //@report_date,

                            string sql = GetSqlByTag(220047);
                           para = new DynamicParameters();

                            para.Add("@patient_id", item.patient_id);
                            para.Add("@item_no", item.item_no);
                            para.Add("@ledger_sn", -item.ledger_sn);
                            para.Add("@times", item.times);
                            para.Add("@charge", -item.charge);
                            para.Add("@cheque_type", manual == 1 ? 1 : item.cheque_type);//手工退号，默认现金
                            para.Add("@cheque_no", item.cheque_no);
                            para.Add("@depo_status", depo_refund_status);
                            para.Add("@price_opera", opera);
                            para.Add("@price_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            //para.Add("@report_date", null);
                            para.Add("@mz_dept_no", item.mz_dept_no);
                            //para.Add("@print_flag", item.print_flag);

                            connection.Execute(sql, para, transaction);
                        } 
                        //如果有组合付款没有退完 择不更新主表
                        //string selectSql = @"select sum(ledger_sn) from gh_deposit where patient_id=@patient_id and times=@times";
                        string selectSql = GetSqlByTag(220048);
                        para = new DynamicParameters();
                        para.Add("@patient_id", vm.patient_id);
                        para.Add("@times", vm.times);
                        var sum = connection.ExecuteScalar(selectSql, para, transaction);
                        if (sum.ToString() == "0")
                        {
                            //更新mz_visit_table状态
                            //string updatesql = @"update mz_visit_table set visit_flag=9 where patient_id=@patient_id and times=@times";
                            string updatesql = GetSqlByTag(220049);
                            para = new DynamicParameters();
                            para.Add("@patient_id", vm.patient_id);
                            para.Add("@times", vm.times);
                            connection.Execute(updatesql, para, transaction);

                            //gh_receipt 写入反向记录
//                            string s1 = @"insert into gh_receipt(patient_id,times,ledger_sn,receipt_sn,pay_unit,charge_total,settle_opera,settle_date,price_opera,price_date,report_date,receipt_no,charge_status,mz_dept_no,op_receipt_sn)  
//select patient_id,times,-ledger_sn,receipt_sn,pay_unit,-charge_total,@settle_opera,settle_date,@price_opera,price_date,report_date,receipt_no,7,mz_dept_no,op_receipt_sn
//from gh_receipt  where patient_id =@patient_id and ledger_sn=@ledger_sn";
                            string s1 = GetSqlByTag(220050);
                            para = new DynamicParameters();

                            para.Add("@patient_id", vm.patient_id);
                            para.Add("@ledger_sn", vm.ledger_sn);
                            para.Add("@settle_opera", opera);
                            para.Add("@price_opera", opera);
                            connection.Execute(s1, para, transaction);

                            //gh_receipt_charge 写入反向记录
//                            string s2 = @"insert into gh_receipt_charge (patient_id,times,ledger_sn,receipt_sn,bill_code,charge,pay_unit)
//select patient_id,times,-ledger_sn,receipt_sn,bill_code,-charge,pay_unit
//from gh_receipt_charge
//where patient_id =@patient_id and ledger_sn=@ledger_sn";
                            string s2 = GetSqlByTag(220051);
                            para = new DynamicParameters();

                            para.Add("@patient_id", vm.patient_id);
                            para.Add("@ledger_sn", vm.ledger_sn);
                            connection.Execute(s2, para, transaction);

                            // gh_detail_charge写入反向记录
//                            string s3 = @"insert into gh_detail_charge (patient_id,times,item_no,ledger_sn,happen_date,charge_code,audit_code,bill_code,exec_sn,apply_sn,org_price,charge_price,charge_amount,
//charge_group,enter_opera,enter_date,enter_win_no,confirm_opera,confirm_date,confirm_win_no,charge_status,trans_flag,fit_type,report_date,mz_dept_no)
//select patient_id,times,item_no,-ledger_sn,happen_date,charge_code,audit_code,bill_code,exec_sn,apply_sn,org_price,charge_price,-charge_amount,
//charge_group,@enter_opera,enter_date,enter_win_no,@confirm_opera,confirm_date,confirm_win_no,7,trans_flag,fit_type,report_date,mz_dept_no
//from gh_detail_charge
//where patient_id =@patient_id and ledger_sn=@ledger_sn";

                            string s3 = GetSqlByTag(220052);

                            para = new DynamicParameters();

                            para.Add("@patient_id", vm.patient_id);
                            para.Add("@ledger_sn", vm.ledger_sn);
                            para.Add("@enter_opera", opera);
                            para.Add("@confirm_opera", opera);
                            connection.Execute(s3, para, transaction);

                        }
                    }
                    transaction.Commit();
                    return 1;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public List<GhDeposit> GetGhRefundPayList(string request_date, string patient_id, int times)
        {

            string sql = @"SELECT
      DISTINCT
	 
      d.charge,
      d.ledger_sn,
      d.item_no,
      d.times,
      d.price_date,
      ISNULL(g.name, '') cheque_name,
      ISNULL(d.cheque_type, '') cheque_type,
      ISNULL(d.cheque_no, '') cheque_no,
      ISNULL(f.receipt_sn, '') receipt_sn,
      ISNULL(f.receipt_no, '') receipt_no,
      a.name as price_opera
FROM  view_mz_visit_table v  
      left join view_gh_deposit d on v.patient_id = d.patient_id AND v.times = d.times 
      left join a_employee_mi a on d.price_opera = a.emp_sn  
      left join gh_receipt f on f.patient_id = d.patient_id AND f.times = d.times 
      left join zd_cheque_type g on g.code = d.cheque_type  
WHERE 
      DATEDIFF(dd, v.visit_date, @request_date) = 0  and
	    v.patient_id=@patient_id
	  and d.times=@times
order by ledger_sn desc,d.item_no";

            var para = new DynamicParameters();
            para.Add("@request_date", request_date);
            para.Add("@patient_id", patient_id);
            para.Add("@times", times);


            return Select(sql, para);
        }

    }
}
