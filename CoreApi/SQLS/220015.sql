 
--220015¹ÒºÅ ¸üÐÂ·¢Æ±ºÅ
UPDATE mz_order_generator  
     SET max_sn = max_sn + 1
   WHERE(mz_order_generator.define = 'gh_receipt_sn')
SELECT mz_order_generator.max_sn
   FROM mz_order_generator
   WHERE(mz_order_generator.define = 'gh_receipt_sn')
 