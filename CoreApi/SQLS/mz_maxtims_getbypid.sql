 
--根据patient_id获取最大到访次数
 declare @times int
 
 select 
    @times = MAX(times) 
 from
	 (
	 select times from view_mz_visit_table with(nolock) where patient_id = @patient_id
 	 ) aa
  
  if @times is null
    set @times = 1
  else   
    set @times = @times + 1 
  --update mz_patient_mi set max_times = @times where patient_id = ‘’
  --update mz_patient_mi_b set max_times = @times where patient_id = @patient_id
  select @times times 
 