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
            string selectSql = @"select gh_deposit.*,zd_cheque_type.name tname,zd_deposit_status.name sname from gh_deposit 
left join zd_cheque_type on gh_deposit.cheque_type = zd_cheque_type.code
left join zd_deposit_status on gh_deposit.depo_status = zd_deposit_status.code
where patient_id =@patient_id order by price_date desc";

            var para = new DynamicParameters();
            para.Add("@patient_id", patient_id);

            return Select(selectSql, para);
        }
        public List<GhDeposit> GetGhDepositByStatus(string pid, int times, int status, int cheque_type, int item_no)
        {
            string selectSql = @"select gh_deposit.* from gh_deposit
where patient_id =@patient_id and times=@times and depo_status=@status and item_no=@item_no";

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
        public int Refund(string patient_id, int ledger_sn, string cheque_type, string item_no, decimal charge, string opera, int manual = 0)
        {
            var para = new DynamicParameters();

            //判断挂号数据是否存在
            string seldeposit = @"select * from gh_deposit where patient_id=@patient_id and ledger_sn =@ledger_sn and cheque_type=@cheque_type and item_no=@item_no and charge=@charge and depo_status=@depo_status";
            para.Add("@patient_id", patient_id);
            para.Add("@ledger_sn", ledger_sn);
            para.Add("@cheque_type", cheque_type);
            para.Add("@item_no", item_no);
            para.Add("@charge", charge);
            para.Add("@depo_status", 4);


            var depolist = Select(seldeposit, para);

            if (depolist == null || depolist.Count == 0)
            {
                throw new Exception("数据错误，没有找到匹配的退号数据");
            }
            //判断是否已经退号了
            seldeposit = @"select * from gh_deposit where patient_id=@patient_id and ledger_sn =@ledger_sn and item_no=@item_no and charge=@charge and depo_status=@depo_status";
            para = new DynamicParameters();
            para.Add("@patient_id", patient_id);
            para.Add("@ledger_sn", -ledger_sn);
            // para.Add("@cheque_type", cheque_type); 这个不是必要条件 有item_no 就够了，用于区分退款失败，手工现金退款
            para.Add("@item_no", item_no);
            para.Add("@charge", -charge);
            para.Add("@depo_status", 7);
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
                        //写入一条反向记录到现金流表
                        string selectSql = @"insert into gh_deposit(patient_id, item_no, ledger_sn, times, charge, 
cheque_type, cheque_no,depo_status, price_opera, price_date, mz_dept_no)
values(@patient_id,@item_no,@ledger_sn,@times,@charge,@cheque_type,@cheque_no,
@depo_status,@price_opera,@price_date,@mz_dept_no)";
                        //@report_date,
                        para = new DynamicParameters();

                        para.Add("@patient_id", vm.patient_id);
                        para.Add("@item_no", vm.item_no);
                        para.Add("@ledger_sn", -vm.ledger_sn);
                        para.Add("@times", vm.times);
                        para.Add("@charge", -vm.charge);
                        para.Add("@cheque_type", manual == 1 ? 1: vm.cheque_type);//手工退号，默认现金
                        para.Add("@cheque_no", vm.cheque_no);
                        para.Add("@depo_status", 7);
                        para.Add("@price_opera", opera);
                        para.Add("@price_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        //para.Add("@report_date", null);
                        para.Add("@mz_dept_no", vm.mz_dept_no);
                        //para.Add("@print_flag", vm.print_flag);

                        connection.Execute(selectSql, para, transaction);

                        //如果有组合付款没有退完 择不更新主表
                        selectSql = @"select sum(ledger_sn) from gh_deposit where patient_id=@patient_id and times=@times";
                        para = new DynamicParameters();
                        para.Add("@patient_id", vm.patient_id);
                        para.Add("@times", vm.times);
                        var sum = connection.ExecuteScalar(selectSql, para, transaction);
                        if (sum.ToString() == "0")
                        {
                            //更新mz_visit_table状态
                            string updatesql = @"update mz_visit_table set visit_flag=9 where patient_id=@patient_id and times=@times";
                            para = new DynamicParameters();
                            para.Add("@patient_id", vm.patient_id);
                            para.Add("@times", vm.times);
                            connection.Execute(updatesql, para, transaction);

                            //gh_receipt 写入反向记录
                            string s1 = @"insert into gh_receipt(patient_id,times,ledger_sn,receipt_sn,pay_unit,charge_total,settle_opera,settle_date,price_opera,price_date,report_date,receipt_no,charge_status,mz_dept_no,op_receipt_sn)  
select patient_id,times,-ledger_sn,receipt_sn,pay_unit,-charge_total,@settle_opera,settle_date,@price_opera,price_date,report_date,receipt_no,7,mz_dept_no,op_receipt_sn
from gh_receipt  where patient_id =@patient_id and ledger_sn=@ledger_sn";
                            para = new DynamicParameters();

                            para.Add("@patient_id", vm.patient_id);
                            para.Add("@ledger_sn", vm.ledger_sn);
                            para.Add("@settle_opera", opera);
                            para.Add("@price_opera", opera);
                            connection.Execute(s1, para, transaction);

                            //gh_receipt_charge 写入反向记录
                            string s2 = @"insert into gh_receipt_charge (patient_id,times,ledger_sn,receipt_sn,bill_code,charge,pay_unit)
select patient_id,times,-ledger_sn,receipt_sn,bill_code,-charge,pay_unit
from gh_receipt_charge
where patient_id =@patient_id and ledger_sn=@ledger_sn";
                            para = new DynamicParameters();

                            para.Add("@patient_id", vm.patient_id);
                            para.Add("@ledger_sn", vm.ledger_sn);
                            connection.Execute(s2, para, transaction);

                            // gh_detail_charge写入反向记录
                            string s3 = @"insert into gh_detail_charge (patient_id,times,item_no,ledger_sn,happen_date,charge_code,audit_code,bill_code,exec_sn,apply_sn,org_price,charge_price,charge_amount,
charge_group,enter_opera,enter_date,enter_win_no,confirm_opera,confirm_date,confirm_win_no,charge_status,trans_flag,fit_type,report_date,mz_dept_no)
select patient_id,times,item_no,-ledger_sn,happen_date,charge_code,audit_code,bill_code,exec_sn,apply_sn,org_price,charge_price,-charge_amount,
charge_group,@enter_opera,enter_date,enter_win_no,@confirm_opera,confirm_date,confirm_win_no,7,trans_flag,fit_type,report_date,mz_dept_no
from gh_detail_charge
where patient_id =@patient_id and ledger_sn=@ledger_sn";

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
    }
}
