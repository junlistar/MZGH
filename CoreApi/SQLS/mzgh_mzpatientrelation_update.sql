--更新患者监护人信息
update mz_patient_relation set relation_code=@relation_code,sfz_id=@sfz_id,username=@username,birth=@birth,sex=@sex,tel=@tel,opera=@opera,update_date=@update_date,[address]=@address 
  where patient_id=@patient_id