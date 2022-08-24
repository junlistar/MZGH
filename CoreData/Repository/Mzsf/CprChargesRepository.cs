using Dapper;
using Data.Entities.Mzsf;
using Data.IRepository.Mzsf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Linq;

namespace Data.Repository.Mzsf
{
    public class CprChargesRepository : RepositoryBase<CprCharges>, ICprChargesRepository
    {

        public List<CprCharges> GetCprCharges(string patient_id, int times, string charge_status)
        {

            string ghsql = GetSqlByTag("mzsf_mzdetailchargeitem_getbypid");
            var para = new DynamicParameters();

            para.Add("@patient_id", patient_id);
            para.Add("@times", times);
            para.Add("@charge_status", charge_status);
            return Select(ghsql, para);
        }


        /// <summary>
        /// 门诊收费获取药房处方数据
        /// </summary>
        /// <param name="p_id"></param>
        /// <param name="ledger_sn"></param>
        /// <param name="tbl_flag"></param>
        /// <returns></returns>
        public List<CprCharges> GetDrugDetails(string p_id, int ledger_sn, string tbl_flag)
        {  
            var para = new DynamicParameters();

            para.Add("@p_id", p_id);
            para.Add("@ledger_sn", ledger_sn);
            para.Add("@tbl_flag", tbl_flag);
            return ExecQuerySP("mzsf_GetDrugDetails", para); 
        }
         
        public bool CallCprCharges(string user_mi,string patient_id, int times, string status)
        {
            var para = new DynamicParameters();

            para.Add("@user_mi", user_mi);
            para.Add("@patient_id", patient_id);
            para.Add("@times", times);
            para.Add("@status", status);
            ExecQuerySP("mzsf_CallCprCharges", para);
            return true;
        }

        public int GetRefundNewRecordLedgerSn(int ledger_sn)
        {
            using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
            {
                string sql = GetSqlByTag("mzsf_mzdetailcharge_getparentledgersn");
              
                var para = new DynamicParameters();
                para.Add("@parent_ledger_sn", ledger_sn);

                return connection.Query<int>(sql,para).FirstOrDefault();
            } 
        }
    }
}
