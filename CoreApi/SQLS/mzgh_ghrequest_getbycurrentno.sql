 
--220012挂号 查询当前号是否超过数量
select * from gh_request where record_sn = @record_sn and current_no<= end_no
 