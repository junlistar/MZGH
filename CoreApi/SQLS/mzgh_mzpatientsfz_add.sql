 --添加新用户之后，增加用户Id和身份证关联表信息（废弃）
 insert into mz_patient_sfz(patient_id,sfz_id) values (@patient_id,@sfz_id)