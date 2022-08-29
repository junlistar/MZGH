 
--根据patient_id获取最大缴费次数

 declare @ledger_sn int
 
 select 
    @ledger_sn = MAX(ledger_sn ) 
 from
	 (
	 select ledger_sn  from view_gh_deposit with(nolock) where patient_id = @patient_id
	 union all
	 select ledger_sn  from view_mz_deposit with(nolock) where patient_id = @patient_id
	 ) aa
	  
	  
  if @ledger_sn is null
    set @ledger_sn = 1
  else
    set @ledger_sn = @ledger_sn + 1 
   
  select @ledger_sn ledger_sn
 
 