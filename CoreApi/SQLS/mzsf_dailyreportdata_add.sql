﻿--添加挂号日结记录a_daily_report_data
 insert into a_daily_report_data
                          (report_sn, code, in_amount, out_amount)
                        values
                          (@P1, @P2, @P3, @P4)