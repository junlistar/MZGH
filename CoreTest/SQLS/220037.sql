 
--220037¹ÒºÅ ÐÞ¸Ä¹ÒºÅÐÅÏ¢
update gh_request set request_date=@request_date,ampm=@ampm,unit_sn=@unit_sn,group_sn=@group_sn,doctor_sn=@doctor_sn,clinic_type=@clinic_type,
req_type=@req_type,end_no=@end_no, enter_opera=@enter_opera, enter_date=@enter_date, open_flag=@open_flag, window_no=@window_no
where record_sn=@record_sn
