using Dapper;
using Data.Entities.Mzsf;
using Data.IRepository.Mzsf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Data.Repository.Mzsf
{
    public class MzVisitRepository : RepositoryBase<MzVisit>, IMzVisitRepository
    {
    
        public List<MzVisit> GetMzVisitsByDate(string patient_id, string begin,string end)
        {

            string ghsql = GetSqlByTag("mzsf_mzdetailcharge_getbydate");
            var para = new DynamicParameters();

            para.Add("@patient_id", patient_id);
            para.Add("@begin", begin);
            para.Add("@end", end);
            return Select(ghsql, para);
        } 

        /// <summary>
        /// 生成挂号记录
        /// </summary>
        /// <param name="haoming_code"></param>
        /// <param name="patient_id"></param>
        /// <param name="times"></param>
        /// <param name="expertflag"></param>
        /// <param name="unit_sn"></param>
        /// <param name="doctor_sn"></param>
        /// <returns></returns>
        public List<MzVisit> CreateVisitRecord(string haoming_code,string patient_id,int times,int expertflag,string unit_sn,string doctor_sn)
        {  
            string sql = @"mzcpr_UpdateVisitInfo";
            var para = new DynamicParameters();

            para.Add("@haoming_code", haoming_code);
            para.Add("@patient_id", patient_id);
            para.Add("@times", times);
            para.Add("@expertflag", expertflag);
            para.Add("@unit_sn", unit_sn);
            para.Add("@doctor_sn", doctor_sn);
            para.Add("@visit_flag", "1");
            para.Add("@visit_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            return base.ExecQuerySP(sql, para);

        }
    }
}
