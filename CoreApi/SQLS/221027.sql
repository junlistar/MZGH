 select distinct
       report_date 
from view_GhDailyReport_op
where (price_opera like @price_opera) and
      (report_date is null or
      convert(char(10), report_date, 121) = @report_date) and
      (mz_dept_no like @mz_dept_no)
order by report_date