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

        public List<GhSearch> GetRecordByPatientId(string patient_id)
        {
            string sql = @"select 
        a.patient_id,
        a.times,
        a.gh_date,
        a.name patient_name, 
        b.name unit_name, 
        c.name doctor_name,
        b1.name group_name, 
        case a.ampm when 'a' then '上午' when 'm' then '中午' when 'p' then '下午' else '夜间' end ampm, 
        case a.visit_flag when '0' then '未到' when '9' then '退号' when '8' then '已打印' else '已到' end visit_status
       
from    view_mz_visit_table a left join  zd_unit_code b on a.visit_dept = b.unit_sn
        left join  zd_unit_code b1 on a.group_sn = b1.unit_sn 
        left join  a_employee_mi c on a.doctor_code = c.emp_sn 
        
where  a.patient_id=@patient_id
order by
        a.gh_date desc";

            var para = new DynamicParameters();
            para.Add("@patient_id", patient_id); 

            return Select(sql, para);
        }

    }
}
