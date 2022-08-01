 SELECT code,  
        case when  serial ='**' then  name  else  name end name,
        specification,
        orig_price, 
        manufactory,
        serial, 
        dosage, 
        bill_item_code, 
        audit_code, 
        exec_unit, 
        charge_group, 
        self_flag, 
        separate_flag, 
        suprice_flag, 
        drug_flag, 
        mz_confirm_flag, 
        amount1, 
        amount2, 
        amount3, 
        amount4, 
        amount5, 
        item_flag ,
        group_no,
        group_name
  FROM view_mz_huajia_zhenliao
 WHERE    
        code =@code AND  
       code <> '000085'
ORDER BY len(py_code) ,d_code, name,amount1