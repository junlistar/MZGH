 
--220024¹ÒºÅ ÓÃ»§×Öµä
select   a_employee_mi.code, a_employee_mi.name,
zd_unit_code.name dept_name, 
  a_employee_mi.py_code, a_employee_mi.d_code,
a_employee_mi.emp_sn,
a_employee_mi.dept_sn ,yb_ys_code
FROM a_employee_mi  
    left join zd_unit_code on a_employee_mi.dept_sn = zd_unit_code.unit_sn
where -- a_employee_mi.code not in ('00000','99999') and
emp_sn not in (select emp_sn from rs_info_empdel)
and  isnull(a_employee_mi.deleted_flag,0) <> '1' 
order by a_employee_mi.py_code