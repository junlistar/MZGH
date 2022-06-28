--221006 门诊收费 - 门诊机制发票号
UPDATE mz_order_generator 
      SET max_sn = ISNULL(max_sn, 0) + 1
    WHERE define = 'mz_receipt_sn'    
   SELECT max_sn 
     FROM mz_order_generator
    WHERE define = 'mz_receipt_sn'