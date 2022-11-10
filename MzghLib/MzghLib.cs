using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data;
using System.Runtime.InteropServices;
using System.EnterpriseServices;
using System.Data.SqlClient;

namespace MyMzghLib
{
    //[ComVisible(true)]
    //[Guid("CA5DC999-37B0-49D5-A5A0-376D79A8BF5E"), ClassInterface(ClassInterfaceType.None)]
    //[ProgId("MyMzghLib.MzghLib")]
    public class MzghLib : IMzghLib
    {
        public void Initialize()
        {
            // nothing to do  
        }

        public void Dispose()
        {
            // nothing to do  
        }
        //[DispId(1)]
        public DataTable GetUnit()
        {
            string sql = @"
SELECT zd_unit_code.code 部门编码,
              zd_unit_code.name 部门名称,
      zd_unit_code.py_code 拼音,
               zd_unit_code.d_code 自定义码,
       zd_unit_code.unit_sn 永久码
FROM zd_unit_code
WHERE zd_unit_code.code in (
select unit_sn from gh_request where DATEDIFF(dd, request_date, getdate()) = '0') 
   -- and
   --  zd_unit_code.py_code Like @P1 and
 --zd_unit_code.d_code like @P2  and
-- zd_unit_code.code like @P3 and
 --zd_unit_code.name  like @P4
order by zd_unit_code.code";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@P1","%"),
                new SqlParameter("@P2","%"),
                new SqlParameter("@P3","%"),
                new SqlParameter("@P4","%")
            };
            return DbHelper.ExecuteDataTable(sql, param);
        }

        /// <summary>
        /// 获取所有科室
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllUnit()
        {
            string sql = @"select   zd_unit_code.code 部门编码,
       zd_unit_code.name 部门名称,
       zd_unit_code.py_code 拼音码,
       zd_unit_code.d_code 自定义码,
       zd_unit_code.unit_sn 永久码
from zd_unit_code
where  
      zd_unit_code.deleted_flag = '0'
order by code";
            return DbHelper.ExecuteDataTable(sql);
        }

        /// <summary>
        /// 查询当天的可以挂号的科室医生信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetGhData(string request_date, string ampm, string unit_sn = "%", string clinic_type = "%", string doctor_sn = "%", string group_sn = "%", string req_type = "01", string win_no = "%")
        {
            if (string.IsNullOrEmpty(request_date))
            {
                request_date = DateTime.Now.ToString("yyyy-MM-dd");
            }
            if (string.IsNullOrEmpty(ampm))
            {
                ampm = DateTime.Now.Hour > 12 ? "p" : "a";
            }

            string sql = "mzgh_GetGhRequestInfo";
            SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@request_date",request_date),
                new SqlParameter("@unit_sn",unit_sn),
                new SqlParameter("@clinic_type",clinic_type),
                new SqlParameter("@doctor_sn",doctor_sn),
                new SqlParameter("@group_sn",group_sn),
                new SqlParameter("@req_type",req_type),
                new SqlParameter("@ampm",ampm),
                new SqlParameter("@win_no",win_no)
            };

            return DbHelper.ExecuteProc(sql, para);
        }

        public DataTable GetUserInfo(string barcode)
        {

            string sql = @"SELECT  gh_zd_clinic_type.code 代码, gh_zd_clinic_type.name 名称, 
  gh_zd_clinic_type.py_code 拼音码, gh_zd_clinic_type.d_code 自定义码
FROM gh_zd_clinic_type
WHERE gh_zd_clinic_type.py_code LIKE @P1 AND gh_zd_clinic_type.d_code LIKE @P2 AND gh_zd_clinic_type.code LIKE @P3 AND gh_zd_clinic_type.name LIKE @P4
and isnull(deleted_flag, ''0'') = 0";

            string usql = @"select distinct a.patient_id, a.max_times times, a.[name], a.sex, a.birthday, cast(DateDiff(YY,a.birthday, GetDate()) as float) age, a.response_type, a.contract_code, a.occupation_type, a.charge_type, '07' haoming_code, '2969317' code, inpatient_no, getdate() visit_date, 
a.social_no, '07' real_haoming_code, a.home_district, a.home_street, a.relation_tel, a.hic_no, a.addition_no1, a.home_tel, a.relation_name, a.relation_code, a.max_times real_times, a.p_bar_code, a.p_bar_code2, a.black_flag, a.address, a.poverty_code, a.employer_name, a.employer_street, employer_district,
a.employer_tel, a.allergic_diag, a.marry_code, a.max_times, a.max_ledger_sn, a.max_receipt_sn, a.max_item_sn, a.enter_opera, a.enter_date, a.update_opera, a.update_date from 
 mz_patient_mi a where 
a.p_bar_code = ? order by max_ledger_sn desc";

            SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@p1",barcode),
            };

            return DbHelper.ExecuteDataTable(usql, para);


        }
        public DataTable GetUserInfoByCard(string card)
        {
            string usql = @"select distinct a.patient_id, a.max_times times, a.[name], a.sex, a.birthday, cast(DateDiff(YY,a.birthday, GetDate()) as float) age, a.response_type, a.contract_code, a.occupation_type, a.charge_type, '07' haoming_code, '2969317' code, inpatient_no, getdate() visit_date, 
a.social_no, '07' real_haoming_code, a.home_district, a.home_street, a.relation_tel, a.hic_no, a.addition_no1, a.home_tel, a.relation_name, a.relation_code, a.max_times real_times, a.p_bar_code, a.p_bar_code2, a.black_flag, a.address, a.poverty_code, a.employer_name, a.employer_street, employer_district,
a.employer_tel, a.allergic_diag, a.marry_code, a.max_times, a.max_ledger_sn, a.max_receipt_sn, a.max_item_sn, a.enter_opera, a.enter_date, a.update_opera, a.update_date from 
 mz_patient_mi a where 
a.p_bar_code = ? or a.social_no=? or a.hic_no=? order by max_ledger_sn desc";

            SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@p1",card),
                new SqlParameter("@p2",card),
                new SqlParameter("@p3",card),
            };

            return DbHelper.ExecuteDataTable(usql, para);


        }
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="sno"></param>
        /// <param name="hicno"></param>
        /// <param name="barcode"></param>
        /// <param name="name"></param>
        /// <param name="sex"></param>
        /// <param name="birthday"></param>
        /// <param name="tel"></param>
        /// <returns></returns>
        public int EditUserInfo(string pid, string sno, string hicno, string barcode, string name, string sex, string birthday, string tel)
        {
            //修改
            if (!string.IsNullOrEmpty(pid))
            {
                string sql = @"update mz_patient_mi
set social_no=?,hic_no=?,p_bar_code=?,name=?,sex=?,birthday=?,home_tel=?
where patient_id=?";
                SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@p1",sno),
                new SqlParameter("@p2",hicno),
                new SqlParameter("@p3",barcode),
                new SqlParameter("@p4",name),
                new SqlParameter("@p5",sex),
                new SqlParameter("@p6",birthday),
                new SqlParameter("@p7",tel),
                new SqlParameter("@p8",pid),
            };

                return DbHelper.ExecuteNonQuery(sql, para);
            }
            else
            {
                //新增
                //string snosql = @"Update gh_config set patient_sn = patient_sn + 1;select patient_sn from gh_config";
                string snosql = @"select patient_sn from gh_config";
                var dtconfig = DbHelper.ExecuteDataTable(snosql);
                var patientid = "";
                if (dtconfig != null && dtconfig.Rows.Count > 0)
                {
                    patientid = dtconfig.Rows[0]["patient_sn"].ToString();
                }
                if (string.IsNullOrEmpty(patientid))
                {
                    return 0;
                }
                patientid = "000" + patientid + "00";

                string sql = @"insert into mz_patient_mi(patient_id,social_no,hic_no,p_bar_code,name,sex,birthday,home_tel,
balance,max_times,max_ledger_sn,max_item_sn,max_receipt_sn,charge_type) values
(?,?,?,?,?,?,?,?,'01',0,0,0,0,'01')";
                SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@p1",patientid),
                new SqlParameter("@p2",sno),
                new SqlParameter("@p3",hicno),
                new SqlParameter("@p4",barcode),
                new SqlParameter("@p5",name),
                new SqlParameter("@p6",int.Parse(sex)),
                new SqlParameter("@p7",birthday),
                new SqlParameter("@p8",tel),
                //new SqlParameter("@p9","01"),
                //new SqlParameter("@p9",0),
                //new SqlParameter("@p10",0),
                //new SqlParameter("@p11",0),
                //new SqlParameter("@p12",0),
                //new SqlParameter("@p13",0),
                //new SqlParameter("@p14","01"),
            };

                return DbHelper.ExecuteNonQuery(sql, para);
            }
        }

        /// <summary>
        /// 获取当前发票号
        /// </summary>
        /// <returns></returns>
        public DataTable GetCurrentReceiptNo()
        {
            string sql = "select top 1 * from gh_op_receipt order by happen_date desc ";

            return DbHelper.ExecuteDataTable(sql);
        }
        /// <summary>
        /// 获取号别信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetHaoLie()
        {
            string sql = "select * from gh_zd_clinic_type where deleted_flag = 0 ";

            return DbHelper.ExecuteDataTable(sql);
        }
        /// <summary>
        /// 获取号类信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetHaobie()
        {
            string sql = "select * from gh_zd_request_type where deleted_flag = 0 ";

            return DbHelper.ExecuteDataTable(sql);
        }
        public bool GuaHao(string patient_id, string record_sn)
        {
            try
            {

                //更新挂号表 当前号
                string sql1 = "UPDATE gh_request SET current_no =current_no+1 WHERE record_sn = ?";
                SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@p1",record_sn),
            };
                DbHelper.ExecuteNonQuery(sql1, para);

                //更新门诊用户信息 max_times
                string sql2 = "update mz_patient_mi set max_times = max_times+1,max_ledger_sn =max_ledger_sn+1 where  patient_id=? " +
                    "select max_ledger_sn,max_times from mz_patient_mi where  patient_id=?";
                //, name = 'test0328', sex = '1', response_type = '01',
                //charge_type = '01', black_flag = '', birthday = '2009-03-28', p_bar_code = '2969317',
                //relation_name = 'test0328' where patient_id like '000296931700'
                para = new SqlParameter[]{
                new SqlParameter("@p1",patient_id),
                new SqlParameter("@p2",patient_id),
            };
                int max_ledger_sn = 0;
                int max_times = 0;

                var dt1 = DbHelper.ExecuteDataTable(sql2, para);
                if (dt1 != null && dt1.Rows.Count > 0)
                {
                    max_ledger_sn = Convert.ToInt32(dt1.Rows[0]["max_ledger_sn"]);
                    max_times = Convert.ToInt32(dt1.Rows[0]["max_times"]);
                }


                //更新发票号
                string sql3 = @"UPDATE mz_order_generator  
     SET max_sn = max_sn + 1
   WHERE(mz_order_generator.define = 'gh_receipt_sn')
SELECT mz_order_generator.max_sn
   FROM mz_order_generator
   WHERE(mz_order_generator.define = 'gh_receipt_sn') ";
                int max_sn = DbHelper.ExecuteScalar(sql3);

                //写入挂号收费明细表
                //查询挂号费
                var charge_code = "100001";
                string ghsql = "select * from zd_charge_item where code = '" + charge_code + "' ";
                var dt2 = DbHelper.ExecuteDataTable(ghsql);
                decimal charge_price = 0;
                decimal effective_price = 0;
                var audit_code = "";
                var mz_bill_item = "";
                var mz_charge_group = "";
                if (dt2 != null && dt2.Rows.Count > 0)
                {
                    charge_price = Convert.ToDecimal(dt2.Rows[0]["charge_price"]);
                    effective_price = Convert.ToDecimal(dt2.Rows[0]["effective_price"]);
                    audit_code = Convert.ToString(dt2.Rows[0]["audit_code"]);
                    mz_bill_item = Convert.ToString(dt2.Rows[0]["mz_bill_item"]);
                    mz_charge_group = Convert.ToString(dt2.Rows[0]["mz_charge_group"]);
                }

                string sql4 = @"insert into gh_detail_charge
  (patient_id, times, item_no, ledger_sn, happen_date, charge_code, audit_code, bill_code, exec_sn, apply_sn,
org_price, charge_price, charge_amount, charge_group, enter_opera, enter_date, enter_win_no, 
confirm_opera, confirm_date, confirm_win_no, charge_status, trans_flag, mz_dept_no)
values (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

                para = new SqlParameter[]{
                new SqlParameter("@p1",patient_id),
                new SqlParameter("@p2",max_times),
                new SqlParameter("@p3",1),
                new SqlParameter("@p4",max_ledger_sn),
                new SqlParameter("@p5",DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                new SqlParameter("@p6",charge_code),
                new SqlParameter("@p7",audit_code),
                new SqlParameter("@p8",mz_bill_item),
                new SqlParameter("@p9","1010501"),
                new SqlParameter("@p10","0000000"),
                new SqlParameter("@p11",charge_price),
                new SqlParameter("@p12",effective_price),
                new SqlParameter("@p13","1"),
                new SqlParameter("@p14",mz_charge_group),
                new SqlParameter("@p15","00000"),
                new SqlParameter("@p16",DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                new SqlParameter("@p17","0"),
                new SqlParameter("@p18","00000"),
                new SqlParameter("@p19",DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                new SqlParameter("@p20","0"),
                new SqlParameter("@p21","4"),
                new SqlParameter("@p22","0"),
                new SqlParameter("@p23","1"),
            };
                var result = DbHelper.ExecuteNonQuery(sql4, para);

                var dtreceipt = GetCurrentReceiptNo();
                var current_no = "";
                var start_no = "";
                var end_no = "";
                var happen_date = "";
                var step_length = 1;
                if (dtreceipt != null && dtreceipt.Rows.Count > 0)
                {
                    current_no = dtreceipt.Rows[0]["current_no"].ToString();
                    start_no = dtreceipt.Rows[0]["start_no"].ToString();
                    end_no = dtreceipt.Rows[0]["end_no"].ToString();
                    happen_date = dtreceipt.Rows[0]["happen_date"].ToString();
                    int res = 1;
                    if (int.TryParse(dtreceipt.Rows[0]["step_length"].ToString(), out res))
                    {
                        step_length = res;
                    }
                }

                //写入挂号发票表
                string sql5 = @"insert into gh_receipt
  (patient_id, times, ledger_sn, receipt_sn, pay_unit, charge_total, settle_opera, settle_date, price_opera, price_date, receipt_no, charge_status, mz_dept_no)
values
  (?, ?,?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
                para = new SqlParameter[]{
                new SqlParameter("@p1",patient_id),
                new SqlParameter("@p2",max_times),
                new SqlParameter("@p3",max_ledger_sn),
                new SqlParameter("@p4",max_sn),
                new SqlParameter("@p5","01"),
                new SqlParameter("@p6",effective_price),
                new SqlParameter("@p7","00000"),
                new SqlParameter("@p8",DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                new SqlParameter("@p9","00000"),
                new SqlParameter("@p10",DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                new SqlParameter("@p11",current_no),//gh_op_receipt receipt_no
                new SqlParameter("@p12","4"),
                new SqlParameter("@p13","1"),
            };
                result = DbHelper.ExecuteNonQuery(sql5, para);

                //写入挂号发票明细表
                string sql6 = @"insert into gh_receipt_charge
  (patient_id, times, ledger_sn, receipt_sn, bill_code, charge, pay_unit)
values
  (?, ?, ?, ?, ?, ?, ?) ";

                para = new SqlParameter[]{
                new SqlParameter("@p1",patient_id),
                new SqlParameter("@p2",max_times),
                new SqlParameter("@p3",max_ledger_sn),
                new SqlParameter("@p4",max_sn),
                new SqlParameter("@p5",mz_bill_item),
                new SqlParameter("@p6",effective_price),
                new SqlParameter("@p7","01")
            };
                result = DbHelper.ExecuteNonQuery(sql6, para);

                //写入现金流表
                string sql7 = @"insert into gh_deposit
  (patient_id, item_no, ledger_sn, times, charge, cheque_type, depo_status, price_opera, price_date, mz_dept_no)
values
  (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

                para = new SqlParameter[]{
                new SqlParameter("@p1",patient_id),
                new SqlParameter("@p2",1),
                new SqlParameter("@p3",max_ledger_sn),
                new SqlParameter("@p4",max_times),
                new SqlParameter("@p5",effective_price),
                new SqlParameter("@p6","1"),
                new SqlParameter("@p7","4"),
                new SqlParameter("@p8","0000"),
                new SqlParameter("@p9",DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                new SqlParameter("@p10","1"),
            };
                result = DbHelper.ExecuteNonQuery(sql7, para);

                int new_no = Convert.ToInt32(current_no) + step_length;
                //更新挂号发票记录表
                string sql8 = @"update gh_op_receipt  set
                                 current_no = ? 
                                 where
                                 operator = ? and
                                 happen_date = ? and
                                 start_no = ? and
                                 current_no = ? and
                                 end_no = ? and
                                 step_length =? and
                                 deleted_flag = ? and
                                 report_flag = ? and
                                 receipt_type = ?";
                para = new SqlParameter[]{
                new SqlParameter("@p1",new_no.ToString().PadLeft(10,'0')),
                new SqlParameter("@p2","00000"),
                new SqlParameter("@p3",happen_date),
                new SqlParameter("@p4",start_no),
                new SqlParameter("@p5",current_no),
                new SqlParameter("@p6",end_no),
                new SqlParameter("@p7",1),
                new SqlParameter("@p8","0"),
                new SqlParameter("@p9","0"),
                new SqlParameter("@p10","1"),
                };
                result = DbHelper.ExecuteNonQuery(sql8, para);


            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }



        /// <summary>
        /// 生成号表操作 
        /// </summary>
        /// <returns></returns>
        public bool Schb(string unit_sn, string group_sn, string doctor_sn, string clinic_type, int week, int day, string ampm, int totle_num, string window_no, string open_flag)
        {
            //查询是否存在相同信息
            string sql1 = @"select * from gh_base_request
where unit_sn like ? and
      isnull(group_sn, '' - 1'') like ? and
      isnull(doctor_sn, '' - 1'') like ? and
         clinic_type like ? and
         week = ? and
         day = ? and
         ampm like ? ";
            //N'@P1 varchar(7),@P2 varchar(7),@P3 varchar(5),@P4 varchar(2),@P5 int,@P6 int,@P7 varchar(1)','1010000','1010000','00679','01',1,1,'p'
            SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@p1",unit_sn),
                new SqlParameter("@p2",group_sn),
                new SqlParameter("@p3",doctor_sn),
                new SqlParameter("@p4",clinic_type),
                new SqlParameter("@p5",week),
                new SqlParameter("@p6",day),
                new SqlParameter("@p7",ampm)
            };

            var dt1 = DbHelper.ExecuteDataTable(sql1, para);

            if (dt1.Rows.Count > 0)
            {
                //如果存在 继续判断是否是修改操作
                var _totle = dt1.Rows[0]["totle_num"].ToString();
                if (totle_num.ToString() != _totle)
                {

                }
            }
            else
            {
                //如果不存在 择写入新数据 
                string sql2 = @"select * from gh_base_request
where unit_sn like ? and
      isnull(group_sn,'''') like ? and
      isnull(doctor_sn,'''') like ? and
      clinic_type like ? and
      isnull(cast(week as char),'''') like ? and
      isnull(cast(day as char),'''') like ? and
      ampm like @P7 and
      isnull(cast(window_no as char),'''') like ? and
      open_flag like ?
order by unit_sn,
         group_sn,
         doctor_sn,
         clinic_type,
         week,
         day,
         ampm,
         window_no";
                para = new SqlParameter[]{
                new SqlParameter("@p1",unit_sn),
                new SqlParameter("@p2",group_sn),
                new SqlParameter("@p3",doctor_sn),
                new SqlParameter("@p4",clinic_type),
                new SqlParameter("@p5",week),
                new SqlParameter("@p6",day),
                new SqlParameter("@p7",ampm),
                new SqlParameter("@p8",window_no),
                new SqlParameter("@p9",open_flag)
            };

                var dt2 = DbHelper.ExecuteDataTable(sql2, para);

                //查询最大的sn


                string sql3 = @"insert into gh_base_request
  (request_sn, week, day, ampm, unit_sn, group_sn, doctor_sn, clinic_type, totle_num, op_id, op_date, open_flag, window_no)
values
  (?, ?, ?, ?, ?, ?, ?, ?, ?, ?,?, ?, ?)
',N'@P1 int,@P2 smallint,@P3 smallint,@P4 char(1),@P5 char(7),@P6 char(7),@P7 char(5),@P8 char(2),@P9 smallint,@P10 char(5),@P11 datetime,@P12 char(1),@P13 smallint',
,1,1,,'1010000','1010000','00679','01',30,'00000','2022-04-07 14:05:55','1',0";

                para = new SqlParameter[]{
                new SqlParameter("@p1",6389),
                new SqlParameter("@p2",1),
                new SqlParameter("@p3",1),
                new SqlParameter("@p4",'p'),
                new SqlParameter("@p5",unit_sn),
                new SqlParameter("@p6",group_sn),
                new SqlParameter("@p7",doctor_sn),
                new SqlParameter("@p8",clinic_type),
                new SqlParameter("@p9",totle_num),
                new SqlParameter("@p10","00000"),
                new SqlParameter("@p11",DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                new SqlParameter("@p12",open_flag),
                new SqlParameter("@p13",window_no)
            };
                var dt3 = DbHelper.ExecuteDataTable(sql2, para);
            }



            return true;
        }
    }
}
