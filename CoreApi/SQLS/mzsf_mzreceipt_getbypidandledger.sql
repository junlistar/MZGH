--查询患者门诊发票信息
SELECT* FROM mz_receipt WHERE patient_id = @patient_id  AND ledger_sn =@ledger_sn AND receipt_sn = @receipt_sn