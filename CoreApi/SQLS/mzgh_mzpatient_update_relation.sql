 update mz_patient_mi 
 set name=@name,home_tel=@home_tel,sex=@sex,marry_code=@marry_code,birthday=@birthday,
 relation_name=@relation_name,relation_code=@relation_code,home_street=@home_street,home_district=@home_district,response_type=@response_type,charge_type=@charge_type,update_opera=@update_opera,update_date=getdate()
 where patient_id=@patient_id