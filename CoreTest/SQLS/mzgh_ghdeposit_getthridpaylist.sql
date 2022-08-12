 select b.name patient_name,c.name cheque_name,a.*,d.cheque_no his_no,e.[name] opera_name from mz_thirdpay a 
	left join mz_patient_mi b on  a.patient_id = b.patient_id
	left join zd_cheque_type c on a.cheque_type= c.code
	left join (
	 select cheque_type,cheque_no from view_gh_deposit
   where price_date between @bengin_date and @end_date and cheque_type<>'1'
   union all 
    select cheque_type,cheque_no from view_mz_deposit
  where dcount_date between @bengin_date and @end_date) d
  on a.cheque_type=d.cheque_type and a.cheque_no=d.cheque_no
  left join a_employee_mi e on a.opera= e.code
	 where a.price_date between @bengin_date and @end_date  
	 and isnull(d.cheque_no,'-1') like @his_status
	 and a.patient_id like @patient_id
	 order by a.price_date