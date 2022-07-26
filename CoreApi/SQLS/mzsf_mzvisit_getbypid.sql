--221013 门诊收费 - 获取就诊信息
SELECT b.name unit_name,c.name doct_name,a.* FROM mz_visit_table a  
 left join zd_unit_code b on a.visit_dept = b.code 
 left join a_employee_mi c on a.doctor_code = c.code 
 WHERE patient_id =@patient_id and times=@times 