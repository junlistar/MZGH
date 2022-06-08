using Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface IRequestHourRepository : IRepositoryBase<RequestHour> 
    {
        #region 扩展的dapper操作
         
        List<RequestHour> GetRequestHours();
         
        #endregion
    }
}
