--221017 门诊收费 -  写入mz_receipt_charge
insert into mz_receipt_charge
  (patient_id, ledger_sn, receipt_sn, bill_code, charge, pay_unit)
values
  (@patient_id, @ledger_sn, @receipt_sn, @bill_code, @charge, @pay_unit)