--更新客户端配置信息
 update mz_client_config set client_name=@client_name,client_version=@client_version,client_ghsearchkey_length=@client_ghsearchkey_length,update_time=getdate()
where sys_type=@sys_type