--221018 门诊收费 -  写入mz_receipt
insert into mz_receipt
  (patient_id, ledger_sn, receipt_sn, pay_unit, charge_total, charge_status, cash_date, cash_opera, windows_no,
report_date, receipt_no, mz_dept_no, group_date, contract_code)
values (@patient_id, @ledger_sn, @receipt_sn, @pay_unit, @charge_total, @charge_status, @cash_date, @cash_opera, @windows_no,
null, null, @mz_dept_no, null, @contract_code)