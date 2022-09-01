 
--医保支付  操作日志
insert into ybNew_log(oper_date,oper_code,[data],patient_id,admiss_times,flag,msgid,ver,opera)
		values(@oper_date,@oper_code,@data,@patient_id,@admiss_times,@flag,@msgid,@ver,@opera)
 