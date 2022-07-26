select *
    from mz_patient_sfz a
   left
    join mz_patient_sfz_info b on a.sfz_id = b.card_no
   where a.patient_id = @pid