INSERT INTO mz_deposit 
( patient_id, item_no, ledger_sn, cheque_type, cheque_no, charge, depo_status, windows_no, dcount_date, dcount_id, mz_dept_no)
Values ( @patient_id, @item_no, @ledger_sn, @cheque_type, @cheque_no, @charge, @depo_status, @windows_no, @dcount_date, @dcount_id, @mz_dept_no)