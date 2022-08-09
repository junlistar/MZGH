 update mz_thirdpay
set refund_date=@refund_date
where patient_id=@patient_id and cheque_type=@cheque_type 
and cheque_no=@cheque_no and charge=@charge --and price_date=@price_date