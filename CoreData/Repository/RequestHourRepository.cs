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
            string ghsql = GetSqlByTag("mzgh_requesthoure_get");

            return Select(ghsql);
        }

        public bool EditRequestHour(string code, string name, string start_hour, string end_hour)
        {
            string sql = "";
            var all = GetRequestHours();
            if (all.Where(p => p.code == code).Count() > 0)
            {
                //存在：更新操作
                sql = GetSqlByTag("mzgh_requesthour_update");
            }
            else
            {
                //不存在：添加操作
                sql = GetSqlByTag("mzgh_requesthoure_add");

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
            string sql = GetSqlByTag("mzgh_requesthour_del");

            var param = new DynamicParameters();
            param.Add("@code", code); 

            return Update(sql, param) > 0;

        }
    }
}
