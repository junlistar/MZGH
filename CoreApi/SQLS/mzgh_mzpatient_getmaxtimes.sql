 
--220014�Һ� ���������û�����������ɷѴ�����Ϣ������ѯ
update mz_patient_mi set max_times = max_times+1,max_ledger_sn =max_ledger_sn+1 where  patient_id=@patient_id;select max_ledger_sn,max_times from mz_patient_mi where  patient_id=@patient_id
 