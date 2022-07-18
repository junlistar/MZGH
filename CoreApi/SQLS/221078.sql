 select * from mz_patient_sfz
left join mz_patient_sfz_info on mz_patient_sfz.sfz_id= mz_patient_sfz_info.card_no
left join mz_patient_ybk_info on mz_patient_sfz.sfz_id= mz_patient_ybk_info.certno
 where sfz_id=@sfz_id