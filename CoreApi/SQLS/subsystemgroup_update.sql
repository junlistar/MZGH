 
-- ��ϵͳ �޸���ϵͳ 
update subsystem_group set group_name=@group_name,sort=@sort,update_time=getDate(),active_flag=@active_flag
where group_code=@group_code 