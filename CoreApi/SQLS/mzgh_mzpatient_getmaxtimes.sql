 
--220014挂号 更新门诊用户就诊次数，缴费次数信息，并查询
update mz_patient_mi set max_times = max_times+1,max_ledger_sn =max_ledger_sn+1 where  patient_id=@patient_id;select max_ledger_sn,max_times from mz_patient_mi where  patient_id=@patient_id
 