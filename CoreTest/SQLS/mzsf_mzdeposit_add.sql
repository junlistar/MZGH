--221019 门诊收费 -  写入mz_deposit
insert into mz_deposit
  (patient_id, item_no, ledger_sn, cheque_type, cheque_no, charge, depo_status, windows_no, dcount_date, dcount_id, deposit_no, account_no, 
business_no, mz_dept_no, valid_no)
values
  (@patient_id, @item_no, @ledger_sn, @cheque_type, @cheque_no, @charge, @depo_status, @windows_no, @dcount_date, @dcount_id, null, null,
null, @mz_dept_no, null)