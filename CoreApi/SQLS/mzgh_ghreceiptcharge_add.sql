 
--220019�Һ� д��Һŷ�Ʊ��ϸ��
insert into gh_receipt_charge
  (patient_id, times, ledger_sn, receipt_sn, bill_code, charge, pay_unit)
values
  (@patient_id, @times, @ledger_sn, @receipt_sn, @bill_code, @charge, @pay_unit)
 