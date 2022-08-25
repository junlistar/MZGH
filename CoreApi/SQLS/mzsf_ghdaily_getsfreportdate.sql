 --查询日结日期记录
 select report_date from a_daily_report
where opera_id=@opera and datediff(dd,report_date,@rdate)=0 and subsys_id=@subsys
order by report_date desc