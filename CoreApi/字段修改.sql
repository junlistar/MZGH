if not exists(select * from syscolumns where id=object_id('mz_patient_mi') and name='yb_psn_no') begin
ALTER TABLE mz_patient_mi ADD yb_psn_no  varchar(30) default (null)
end
if not exists(select * from syscolumns where id=object_id('mz_patient_mi') and name='yb_insutype') begin
ALTER TABLE mz_patient_mi ADD yb_insutype  varchar(10) default (null)
end
if not exists(select * from syscolumns where id=object_id('mz_patient_mi') and name='yb_insuplc_admdvs') begin
ALTER TABLE mz_patient_mi ADD yb_insuplc_admdvs  varchar(10) default (null)
end