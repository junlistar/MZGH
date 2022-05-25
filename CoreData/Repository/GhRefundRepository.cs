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
    public class GhRefundRepository : RepositoryBase<GhRefund>, IGhRefundRepository
    {

        public List<GhRefund> GetGhRefund(string datestr, string patient_id)
        {

            string sql = GetSqlByTag(220038);

            var para = new DynamicParameters();
            para.Add("@request_date", datestr);
            para.Add("@unit_sn", "%");
            para.Add("@group_sn", "%");
            para.Add("@doctor_sn", "%");
            para.Add("@sequence_no", "%");
            para.Add("@patient_id", patient_id+"%");
            para.Add("@times", "%");
            para.Add("@gh_op", "%");
            para.Add("@rcp_no", "%"); 
             

            //return ExecQuerySP("mzgh_GetRequestBack", para);
            return Select(sql, para);
        }

        
    }
}
