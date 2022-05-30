 
--220010挂号 修改用户信息页面
update mz_patient_mi
set social_no=@social_no,hic_no=@hic_no,p_bar_code=@p_bar_code,name=@name,sex=@sex,birthday=@birthday,home_tel=@tel,
home_district=@home_district,home_street=@home_street,occupation_type=@occupation_type,response_type=@response_type,charge_type=@charge_type,
update_date=@update_date,update_opera=@update_opera,relation_name=@relation_name,marry_code=@marry_code,addition_no1=@addition_no1,employer_name=@employer_name
where patient_id=@patient_id 
 