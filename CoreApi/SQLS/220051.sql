 
--220051�Һ�  �˺ŷ�Ʊ��ϸ��д��Գ�����
insert into gh_receipt_charge (patient_id,times,ledger_sn,receipt_sn,bill_code,charge,pay_unit)
select patient_id,times,-ledger_sn,receipt_sn,bill_code,-charge,pay_unit
from gh_receipt_charge
where patient_id =@patient_id and ledger_sn=@ledger_sn
 