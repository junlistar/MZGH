 
--220048挂号  查询组合支付是否退款完毕
select sum(ledger_sn) from gh_deposit where patient_id=@patient_id and times=@times
 