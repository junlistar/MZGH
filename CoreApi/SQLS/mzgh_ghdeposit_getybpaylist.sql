 select b.name patient_name,c.name cheque_name,a.patient_id,a.ledger_sn,a.charge,a.cheque_no,a.cheque_type,a.depo_status,a.price_opera,a.price_date,a.mz_dept_no 
 from view_gh_deposit  a
 left join mz_patient_mi b on  a.patient_id = b.patient_id
 left join zd_cheque_type c on a.cheque_type= c.code
 where price_date between @bengin_date and @end_date and a.cheque_type=6
  union all 
  select b.name patient_name,c.name cheque_name,a.patient_id,a.ledger_sn,a.charge,a.cheque_no,a.cheque_type,a.depo_status,a.dcount_id,a.dcount_date,a.mz_dept_no
   from view_mz_deposit a
  left join mz_patient_mi b on  a.patient_id = b.patient_id
 left join zd_cheque_type c on a.cheque_type= c.code
  where dcount_date between @bengin_date and @end_date and a.cheque_type=6
   order by patient_id, cheque_no asc,ledger_sn desc