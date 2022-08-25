 --添加患者监护人信息
 insert into mz_patient_relation(patient_id,relation_code,sfz_id,username,birth,sex,tel,opera,update_date,[address])
 values (@patient_id,@relation_code,@sfz_id,@username,@birth,@sex,@tel,@opera,@update_date,@address)