--220001 挂号-登录
 SELECT xt_user.user_name,
                  xt_user.subsys_id,   
                  xt_user.user_group,
                  xt_user.user_mi, 
                  a_employee_mi.dept_sn,
                   a_employee_mi.[name]
             FROM xt_user,   
                  a_employee_mi  
            WHERE ( xt_user.user_mi = a_employee_mi.emp_sn ) and  
                  ( ( xt_user.subsys_id = 'mzgh' ) AND  
                  ( xt_user.user_name = @uname )  And
                    xt_user.pass_word =@pwd ) 