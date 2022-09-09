 
--增加医保基础信息 
 insert into ybNew_1101_baseinfo(patient_id,admiss_times,psn_no,psn_cert_type,certno,psn_name,gend,naty,brdy,age,flag,mzzy,insuplc_admdvs)
values(@patient_id,@admiss_times,@psn_no,@psn_cert_type,@certno,@psn_name,@gend,@naty,@brdy,@age,null,null,null)
 
 