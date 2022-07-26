 update gh_op_receipt  set
                                         report_flag = @P1
                                        where
                                         operator = @P2 and
                                         happen_date = @P3 and
                                         start_no = @P4 and
                                         current_no = @P5 and
                                         end_no = @P6 and
                                         step_length = @P7 and
                                         deleted_flag = @P8 and
                                         report_flag = @P9 and
                                         receipt_type is null