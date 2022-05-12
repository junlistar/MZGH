using Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface IGhRequestRepository : IRepositoryBase<GhRequest> 
    {
        #region 扩展的dapper操作

        List<GhRequest> GetGhRequest(string request_date, string ampm, string unit_sn = "%", string clinic_type = "%", string doctor_sn = "%", string group_sn = "%", string req_type = "01", string win_no = "%");

        List<GhRequest> GetGhRecord(string record_sn);


        int CreateRequestRecord(string begin, string end, string weeks, int day, string op_id);
        #endregion
    }
}
