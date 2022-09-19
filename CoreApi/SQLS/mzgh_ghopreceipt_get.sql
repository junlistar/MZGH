 
--220039挂号 获取发票号信息 
select top 100 * from gh_op_receipt 
where  operator=@operator
and deleted_flag='0' and report_flag='0'
 order by happen_date asc 