 
-- ��ϵͳ �����ϵͳ 
insert into subsystem(sys_code,sys_name,sys_no,sys_desc,file_path,file_type,icon_path,open_mode,active_flag,update_time,sys_update_url,sys_relative_path) 
values(@sys_code,@sys_name,@sys_no,@sys_desc,@file_path,@file_type,@icon_path,@open_mode,@active_flag,getDate(),@sys_update_url,@sys_relative_path)