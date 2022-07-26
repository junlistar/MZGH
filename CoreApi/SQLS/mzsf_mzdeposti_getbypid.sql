--221020 门诊收费 -  查询用户支付记录
SELECT CAST(0 AS FLOAT) amount, m.*, z.name cheque_name, z.cheque_flag   FROM view_mz_deposit m     
INNER JOIN zd_cheque_type z ON m.cheque_type = z.code     
WHERE patient_id =@patient_id  AND ledger_sn = @ledger_sn 