 
--220038挂号 查询退款列表
SELECT
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
      ISNULL(f.receipt_sn, '') receipt_sn,
      ISNULL(f.receipt_no, '') receipt_no,
      f.report_date,
	  charge= (select max(charge_total) from gh_receipt where patient_id=v.patient_id and  times=v.times ),
      ic_count = (SELECT COUNT(*) FROM ic_deposit h 
				  WHERE h.patient_id = f.patient_id AND
						h.cheque_no = f.receipt_no AND
						h.deposit_no = f.receipt_sn ),
      v.visit_flag,						
      visit_flag_name = CASE ISNULL(v.visit_flag, '0') WHEN '1' THEN '挂号'
                                                  WHEN '2' THEN '分诊'
                                                  WHEN '3' THEN '接诊'
                                                  WHEN '4' THEN '已就诊'
                                                  WHEN '9' THEN '退号'
                   END    
FROM  view_mz_visit_table v 
      left join zd_unit_code u1 on v.visit_dept = u1.unit_sn 
      left join zd_unit_code u2 on v.group_sn = u2.unit_sn 
      left join a_employee_mi a on v.doctor_code = a.emp_sn  
      left join gh_zd_clinic_type c on v.clinic_type = c.code 
      left join gh_zd_request_type r on v.req_type = r.code
      left join gh_receipt f on f.patient_id = v.patient_id AND f.times = v.times 
WHERE 
      DATEDIFF(dd, v.gh_date, @request_date) = 0 AND 
      v.patient_id LIKE @patient_id
   
order by v.gh_date desc 