 
-- 子系统 修改子系统 
update subsystem set sys_name=@sys_name,sys_no=@sys_no,sys_desc=@sys_desc,file_path=@file_path,file_type=@file_type,icon_path=@icon_path,
open_mode=@open_mode,active_flag=@active_flag,update_time=getDate(),sys_update_url=@sys_update_url,sys_relative_path=@sys_relative_path,sys_group_code=@sys_group_code,
subsys_id=@subsys_id,group_no=@group_no
where sys_code=@sys_code 