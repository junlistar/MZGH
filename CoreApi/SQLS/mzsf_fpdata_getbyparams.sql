 --查询指定patient_id ledger_sn subsys_id的发票信息
 select * from fp_data where patient_id=@patient_id and ledger_sn=@ledger_sn and subsys_id=@subsys_id