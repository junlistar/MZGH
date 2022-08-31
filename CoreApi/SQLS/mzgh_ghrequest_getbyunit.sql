 
--220034挂号 根据科室，上下午，号别查询挂号信息(医生为空)
select * from gh_request where request_date=@request_date
                            and unit_sn=@unit_sn and ampm=@ampm and clinic_type=@clinic_type and delete_flag is null
 