 
--220035挂号 查询指定日期医生时间的挂号信息 
select * from gh_request where request_date=@request_date
                            and ampm=@ampm and doctor_sn=@doctor_sn
 