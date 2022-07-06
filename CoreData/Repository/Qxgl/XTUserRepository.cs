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
            string ghsql = @"select a.*,b.name from xt_user a
join a_employee_mi b on a.user_mi = b.code
where subsys_id = @subsys_id
  and user_group = @user_group";
            var para = new DynamicParameters();

            para.Add("@subsys_id", subsys_id);
            para.Add("@user_group", user_group);
            return  Select(ghsql,para); 

        } 

        public int AddXtUser(string user_name, string subsys_id, string pass_word, string user_group, string user_mi)
        {
            string sql = @"insert into xt_user
  (user_name, subsys_id, pass_word, user_group, create_pw_date, user_mi, outlookbar2, outlookbar)
values
  (@user_name, @subsys_id, @pass_word, @user_group, @create_pw_date, @user_mi,NULL,NULL  )";

           var para = new DynamicParameters();
            if (string.IsNullOrEmpty(pass_word))
            {
                pass_word = ""; 
            }
            para.Add("@user_name", user_name);
            para.Add("@subsys_id", subsys_id);
            para.Add("@pass_word", pass_word);
            para.Add("@user_group", user_group);
            para.Add("@create_pw_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            para.Add("@user_mi", user_mi); 

            return Update(sql, para);

        }

        public int DeleteXtUser(string user_name, string subsys_id, string user_group)
        {
            string sql = @"delete from  xt_user where user_name=@user_name and subsys_id=@subsys_id and user_group=@user_group";

            var para = new DynamicParameters();

            para.Add("@user_name", user_name);
            para.Add("@subsys_id", subsys_id); 
            para.Add("@user_group", user_group); 

            return Update(sql, para);

        }
    }
}
