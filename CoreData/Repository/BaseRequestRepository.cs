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
            string week, string day, string ampm, string window_no, string open_flag)
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


            return Select(ghsql, para);


        }

        public int EditBaseRequest(string request_sn, string unit_sn, string group_sn, string doctor_sn, string clinic_type,
            string week, string day, string ampm, int totle_num, string window_no, string open_flag, string op_id)
        {

            //修改
            if (!string.IsNullOrEmpty(request_sn))
            {
                string sql = @"update mz_patient_mi
set social_no=@social_no,hic_no=@hic_no,p_bar_code=@p_bar_code,name=@name,sex=@sex,birthday=@birthday,home_tel=@tel,
home_district=@home_district,home_street=@home_street,occupation_type=@occupation_type,response_type=@response_type,charge_type=@charge_type
where patient_id=@patient_id";
                var para = new DynamicParameters();
                //para.Add("@social_no", sno);
                //para.Add("@hic_no", hicno);
                //para.Add("@p_bar_code", barcode);
                //para.Add("@name", name);
                //para.Add("@sex", sex);
                //para.Add("@birthday", birthday);
                //para.Add("@tel", tel);
                //para.Add("@home_district", home_district);
                //para.Add("@home_street", home_street);
                //para.Add("@occupation_type", occupation_type);
                //para.Add("@response_type", response_type);
                //para.Add("@charge_type", charge_type);
                //para.Add("@patient_id", pid);

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

            //挂号区间表
            string segsql = GetSqlByTag(220057);
            var para = new DynamicParameters();
            para.Add("@request_sn", request_sn);

            return Update(segsql, para);
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

    }
}
