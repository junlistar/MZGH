--添加挂号时段
 insert into gh_zd_request_hour(code,name,start_hour,end_hour)
values(@code,@name,@start_hour,@end_hour)