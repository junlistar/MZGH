--查询指定的门诊收费项目
SELECT* FROM mz_detail_charge WHERE patient_id = @patient_id AND ledger_sn =@ledger_sn