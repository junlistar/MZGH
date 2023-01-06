 select a.*,
       b.sys_name func_desc 
from xt_user_group a
join subsystem b on b.sys_code = a.func_name
--              and b.subsys_id = a.subsys_id
where a.subsys_id =@subsys_id
  and a.user_group = @user_group and a.sys_type='2.0'