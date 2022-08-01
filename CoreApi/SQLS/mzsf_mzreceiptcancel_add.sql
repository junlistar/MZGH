 INSERT INTO mz_receipt_cancel
         ( operator,   
           happen_date,   
           report_date,   
           receipt_sn,
           receipt_no,   
           subsys_id,
           mz_dept_no )  
  VALUES ( @operator,
            cast( convert(char(19),getdate(),121) as datetime) ,   
           null,
           @receipt_sn,
           @receipt_no,   
           @subsys_id,
           @mz_dept_no)