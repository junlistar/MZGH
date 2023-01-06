--获取用户子系统
select a.*,b.sys_code,b.sys_name,b.group_no,c.group_code,c.group_name from xt_user_group a 
	inner join subsystem b on a. func_name = b.sys_code
	left join subsystem_group c on b.sys_group_code = c.group_code
	where a.subsys_id = @subsys_id and a.user_group = @user_group and a.sys_type=@sys_type
	order by c.sort