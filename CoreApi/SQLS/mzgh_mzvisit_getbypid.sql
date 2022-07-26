 select 
        a.patient_id,
        a.times,
        a.gh_date,
        a.name patient_name, 
        b.name unit_name, 
        c.name doctor_name,
        b1.name group_name, 
        case a.ampm when 'a' then '����' when 'm' then '����' when 'p' then '����' else 'ҹ��' end ampm, 
        case a.visit_flag when '0' then 'δ��' when '9' then '�˺�' when '8' then '�Ѵ�ӡ' else '�ѵ�' end visit_status
       
from    view_mz_visit_table a left join  zd_unit_code b on a.visit_dept = b.unit_sn
        left join  zd_unit_code b1 on a.group_sn = b1.unit_sn 
        left join  a_employee_mi c on a.doctor_code = c.emp_sn 
        
where  a.patient_id=@patient_id
order by
        a.gh_date desc