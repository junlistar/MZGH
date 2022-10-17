--220001 挂号-登录
 SELECT xt_user.user_name,
                  xt_user.subsys_id,   
                  xt_user.user_group,
                  xt_user.user_mi, 
                  a_employee_mi.dept_sn,
                   a_employee_mi.[name]
             FROM xt_user left join 
                  a_employee_mi  on xt_user.user_mi = a_employee_mi.emp_sn 
            WHERE   xt_user.subsys_id = 'mz'  AND  
                   xt_user.user_mi = @user_mi  
                     