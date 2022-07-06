using Dapper;
using Data.Entities;
using Data.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class XTUserReportRepository : RepositoryBase<XTUserReport>, IXTUserReportRepository
    {
   
        public List<XTUserReport> GetXTUserReportsByGroupId(string subsys_id,string user_group)
        {
            string ghsql = @"select * from xt_user_report where user_group=@user_group and subsys_id=@subsys_id";
            var para = new DynamicParameters();

            para.Add("@user_group", user_group);
            para.Add("@subsys_id", subsys_id);
            return  Select(ghsql,para); 

        }
        public List<XTUserReport> GetXTUserReports(string subsys_id)
        {
            string ghsql = @"select * from rt_report_subsys where subsys_id =@subsys_id";
            var para = new DynamicParameters();

            para.Add("@subsys_id", subsys_id);
            return Select(ghsql, para);

        }
    }
}
