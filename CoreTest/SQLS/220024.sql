 
--220024¹ÒºÅ ÓÃ»§×Öµä
--select * from a_employee_mi where deleted_flag=0  order by emp_sn
SELECT a.code,
       a.name , 
       a.py_code, 
       a.d_code ,
       a.emp_sn,
       a.dept_sn,
       z.name dept_name
  FROM a_employee_mi a,zd_unit_code z
 WHERE 
       a.order_flag = '1' AND
       a.dept_sn = z.unit_sn AND
       a.code <> '00000'
       ORDER BY a.py_code