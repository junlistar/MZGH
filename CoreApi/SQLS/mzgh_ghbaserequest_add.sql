 
--220055 新增基础号表 
insert into gh_base_request(request_sn,[week],[day],ampm,unit_sn,group_sn,doctor_sn,
clinic_type,totle_num,op_id,op_date,open_flag,window_no,limit_appoint_percent)
values(@request_sn,@week,@day,@ampm,@unit_sn,@group_sn,@doctor_sn,
@clinic_type,@totle_num,@op_id,@op_date,@open_flag,@window_no,@limit_appoint_percent)
 