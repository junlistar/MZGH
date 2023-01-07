--221021 门诊收费 -  退费界面数据查询
 DECLARE @tflag CHAR(1)

	SET @tflag = dbo.GetTableFlag(@begin_date)

	IF @tflag='b'   --b表
	BEGIN
		SELECT
		   t.name patient_name,
		   a.patient_id,
		   n.times,
		   t.social_no,
		   t.p_bar_code,
			 a.receipt_no,
			   a.receipt_sn,
			   a.cash_opera,
			   a.cash_date,
			   a.charge_total,
			   a.ledger_sn,
			   a.charge_status status,
			   a.report_date,           
			   dbo.Get_mzCheque_code2(a.patient_id, a.ledger_sn, @tflag) cheque_type,
			   Get_mzCheque_name_20220922(a.patient_id, a.ledger_sn, @tflag) cheque_type_name,
			   m.[name] cash_name,
			   @tflag tableflag,
			   l.responce_group,
			   a.backfee_date
		FROM mz_receipt_b a 
			 INNER JOIN view_mz_allpatient t ON a.patient_id = t.patient_id
			 INNER JOIN a_employee_mi m ON a.cash_opera = m.emp_sn
			 INNER JOIN view_mz_detail_charge n ON a.patient_id = n.patient_id AND a.ledger_sn = n.ledger_sn
		     LEFT JOIN zd_responce_type l ON n.response_type = l.code 
		WHERE a.cash_opera LIKE @cash_opera AND
			  CONVERT(DATETIME, a.cash_date) BETWEEN @begin_date AND @end_date
			   and t.p_bar_code like @bar_code
			    and a.charge_status like @status
			  --AND a.ledger_sn > 0
			  -- AND dbo.Is_mzReceiptReturn(a.patient_id, a.ledger_sn, @tflag) = 0
		GROUP BY t.name, a.patient_id, n.times, t.social_no, t.p_bar_code, a.receipt_no, 
				a.receipt_sn, a.cash_opera, a.cash_date, a.charge_total, a.charge_status, 
				a.ledger_sn, a.charge_status, a.report_date, m.[name], l.responce_group,a.backfee_date
		ORDER BY receipt_no,charge_total desc   
	END ELSE
	BEGIN
		SELECT 
		   t.name patient_name,
		   a.patient_id,
		   n.times,
		   t.social_no,
		   t.p_bar_code,
			 a.receipt_no,
			   a.receipt_sn,
			   a.cash_opera,
			   a.cash_date,
			   a.charge_total,
			   a.ledger_sn,
			   a.charge_status status,
			   a.report_date,           
			   dbo.Get_mzCheque_code2(a.patient_id, a.ledger_sn, @tflag) cheque_type,
			   Get_mzCheque_name_20220922(a.patient_id, a.ledger_sn, @tflag) cheque_type_name,
			   m.[name] cash_name,
			   @tflag tableflag,
			   l.responce_group,
			   a.backfee_date
		FROM mz_receipt a 
			 INNER JOIN mz_patient_mi t ON a.patient_id = t.patient_id
			 INNER JOIN a_employee_mi m ON a.cash_opera = m.emp_sn
			 INNER JOIN mz_detail_charge n ON a.patient_id = n.patient_id AND a.ledger_sn = n.ledger_sn
		     LEFT JOIN zd_responce_type l ON n.response_type = l.code 
		WHERE a.cash_opera LIKE @cash_opera AND
	  		  CONVERT(DATETIME, a.cash_date) BETWEEN @begin_date AND @end_date
			   and t.p_bar_code like @bar_code
			    and a.charge_status like @status
	 			-- AND a.ledger_sn > 0  
				-- AND dbo.Is_mzReceiptReturn(a.patient_id, a.ledger_sn, @tflag) = 0
		GROUP BY t.name, a.patient_id, n.times, t.social_no, t.p_bar_code, a.receipt_no, 
				a.receipt_sn, a.cash_opera, a.cash_date, a.charge_total, a.charge_status, 
				a.ledger_sn, a.charge_status, a.report_date, m.[name], l.responce_group,a.backfee_date
	  ORDER BY receipt_no,charge_total desc 
	END