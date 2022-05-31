 
--220052挂号  退号收费明细表写入对冲数据
insert into gh_detail_charge (patient_id,times,item_no,ledger_sn,happen_date,charge_code,audit_code,bill_code,exec_sn,apply_sn,org_price,charge_price,charge_amount,
charge_group,enter_opera,enter_date,enter_win_no,confirm_opera,confirm_date,confirm_win_no,charge_status,trans_flag,fit_type,report_date,mz_dept_no)
select patient_id,times,item_no,-ledger_sn,happen_date,charge_code,audit_code,bill_code,exec_sn,apply_sn,org_price,charge_price,-charge_amount,
charge_group,@enter_opera,enter_date,enter_win_no,@confirm_opera,confirm_date,confirm_win_no,7,trans_flag,fit_type,report_date,mz_dept_no
from gh_detail_charge
where patient_id =@patient_id and ledger_sn=@ledger_sn

 