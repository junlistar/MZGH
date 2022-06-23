--221016 门诊收费 -  查询mz_receipt_charge
select patient_id,times,order_type,bill_code,exec_sn,sum(charge_amount* charge_price) charge from 
 mz_detail_charge 
 WHERE patient_id = @patient_id
 AND       times =@times and order_no in(@order_no_str)
 and charge_amount>0
 group by patient_id,times,exec_sn,order_type,bill_code