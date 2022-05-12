using Dapper;
using Data.Entities;
using Data.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Linq;

namespace Data.Repository
{
    public class GhRequestRepository : RepositoryBase<GhRequest>, IGhRequestRepository
    {

        GhDoctorOutRepository doctoutResponse = new GhDoctorOutRepository();
        BaseRequestRepository baseRequestRepository = new BaseRequestRepository();

        public List<GhRequest> GetGhRequest(string request_date, string ampm, string unit_sn = "%", string clinic_type = "%", string doctor_sn = "%", string group_sn = "%", string req_type = "01", string win_no = "%")
        {
            //            string selectSql = @"select   zd_unit_code.code,
            //       zd_unit_code.name,
            //       zd_unit_code.py_code,
            //       zd_unit_code.d_code,
            //       zd_unit_code.unit_sn
            //from zd_unit_code
            //where  
            //      zd_unit_code.deleted_flag = '0'
            //order by code";
            //            return  Select(selectSql);
            var para = new DynamicParameters();
            para.Add("@request_date", request_date);
            para.Add("@unit_sn", unit_sn);
            para.Add("@clinic_type", clinic_type);
            para.Add("@doctor_sn", doctor_sn);
            para.Add("@group_sn", group_sn);
            para.Add("@req_type", req_type);
            para.Add("@ampm", ampm);
            para.Add("@win_no", win_no);


            return ExecQuerySP("mzgh_GetGhRequestInfo", para);
        }


        public List<GhRequest> GetGhRecord(string record_sn)
        {
            string ghsql = @"select * from gh_request where record_sn = '" + record_sn + "'";
            return Select(ghsql);

        }



        public int CreateRequestRecord(string begin, string end, string weeks, int day, string op_id)
        {
            //准备数据
            string sql1 = @"select * from gh_request where request_date between @begin and @end";
            var para = new DynamicParameters();
            para.Add("@begin", begin);
            para.Add("@end", end);

            var requestlist = Select(sql1, para);


            var baselist = baseRequestRepository.GetBaseRequestsByWeekDay(begin, end, weeks, day);


            //var docoutList = doctoutResponse.GetGhDoctorOuts();
            //if (docoutList != null && docoutList.Count > 0)
            //{
            //    // 移除医生列表
            //    foreach (var item in docoutList)
            //    {
            //        var doc_id = item.doctor_id;

            //    }


            //}


            //先删除，再写入
            string deletesql = "delete from gh_request where request_date between @begin and @end";

            Update(deletesql, para);

            string insertsql = @"insert into gh_request
  (request_date, ampm, unit_sn, group_sn, doctor_sn, clinic_type, req_type, begin_no, current_no, end_no, enter_opera, enter_date, open_flag, window_no)
values
  (@request_date, @ampm, @unit_sn, @group_sn, @doctor_sn, @clinic_type, @req_type, @begin_no, @current_no, @end_no, @enter_opera, @enter_date, @open_flag, @window_no)";

            //生成日期只有一天
            if (day > 0 && (begin == end))
            {
                var request_date = Convert.ToDateTime(begin);
                var req_type = "01";//门诊号

                foreach (var item in baselist)
                {
                    para = new DynamicParameters();
                    para.Add("@request_date", request_date);
                    para.Add("@ampm", item.ampm);
                    para.Add("@unit_sn", item.unit_sn);
                    para.Add("@group_sn", item.group_sn);
                    para.Add("@doctor_sn", item.doctor_sn);
                    para.Add("@clinic_type", item.clinic_type);
                    para.Add("@req_type", req_type);
                    para.Add("@begin_no", 1);
                    para.Add("@current_no", 1);
                    para.Add("@end_no", item.totle_num);
                    para.Add("@enter_opera", op_id);
                    para.Add("@enter_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    para.Add("@open_flag", item.open_flag);
                    para.Add("@window_no", item.window_no);

                    Update(insertsql, para);
                }
            }
            else if (begin != end)
            {
                var request_date = Convert.ToDateTime(begin);
                var end_date = Convert.ToDateTime(end);
                var enter_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                var req_type = "01";//门诊号

                var week_arr = weeks.Split(',');//1,2,4,1

                int[] DayArray = new int[] { 7, 1, 2, 3, 4, 5, 6 };

                for (int i = 0; i < week_arr.Length; i++)
                {
                    //组装当日数据
                    var weeklist = baselist.Where(p => p.week.ToString() == week_arr[i]).OrderBy(p => p.week).OrderBy(p => p.day).ToList();
                    //foreach (var witem in weeklist)
                    //{
                    int _day = 1;  
                    if (i==0)
                    {
                        _day = DayArray[Convert.ToInt32(request_date.DayOfWeek.ToString("d"))];
                    }
                    else
                    {
                        _day= weeklist[0].day;
                    }
                   

                    do
                    {
                        var daylist = weeklist.Where(p => p.day == _day);

                        foreach (var item in daylist)
                        {
                            para = new DynamicParameters();
                            para.Add("@request_date", request_date);
                            para.Add("@ampm", item.ampm);
                            para.Add("@unit_sn", item.unit_sn);
                            para.Add("@group_sn", item.group_sn);
                            para.Add("@doctor_sn", item.doctor_sn);
                            para.Add("@clinic_type", item.clinic_type);
                            para.Add("@req_type", req_type);
                            para.Add("@begin_no", 1);
                            para.Add("@current_no", 1);
                            para.Add("@end_no", item.totle_num);
                            para.Add("@enter_opera", op_id);
                            para.Add("@enter_date", enter_date);
                            para.Add("@open_flag", item.open_flag);
                            para.Add("@window_no", item.window_no);

                            Update(insertsql, para);
                        }
                        _day++;
                        request_date = request_date.AddDays(1);
                        if (request_date > end_date)
                        {
                            break;
                        }
                    } while (_day <8);
                    // }
                }
            }


            return 1;
        }

    }
}
