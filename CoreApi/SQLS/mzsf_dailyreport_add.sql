 --添加挂号日结记录a_daily_report
 insert into a_daily_report
                          (report_sn, report_date, opera_id, subsys_id, dept_no)
                        values
                          (@P1, @P2, @P3, @P4, @P5)