using Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface IRequestTimeRepository : IRepositoryBase<RequestTime> 
    {
        #region 扩展的dapper操作
         
        List<RequestTime> GetRequestTimes();

        bool EditRequestTime(string section, string section_name, string start_time, string end_time, string ampm);

        bool DeleteRequestTime(string section);

        #endregion
    }
}
