 
--220023¹ÒºÅ ¿ÆÊÒ×Öµä
select   zd_unit_code.code,
       zd_unit_code.name,
       zd_unit_code.py_code,
       zd_unit_code.d_code,
       zd_unit_code.unit_sn,
       zd_unit_code.yb_ks_code,
       zd_unit_code.yb_ks_name
from zd_unit_code
where zd_unit_code.deleted_flag = '0' 
order by code
 