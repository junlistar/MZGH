using Dapper;
using MzsfData.Entities;
using MzsfData.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MzsfData.Repository
{
    public class CprChargesRepository : RepositoryBase<CprCharges>, ICprChargesRepository
    {

        public List<CprCharges> GetCprCharges(string patient_id, int times, string charge_status)
        {

            string ghsql = GetSqlByTag(221003);
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


        public bool Refund()
        {

            return true;

        }
    }
}
