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

            string sql = @"SELECT
      DISTINCT
	  v.visit_date,
      v.visit_dept,
      v.group_sn,
      v.doctor_code,
      v.ampm,
      u1.name unit_name,
	  u2.name group_name,
	  a.name doctor_name,
	  v.gh_sequence,
      v.patient_id,
      v.name,
      v.times,
      d.charge,
      d.ledger_sn,
      d.item_no,
      ISNULL(v.response_type, '') response_type,
      ISNULL(v.charge_type, '') charge_type,
      ISNULL(v.clinic_type, '') clinic_type,
      ISNULL(v.req_type, '') req_type,
      ISNULL(c.name, '') clinic_name,
      ISNULL(r.name, '') request_name,
      ISNULL(v.gh_opera , '') gh_opera,
      v.gh_date,
      CASE  WHEN v.gh_sequence < 0 THEN '加号' + CAST(ABS(v.gh_sequence) AS CHAR)
            ELSE CAST(ABS(v.gh_sequence) AS CHAR) 
            END gh_sequence_c,
      ISNULL(g.name, '') cheque_name,
      ISNULL(d.cheque_type, '') cheque_type,
      ISNULL(d.cheque_no, '') cheque_no,
      ISNULL(f.receipt_sn, '') receipt_sn,
      ISNULL(f.receipt_no, '') receipt_no,
      f.report_date,
      ic_count = (SELECT COUNT(*) FROM ic_deposit h 
				  WHERE h.patient_id = f.patient_id AND
						h.cheque_no = f.receipt_no AND
						h.deposit_no = f.receipt_sn ),
      v.visit_flag,						
      visit_flag_name = CASE ISNULL(v.visit_flag, '0') WHEN '1' THEN '挂号'
                                                  WHEN '2' THEN '分诊'
                                                  WHEN '4' THEN '已就诊'
                                                  WHEN '9' THEN '取消分诊'
                   END    
FROM  view_mz_visit_table v 
      left join zd_unit_code u1 on v.visit_dept = u1.unit_sn 
      left join zd_unit_code u2 on v.group_sn = u2.unit_sn 
      left join a_employee_mi a on v.doctor_code = a.emp_sn 
      left join view_gh_deposit d on v.patient_id = d.patient_id AND v.times = d.times 
      left join gh_zd_clinic_type c on v.clinic_type = c.code 
      left join gh_zd_request_type r on v.req_type = r.code
      left join gh_receipt f on f.patient_id = d.patient_id AND f.times = d.times 
      left join zd_cheque_type g on g.code = d.cheque_type 
WHERE 
    
      d.ledger_sn > 0 AND
      f.ledger_sn = d.ledger_sn AND  
     -- v.visit_flag <> '9' AND
      DATEDIFF(dd, v.visit_date, @request_date) = 0 AND 
      ISNULL(v.visit_dept, '') LIKE @unit_sn AND
      ISNULL(v.group_sn, '-1') LIKE @group_sn AND
      ISNULL(v.doctor_code, '-1') LIKE @doctor_sn and
      CAST(v.gh_sequence AS VARCHAR) LIKE @sequence_no AND
      v.patient_id LIKE @patient_id AND
      ISNULL(CONVERT(VARCHAR, v.times), '0') LIKE @times AND
      ISNULL(f.receipt_no, '') LIKE @rcp_no
   
order by v.gh_date desc";

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

            //'2022-04-15','%','%','%','%','000296903300%','%','%','%'

            //return ExecQuerySP("mzgh_GetRequestBack", para);
            return Select(sql, para);
        }

        
    }
}
