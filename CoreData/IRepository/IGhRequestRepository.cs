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

        bool Schb(string begin, string end, string op_id);

        bool SchbTemp(string request_sn, string op_id);


        int CreateRequestRecord(string begin, string end, string weeks, int day, string op_id);

        int EditRequest(string record_sn, string request_date, string unit_sn, string group_sn, string doctor_sn, string clinic_type, string request_type,
          string ampm, int totle_num, string window_no, string open_flag, string op_id,string limit_appoint_percent);

        int EditRequestTotalNum(string record_sn, int total_num);
        #endregion
    }
}
