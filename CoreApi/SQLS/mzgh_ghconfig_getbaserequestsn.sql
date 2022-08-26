 
--220054 挂号基础表最新序号 
update gh_config set base_request_sn=base_request_sn+1 --where op_receipt_table='gh_op_receipt';
select base_request_sn from gh_config --where op_receipt_table='gh_op_receipt'
 