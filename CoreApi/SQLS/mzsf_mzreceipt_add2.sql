--221018 门诊收费发票 -  写入mz_receipt
INSERT INTO mz_receipt ( patient_id, ledger_sn, receipt_sn, pay_unit, charge_total,
charge_status, cash_date, cash_opera, windows_no, receipt_no, mz_dept_no, contract_code, backfee_date)  
Values ( @patient_id, @ledger_sn, @receipt_sn, @pay_unit, @charge_total,
@charge_status, @cash_date, @cash_opera, @windows_no, @receipt_no, @mz_dept_no, @contract_code, null)