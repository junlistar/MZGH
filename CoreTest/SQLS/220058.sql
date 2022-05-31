 
--220058¹ÒºÅ  ²éÑ¯»ù´¡ºÅ±í 
select b.*,
	w.name window_name,	
        t.name clinic_name, 
	u1.name unit_name,
        u2.name group_name,
	a.name doct_name,
        c.req_type,
        c.begin_no,
        c.end_no      
from 	gh_base_request as b left join gh_zd_clinic_type as t on  b.clinic_type=t.code  
	left join gh_zd_window_no as w on b.window_no =w.window_no  
	left join zd_unit_code as u1 on b.unit_sn =u1.unit_sn  
	left join zd_unit_code as u2 on b.group_sn=u2.unit_sn 
	left join a_employee_mi as a on b.doctor_sn=a.emp_sn 
        inner join gh_base_request_segment c on b.request_sn = c.request_sn 
where  b.open_flag='1'
 