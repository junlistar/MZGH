 --添加挂号日结发票记录
 insert into a_daily_report_receipt
                                                          (report_sn, begin_no, end_no, flag)
                                                        values
                                                          (@P1, @P2, @P3, @P4)