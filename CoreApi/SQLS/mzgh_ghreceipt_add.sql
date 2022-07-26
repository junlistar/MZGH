 
--220020π“∫≈ –¥»Îπ“∫≈∑¢∆±±Ì
insert into gh_receipt
  (patient_id, times, ledger_sn, receipt_sn, pay_unit, charge_total, settle_opera, settle_date, price_opera, price_date, receipt_no, charge_status, mz_dept_no)
values
  (@patient_id,@times,@ledger_sn, @receipt_sn, @pay_unit, @charge_total, @settle_opera,@settle_date, @price_opera, @price_date, @receipt_no, @charge_status, @mz_dept_no)
 