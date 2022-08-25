 
--220056   新增基础号区间表 
insert into gh_base_request_segment(request_sn,req_type,begin_no,end_no)
values(@request_sn,@req_type,@begin_no,@end_no)
 