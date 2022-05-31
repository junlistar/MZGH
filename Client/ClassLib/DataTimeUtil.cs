using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ClassLib
{
    public class DataTimeUtil
    {
        /// 通过生日和当前日期计算岁，月，天

        /// </summary>

        /// <param name="birthday">生日</param>

        /// <param name="now">当前日期</param>

        /// <param name="year">岁</param>

        /// <param name="month">月</param>

        /// <param name="day">天</param>

        public static void GetAgeByBirthday(DateTime birthday, DateTime now, out int year, out int month,

        out int day)

        {

            //生日的年，月，日

            int birthdayYear = birthday.Year;

            int birthdayMonth = birthday.Month;

            int birthdayDay = birthday.Day;



            //当前时间的年,月,日



            int nowYear = now.Year;

            int nowMonth = now.Month;

            int nowDay = now.Day;



            //得到天

            if (nowDay >= birthdayDay)

            {

                day = nowDay - birthdayDay;

            }

            else

            {

                nowMonth -= 1;

                day = GetDay(nowMonth, nowYear) + nowDay - birthdayDay;

            }



            //得到月

            if (nowMonth >= birthdayMonth)

            {

                month = nowMonth - birthdayMonth;

            }

            else

            {

                nowYear -= 1;

                month = 12 + nowMonth - birthdayMonth;

            }



            //得到年

            year = nowYear - birthdayYear;

        }



        /// <summary>

        /// 获取天数

        /// </summary>

        private static int GetDay(int month, int year)

        {

            int day = 0;

            switch (month)

            {

                case 1:

                case 3:

                case 5:

                case 7:

                case 8:

                case 10:

                case 12:

                    day = 31;

                    break;

                case 2:

                    //闰年天，平年天

                    if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)

                    {

                        day = 29;

                    }

                    else

                    {

                        day = 28;

                    }

                    break;

                case 4:

                case 6:

                case 9:

                case 11:

                    day = 30;

                    break;

            }

            return day;

        }

        //获取周一
        public static DateTime getMonday(DateTime now)
        { 
            DateTime temp = new DateTime(now.Year, now.Month, now.Day);
            int count = now.DayOfWeek - DayOfWeek.Monday;
            if (count == -1) count = 6;

            return temp.AddDays(-count);
        }
        //获取周天
        public static DateTime getSunday(DateTime now)
        { 
            DateTime temp = new DateTime(now.Year, now.Month, now.Day);
            int count = now.DayOfWeek - DayOfWeek.Sunday;
            if (count != 0) count = 7 - count;

            return temp.AddDays(count);
        }

        /// <summary>
        /// 当前周的第一天(星期一)
        /// </summary>
        /// <param name="yearWeek">周数，格式：yyyywww</param>
        /// <returns></returns>
        public static DateTime GetWeekStartTime(string yearWeek)
        {
            int year = int.Parse(yearWeek.Substring(0, 4));
            //本年1月1日
            DateTime firstOfYear = new DateTime(year, 1, 1);
            //周数
            int weekNum = int.Parse(yearWeek.Substring(4));
            //本年1月1日与本周星期一相差的天数
            int dayDiff = (firstOfYear.DayOfWeek == DayOfWeek.Sunday ? 7 : Convert.ToInt32(firstOfYear.DayOfWeek)) - 1;
            //第一周的星期一
            DateTime firstDayOfFirstWeek = firstOfYear.AddDays(-dayDiff);
            //当前周的星期一
            DateTime firstDayOfThisWeek = firstDayOfFirstWeek.AddDays((weekNum - 1) * 7);
            return firstDayOfThisWeek;

        }/// <summary>
         /// 当前周的最后一天(星期天)
         /// </summary>
         /// <param name="yearWeek">周数，格式：yyyywww</param>
         /// <returns></returns>
        public static DateTime GetWeekEndTime(string yearWeek)
        {
            //当前周的星期一
            DateTime firstDayOfThisWeek = GetWeekStartTime(yearWeek);
            //当前周的星期天
            DateTime lastDayOfThisWeek = firstDayOfThisWeek.AddDays(6);
            return lastDayOfThisWeek;
        }

        public static string GetDayFromEnum(DayOfWeek dof)
        {
            string res = "";
            switch (dof)
            { 
                case DayOfWeek.Sunday:
                    res = "星期日";
                    break;
                case DayOfWeek.Monday:
                    res = "星期一";
                    break;
                case DayOfWeek.Tuesday:
                    res = "星期二";
                    break;
                case DayOfWeek.Wednesday:
                    res = "星期三";
                    break;
                case DayOfWeek.Thursday:
                    res = "星期四";
                    break;
                case DayOfWeek.Friday:
                    res = "星期五";
                    break;
                case DayOfWeek.Saturday:
                    res = "星期六";
                    break;
                default:
                    break;
            }
            return res;

        }

        public static int GetIntByDayStr(string cnstr)
        {
            switch (cnstr)
            {
                case "星期一": return 1;
                case "星期二": return 2;
                case "星期三": return 3;
                case "星期四": return 4;
                case "星期五": return 5;
                case "星期六": return 6;
                case "星期日": return 7;
                default:
                    return 0; 
            }
        }
        public static int GetIntByWeekStr(string cnstr)
        { 
            switch (cnstr)
            {
                case "第一周": return 1;
                case "第二周": return 2;
                case "第三周": return 3;
                case "第四周": return 4;
                case "第五周": return 5;
                case "第六周": return 6;
                case "第七周": return 7;
                case "第八周": return 8;
                default:
                    return 0;
            }
        }
    }
}
