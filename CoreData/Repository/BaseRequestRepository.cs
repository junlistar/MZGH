using Dapper;
using Data.Entities;
using Data.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class BaseRequestRepository : RepositoryBase<BaseRequest>, IBaseRequestRepository
    {

        public List<BaseRequest> GetBaseRequests(string unit_sn, string group_sn, string doctor_sn, string clinic_type,
            string week, string day, string ampm, string window_no, string open_flag,int temp_flag)
        {
            string ghsql = GetSqlByTag(220053);

            var para = new DynamicParameters();

            para.Add("@unit_sn", string.IsNullOrWhiteSpace(unit_sn) ? "%" : unit_sn.Trim());
            para.Add("@group_sn", string.IsNullOrWhiteSpace(group_sn) ? "%" : group_sn.Trim());
            para.Add("@doctor_sn", string.IsNullOrWhiteSpace(doctor_sn) ? "%" : doctor_sn.Trim());
            para.Add("@clinic_type", string.IsNullOrWhiteSpace(clinic_type) ? "%" : clinic_type.Trim());

            if (week == "" || week == "%")
            {
                para.Add("@week", string.IsNullOrWhiteSpace(week) ? "%" : week.Trim());
            }
            else
            {
                int iweek = int.Parse(week);
                para.Add("@week", iweek);
            }

            if (day == "" || day == "%")
            {
                para.Add("@day", string.IsNullOrWhiteSpace(day) ? "%" : day.Trim());
            }
            else
            {
                int iday = int.Parse(day);
                para.Add("@day", iday);
            }


            para.Add("@ampm", string.IsNullOrWhiteSpace(ampm) ? "%" : ampm.Trim());
            para.Add("@window_no", string.IsNullOrWhiteSpace(window_no) ? "%" : window_no.Trim());
            para.Add("@open_flag", string.IsNullOrWhiteSpace(open_flag) ? "%" : open_flag.Trim());
            para.Add("@temp_flag", temp_flag);


            return Select(ghsql, para);


        }

        public int EditBaseRequest(string request_sn, string unit_sn, string group_sn, string doctor_sn, string clinic_type,
            string week, string day, string ampm, int totle_num, string window_no, string open_flag, string op_id,int temp_flag,int limit_appoint_percent)
        {

            //修改
            if (!string.IsNullOrEmpty(request_sn))
            {
                //                string sql = @"update gh_base_request
                //set [week]=@week,[day]=@day,ampm=@ampm,unit_sn=@unit_sn,group_sn=@group_sn,doctor_sn=@doctor_sn,
                //clinic_type=@clinic_type,totle_num=@totle_num,op_id=@op_id,op_date=@op_date,open_flag=@open_flag,window_no=@window_no 
                //where request_sn = @request_sn";

                string sql = GetSqlByTag(220062);
                var para = new DynamicParameters();
                para.Add("@request_sn", request_sn);
                para.Add("@week", week);
                para.Add("@day", day);
                para.Add("@ampm", ampm);
                para.Add("@unit_sn", unit_sn);
                para.Add("@group_sn", group_sn);
                para.Add("@doctor_sn", doctor_sn);
                para.Add("@clinic_type", clinic_type);

                para.Add("@totle_num", totle_num);
                para.Add("@op_id", op_id);
                para.Add("@op_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                para.Add("@open_flag", open_flag);
                para.Add("@window_no", window_no);
                para.Add("@limit_appoint_percent", limit_appoint_percent);

                return Update(sql, para);
            }
            else
            {
                //新增
                string snosql = GetSqlByTag(220054);

                var dtconfig = ExcuteScalar(snosql, null);

                if (dtconfig != null)
                {
                    request_sn = dtconfig.ToString();
                }


                string sql = GetSqlByTag(220055);

                var para = new DynamicParameters();
                para.Add("@request_sn", request_sn);
                para.Add("@week", week);
                para.Add("@day", day);
                para.Add("@ampm", ampm);
                para.Add("@unit_sn", unit_sn);
                para.Add("@group_sn", group_sn);
                para.Add("@doctor_sn", doctor_sn);
                para.Add("@clinic_type", clinic_type);

                para.Add("@totle_num", totle_num);
                para.Add("@op_id", op_id);
                para.Add("@op_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                para.Add("@open_flag", open_flag);
                para.Add("@window_no", window_no);
                para.Add("@temp_flag", temp_flag);
                para.Add("@limit_appoint_percent", limit_appoint_percent);

                
                Update(sql, para);


                //挂号区间表
                string segsql = GetSqlByTag(220056);
                para = new DynamicParameters();
                para.Add("@request_sn", request_sn);
                para.Add("@req_type", "01");
                para.Add("@begin_no", 1);
                para.Add("@end_no", totle_num);

                return Update(segsql, para);

            }


        }

        public int DeleteBaseRequest(string request_sn)
        {
            string segsql = GetSqlByTag(220057);
            var para = new DynamicParameters();
            para.Add("@request_sn", request_sn);

            return Update(segsql, para);
        }
        public List<BaseRequest> GetBaseRequestsBySN(string request_sn)
        {
            // string segsql = @"select * from gh_base_request where request_sn=@request_sn";

            string segsql = GetSqlByTag(220061);
            var para = new DynamicParameters();
            para.Add("@request_sn", request_sn);

            return Select(segsql, para);
        }
        public List<BaseRequest> GetBaseRequestsByDate(string begin, string end)
        {
            string ghsql = GetSqlByTag(220058);

            string weeks = "1";
            string[] arr = weeks.Split(',');

            int[] DayArray = new int[] { 7, 1, 2, 3, 4, 5, 6 };
            if (arr.Length > 0)
            {
                DateTime dt1 = Convert.ToDateTime(begin);
                DateTime dt2 = Convert.ToDateTime(end);

                string append = " and (";

                if (arr.Length == 1)
                {
                    int week = int.Parse(arr[0]);
                    append += $" (((week*7)+day>={week * 7 + DayArray[Convert.ToInt32(dt1.DayOfWeek.ToString("d"))]}) AND ((week*7)+day<={week * 7 + DayArray[Convert.ToInt32(dt2.DayOfWeek.ToString("d"))]}))";
                }
                else
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        int week = int.Parse(arr[i]);
                        if (i == 0)
                        {
                            append += $" (((week*7)+day>={week * 7 + DayArray[Convert.ToInt32(dt1.DayOfWeek.ToString("d"))]}) AND ((week*7)+day<={(week + 1) * 7}))";

                        }
                        else if (i == arr.Length - 1)
                        {
                            append += $" or (((week*7)+day>={week * 7 + 1}) AND ((week*7)+day<={week * 7 + DayArray[Convert.ToInt32(dt2.DayOfWeek.ToString("d"))]}))";
                        }
                        else
                        {
                            append += $" or (((week*7)+day>={week * 7 + 1}) AND ((week*7)+day<={(week + 1) * 7}))";

                        }
                    }
                }
                append += $" ) ";
                ghsql += append;
            }

            ghsql += $" order by week,day"; 

            return Select(ghsql); 
        }


        public List<BaseRequest> GetBaseRequestsByWeekDay(string begin, string end, string weeks, int day)
        {
            string ghsql = GetSqlByTag(220058);

            if (day > 0)
            {
                ghsql += $"  and (week={weeks} and day={day})";
            }
            else
            {
                if (string.IsNullOrWhiteSpace(weeks))
                {
                    return null;
                }
                string[] arr = weeks.Split(',');

                int[] DayArray = new int[] { 7, 1, 2, 3, 4, 5, 6 };
                if (arr.Length > 0)
                {
                    DateTime dt1 = Convert.ToDateTime(begin);
                    DateTime dt2 = Convert.ToDateTime(end);

                    string append = " and (";

                    if (arr.Length == 1)
                    {
                        int week = int.Parse(arr[0]);
                        append += $" (((week*7)+day>={week * 7 + DayArray[Convert.ToInt32(dt1.DayOfWeek.ToString("d"))]}) AND ((week*7)+day<={week * 7 + DayArray[Convert.ToInt32(dt2.DayOfWeek.ToString("d"))]}))";
                    }
                    else
                    {
                        for (int i = 0; i < arr.Length; i++)
                        {
                            int week = int.Parse(arr[i]);
                            if (i == 0)
                            {
                                append += $" (((week*7)+day>={week * 7 + DayArray[Convert.ToInt32(dt1.DayOfWeek.ToString("d"))]}) AND ((week*7)+day<={(week + 1) * 7}))";

                            }
                            else if (i == arr.Length - 1)
                            {
                                append += $" or (((week*7)+day>={week * 7 + 1}) AND ((week*7)+day<={week * 7 + DayArray[Convert.ToInt32(dt2.DayOfWeek.ToString("d"))]}))";
                            }
                            else
                            {
                                append += $" or (((week*7)+day>={week * 7 + 1}) AND ((week*7)+day<={(week + 1) * 7}))";

                            }
                        }

                    }
                    append += $" ) ";
                    ghsql += append;
                }
            }
            ghsql += $" order by week,day";



            return Select(ghsql);


        }

        public List<BaseRequest> GetRequestsByDate(string begin, string end)
        {
            string ghsql = GetSqlByTag(220059);

            var para = new DynamicParameters();
            para.Add("@P1", begin);
            para.Add("@P2", end);

            return Select(ghsql, para);


        }

        public List<BaseRequest> GetRequestsByParams(string begin, string end, string unit_sn, string group_sn, string doctor_sn, string clinic_type, string req_type,
             string ampm, string window_no, string open_flag)
        {
            string ghsql = GetSqlByTag(220060);


            var para = new DynamicParameters();
            para.Add("@P1", begin);
            para.Add("@P2", end);
            para.Add("@unit_sn", string.IsNullOrWhiteSpace(unit_sn) ? "%" : unit_sn.Trim());
            para.Add("@group_sn", string.IsNullOrWhiteSpace(group_sn) ? "%" : group_sn.Trim());
            para.Add("@doctor_sn", string.IsNullOrWhiteSpace(doctor_sn) ? "%" : doctor_sn.Trim());
            para.Add("@clinic_type", string.IsNullOrWhiteSpace(clinic_type) ? "%" : clinic_type.Trim());
            para.Add("@req_type", string.IsNullOrWhiteSpace(req_type) ? "%" : req_type.Trim());

            para.Add("@ampm", string.IsNullOrWhiteSpace(ampm) ? "%" : ampm.Trim());
            para.Add("@window_no", string.IsNullOrWhiteSpace(window_no) ? "%" : window_no.Trim());
            para.Add("@open_flag", string.IsNullOrWhiteSpace(open_flag) ? "%" : open_flag.Trim());


            return Select(ghsql, para);


        }
        public DataTable GetRequestsByParamsV2(string begin, string end, string unit_sn, string group_sn, string doctor_sn, string clinic_type, string req_type,
            string ampm, string window_no, string open_flag, string temp_flag)
        {
            DateTime dt1 = DateTime.Parse(begin);
            DateTime dt = dt1;
            DateTime dt2 = DateTime.Parse(end);
            string sel_columns = "";
            while (dt <= dt2)
            {
                sel_columns += $@",MAX(CASE request_date
WHEN '{dt.ToShortDateString()}' THEN b.record_sn
ELSE ''
END) [sn]
,MAX(CASE request_date
WHEN '{dt.ToShortDateString()}' THEN b.ampm
ELSE ''
END) [bc]
,MAX(CASE request_date
WHEN '{dt.ToShortDateString()}' THEN CONVERT(varchar(20),b.current_no) +'/'+CONVERT(varchar(20),b.end_no) 
ELSE ''
END) [xe]
,MAX(CASE request_date
WHEN '{dt.ToShortDateString()}' THEN CONVERT(varchar(20),b.limit_appoint_percent)
ELSE ''
END) [xy]";
                dt = dt.AddDays(1);
            } 
            string ghsql = $@" SELECT 
	u1.name unit_name,b.unit_sn,
       u2.name group_name,
       c.name clinic_name, 
       a.name doct_name, b.group_sn,b.clinic_type,b.doctor_sn,b.ampm {sel_columns}
from gh_request b left join a_employee_mi a on b.doctor_sn = a.emp_sn 
     inner join zd_unit_code u1 on b.unit_sn = u1.unit_sn  
     left join zd_unit_code u2 on b.group_sn = u2.unit_sn 
     inner join gh_zd_clinic_type  c on b.clinic_type = c.code 
     inner join gh_zd_request_type r on b.req_type = r.code  
where b.request_date between @P1 and @P2
and b.unit_sn like @unit_sn and
      isnull(b.group_sn,'') like @group_sn and
      isnull(b.doctor_sn,'') like @doctor_sn and
      b.clinic_type like @clinic_type and
      b.req_type like @req_type and 
      b.ampm like @ampm and
      isnull(cast(b.window_no as char),'') like @window_no and
      b.open_flag like @open_flag and 
      isnull(b.temp_flag,'0') like @temp_flag
group by  b.unit_sn,b.group_sn ,b.clinic_type,b.doctor_sn,b.ampm,
u1.name,u2.name,a.name,c.name
order by unit_sn,group_sn,clinic_type,doctor_sn,ampm
";


            var para = new DynamicParameters();
            para.Add("@P1", begin);
            para.Add("@P2", end);
            para.Add("@unit_sn", string.IsNullOrWhiteSpace(unit_sn) ? "%" : unit_sn.Trim());
            para.Add("@group_sn", string.IsNullOrWhiteSpace(group_sn) ? "%" : group_sn.Trim());
            para.Add("@doctor_sn", string.IsNullOrWhiteSpace(doctor_sn) ? "%" : doctor_sn.Trim());
            para.Add("@clinic_type", string.IsNullOrWhiteSpace(clinic_type) ? "%" : clinic_type.Trim());
            para.Add("@req_type", string.IsNullOrWhiteSpace(req_type) ? "%" : req_type.Trim());

            para.Add("@ampm", string.IsNullOrWhiteSpace(ampm) ? "%" : ampm.Trim());
            para.Add("@window_no", string.IsNullOrWhiteSpace(window_no) ? "%" : window_no.Trim());
            para.Add("@open_flag", string.IsNullOrWhiteSpace(open_flag) ? "%" : open_flag.Trim());
            para.Add("@temp_flag", string.IsNullOrWhiteSpace(temp_flag) ? "%" : temp_flag.Trim());
            

            return ExecuteTable(ghsql, para, CommandType.Text);


        }

        public bool CreateRequestNoList(string begin, string end, int type)
        {
            string ghsql = GetSqlByTag(220063);

            var para = new DynamicParameters();
            para.Add("@Op_type", type);
            para.Add("@sDate", begin);
            para.Add("@eDate", end);
            //exec mzgh_CreateRequestNo_List @Op_type,@sDate,@eDate

            var dt = base.ExecuteTable(ghsql, para, CommandType.Text);
            if (dt != null && dt.Rows.Count > 0)
            {
                var code = dt.Rows[0][0].ToString();
                if (code == "0")
                {
                    return true;
                }
                else
                {
                    throw new Exception(dt.Rows[0][1].ToString());
                }
            }
            return false;
        }

        public bool CheckGhRepeat(string patient_id, string record_sn)
        {
            //            string sql = @"select COUNT(*) from view_mz_visit_table a
            //inner join gh_request b on a.visit_date = b.request_date 
            //and a.visit_dept= b.unit_sn 
            //and a.clinic_type = b.clinic_type
            //and ISNULL(a.group_sn,'0') =ISNULL(b.group_sn,'0') 
            //and ISNULL(a.doctor_code,'0') LIKE ISNULL(b.doctor_sn,'0')
            //and a.ampm=b.ampm
            //where patient_id = @patient_id
            //and record_sn = @record_sn";

            string sql = GetSqlByTag(220065);

            var para = new DynamicParameters();
            para.Add("@patient_id", patient_id);
            para.Add("@record_sn", record_sn);
            var count = ExcuteScalar(sql, para);
            if (Convert.ToInt32(count) > 0)
            {
                return true;
            }
            return false;
        }
    }
}
