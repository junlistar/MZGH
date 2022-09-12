 --编辑医生停诊信息
 update [gh_doctor_leave] set [doctor_id]=@doctor_id,[begin_date]=@begin_date,[end_date]=@end_date,[is_delete]=@is_delete
 where  [sn]=@sn
