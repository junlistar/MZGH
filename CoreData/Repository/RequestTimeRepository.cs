using Dapper;
using Data.Entities;
using Data.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repository
{
    public class RequestTimeRepository : RepositoryBase<RequestTime>, IRequestTimeRepository
    {

        public List<RequestTime> GetRequestTimes()
        {
            //string ghsql = GetSqlByTag(220064);
            string ghsql = @"select * from gh_zd_request_time ";

            return Select(ghsql);
        }

        public bool EditRequestTime(string section, string section_name, string start_time, string end_time,string ampm)
        {
            string sql = "";
            var all = GetRequestTimes();
            if (all.Where(p => p.Section_number == int.Parse(section)).Count() > 0)
            {
                //存在：更新操作
                sql = @"update gh_zd_request_time
set Section_number_comment =@Section_number_comment,start_time=@start_time,end_time=@end_time,ampm=@ampm
where Section_number=@Section_number";
            }
            else
            {
                //不存在：添加操作
                sql = @"insert into gh_zd_request_time(Section_number,Section_number_comment,start_time,end_time,ampm)
values(@Section_number,@Section_number_comment,@start_time,@end_time,@ampm)";

            }

            var param = new DynamicParameters();
            param.Add("@Section_number", section);
            param.Add("@Section_number_comment", section_name);
            param.Add("@start_time", start_time);
            param.Add("@end_time", end_time);
            param.Add("@ampm", ampm);

            return Update(sql, param) > 0;

        }
        public bool DeleteRequestTime(string section)
        {
            string sql = @"delete from gh_zd_request_time where Section_number=@Section_number";
  
            var param = new DynamicParameters();
            param.Add("@Section_number", section); 

            return Update(sql, param) > 0;

        }
    }
}
