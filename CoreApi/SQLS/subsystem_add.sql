 
-- 子系统 添加子系统 
insert into subsystem(sys_code,sys_name,sys_no,sys_desc,file_path,file_type,icon_path,open_mode,active_flag,update_time) 
values(@sys_code,@sys_name,@sys_no,@sys_desc,@file_path,@file_type,@icon_path,@open_mode,@active_flag,getDate())