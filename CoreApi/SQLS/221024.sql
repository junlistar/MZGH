--221024 门诊收费 -  查询处方项目 - 西药

 
SELECT top 50 code,  
        case when  serial ='**' then  name
  else  
name +'('+specification+')' +' '+isnull(abname,'') 
end name,
        py_code,
        d_code,
        --specification 规格,
        cast(orig_price as decimal(38,6)) orig_price,
        stock_amount,
        stock_amount2,
        specification, 
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
    FROM (SELECT DISTINCT 
      dbo.yp_dict.charge_code AS code, RTRIM(dbo.yp_dict.drugname) AS name, 
      (select top 1 drugname from  yp_drugname ab where ab.drug_id=yp_drugname.drug_id and flag ='0'  order by drugname desc ) as abname,      
      RTRIM(dbo.yp_dict.specification) AS specification, dbo.yp_dict.dosage, 
      dbo.yp_drugname.py_code, yp_drugname.d_code, 
      dbo.yp_dict.mz_bill_item AS bill_item_code, dbo.yp_dict.audit_code, 
      dbo.yp_dict.retprice AS orig_price, dbo.yp_dict.mz_charge_group AS charge_group, 
      dbo.yp_group_name.dept_sn AS exec_unit, dbo.yp_dict.retprice AS amount1, 
      dbo.yp_dict.retprice AS amount2, dbo.yp_dict.retprice AS amount3, 
      dbo.yp_dict.retprice AS amount4, dbo.yp_dict.retprice AS amount5, 
      dbo.yp_base.self_flag, dbo.yp_base.separate_flag, dbo.yp_base.suprice_flag, 
      dbo.yp_base.drug_flag, dbo.yp_dict.serial, dbo.yp_base.group_no, 
      '1' AS mz_confirm_flag, '0' AS item_flag, 
      dbo.yp_group_name.dept_name AS manufactory, RTRIM(dbo.yp_base.stock_amount) 
      AS stock_amount,RTRIM(dbo.yp_base.stock_amount2) 
      AS stock_amount2,
      dbo.zd_charge_group.name as group_name
FROM  dbo.yp_drugname INNER JOIN 
      dbo.yp_dict ON dbo.yp_drugname.drug_id  = dbo.yp_dict.drug_id INNER JOIN  
      dbo.yp_base ON dbo.yp_dict.charge_code = dbo.yp_base.charge_code  and
      dbo.yp_dict.serial = dbo.yp_base.serial INNER JOIN
      dbo.yp_group_name ON 
      dbo.yp_base.group_no = dbo.yp_group_name.group_no INNER JOIN
      dbo.zd_charge_group ON 
      dbo.yp_dict.mz_charge_group = dbo.zd_charge_group.code
WHERE (dbo.yp_base.stock_amount > 0)  AND 
      (dbo.yp_dict.deleted_flag = '0')  AND (dbo.yp_group_name.group_no = '000003' OR
      dbo.yp_group_name.group_no = '000005' OR
      dbo.yp_group_name.group_no = '000006' OR
      dbo.yp_group_name.group_no = '000008' or
      dbo.yp_group_name.group_no = '000014' 
) and RTRIM(dbo.yp_base.stock_amount2)>0) view_mz_huajia_xiyao
   WHERE py_code like @py_code AND 
         d_code like @d_code AND 
          code like @code AND  
          [name] like @name AND
         (bill_item_code like @bill_item_code OR
          bill_item_code like '003') AND
          group_no  like  @group_no
ORDER BY d_code,py_code, name,serial DESC
 