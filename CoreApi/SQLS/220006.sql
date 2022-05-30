 
--220006挂号 清除现有身份证数据
 UPDATE mz_patient_mi SET hic_no='' WHERE hic_no=@hic_no 
 