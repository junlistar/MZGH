 select a.*,
       b.func_desc,b.sys_type
from xt_user_group a
join xt_func b on b.func_name = a.func_name
               and b.subsys_id = a.subsys_id
where a.subsys_id = @subsys_id
  and a.user_group = @user_group and a.sys_type='2.0'