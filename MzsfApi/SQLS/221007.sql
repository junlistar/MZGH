--221007 门诊收费 - 门诊发票号
SELECT top 1 *
    FROM mz_op_receipt  
   WHERE ( mz_op_receipt.operator = @operator ) AND
         (mz_op_receipt.receipt_type=@receipt_type ) and
         ( mz_op_receipt.deleted_flag = '0' ) AND  
         ( mz_op_receipt.current_no <= mz_op_receipt.end_no )