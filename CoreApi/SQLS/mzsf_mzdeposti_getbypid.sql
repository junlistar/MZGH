--221020 门诊收费 -  查询用户支付记录
--SELECT CAST(0 AS FLOAT) amount, m.*, z.name cheque_name, z.cheque_flag,t.mdtrt_id,t.psn_no,t.setl_id   FROM view_mz_deposit m     
--INNER JOIN zd_cheque_type z ON m.cheque_type = z.code     
--left join mz_thirdpay t on m.cheque_no = t.cheque_no and m.patient_id = t.patient_id
--WHERE m.patient_id =@patient_id  AND m.ledger_sn = @ledger_sn 

SELECT CAST(0 AS FLOAT) amount, m.*, z.name cheque_name, z.cheque_flag,t.mdtrt_id,t.psn_no,t.setl_id,t.admiss_times,t.clr_optins
FROM view_mz_deposit m     
INNER JOIN zd_cheque_type z ON m.cheque_type = z.code     
left join ybNew_2207_result t on m.cheque_no= t.mdtrt_id  and m.patient_id = t.patient_id
WHERE m.patient_id =@patient_id  AND m.ledger_sn = @ledger_sn 