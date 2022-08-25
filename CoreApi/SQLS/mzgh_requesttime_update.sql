 --更新挂号分时
 update gh_zd_request_time
set Section_number_comment =@Section_number_comment,start_time=@start_time,end_time=@end_time,ampm=@ampm
where Section_number=@Section_number