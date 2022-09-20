﻿using Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        public static Color dgv_row_seleced_color = Color.FromArgb(104, 173, 255);

        //系统配置信息，医院名称，版本号，挂号搜索词长度配置等
        public static MzClientConfigVM MzClientConfigVM; 

        public static string cardno = "";

        public static int clientWidth;
        public static int clientHeight;

        public static List<RequestHourVM> requestHours;

        public static string sel_patientid;


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
        //与患者关系
        public static List<RelativeCodeVM> relativeCodes;
        //支付类型比较
        public static List<PageChequeCompareVM> pageChequeCompares;
        //医保支付类型
        public static List<YbNameVM> ybNames; 


        //医保目录字典
        public static List<YbhzzdVM> ybhzCompare;
        //医保字典
        public static List<InsutypeVM> insutypes;
        public static List<MdtrtCertTypeVM> mdtrtCertTypes;
        public static List<MedTypeVM> medTypes;
        public static List<DiagTypeVM> diagTypes;
        public static List<IcdCodeVM> icdCodes;
        public static List<BirctrlTypeVM> birctrlTypes;

        


        /// <summary>
        /// 身份证读卡数据
        /// </summary>
        public static CardReader_Data CardReader;

        //门诊挂号，收费打印，报表编号
        public static int mzgh_report_code;
        public static int mzsf_report_code;
        //挂号日结，收费日结
        public static int ghrj_report_code;
        public static int sfrj_report_code;

         
        //标志 挂号操作是否需要打印
        public static bool do_gh_print = false;
        public static bool do_sf_print = false;
        public static int sf_print_user_ledger = 0;

        //默认打印机配置
        public static string gh_printer;
        public static string sf_printer;
        public static string jsbb_printer;
        public static string default_printer;

        //门诊处方类型列表
        public static List<OrderTypeVM> mzOrderTypes;

        //门诊处方
        public static List<MzOrderVM> mzOrders;
        //门诊处方详情
        public static List<CprChargesVM> cprCharges;

        public static List<MzChargePatternVM> MzChargePatterns;
        public static List<MzChargePatternDetailVM> MzChargePatternDetails;

        //模板处方 
        public static List<CprChargesVM> mbChargeList;

        //就诊信息
        public static List<Diseinfo> diseinfoList = new List<Diseinfo>();

        public static string pay_xianjin;
        public static string pay_weixin;
        public static string pay_zhifubao;
        public static string pay_yinlian;
        public static string pay_yibao;
    }
}
