 
--220036挂号 新增挂号信息
insert into gh_request
  (request_date, ampm, unit_sn, group_sn, doctor_sn, clinic_type, req_type, begin_no, current_no, end_no, enter_opera, enter_date, open_flag, window_no)
values
  (@request_date, @ampm, @unit_sn, @group_sn, @doctor_sn, @clinic_type, @req_type, @begin_no, @current_no, @end_no, @enter_opera, @enter_date, @open_flag, @window_no) 