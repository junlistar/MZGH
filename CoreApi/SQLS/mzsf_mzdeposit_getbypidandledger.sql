--查询指定patient_id和ledger_sn的门诊收费流水记录
SELECT* FROM mz_deposit WHERE patient_id = @patient_id AND ledger_sn = @ledger_sn