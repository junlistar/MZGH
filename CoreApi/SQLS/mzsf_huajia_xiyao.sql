--门诊收费划价，查询西信息
SELECT code,  
        name=case when  serial ='**' then  name
  else  
name +'('+specification+')' +' '+isnull(abname,'') 
end,
        py_code,
        d_code,
        cast(orig_price as decimal(38,6)) orig_price,
        stock_amount,
        specification, 
        manufactory,
        serial, 
        dosage, 
        bill_item_code, 
        audit_code, 
        exec_unit , 
        charge_group, 
        self_flag,
        separate_flag, 
        suprice_flag , 
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
    FROM view_mz_huajia_xiyao
   WHERE code=@code AND  serial=@serial and
         (bill_item_code like '001' OR
          bill_item_code like '003') AND
          group_no  like '000003'
ORDER BY d_code,py_code, name,serial DESC