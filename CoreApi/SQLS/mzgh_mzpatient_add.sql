 
--220009挂号 新增用户信息弹窗保存
insert into mz_patient_mi(patient_id,social_no,hic_no,p_bar_code,name,sex,birthday,home_tel,addition_no1,employer_name,marry_code,
balance,max_times,max_ledger_sn,max_item_sn,max_receipt_sn,
home_district,home_street,occupation_type,response_type,charge_type,relation_code,relation_name,enter_date,update_date,enter_opera,update_opera) values
(@patient_id,@social_no,@hic_no,@p_bar_code,@name,@sex,@birthday,@home_tel,@addition_no1,@employer_name,@marry_code,'0',0,0,0,0,
@home_district,@home_street,@occupation_type,@response_type,@charge_type,@relation_code,@relation_name,@enter_date,@update_date,@enter_opera,@update_opera)
 