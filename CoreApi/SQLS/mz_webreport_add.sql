 
--����WEB����
insert into mz_webreport(code,name,url,open_flag,create_opera,create_time)
values(@code, @name, @url, @open_flag, @create_opera, GETDATE())
 