 --根据日期区间查询可以挂号的科目信息
 select * from gh_request where request_date between @begin and @end and delete_flag is null order by enter_date desc