 

--220040�Һ� ��ȡҽ��ͣ����Ϣ
select d.* ,a.name doctor_name
from gh_doctor_leave d
left join a_employee_mi a on d.doctor_id = a.code
where d.doctor_id like @doctor_id and @begin_date>=d.begin_date  and @begin_date <= d.end_date 
and is_delete=0
order by d.end_date desc