 

--220017挂号 新增挂号收费明细表
insert into gh_detail_charge
  (patient_id, times, item_no, ledger_sn, happen_date, charge_code, audit_code, bill_code, exec_sn, apply_sn,
org_price, charge_price, charge_amount, charge_group, enter_opera, enter_date, enter_win_no, 
confirm_opera, confirm_date, confirm_win_no, charge_status, trans_flag, mz_dept_no)
values (@patient_id, @max_times, @item_no, @ledger_sn, @happen_date, @charge_code, @audit_code, @bill_code, @exec_sn, @apply_sn,
@org_price, @charge_price, @charge_amount, @charge_group,@enter_opera, @enter_date, @enter_win_no,
@confirm_opera,@confirm_date, @confirm_win_no, @charge_status, @trans_flag, @mz_dept_no)
 