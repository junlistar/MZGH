 
--更新WEB报表
update mz_webreport
set name = @name, url = @url, open_flag = @open_flag, update_opera = @update_opera, update_time = GETDATE()
where code =@code 
 