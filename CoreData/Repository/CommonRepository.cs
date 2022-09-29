using Dapper;
using Data.Entities;
using Data.IRepository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Data.Repository
{
    public class CommonRepository : RepositoryBase<BaseModel>, ICommonRepository
    {
        public List<PageChequeCompare> GetPageChequeCompares()
        {
            using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
            {
                //IDbTransaction transaction = connection.BeginTransaction();

                string sql = GetSqlByTag("zd_pagechequecompare_get");

                return connection.Query<PageChequeCompare>(sql).AsList();

            }
        }
        public List<YbName> GetYbName()
        {
            using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
            {
                //IDbTransaction transaction = connection.BeginTransaction();

                string sql = GetSqlByTag("zd_ybname_get");

                return connection.Query<YbName>(sql).AsList();

            }
        }

        public List<Ybhzzd> GetYbhzzdList()
        {
            using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
            {
                string sql = GetSqlByTag("zd_ybhz_zd_ypitem_dy");

                return connection.Query<Ybhzzd>(sql).AsList();

            }
        }

        public MzClientConfig GetMzClientConfig()
        {
            using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
            {
                string sql = GetSqlByTag("zd_mzclientconfig_get");

                return connection.Query<MzClientConfig>(sql).FirstOrDefault();
            }
        }
        public FpConfig GetFPConfig()
        {
            using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
            {
                string sql = GetSqlByTag("zd_fpconfig_get");

                return connection.Query<FpConfig>(sql).FirstOrDefault();
            }
        }

        public bool UpdateMzClientConfig(string jsonStr)
        {
            MzClientConfig clientConfig = JsonConvert.DeserializeObject<MzClientConfig>(jsonStr);
            using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
            {
                string sql = GetSqlByTag("zd_mzclientconfig_update");

                var para = new DynamicParameters();
                para.Add("@client_name", clientConfig.client_name);
                para.Add("@client_version", clientConfig.client_version);
                para.Add("@client_ghsearchkey_length", clientConfig.client_ghsearchkey_length);
                para.Add("@sys_type", clientConfig.sys_type);

                return connection.Execute(sql, para) > 0;
            }
        }
        public bool AddYbLog(string jsonStr)
        {
            YbLog _yblog = JsonConvert.DeserializeObject<YbLog>(jsonStr);
            using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
            {
                string sql = GetSqlByTag("mzsf_yblog_add");

                var para = new DynamicParameters();
                para.Add("@oper_date", _yblog.oper_date);
                para.Add("@oper_code", _yblog.oper_code);
                para.Add("@data", _yblog.data);
                para.Add("@patient_id", _yblog.patient_id);
                para.Add("@admiss_times", _yblog.admiss_times);
                para.Add("@flag", _yblog.flag);
                para.Add("@msgid", _yblog.msgid);
                para.Add("@ver", _yblog.ver);
                para.Add("@opera", _yblog.opera);

                return connection.Execute(sql, para) > 0;
            }
        }
        public SysConfig GetSysConfig(string item_name)
        {
            using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
            {
                //string sql = GetSqlByTag("zd_fpconfig_get");
                string sql = @"select * from sys_config where item_name = @item_name";
                var para = new DynamicParameters();
                para.Add("@item_name", item_name);
                return connection.Query<SysConfig>(sql, para).FirstOrDefault();
            }
        }

        public bool UpdateSysConfig(string jsonStr)
        {
            SysConfig sysConfig = JsonConvert.DeserializeObject<SysConfig>(jsonStr);
            using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
            {

                string sql = @"update sys_config set current_value=@current_value,comment=@comment,current_settings=@current_settings
where item_name=@item_name and subsys_id='mz'";
                var para = new DynamicParameters();
                para.Add("@item_name", sysConfig.item_name);
                para.Add("@current_value", sysConfig.current_value);
                para.Add("@comment", sysConfig.comment);
                para.Add("@current_settings", sysConfig.current_settings);
                return connection.Execute(sql, para) > 0;
            }
        }
        public List<string> GetColumnNames(string obj_name)
        {
            using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
            {
                //string sql = GetSqlByTag("zd_fpconfig_get");
                string sql = @"Select name from syscolumns Where ID=OBJECT_ID(@obj_name)";
                var para = new DynamicParameters();
                para.Add("@obj_name", obj_name);
                return connection.Query<string>(sql, para).ToList();
            }
        }
    }


}
