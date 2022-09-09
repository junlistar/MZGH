using Data.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface IBaseRequestRepository : IRepositoryBase<BaseRequest> 
    {
        #region 扩展的dapper操作

        List<BaseRequest> GetBaseRequests(string unit_sn, string group_sn, string doctor_sn, string clinic_type,
           string week, string day, string ampm, string window_no, string open_flag,int temp_flag);


        int EditBaseRequest(string request_sn, string unit_sn, string group_sn, string doctor_sn, string clinic_type,
           string week, string day, string ampm, int totle_num, string woork_room, string open_flag, string op_id, int temp_flag,int limit_appoint_percent);
         
        int DeleteBaseRequest(string request_sn);

        List<BaseRequest> GetBaseRequestsBySN(string request_sn);

        List<BaseRequest> GetBaseRequestsByWeekDay(string begin, string end, string weeks, int day);

        List<BaseRequest> GetRequestsByDate(string begin, string end);

        List<BaseRequest> GetRequestsByParams(string begin, string end, string unit_sn, string group_sn, string doctor_sn, string clinic_type, string req_type,
             string ampm, string window_no, string open_flag);

        DataTable GetRequestsByParamsV2(string begin, string end, string unit_sn, string group_sn, string doctor_sn, string clinic_type, string req_type,
           string ampm, string window_no, string open_flag, string temp_flag);

        bool CreateRequestNoList(string begin, string end, int type);


        bool CheckGhRepeat(string patient_id, string record_sn);

        #endregion
    }
}
