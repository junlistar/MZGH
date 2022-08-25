--添加门诊收费项目明细
INSERT INTO mz_detail_charge 
( charge_price, patient_id, times, order_type, order_no, item_no, ledger_sn, charge_code, serial_no, group_no, 
charge_status, bill_code, audit_code, exec_sn, charge_amount, orig_price, charge_group, caoyao_fu, back_amount,
happen_date, enter_date, enter_opera, windows_no,confirm_flag,trans_flag, dosage, persist_days, dosage_unit, fit_type, poision_flag, 
charge_no, mz_dept_no, apply_unit, doctor_code, name, parent_no, order_properties, skin_test_flag, change_drug_code, order_sn) 
Values ( @charge_price, @patient_id, @times, @order_type, @order_no, @item_no, @ledger_sn, @charge_code, @serial_no, @group_no, 
@charge_status, @bill_code, @audit_code, @exec_sn, @charge_amount, @orig_price, @charge_group, @caoyao_fu, @back_amount,
@happen_date, @enter_date, @enter_opera, @windows_no,@confirm_flag,@trans_flag, @dosage, @persist_days, @dosage_unit, @fit_type, @poision_flag, 
@charge_no, @mz_dept_no, @apply_unit, @doctor_code, @name, @parent_no, @order_properties, @skin_test_flag, @change_drug_code, @order_sn)