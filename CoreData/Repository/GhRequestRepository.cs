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
            string ghsql = GetSqlByTag(220033);
            var para = new DynamicParameters();
            para.Add("@record_sn", record_sn);
            return Select(ghsql, para);

        }

        public bool IsExistRecord(BaseRequest item)
        {
            string sql = "";
            var para = new DynamicParameters();
            //准备数据
            if (string.IsNullOrWhiteSpace(item.doctor_sn))
            {
                //如果医生为空，则日期，科室，专科，上下午，号类 唯一条件
                sql = GetSqlByTag(220034);
            }
            else
            {
                //医生不为空，则日期，上下午，医生 唯一条件
                sql = GetSqlByTag(220035);
            }
            para.Add("@request_date", item.request_date);
            para.Add("@ampm", item.ampm);
            para.Add("@unit_sn", item.unit_sn);
            if (string.IsNullOrWhiteSpace(item.group_sn))
            {
                sql += " and group_sn is null";

            }
            else
            {
                sql += " and group_sn = @group_sn";

                para.Add("@group_sn", item.group_sn);
            }

            para.Add("@doctor_sn", item.doctor_sn);
            para.Add("@clinic_type", item.clinic_type);


            var requestlist = Select(sql, para);

            if (requestlist != null && requestlist.Count > 0)
            {
                return true;
            }

            return false;
        }

        public bool Schb(string begin, string end, string op_id)
        {
            var baselist = baseRequestRepository.GetBaseRequestsByDate(begin, end);
            try
            {

                using (IDbConnection connection = DataBaseConfig.GetSqlConnection("write"))
                {
                    IDbTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        var para = new DynamicParameters();

                        string insertsql = GetSqlByTag(220036);

                        var request_date = Convert.ToDateTime(begin);
                        var end_date = Convert.ToDateTime(end);
                        var enter_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        var req_type = "01";//门诊号

                        string weeks = "1";
                        var week_arr = weeks.Split(',');//1,2,4,1

                        int[] DayArray = new int[] { 7, 1, 2, 3, 4, 5, 6 };

                        //for (int i = 0; i < week_arr.Length; i++)
                        //{
                        //    //组装当日数据
                        //    var weeklist = baselist.Where(p => p.week.ToString() == week_arr[i]).OrderBy(p => p.week).OrderBy(p => p.day).ToList();

                        //    int _day = 1;
                        //    if (i == 0)
                        //    {
                        //        _day = DayArray[Convert.ToInt32(request_date.DayOfWeek.ToString("d"))];
                        //    }
                        //    else
                        //    {
                        //        _day = weeklist[0].day;
                        //    }


                        //    do
                        //    {
                        //        var daylist = weeklist.Where(p => p.day == _day);

                        //        foreach (var item in daylist)
                        //        {
                        //            item.request_date = request_date;
                        //            if (IsExistRecord(item, connection, transaction))
                        //            {
                        //                continue;
                        //            }
                        //            para = new DynamicParameters();
                        //            para.Add("@request_date", request_date);
                        //            para.Add("@ampm", item.ampm);
                        //            para.Add("@unit_sn", item.unit_sn);
                        //            para.Add("@group_sn", item.group_sn);
                        //            para.Add("@doctor_sn", item.doctor_sn);
                        //            para.Add("@clinic_type", item.clinic_type);
                        //            para.Add("@req_type", req_type);
                        //            para.Add("@begin_no", 1);
                        //            para.Add("@current_no", 1);
                        //            para.Add("@end_no", item.totle_num);
                        //            para.Add("@enter_opera", op_id);
                        //            para.Add("@enter_date", enter_date);
                        //            para.Add("@open_flag", item.open_flag);
                        //            para.Add("@window_no", item.window_no);
                        //            para.Add("@temp_flag", item.temp_flag);
                        //            para.Add("@limit_appoint_percent", item.limit_appoint_percent);

                        //            connection.Execute(insertsql, para, transaction);
                        //        }
                        //        _day++;
                        //        request_date = request_date.AddDays(1);
                        //        if (request_date > end_date)
                        //        {
                        //            break;
                        //        }
                        //    } while (_day < 8);

                        //}
                        ///////////////////////////////////////////

                        var current_list = new List<GhRequest>();

                        //组装当期数据
                        for (int i = 0; i < week_arr.Length; i++)
                        {
                            var weeklist = baselist.Where(p => p.week.ToString() == week_arr[i]).OrderBy(p => p.week).OrderBy(p => p.day).ToList();

                            int _day = 1;
                            if (i == 0)
                            {
                                _day = DayArray[Convert.ToInt32(request_date.DayOfWeek.ToString("d"))];
                            }
                            else
                            {
                                _day = weeklist[0].day;
                            }


                            do
                            {
                                var daylist = weeklist.Where(p => p.day == _day);

                                foreach (var item in daylist)
                                {
                                    item.request_date = request_date;
                                    GhRequest ghRequest = new GhRequest();
                                    ghRequest.ampm = item.ampm;
                                    ghRequest.ap = item.ampm;
                                    ghRequest.begin_no = item.begin_no;
                                    ghRequest.clinic_type = item.clinic_type;
                                    ghRequest.current_no = item.current_no;
                                    ghRequest.doctor_sn = item.doctor_sn;
                                    ghRequest.end_no = item.totle_num;
                                    ghRequest.enter_date = enter_date;
                                    ghRequest.enter_opera = op_id;
                                    ghRequest.group_sn = item.group_sn;
                                    ghRequest.limit_appoint_percent = item.limit_appoint_percent;
                                    ghRequest.open_flag = item.open_flag;
                                    ghRequest.request_date = item.request_date;
                                    ghRequest.record_sn = item.record_sn;
                                    ghRequest.req_type = item.req_type;
                                    ghRequest.temp_flag = item.temp_flag;
                                    ghRequest.unit_sn = item.unit_sn;
                                    ghRequest.window_no = item.window_no.ToString(); 

                                    current_list.Add(ghRequest);
                                }
                                _day++;
                                request_date = request_date.AddDays(1);
                                if (request_date > end_date)
                                {
                                    break;
                                }
                            } while (_day < 8);
                        }

                        //查询现有数据
                        string sql = @"select * from gh_request where request_date between @begin and @end order by enter_date desc";
                        para = new DynamicParameters();
                        para.Add("@begin", begin);
                        para.Add("@end", end);

                        var list_request = connection.Query<GhRequest>(sql, para, transaction);

                        //排除冲突（已经生成）数据
                        foreach (var item in current_list.ToArray())
                        {
                            if (string.IsNullOrEmpty(item.doctor_sn))
                            {
                                if (list_request.Where(p=>p.request_date == item.request_date && p.unit_sn==item.unit_sn&& p.clinic_type==item.clinic_type&& p.ampm == item.ampm).Count()>0)
                                {
                                    current_list.Remove(item);
                                }
                            }
                            else
                            {
                                if (list_request.Where(p => p.request_date == item.request_date && p.doctor_sn == item.doctor_sn && p.ampm == item.ampm).Count() > 0)
                                {
                                    current_list.Remove(item);
                                }
                            }
                        }

                        //写入数据
                        foreach (var item in current_list)
                        {
                            para = new DynamicParameters();
                            para.Add("@request_date", item.request_date);
                            para.Add("@ampm", item.ampm);
                            para.Add("@unit_sn", item.unit_sn);
                            para.Add("@group_sn", item.group_sn);
                            para.Add("@doctor_sn", item.doctor_sn);
                            para.Add("@clinic_type", item.clinic_type);
                            para.Add("@req_type", req_type);
                            para.Add("@begin_no", 1);
                            para.Add("@current_no", 1);
                            para.Add("@end_no", item.end_no);
                            para.Add("@enter_opera", op_id);
                            para.Add("@enter_date", enter_date);
                            para.Add("@open_flag", item.open_flag);
                            para.Add("@window_no", item.window_no);
                            para.Add("@temp_flag", item.temp_flag);
                            para.Add("@limit_appoint_percent", item.limit_appoint_percent);

                            connection.Execute(insertsql, para, transaction);
                        }

                        transaction.Commit();

                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool SchbTemp(string request_sn, string op_id)
        {
            var baselist = baseRequestRepository.GetBaseRequestsBySN(request_sn);
            try
            {

                using (IDbConnection connection = DataBaseConfig.GetSqlConnection("write"))
                {
                    IDbTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        var para = new DynamicParameters();

                        string insertsql = GetSqlByTag(220036);

                        var request_date = DateTime.Now.ToShortDateString();
                        var enter_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        var req_type = "01";//门诊号

                        string weeks = "1";
                        foreach (var item in baselist)
                        {
                            item.request_date = Convert.ToDateTime(request_date);
                            if (IsExistRecord(item, connection, transaction))
                            {
                                continue;
                            }
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
                            para.Add("@temp_flag", item.temp_flag);
                            para.Add("@limit_appoint_percent", item.limit_appoint_percent);

                            connection.Execute(insertsql, para, transaction);

                        }

                        transaction.Commit();

                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool IsExistRecord(BaseRequest item, IDbConnection connection, IDbTransaction transaction)
        {
            string sql = "";
            var para = new DynamicParameters();
            //准备数据
            if (string.IsNullOrWhiteSpace(item.doctor_sn))
            {
                //如果医生为空，则日期，科室，专科，上下午，号类 唯一条件
                sql = GetSqlByTag(220034);
            }
            else
            {
                //医生不为空，则日期，上下午，医生 唯一条件
                sql = GetSqlByTag(220035);
            }
            para.Add("@request_date", item.request_date);
            para.Add("@ampm", item.ampm);
            para.Add("@unit_sn", item.unit_sn);
            if (string.IsNullOrWhiteSpace(item.group_sn))
            {
                sql += " and group_sn is null";

            }
            else
            {
                sql += " and group_sn = @group_sn";

                para.Add("@group_sn", item.group_sn);
            }

            para.Add("@doctor_sn", item.doctor_sn);
            para.Add("@clinic_type", item.clinic_type);


            var requestlist = connection.Query<GhRequest>(sql, para, transaction).ToList();

            if (requestlist != null && requestlist.Count > 0)
            {
                return true;
            }

            return false;
        }


        public int CreateRequestRecord(string begin, string end, string weeks, int day, string op_id)
        {
            ////准备数据
            //string sql1 = @"select * from gh_request where request_date between @begin and @end";
            var para = new DynamicParameters();
            //para.Add("@begin", begin);
            //para.Add("@end", end);

            //var requestlist = Select(sql1, para);

            var baselist = baseRequestRepository.GetBaseRequestsByWeekDay(begin, end, weeks, day);

            ////先删除，再写入（不能删除，重复不写入）
            //string deletesql = "delete from gh_request where request_date between @begin and @end";
            //Update(deletesql, para);

            //            string insertsql = @"insert into gh_request
            //  (request_date, ampm, unit_sn, group_sn, doctor_sn, clinic_type, req_type, begin_no, current_no, end_no, enter_opera, enter_date, open_flag, window_no)
            //values
            //  (@request_date, @ampm, @unit_sn, @group_sn, @doctor_sn, @clinic_type, @req_type, @begin_no, @current_no, @end_no, @enter_opera, @enter_date, @open_flag, @window_no)";
            string insertsql = GetSqlByTag(220036);

            //生成日期只有一天
            if (day > 0 && (begin == end))
            {
                var request_date = Convert.ToDateTime(begin);
                var req_type = "01";//门诊号

                foreach (var item in baselist)
                {
                    //写入之前，判断是否存在，存在则跳过
                    item.request_date = request_date;
                    if (IsExistRecord(item))
                    {
                        continue;
                    }

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

                    int _day = 1;
                    if (i == 0)
                    {
                        _day = DayArray[Convert.ToInt32(request_date.DayOfWeek.ToString("d"))];
                    }
                    else
                    {
                        _day = weeklist[0].day;
                    }


                    do
                    {
                        var daylist = weeklist.Where(p => p.day == _day);

                        foreach (var item in daylist)
                        {
                            item.request_date = request_date;
                            if (IsExistRecord(item))
                            {
                                continue;
                            }
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
                    } while (_day < 8);

                }
            }
            return 1;
        }
        public bool IsExistGhRecord(BaseRequest item)
        {
            string sql = "";
            var para = new DynamicParameters();
            //准备数据
            if (string.IsNullOrWhiteSpace(item.doctor_sn))
            {
                //如果医生为空，则日期，科室，专科，上下午，号类 唯一条件
                sql = GetSqlByTag(220034);
            }
            else
            {
                //医生不为空，则日期，上下午，医生 唯一条件
                sql = GetSqlByTag(220035);
            }
            para.Add("@request_date", item.request_date); 
            para.Add("@week", item.week);
            para.Add("@ampm", item.ampm);
            para.Add("@unit_sn", item.unit_sn);
            if (string.IsNullOrWhiteSpace(item.group_sn))
            {
                sql += " and group_sn is null";

            }
            else
            {
                sql += " and group_sn = @group_sn";

                para.Add("@group_sn", item.group_sn);
            }

            para.Add("@doctor_sn", item.doctor_sn);
            para.Add("@clinic_type", item.clinic_type);


            var requestlist = Select(sql, para);

            if (requestlist != null && requestlist.Count > 0)
            {
                foreach (var ghRequest in requestlist)
                {
                    if (ghRequest.record_sn != item.record_sn)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public int EditRequest(string record_sn, string request_date, string unit_sn, string group_sn, string doctor_sn, string clinic_type, string request_type,
         string ampm, int totle_num, string window_no, string open_flag, string op_id, string temp_flag, string limit_appoint_percent)
        {
            BaseRequest baseRequest = new BaseRequest();
            baseRequest.request_date = Convert.ToDateTime(request_date);
            baseRequest.unit_sn = unit_sn;
            baseRequest.group_sn = group_sn;
            baseRequest.doctor_sn = doctor_sn;
            baseRequest.clinic_type = clinic_type;
            baseRequest.ampm = ampm;
            baseRequest.record_sn = record_sn;
            if (IsExistGhRecord(baseRequest))
            {
                throw new Exception("数据重复！");
            }
            //修改
            if (!string.IsNullOrEmpty(record_sn))
            {

                string sql = GetSqlByTag(220037);
                var para = new DynamicParameters();
                para.Add("@record_sn", record_sn);
                para.Add("@request_date", request_date);

                para.Add("@ampm", ampm);
                para.Add("@unit_sn", unit_sn);
                para.Add("@group_sn", group_sn);
                para.Add("@doctor_sn", doctor_sn);
                para.Add("@clinic_type", clinic_type);
                para.Add("@req_type", request_type);

                para.Add("@end_no", totle_num);

                para.Add("@enter_opera", op_id);
                para.Add("@enter_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                para.Add("@open_flag", open_flag);
                para.Add("@window_no", window_no);
                para.Add("@limit_appoint_percent", limit_appoint_percent);

                return Update(sql, para);
            }
            else
            {
                //新增
                string insertsql = GetSqlByTag(220036);
                var para = new DynamicParameters();

                var enter_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                para = new DynamicParameters();
                para.Add("@request_date", request_date);
                para.Add("@ampm", ampm);
                para.Add("@unit_sn", unit_sn);
                para.Add("@group_sn", group_sn);
                para.Add("@doctor_sn", doctor_sn);
                para.Add("@clinic_type", clinic_type);
                para.Add("@req_type", request_type);
                para.Add("@begin_no", 1);
                para.Add("@current_no", 1);
                para.Add("@end_no", totle_num);
                para.Add("@enter_opera", op_id);
                para.Add("@enter_date", enter_date);
                para.Add("@open_flag", open_flag);
                para.Add("@window_no", window_no);
                para.Add("@temp_flag", 1);
                para.Add("@limit_appoint_percent", limit_appoint_percent);

                return Update(insertsql, para);

            }
        }

        public int EditRequestTotalNum(string record_sn, int total_num)
        {
            string sql = "update gh_request set end_no=@total_num where record_sn=@record_sn";
            var para = new DynamicParameters();
            para.Add("@record_sn", record_sn);
            para.Add("@total_num", total_num);

            return Update(sql, para);

        }
    }
}
