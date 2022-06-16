--221015 门诊收费 -  收费详情（西药）
UPDATE mz_detail_charge SET ledger_sn = @ledger_sn, charge_status = '4', price_data = @price_data,
price_opera = @price_opera, windows_no = @windows_no, confirm_win = @confirm_win, response_type = @response_type, charge_type = @charge_type, 
sum_total =@sum_total
WHERE patient_id = @patient_id AND times = @times AND order_type = @order_type AND order_no = @order_no AND item_no =@item_no AND ledger_sn = @ledger_sn