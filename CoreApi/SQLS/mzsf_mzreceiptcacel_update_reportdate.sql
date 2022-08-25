 --更新门诊退费发票记录
 update mz_receipt_cancel  set
                                         report_date = @P1
                                        where
                                         operator = @P2 and
                                         report_date is null and
                                         subsys_id = @P3 and
                                         mz_dept_no = @P4