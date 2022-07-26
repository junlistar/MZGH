 
--220042挂号 根据挂号信息获取收费项目
select b.*,c.name,c.charge_price,c.charge_price,c.effective_price,c.audit_code,c.mz_bill_item,mz_charge_group from gh_zd_clinic_type a 
left join gh_zd_clinic_charge b on a.code = b.code
left join zd_charge_item c on b.charge_code = c.code
left join mz_bill_item d on d.code=c.mz_bill_item
where a.code=(select clinic_type from gh_request where record_sn=@record_sn)