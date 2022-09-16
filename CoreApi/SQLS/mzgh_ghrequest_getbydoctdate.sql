 
-- 查询指定日期区间医生的挂号信息 
select b.record_sn,b.request_date,
       h.name ampm,
       b.unit_sn,
       b.group_sn,
       b.doctor_sn,
       b.clinic_type,
       b.req_type,
       u1.name unit_name,
       u2.name group_name,
       a.name doct_name,
       c.name clinic_name,
       r.name req_name,
       b.begin_no,
       b.current_no,
       b.end_no,
       b.window_no,
       case b.open_flag when '1' then '开放' else '不开放' end open_flag
from gh_request b left join a_employee_mi a on b.doctor_sn = a.emp_sn 
     inner join zd_unit_code u1 on b.unit_sn = u1.unit_sn  
     left join zd_unit_code u2 on b.group_sn = u2.unit_sn 
     inner join gh_zd_clinic_type  c on b.clinic_type = c.code 
     inner join gh_zd_request_type r on b.req_type = r.code  
	 left join gh_zd_request_hour h on b.ampm = h.code
where b.request_date between @P1 and @P2
and   b.doctor_sn= @doctor_sn and 
      b.open_flag =1 and delete_flag is null
 