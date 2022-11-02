using Dapper;
using Data.Entities;
using Data.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class XTUserRepository : RepositoryBase<XTUser>, IXTUserRepository
    {
   
        public List<XTUser> GetXTUsersBySysId(string subsys_id,string user_group)
        {
            string ghsql = GetSqlByTag("xt_user_get");
            var para = new DynamicParameters();

            para.Add("@subsys_id", subsys_id);
            para.Add("@user_group", user_group); 
            return  Select(ghsql,para); 

        } 

        public int AddXtUser(string user_name, string subsys_id, string pass_word, string user_group, string user_mi)
        {
            string sql = GetSqlByTag("xt_user_add");

            var para = new DynamicParameters();
            if (string.IsNullOrEmpty(pass_word))
            {
                pass_word = ""; 
            }
            para.Add("@user_name", user_name);
            para.Add("@subsys_id", subsys_id);
            para.Add("@pass_word", pass_word);
            para.Add("@user_group", user_group);
            para.Add("@create_pw_date", GetServerDateTime().ToString("yyyy-MM-dd HH:mm:ss"));
            para.Add("@user_mi", user_mi); 

            return Update(sql, para);

        }

        public int DeleteXtUser(string user_name, string subsys_id, string user_group)
        {
            string sql = GetSqlByTag("xt_user_del");

            var para = new DynamicParameters();

            para.Add("@user_name", user_name);
            para.Add("@subsys_id", subsys_id); 
            para.Add("@user_group", user_group); 

            return Update(sql, para);

        }
    }
}
