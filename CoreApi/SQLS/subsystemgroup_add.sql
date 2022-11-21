 
-- 子系统分组 添加系统个分组 
insert into subsystem_group(group_code,group_name,sort,update_time,active_flag) 
values(@group_code,@group_name,@sort,getDate(),@active_flag)