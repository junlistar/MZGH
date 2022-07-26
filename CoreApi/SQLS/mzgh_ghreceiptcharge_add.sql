 
--220019¹ÒºÅ Ð´Èë¹ÒºÅ·¢Æ±Ã÷Ï¸±í
insert into gh_receipt_charge
  (patient_id, times, ledger_sn, receipt_sn, bill_code, charge, pay_unit)
values
  (@patient_id, @times, @ledger_sn, @receipt_sn, @bill_code, @charge, @pay_unit)
 