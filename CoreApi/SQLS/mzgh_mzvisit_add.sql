 
--220016挂号 新增用户挂号记录表
insert into mz_visit_table(patient_id,times,visit_dept,doctor_code,visit_date,name,response_type,haoming_code,charge_type,
age,group_sn,clinic_type,req_type,gh_sequence,ampm,visit_flag,gh_opera,gh_date) values
(@patient_id,@times,@visit_dept,@doctor_code,@visit_date,@name,@response_type,@haoming_code,@charge_type,
@age,@group_sn,@clinic_type,@req_type,@gh_sequence,@ampm,@visit_flag,@gh_opera,@gh_date)
   
 