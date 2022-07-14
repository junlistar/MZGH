 update gh_detail_charge  set
                                         report_date = @P1
                                        where
                                         confirm_opera = @P2 and
                                         report_date is null and
                                         charge_status in ('4', '7') and
                                         mz_dept_no = @P3