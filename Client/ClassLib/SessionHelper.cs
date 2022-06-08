using Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client.ClassLib
{
    public class SessionHelper
    {
       

        public static HttpClient MyHttpClient = null;

        public static LoginUsersVM uservm = new LoginUsersVM();
        public static PatientVM patientVM;

        public static int gh_pay_countdown = 120;//second

        public static string cardno = "";

        public static int clientWidth;
        public static int clientHeight;

        public static List<RequestHourVM> requestHours;


        //费别
        public static List<ChargeTypeVM> chargeTypes;
        //地区
        public static List<DistrictCodeVM> districtCodes;
        //职业
        public static List<OccupationCodeVM> occupationCodes;
        //身份
        public static List<ResponceTypeVM> responseTypes;

        //科室
        public static List<UnitVM> units;
        //号别(门诊号，专家号，急诊号等)select * from gh_zd_clinic_type
        public static List<ClinicTypeVM> clinicTypes;
        //号类（门诊号） select* from gh_zd_request_type
        public static List<RequestTypeVM> requestTypes;
        //用户
        public static List<UserDicVM> userDics;


        /// <summary>
        /// 身份证读卡数据
        /// </summary>
        public static CardReader_Data CardReader;


       
    }
}
