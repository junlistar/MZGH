 
--220039�Һ� ��ȡ��Ʊ����Ϣ 
select top 100 * from gh_op_receipt 
where  operator=@operator
and deleted_flag='0' and report_flag='0'
 order by happen_date asc 