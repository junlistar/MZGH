 
--220060挂号  挂号数据条件查询 
select b.record_sn,b.request_date,
       case b.ampm when 'a' then '上午' when 'm' then '中午' when 'p' then '下午' else '夜间' end ampm,
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
where b.request_date between @P1 and @P2
and b.unit_sn like @unit_sn and
      isnull(b.group_sn,'') like @group_sn and
      isnull(b.doctor_sn,'') like @doctor_sn and
      b.clinic_type like @clinic_type and
      b.req_type like @req_type and 
      b.ampm like @ampm and
      isnull(cast(b.window_no as char),'') like @window_no and
      b.open_flag like @open_flag



 
