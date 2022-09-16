 
--更新用户最大次数
update mz_patient_mi set max_times=max_times+1 where patient_id=@patient_id 