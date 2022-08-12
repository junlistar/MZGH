--221009 门诊收费 - 更新门诊发票号
update mz_order_put set current_count=current_count+1 where order_code=@P1 and
 group_no=@P2 and window_no=@P3