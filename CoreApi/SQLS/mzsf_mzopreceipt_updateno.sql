--221008 门诊收费 - 更新门诊发票号
update mz_op_receipt  set
 current_no = @current_no
where
 operator = @operator and
 happen_date = @happen_date