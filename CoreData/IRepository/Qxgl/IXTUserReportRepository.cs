using Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface IXTUserReportRepository : IRepositoryBase<XTUserReport> 
    {
        #region 扩展的dapper操作


        List<XTUserReport> GetXTUserReportsBySysId(string subsys_id, string user_group);
         

        #endregion
    }
}
