using Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface IXTUserReportRepository : IRepositoryBase<XTUserReport>
    {
        #region 扩展的dapper操作


        List<XTUserReport> GetXTUserReportsByGroupId(string subsys_id, string user_group);

        List<XTUserReport> GetXTUserReports(string subsys_id);
        bool AddXtUserReports(string rep_id, string subsys_id, string user_group);
        bool DelXtUserReports(string rep_id, string subsys_id, string user_group);

        #endregion
    }
}
