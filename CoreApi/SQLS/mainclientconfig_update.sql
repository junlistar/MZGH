--更新主程序客户端配置
update MainClientConfig
set title=@title,show_image=@show_image,show_title=@show_title,show_desc=@show_desc,update_time=getdate()
where id= @id