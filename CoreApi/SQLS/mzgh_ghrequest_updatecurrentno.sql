 
--220013挂号 更新指定挂号信息的当前号记录
UPDATE gh_request SET current_no =current_no+1 WHERE record_sn = @record_sn

 