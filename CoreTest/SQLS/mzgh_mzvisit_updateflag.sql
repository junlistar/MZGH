 
--220049挂号  更新用户挂号表状态为退号
update mz_visit_table set visit_flag=9 where patient_id=@patient_id and times=@times
 