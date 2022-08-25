 --查询身份证表信息（废弃）
select *
    from mz_patient_sfz a
   left
    join mz_patient_sfz_info b on isnull(a.sfz_id,'') !='' and a.sfz_id = b.card_no
   where a.patient_id = @pid