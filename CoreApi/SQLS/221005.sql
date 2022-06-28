--221005 门诊收费 - 获取病人最大的ledger_sn，防止5个表中的ledger_sn不一致  
SELECT ISNULL(MAX(ledger_sn), 1) ledger_sn  
     FROM  
     (  
   SELECT ledger_sn    
     FROM view_gh_deposit WITH(NOLOCK)  
    WHERE patient_id =  @patient_id   
     
   UNION ALL  
     
   SELECT ledger_sn    
     FROM view_mz_deposit WITH(NOLOCK)  
    WHERE patient_id =  @patient_id   
     
   UNION ALL  
     
   SELECT max_ledger_sn ledger_sn  
     FROM mz_patient_mi  WITH(NOLOCK) 
    WHERE patient_id =  @patient_id  
  ) aa  