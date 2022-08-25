 --查询指定操作人和日期的挂号收费信息
 select charge from gh_deposit where report_date=@report_date and price_opera=@price_opera