--查询指定操作员的发票时间段信息
 select * from gh_op_receipt
where operator = @P1 and
report_flag = '0'
order by happen_date