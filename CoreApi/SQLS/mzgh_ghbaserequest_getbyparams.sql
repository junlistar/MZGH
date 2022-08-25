 
--220053  基础号表条件查询
select a.*,b.name unit_name,c.name group_name,d.name doct_name,e.name clinic_name
from gh_base_request a
left join zd_unit_code b on a.unit_sn = b.unit_sn
left join zd_unit_code c on a.group_sn = c.unit_sn
left join a_employee_mi d on a.doctor_sn = d.emp_sn
left join gh_zd_clinic_type e on a.clinic_type = e.code
where a.unit_sn like @unit_sn and
      isnull(a.group_sn,'') like @group_sn and
      isnull(a.doctor_sn,'') like @doctor_sn and
      a.clinic_type like @clinic_type and
      isnull(cast(a.week as char),'') like @week and
      isnull(cast(a.day as char),'') like @day and
      a.ampm like @ampm and
      isnull(cast(a.window_no as char),'') like @window_no and
      a.open_flag like @open_flag and 
      isnull(cast(a.temp_flag as int),0) like @temp_flag
order by op_date desc,unit_sn,
         group_sn,
         doctor_sn,
         clinic_type,
         week,
         day,
         ampm,
         window_no
 