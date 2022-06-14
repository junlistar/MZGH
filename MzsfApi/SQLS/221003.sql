--220001 门诊收费 - 调取病人处方明细存储过程
--mzsf_GetCprCharges


select charge_code+serial code into #yp_otc from yp_dict
where goods_where_code = 'OTC'
 
 SELECT a.*,    
        charge_code_lookup =        
             CASE WHEN c.serial ='**' THEN     
                       c.name +    
                       '(单价:'+    
                       CAST(c.amount1 AS VARCHAR(10)) + ')'    
             ELSE c.name + '(' + c.specification + ')'     
             END,      
        --b.stock_amount,    
        --b.stock_amount2,    
        --supply_code_lookup = d.supply_name,    
        --freq_code_lookup = '(' + RTRIM(a.freq_code) + ')',    
        exec_SN_lookup = f.name--,    
        --s.class_code supply_class      
   FROM mz_detail_charge a    
     --LEFT JOIN yp_base b ON a.charge_code = b.charge_code AND    
     --                       a.serial_no = b.serial AND a.group_no = b.group_no    
     LEFT JOIN view_mz_charge_all c ON a.charge_code = c.code AND    
                            a.serial_no = c.serial     
     --LEFT JOIN yz_supply d ON a.supply_code = d.supply_code    
     --LEFT JOIN yz_frequency e ON a.freq_code = e.code      
     LEFT JOIN zd_unit_code f ON a.exec_sn = f.unit_sn     
     --LEFT JOIN yz_supply s ON a.supply_code = s.supply_code     
     WHERE a.patient_id = @patient_id AND     
           a.times = @times AND    
           a.charge_status = @charge_status AND    
           ledger_sn = 0    
           --and a.group_no not in('000019','000020') /*不调用OCT药房项目 cx：2018-4-25*/ 
           and a.charge_code+a.serial_no not in (select code from #yp_otc) 
           --and not exists(select * from yp_base aa where a.charge_code=aa.charge_code and a.serial_no=aa.serial and aa.group_no='000019')  
     ORDER BY a.order_no, a.item_no 
     
     
     drop table #yp_otc  