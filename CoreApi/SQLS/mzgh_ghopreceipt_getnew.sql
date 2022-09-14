 
--220039挂号 获取发票号信息
select top 1 * from gh_op_receipt where  operator=@operator order by happen_date desc 