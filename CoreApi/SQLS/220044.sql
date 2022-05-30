 
--220044挂号 筛选条件查询流水
select gh_deposit.* from gh_deposit
where patient_id =@patient_id and times=@times and depo_status=@status and item_no=@item_no
 