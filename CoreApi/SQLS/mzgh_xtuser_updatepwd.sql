 --修改登录密码
update xt_user set xt_user.pass_word =@pwd
where xt_user.subsys_id = 'mz' and xt_user.user_name = @uname