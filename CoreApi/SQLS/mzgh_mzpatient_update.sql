 
--220008挂号 修改用户信息弹窗
update mz_patient_mi
set social_no=@social_no,hic_no=@hic_no,p_bar_code=@p_bar_code,name=@name,sex=@sex,birthday=@birthday,home_tel=@tel,
home_district=@home_district,home_street=@home_street,occupation_type=@occupation_type,response_type=@response_type,charge_type=@charge_type,marry_code=@marry_code,relation_code=@relation_code,relation_name=@relation_name,update_date=@update_date,update_opera=@update_opera 
where patient_id=@patient_id
 