 select 
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
        a.gh_date desc