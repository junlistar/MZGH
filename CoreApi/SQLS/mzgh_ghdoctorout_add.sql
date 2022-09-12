 --添加医生停诊信息
insert into [gh_doctor_leave]([sn],[doctor_id],[begin_date],[end_date],[is_delete])
values(@sn, @doctor_id, @begin_date, @end_date, @is_delete)