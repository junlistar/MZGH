 
--220007挂号 更新用户医保信息
UPDATE mz_patient_mi SET social_no=@social_no,yb_psn_no=@yb_psn_no,yb_insutype=@yb_insutype,yb_insuplc_admdvs=@yb_insuplc_admdvs WHERE patient_id=@pid
 