--221002 门诊收费 - 获取病人处方存储过程
--mzsf_GetOrders

SELECT
   		  ma.order_type,
		  ma.order_no,
		  --ischarged = dbo.isCharged_MZ(@patient_id, @times, ma.order_type, ma.order_no), 
          --isbacked = dbo.isFeeBacked_MZ(@patient_id, @times, ma.order_type, ma.order_no), 		  
  	      skin_test = dbo.isHaveSkinTest_MZ(@patient_id, @times, ma.order_type, ma.order_no), 		   
		  ISNULL(b.name, '') order_typename,
		  b.drug_cure,
		  b.bill_code,
		  b.group_no,
		  b.poision_flag,
		  ma.caoyao_fu,
		  ma.order_properties,
		  ISNULL(c.name, '') order_propertiesname
		  --pattern_code = dbo.GetJcJyApplyNos(@patient_id, @times, ma.order_type, ma.order_no)
		  --jcjymark = dbo.GetJcJyMark(@patient_id, @times, ma.order_type, ma.order_no)
     FROM		   
  	      (SELECT DISTINCT 
		  	      a.order_type,
				  a.order_no,
				  caoyao_fu = (SELECT TOP 1 caoyao_fu FROM mz_detail_charge ma1
				                   WHERE ma1.patient_id = @patient_id AND ma1.times = @times AND
				                         ma1.order_no = a.order_no AND ma1.order_type = a.order_type),
				  order_properties = (SELECT TOP 1 order_properties FROM mz_detail_charge ma1
				                          WHERE ma1.patient_id = @patient_id AND ma1.times = @times AND
				                                ma1.order_no = a.order_no AND ma1.order_type = a.order_type)
		   	 FROM mz_detail_charge a
	        WHERE a.patient_id = @patient_id AND a.times = @times) ma
	       LEFT JOIN mz_zd_order_type b ON ma.order_type = b.code
	       LEFT JOIN mz_order_properties c ON ma.order_properties = c.code  
	 ORDER BY ma.order_no 