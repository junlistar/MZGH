 select isnull(max(user_group),0) user_group from xt_group
where subsys_id = @subsys_id and sys_type=@sys_type