 --220004 挂号 根据p_bar_code查询用户
select * from mz_patient_mi a where a.p_bar_code=@barcode 