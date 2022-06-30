using Dapper;
using Data.Entities;
using Data.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repository
{
    public class RequestHourRepository : RepositoryBase<RequestHour>, IRequestHourRepository
    {

        public List<RequestHour> GetRequestHours()
        {
            string ghsql = GetSqlByTag(220064);

            return Select(ghsql);
        }

        public bool EditRequestHour(string code, string name, string start_hour, string end_hour)
        {
            string sql = "";
            var all = GetRequestHours();
            if (all.Where(p => p.code == code).Count() > 0)
            {
                //存在：更新操作
                sql = @"update gh_zd_request_hour
set name = @name, start_hour = @start_hour, end_hour = @end_hour
where code = @code";
            }
            else
            {
                //不存在：添加操作
                sql = @"insert into gh_zd_request_hour(code,name,start_hour,end_hour)
values(@code,@name,@start_hour,@end_hour)";

            }

            var param = new DynamicParameters();
            param.Add("@code", code);
            param.Add("@name", name);
            param.Add("@start_hour", start_hour);
            param.Add("@end_hour", end_hour);

            return Update(sql, param) > 0;

        }
        public bool DeleteRequestHour(string code)
        {
            string sql =   @"delete from gh_zd_request_hour where code = @code";
  
            var param = new DynamicParameters();
            param.Add("@code", code); 

            return Update(sql, param) > 0;

        }
    }
}
