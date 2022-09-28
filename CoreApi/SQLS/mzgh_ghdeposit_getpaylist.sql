 --根据patient_id和日期查询用户的挂号流水信息
 SELECT
      DISTINCT
	 
      d.charge,
      d.ledger_sn,
      d.item_no,
      d.times,
      d.price_date,
      ISNULL(g.name, '') cheque_name,
      ISNULL(d.cheque_type, '') cheque_type,
      ISNULL(d.cheque_no, '') cheque_no,
      ISNULL(d.out_trade_no, '') out_trade_no,
      ISNULL(f.receipt_sn, '') receipt_sn,
      ISNULL(f.receipt_no, '') receipt_no,
      a.name as price_opera,
	  t.admiss_times,t.mdtrt_id,t.psn_no,t.setl_id,t.clr_optins
FROM  view_mz_visit_table v  
      --left join view_gh_deposit d on v.patient_id = d.patient_id AND v.times = d.times 
      left join gh_deposit d on v.patient_id = d.patient_id AND v.times = d.times 
      left join a_employee_mi a on d.price_opera = a.emp_sn  
      left join gh_receipt f on f.patient_id = d.patient_id AND f.times = d.times 
      left join zd_cheque_type g on g.code = d.cheque_type   
	  left join ybNew_2207_result t on d.cheque_no= t.mdtrt_id  and d.patient_id = t.patient_id
WHERE 
      DATEDIFF(dd, v.visit_date, @request_date) = 0  and
	    v.patient_id=@patient_id
	  and d.times=@times
order by ledger_sn desc,d.item_no