 select a.*,b.name from xt_user a
join a_employee_mi b on a.user_mi = b.code
where subsys_id = @subsys_id
  and user_group = @user_group and sys_type='2.0'