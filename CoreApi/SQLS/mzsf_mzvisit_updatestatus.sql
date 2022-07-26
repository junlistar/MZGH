--221012 门诊收费 - 更新 mz_visit_table
update mz_visit_table  set 
 charge_status = @charge_status,
 charge_times = @charge_times
where
 patient_id = @patient_id and
 times = @times