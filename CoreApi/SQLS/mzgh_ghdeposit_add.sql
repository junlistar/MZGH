 
--220018 新增现金流表
insert into gh_deposit
  (patient_id, item_no, ledger_sn, times, charge, cheque_type, cheque_no, depo_status, price_opera, price_date, mz_dept_no)
values
  (@patient_id, @item_no, @ledger_sn, @times, @charge, @cheque_type,@cheque_no, @depo_status, @price_opera, @price_date, @mz_dept_no)