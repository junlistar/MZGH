 
--220047挂号  退款写数据到现金流表
insert into gh_deposit(patient_id, item_no, ledger_sn, times, charge, 
cheque_type, cheque_no,depo_status, price_opera, price_date, mz_dept_no)
values(@patient_id,@item_no,@ledger_sn,@times,@charge,@cheque_type,@cheque_no,
@depo_status,@price_opera,@price_date,@mz_dept_no)
  