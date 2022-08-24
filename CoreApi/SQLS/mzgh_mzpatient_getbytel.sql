 
-- 挂号 根据电话号名查询用户
select distinct a.patient_id, a.max_times times, a.[name], a.sex, a.birthday, cast(DateDiff(YY,a.birthday, GetDate()) as float) age, a.response_type, a.contract_code, a.occupation_type, a.charge_type, '07' haoming_code, '2969317' code, inpatient_no, getdate() visit_date, 
a.social_no, '07' real_haoming_code, a.home_district, a.home_street, a.relation_tel, a.hic_no, a.addition_no1, a.home_tel, a.relation_name, a.relation_code, a.max_times real_times, a.p_bar_code, a.p_bar_code2, a.black_flag, a.address, a.poverty_code, a.employer_name, a.employer_street, employer_district,
a.employer_tel, a.allergic_diag, a.marry_code, a.max_times, a.max_ledger_sn, a.max_receipt_sn, a.max_item_sn, a.enter_opera, a.enter_date, a.update_opera, a.update_date,a.yb_psn_no,a.yb_insuplc_admdvs,a.yb_insutype from 
 mz_patient_mi a 
 where a.home_tel=@home_tel order by patient_id desc
 