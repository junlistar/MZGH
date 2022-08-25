--日结，更新gh_deposit表的report_date
update gh_deposit  set
report_date = @P1
where
price_opera = @P2
and mz_dept_no like @P3 and
report_date is null