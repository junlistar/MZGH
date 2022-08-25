 
--220065挂号  检查重复挂号信息
select COUNT(*) from view_mz_visit_table a
inner join gh_request b on a.visit_date = b.request_date 
and a.visit_dept= b.unit_sn 
and a.clinic_type = b.clinic_type
and ISNULL(a.group_sn,'0') =ISNULL(b.group_sn,'0') 
and ISNULL(a.doctor_code,'0') LIKE ISNULL(b.doctor_sn,'0')
and a.ampm=b.ampm
where patient_id = @patient_id
and record_sn = @record_sn


 
