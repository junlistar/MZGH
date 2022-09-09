--添加医保2203信息 
insert into ybNew_2203_diseinfo(patient_id,admiss_times,mdtrt_id,diag_type,diag_srt_no,diag_code,diag_name,diag_dept,dise_dor_no,dise_dor_name,diag_time,vali_flag)
values(@patient_id,@admiss_times,@mdtrt_id,@diag_type,@diag_srt_no,@diag_code,@diag_name,@diag_dept,@dise_dor_no,@dise_dor_name,@diag_time,@vali_flag)