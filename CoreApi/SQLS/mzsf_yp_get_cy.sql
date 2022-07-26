--221025 门诊收费 -  查询处方项目 - 草药

SELECT top 30 code,  
        case when  serial ='**' then  name  else  name end name,
        py_code ,
        d_code ,
        specification ,
        cast(orig_price as decimal(38,6)) , 
        stock_amount stock_amount2,     
        manufactory ,
        serial ,
        dosage ,
        bill_item_code , 
        audit_code ,
        exec_unit ,
        charge_group , 
        self_flag ,
        separate_flag , 
        suprice_flag , 
        drug_flag , 
        mz_confirm_flag , 
        amount1, 
        amount2, 
        amount3, 
        amount4, 
        amount5, 
        item_flag  ,
        group_no ,
        group_name 
    FROM view_mz_huajia_caoyao
   WHERE py_code like '%' + @py_code AND  
          d_code like '%'+@d_code  AND  
          code like @code  AND  
          name like @name  AND
         (bill_item_code like @bill_item_code OR                    
bill_item_code <> 'aa') AND
         (group_no  like @group_no OR group_no = '%') 
ORDER BY len(name)
 
  