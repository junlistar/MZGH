--添加医保身份信息 
insert into ybNew_1101_idetinfo(patient_id,admiss_times,psn_idet_type,psn_type_lv,memo,begntime,endtime)
values(@patient_id,@admiss_times,@psn_idet_type,@psn_type_lv,@memo,@begntime,@endtime)