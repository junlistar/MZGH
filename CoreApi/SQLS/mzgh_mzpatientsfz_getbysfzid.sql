 select mz_patient_sfz.*,mz_patient_sfz_info.*,mz_patient_ybk_info.*,mz_patient_relation.relation_code from mz_patient_sfz
left join mz_patient_sfz_info on mz_patient_sfz.sfz_id= mz_patient_sfz_info.card_no
left join mz_patient_ybk_info on mz_patient_sfz.sfz_id= mz_patient_ybk_info.certno
left join mz_patient_relation on mz_patient_sfz.sfz_id=mz_patient_relation.sfz_id and mz_patient_sfz.patient_id = mz_patient_relation.patient_id
 where mz_patient_sfz.sfz_id=@sfz_id