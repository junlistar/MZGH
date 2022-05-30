 
--220046挂号 判断退款数据是否已经退号
select * from gh_deposit where patient_id=@patient_id and times =@times and depo_status=@depo_status
