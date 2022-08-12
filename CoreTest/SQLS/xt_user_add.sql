 insert into xt_user
  (user_name, subsys_id, pass_word, user_group, create_pw_date, user_mi, outlookbar2, outlookbar,sys_type)
values
  (@user_name, @subsys_id, @pass_word, @user_group, @create_pw_date, @user_mi,NULL,NULL,'2.0'  )