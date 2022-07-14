using Dapper;
using Data.Entities;
using Data.Entities.Mzsf;
using Data.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Data.Repository
{
    public class MzsfDailyReportRepository : RepositoryBase<ChargeItem>, IMzsfDailyReportRepository
    {

        public List<string> GetMzsfReport(string opera, string report_date)
        {

            //string ghsql = GetSqlByTag(220041);

            string sql = GetSqlByTag(221041);

            var para = new DynamicParameters();

            para.Add("@opera", opera);
            para.Add("@rdate", report_date);
            para.Add("@subsys", "mz");

            return SelectStringList(sql, para);
        }
        /// <summary>
        /// 门诊收费日结保存，轧账功能
        /// </summary>
        /// <param name="opera"></param>
        /// <returns></returns>
        public bool SaveMzsfDaily(string opera,string cash_date)
        {
            try
            {  
                var para = new DynamicParameters();

                para.Add("@rep_date", "1900-01-01");
                para.Add("@op_id", opera);
                para.Add("@mz_dept_no", "1");
                para.Add("@cash_date", cash_date);
                para.Add("@flag", "1");

                return ExecuteSP("mz_day_Reportdata", para)>0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
