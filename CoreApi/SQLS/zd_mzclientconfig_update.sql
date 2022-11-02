--更新客户端配置信息
 update mz_client_config set client_name=@client_name,client_version=@client_version,client_ghsearchkey_length=@client_ghsearchkey_length,
 mzgh_report_code=@mzgh_report_code,
 mzsf_report_code=@mzsf_report_code,
 ghrj_report_code=@ghrj_report_code,
 sfrj_report_code=@sfrj_report_code,
 update_time=getdate()
where sys_type=@sys_type