 
--220035挂号 查询挂号信息（含医生）
select * from gh_request where request_date=@request_date
                            and ampm=@ampm and doctor_sn=@doctor_sn
 