 
--220043 根据患者id获取挂号流水
select gh_deposit.*,zd_cheque_type.name tname,zd_deposit_status.name sname from gh_deposit 
left join zd_cheque_type on gh_deposit.cheque_type = zd_cheque_type.code
left join zd_deposit_status on gh_deposit.depo_status = zd_deposit_status.code
where patient_id =@patient_id order by price_date desc
 