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
            string ghsql = @"select a.*,b.name unit_name,c.name group_name,d.name doct_name,e.name clinic_name from gh_base_request a
left join zd_unit_code b on a.unit_sn = b.unit_sn
left join zd_unit_code c on a.group_sn = c.unit_sn
left join a_employee_mi d on a.doctor_sn = d.emp_sn
left join gh_zd_clinic_type e on a.clinic_type = e.code
where a.unit_sn like @unit_sn and
      isnull(a.group_sn,'''') like @group_sn and
      isnull(a.doctor_sn,'''') like @doctor_sn and
      a.clinic_type like @clinic_type and
      isnull(cast(a.week as char),'''') like @week and
      isnull(cast(a.day as char),'''') like @day and
      a.ampm like @ampm and
      isnull(cast(a.window_no as char),'''') like @window_no and
      a.open_flag like @open_flag
order by op_date desc,unit_sn,
         group_sn,
         doctor_sn,
         clinic_type,
         week,
         day,
         ampm,
         window_no";

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
                string snosql = @"update gh_config set base_request_sn=base_request_sn+1 where op_receipt_table='gh_op_receipt';
select base_request_sn from gh_config where op_receipt_table='gh_op_receipt';";

                var dtconfig = ExcuteScalar(snosql, null);

                if (dtconfig != null)
                {
                    request_sn = dtconfig.ToString();
                }


                string sql = @"insert into gh_base_request(request_sn,[week],[day],ampm,unit_sn,group_sn,doctor_sn,
clinic_type,totle_num,op_id,op_date,open_flag,window_no)
values(@request_sn,@week,@day,@ampm,@unit_sn,@group_sn,@doctor_sn,
@clinic_type,@totle_num,@op_id,@op_date,@open_flag,@window_no)";

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
                string segsql = @"insert into gh_base_request_segment(request_sn,req_type,begin_no,end_no)
values(@request_sn,@req_type,@begin_no,@end_no)";
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
            string segsql = @"delete from gh_base_request where request_sn=@request_sn;delete from gh_base_request_segment where request_sn=@request_sn";
            var para = new DynamicParameters();
            para.Add("@request_sn", request_sn);

            return Update(segsql, para);
        }


        public List<BaseRequest> GetBaseRequestsByWeekDay(string begin, string end, string weeks, int day)
        {
            string ghsql = @"select b.*,
	w.name window_name,	
        t.name clinic_name, 
	u1.name unit_name,
        u2.name group_name,
	a.name doct_name,
        c.req_type,
        c.begin_no,
        c.end_no      
from 	gh_base_request as b left join gh_zd_clinic_type as t on  b.clinic_type=t.code  
	left join gh_zd_window_no as w on b.window_no =w.window_no  
	left join zd_unit_code as u1 on b.unit_sn =u1.unit_sn  
	left join zd_unit_code as u2 on b.group_sn=u2.unit_sn 
	left join a_employee_mi as a on b.doctor_sn=a.emp_sn 
        inner join gh_base_request_segment c on b.request_sn = c.request_sn 
where  b.open_flag='1' ";

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
            string ghsql = @"select b.request_date,
       case b.ampm when 'a' then '上午' else '下午' end ampm,
       b.unit_sn,
       b.group_sn,
       b.doctor_sn,
       b.clinic_type,
       b.req_type,
       u1.name unit_name,
       u2.name group_name,
       a.name doct_name,
       c.name clinic_name,
       r.name req_name,
       b.begin_no,
       b.current_no,
       b.end_no,
       b.window_no,
       case b.open_flag when '1' then '开放' else '不开放' end open_flag
from gh_request b left join a_employee_mi a on b.doctor_sn = a.emp_sn 
     inner join zd_unit_code u1 on b.unit_sn = u1.unit_sn  
     left join zd_unit_code u2 on b.group_sn = u2.unit_sn 
     inner join gh_zd_clinic_type  c on b.clinic_type = c.code 
     inner join gh_zd_request_type r on b.req_type = r.code  
where b.request_date between @P1 and @P2  ";

            var para = new DynamicParameters();
            para.Add("@P1", begin);
            para.Add("@P2", end);

            return Select(ghsql, para);


        }

    }
}
