 

--220040�Һ� ��ȡҽ��ͣ����Ϣ
select d.* ,a.name doctor_name
from gh_doctor_leave d
left join a_employee_mi a on d.doctor_id = a.code 