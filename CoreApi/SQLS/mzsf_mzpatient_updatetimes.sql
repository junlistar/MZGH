--221011 门诊收费 - 更新 mz_patient_mi
update mz_patient_mi  set max_ledger_sn = @max_ledger_sn, max_item_sn = @max_item_sn
where patient_id = @patient_id