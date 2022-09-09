--添加医保余额信息  
insert into ybNew_1101_insuinfo(patient_id,admiss_times,balc,insutype,psn_type,psn_insu_stas,psn_insu_date,paus_insu_date,cvlserv_flag,insuplc_admdvs,emp_name)
values(@patient_id,@admiss_times,@balc,@insutype,@psn_type,@psn_insu_stas,@psn_insu_date,@paus_insu_date,@cvlserv_flag,@insuplc_admdvs,@emp_name)