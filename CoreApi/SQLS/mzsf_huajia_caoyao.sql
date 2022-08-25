--门诊收费划价，查询草药信息
SELECT code,  
        name=case when  serial ='**' then  name  else  name end,
        py_code,
        d_code,
        specification,
        cast(orig_price as decimal(38,6)) orig_price, 
        stock_amount ,     
        manufactory ,
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
        group_no ,
        group_name 
    FROM view_mz_huajia_caoyao
   WHERE code=@code  AND  
         (bill_item_code like '002' OR                    
bill_item_code <> 'aa') AND
         (group_no  like '000004' OR group_no = '%') 
ORDER BY len(name)