 
--220062 ±à¼­»ù´¡ºÅ±í 
update gh_base_request
set [week]=@week,[day]=@day,ampm=@ampm,unit_sn=@unit_sn,group_sn=@group_sn,doctor_sn=@doctor_sn,
clinic_type=@clinic_type,totle_num=@totle_num,op_id=@op_id,op_date=@op_date,open_flag=@open_flag,workroom=@workroom,limit_appoint_percent=@limit_appoint_percent 
where request_sn = @request_sn


 
