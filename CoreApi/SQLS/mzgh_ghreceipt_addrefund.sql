 
--220050挂号  退号发票表写入对冲数据
insert into gh_receipt(patient_id,times,ledger_sn,receipt_sn,pay_unit,charge_total,settle_opera,settle_date,price_opera,price_date,report_date,receipt_no,charge_status,mz_dept_no,op_receipt_sn)  
select patient_id,times,-ledger_sn,receipt_sn,pay_unit,-charge_total,@settle_opera,settle_date,@price_opera,price_date,report_date,receipt_no,7,mz_dept_no,op_receipt_sn
from gh_receipt  where patient_id =@patient_id and ledger_sn=@ledger_sn
 