--221019 门诊挂号 -  获取可以打印的记录
SELECT  
		   a.patient_id, a.times,
			 a.receipt_no,
			   a.receipt_sn,
			   a.settle_opera,
			   a.price_date,
			   a.charge_total,
			   a.ledger_sn,
			   a.charge_status status,
			   a.report_date,            
			   m.[name] cash_name
		FROM  gh_receipt a 
			 INNER JOIN mz_patient_mi t ON a.patient_id = t.patient_id
			 INNER JOIN a_employee_mi m ON a.settle_opera = m.emp_sn  
		WHERE    a.patient_id =@patient_id 
	 			AND a.ledger_sn > 0   
		GROUP BY t.name, a.patient_id, a.times, t.social_no, t.p_bar_code, a.receipt_no, 
				a.receipt_sn, a.settle_opera, a.price_date, a.charge_total, a.charge_status, 
				a.ledger_sn, a.charge_status, a.report_date, m.[name] 
	  ORDER BY times desc  
 