﻿--221022 门诊收费 -  收费详情（草药）
UPDATE mz_detail_charge SET ledger_sn = @current_ledger_sn, group_no = @group_no, charge_status = '4', price_data = @price_data,
price_opera = @price_opera, windows_no = @windows_no, confirm_win = @confirm_win, infant_flag = '0', ope_flag = '0', emergency_flag = '0',
response_type = @response_type, charge_type = @charge_type, sum_total =@sum_total
WHERE patient_id = @patient_id AND times = @times AND order_type = @order_type AND order_no = @order_no AND item_no =@item_no AND ledger_sn = @ledger_sn
 