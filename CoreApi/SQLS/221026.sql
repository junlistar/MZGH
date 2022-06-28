--221026 门诊收费 -  查询处方项目 - 诊疗
 
SELECT top 50 code ,  
        name=case when  serial ='**' then  name  else  name end,
        py_code ,
        d_code ,
        specification ,
        orig_price , 
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
  FROM view_mz_huajia_zhenliao
 WHERE py_code like @py_code AND  
        d_code like @d_code AND  
        code like @code AND  
        name like @name AND
       (bill_item_code like @bill_item_code OR
        bill_item_code like '%') AND
        group_no = @group_no  AND 
       code <> '000085' 

ORDER BY len(py_code) ,d_code, name,amount1

 