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
    public class GhSearchRepository : RepositoryBase<GhSearch>, IGhSearchRepository
    {

        public List<GhSearch> GhSearchList(string gh_date, string visit_dept = "%", string clinic_type = "%", string doctor_code = "%", 
            string group_sn = "%", string req_type = "%", string ampm = "%", string gh_opera = "%",
            string name = "%", string p_bar_code = "%")
        {
            string sql = GetSqlByTag(220032);
             
            var para = new DynamicParameters();
            para.Add("@gh_date", gh_date);
            para.Add("@visit_dept", visit_dept);
            para.Add("@clinic_type", clinic_type);
            para.Add("@doctor_code", doctor_code);
            para.Add("@group_sn", group_sn);
            para.Add("@req_type", req_type);
            para.Add("@ampm", ampm);
            para.Add("@gh_opera", gh_opera);  
            para.Add("@name", "%"+name+"%"); 
            para.Add("@p_bar_code", p_bar_code); 

            return Select(sql, para);
        }

         

    }
}
