 
--220011�Һ� �����û���Ϣҳ��
insert into mz_patient_mi(patient_id,social_no,hic_no,p_bar_code,name,sex,birthday,home_tel,
balance,max_times,max_ledger_sn,max_item_sn,max_receipt_sn,
home_district,home_street,occupation_type,response_type,charge_type,enter_date,update_date,enter_opera,update_opera,
relation_name,marry_code,addition_no1,employer_name) values
(@patient_id,@social_no,@hic_no,@p_bar_code,@name,@sex,@birthday,@home_tel,'0',0,0,0,0,
@home_district,@home_street,@occupation_type,@response_type,@charge_type,@enter_date,@update_date,@enter_opera,@update_opera,
@relation_name,@marry_code,@addition_no1,@employer_name)
 