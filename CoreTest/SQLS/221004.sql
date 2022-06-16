--221004 门诊收费 - 查询近两日就诊处方记录
 SELECT b.name unit_name,c.name doct_name,a.* FROM mz_visit_table a  
 left join zd_unit_code b on a.visit_dept = b.code 
 left join a_employee_mi c on a.doctor_code = c.code 
 WHERE patient_id =@patient_id AND  (visit_date BETWEEN @begin AND @end)  AND  ISNULL(visit_flag, '1') NOT IN ('0', '9')