 
--220021�Һ� ���¹Һŷ�Ʊ��¼��
update gh_op_receipt  set
                                 current_no = @new_no 
                                 where
                                 operator = @operator and
                                 happen_date = @happen_date and
                                 start_no = @start_no and
                                 current_no = @current_no and
                                 end_no = @end_no and
                                 step_length =@step_length 
 
 