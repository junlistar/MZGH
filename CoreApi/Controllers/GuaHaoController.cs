using Data.Entities;
using Data.Helpers;
using Data.IRepository;
using Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace CoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class GuaHaoController : ApiControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        private readonly IUnitRepository _unitRepository;
        private readonly IGhRequestRepository _repository;
        private readonly IPatientRepository _patientRepository;
        private readonly IUserLoginRepository _userLoginRepository;
        private readonly IGhDepositRepository _ghDepositRepository;
        private readonly IGhRefundRepository _ghRefundRepository;
        private readonly IClinicTypeRepository _clinicTypeRepository;
        private readonly IGhSearchRepository _ghSearchRepository;
        private readonly IUserDicRepository _userDicRepository;
        private readonly IChargeTypeRepository _chargeTypeRepository;
        private readonly IDistrictCodeRepository _districtCodeRepository;
        private readonly IOccupationCodeRepository _occupationCodeRepository;
        private readonly IResponceTypeRepository _responceTypeRepository;
        private readonly IBaseRequestRepository _baseRequestRepository;
        private readonly IChargeItemRepository _chargeItemRepository;
        private readonly IMzHaomingRepository _mzHaomingRepository;
        private readonly IReportDataFastRepository _reportDataFastRepository;
         
        public GuaHaoController(ILogger<WeatherForecastController> logger, IUnitRepository unitRepository, IGhRequestRepository repository, IPatientRepository patientRepository,
            IUserLoginRepository userLoginRepository, IGhDepositRepository ghDepositRepository, IGhRefundRepository ghRefundRepository, IClinicTypeRepository clinicTypeRepository,
            IGhSearchRepository ghSearchRepository, IUserDicRepository userDicRepository, IChargeTypeRepository chargeTypeRepository, IDistrictCodeRepository districtCodeRepository,
            IOccupationCodeRepository occupationCodeRepository, IResponceTypeRepository responceTypeRepository, IBaseRequestRepository baseRequestRepository,
            IChargeItemRepository chargeItemRepository, IMzHaomingRepository mzHaomingRepository, IReportDataFastRepository reportDataFastRepository)
        {
            _logger = logger;
            _unitRepository = unitRepository;
            _repository = repository;
            _patientRepository = patientRepository;
            _userLoginRepository = userLoginRepository;
            _ghDepositRepository = ghDepositRepository;
            _ghRefundRepository = ghRefundRepository;
            _clinicTypeRepository = clinicTypeRepository;
            _ghSearchRepository = ghSearchRepository;
            _userDicRepository = userDicRepository;
            _chargeTypeRepository = chargeTypeRepository;
            _districtCodeRepository = districtCodeRepository;
            _occupationCodeRepository = occupationCodeRepository;
            _responceTypeRepository = responceTypeRepository;
            _baseRequestRepository = baseRequestRepository;
            _chargeItemRepository = chargeItemRepository;
            _mzHaomingRepository = mzHaomingRepository;
            _reportDataFastRepository = reportDataFastRepository;
             
        }

        [HttpGet]
        public string GetTest()
        {
            return "ok";
        }

        [HttpGet]
        public ResponseResult<string> GetTest1()
        {
            return ErrorResult<string>("error");
        }
        public ResponseResult<bool> TestDBConnection()
        {


            Stopwatch wt = new Stopwatch();
            wt.Reset();
            wt.Start();

            TcpClient client = new TcpClient();
            try
            {
                var ar = client.BeginConnect("10.102.41.147", 1433, null, null);//host是主机不包含端口,port就是端口了
                ar.AsyncWaitHandle.WaitOne(1000);
                return Result<bool>(ResultStatus.Success, client.Connected, wt.ElapsedMilliseconds.ToString());
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());

                return false;
            }
            finally
            {
                client.Close();
                wt.Stop();
                //Log.Information(string.Format("耗时:{0}", wt.ElapsedMilliseconds));
            }
            //return _patientRepository.TestDBConnection();
        }

        [HttpGet]
        public ResponseResult<IEnumerable<Unit>> Get()
        {
            var list = new List<Unit>();
            try
            {
                list = _unitRepository.GetUnits();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<IEnumerable<Unit>>(ex.Message);
            }

            return list;
        }
        [HttpGet]
        public ResponseResult<List<GhRefund>> GetGhRefund(string datestr, string patient_id)
        {
            Log.Information($"GetGhRefund,{datestr},{patient_id}");
            var list = new List<GhRefund>();
            try
            {
                return _ghRefundRepository.GetGhRefund(datestr, patient_id);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
            return list;
        }
        [HttpGet]
        public ResponseResult<List<GhDeposit>> GetGhRefundPayList(string request_date, string patient_id, int times)
        {

            Log.Information($"GetGhRefundPayList,{request_date},{patient_id},{times}");
            var list = new List<GhDeposit>();
            try
            {
                return _ghDepositRepository.GetGhRefundPayList(request_date, patient_id, times);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
            return list;
        }

        public ResponseResult<IEnumerable<GhRequest>> GetGhRequest(string request_date, string ampm, string unit_sn = "%", string clinic_type = "%", string doctor_sn = "%", string group_sn = "%", string req_type = "01", string win_no = "%")
        {
            Log.Information($"GetGhRequest,{request_date},{ampm}");
            var list = new List<GhRequest>();
            try
            {
                list = _repository.GetGhRequest(request_date, ampm, unit_sn = "%", clinic_type = "%", doctor_sn = "%", group_sn = "%", req_type = "01", win_no = "%");

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<IEnumerable<GhRequest>>(ex.Message);
            }
            return list;


        }


        /// <summary>
        /// 根据卡号获取用户信息
        /// </summary>
        /// <param name="cardno"></param>
        /// <returns></returns>

        public ResponseResult<IEnumerable<Patient>> GetPatientByCard(string cardno)
        {
            Log.Information($"GetPatientByCard,{cardno}");
            var list = new List<Patient>();
            try
            {
                list = _patientRepository.GetPatientByCard(cardno);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<IEnumerable<Patient>>(ex.Message);
            }
            return list;


        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="sno"></param>
        /// <param name="hicno"></param>
        /// <param name="barcode"></param>
        /// <param name="name"></param>
        /// <param name="sex"></param>
        /// <param name="birthday"></param>
        /// <param name="tel"></param>
        /// <returns></returns>
        public ResponseResult<int> EditUserInfo(string pid, string sno, string hicno, string barcode, string name, string sex, string birthday, string tel,
            string home_district, string home_street, string occupation_type, string response_type, string charge_type, string opera)
        {
            Log.Information($"EditUserInfo,{pid},{sno},{hicno},{barcode},{name},{sex},{birthday},{tel},{home_district},{home_street},{occupation_type},{response_type},{charge_type},{opera}");
            try
            {
                return _patientRepository.EditUserInfo(pid, sno, hicno, barcode, name, sex, birthday, tel, home_district, home_street, occupation_type, response_type, charge_type, opera);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<int>(ex.Message);
            }
        }
        public ResponseResult<int> EditUserInfoPage(string pid, string sno, string hicno, string barcode, string name, string sex, string birthday, string tel,
           string home_district, string home_street, string occupation_type, string response_type, string charge_type,
           string relation_name, int marrycode, string addition_no1, string employer_name, string opera)
        {
            Log.Information($"EditUserInfoPage,{pid},{sno},{hicno},{barcode},{name},{sex},{birthday},{tel},{home_district},{home_street},{occupation_type},{response_type},{charge_type},{relation_name},{marrycode},{addition_no1},{employer_name},{opera}");
            try
            {
                return _patientRepository.EditUserInfoPage(pid, sno, hicno, barcode, name, sex, birthday, tel, home_district, home_street, occupation_type, response_type, charge_type, relation_name, marrycode, addition_no1, employer_name, opera);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<int>(ex.Message);
            }
        }
         
        public ResponseResult<bool> GuaHao(string patient_id, string record_sn, string pay_string, int max_sn = 0, string opera = "")
        {
            Log.Information($"GuaHao,{patient_id},{record_sn},{pay_string},{opera}");
            try
            {
                return _patientRepository.GuaHao(patient_id, record_sn, pay_string, max_sn ,opera);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<bool>(ex.Message);
            }

        }
        public ResponseResult<IEnumerable<LoginUsers>> GetLoginUser(string uname, string pwd)
        {
            Log.Information($"GetLoginUser,{uname},{pwd}");
            var list = new List<LoginUsers>();
            try
            {
                list = _userLoginRepository.GetLoginUser(uname, pwd);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<IEnumerable<LoginUsers>>(ex.Message);
            }
            return list;

        }

        /// <summary>
        /// 获取挂号记录
        /// </summary>
        /// <param name="patient_id"></param>
        /// <returns></returns>

        public ResponseResult<List<GhDeposit>> GetGhDeposit(string patient_id)
        {
            Log.Information($"GetGhDeposit,{patient_id}");
            var list = new List<GhDeposit>();
            try
            {
                list = _ghDepositRepository.GetGhDeposit(patient_id);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<GhDeposit>>(ex.Message);
            }
            return list;
        }

        public ResponseResult<List<GhDeposit>> GetGhDepositByStatus(string pid, int times, int status, int cheque_type, int item_no)
        {
            Log.Information($"GetGhDepositByStatus,{pid},{times},{status},{cheque_type},{item_no}");
            var list = new List<GhDeposit>();
            try
            {
                list = _ghDepositRepository.GetGhDepositByStatus(pid, times, status, cheque_type, item_no);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<GhDeposit>>(ex.Message);
            }
            return list;
        }

        public ResponseResult<int> Refund(string patient_id, int times, string opera, int manual = 0)
        {
            Log.Information($"Refund,{patient_id},{times},{opera},{manual}");
            try
            {
                return _ghDepositRepository.Refund(patient_id, times, opera, manual);

            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<int>(ex.Message);
            }
        }

        public ResponseResult<List<Unit>> GetUnits()
        {
            var list = new List<Unit>();
            try
            {
                list = _unitRepository.GetUnits();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<Unit>>(ex.Message);
            }
            return list;
        }

        [HttpGet]
        public ResponseResult<IEnumerable<GhSearch>> GhSearchList(string gh_date, string visit_dept = "%", string clinic_type = "%", string doctor_code = "%",
          string group_sn = "%", string req_type = "%", string ampm = "%", string gh_opera = "%",
          string name = "%", string p_bar_code = "%")
        {

            Log.Information($"GhSearchList,{gh_date},{visit_dept},{clinic_type},{doctor_code},{group_sn},{req_type},{ampm},{gh_opera},{name},{p_bar_code}");
            var list = new List<GhSearch>();
            try
            {
                list = _ghSearchRepository.GhSearchList(gh_date, visit_dept, clinic_type, doctor_code,
           group_sn, req_type, ampm, gh_opera, name, p_bar_code);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<IEnumerable<GhSearch>>(ex.Message);
            }
            return list;
        }

        public ResponseResult<List<ClinicType>> GetClinicTypes()
        {
            Log.Information($"GetClinicTypes");
            var list = new List<ClinicType>();
            try
            {
                list = _clinicTypeRepository.GetClinicTypes();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<ClinicType>>(ex.Message);
            }
            return list;
        }
        public ResponseResult<List<ClinicType>> GetRequestTypes()
        {
            Log.Information($"GetRequestTypes");
            var list = new List<ClinicType>();
            try
            {
                list = _clinicTypeRepository.GetRequestTypes();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<ClinicType>>(ex.Message);
            }
            return list;
        }
        public ResponseResult<List<UserDic>> GetUserDic()
        {
            Log.Information($"GetUserDic");
            var list = new List<UserDic>();
            try
            {
                list = _userDicRepository.GetUserDic();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<UserDic>>(ex.Message);
            }
            return list;
        }

        public ResponseResult<List<ChargeType>> GetChargeTypes()
        {
            Log.Information($"GetChargeTypes");
            var list = new List<ChargeType>();
            try
            {
                list = _chargeTypeRepository.GetChargeTypes();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<ChargeType>>(ex.Message);
            }
            return list;
        }

        public ResponseResult<List<DistrictCode>> GetDistrictCodes()
        {
            Log.Information($"GetDistrictCodes");
            var list = new List<DistrictCode>();
            try
            {
                list = _districtCodeRepository.GetDistrictCodes();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<DistrictCode>>(ex.Message);
            }
            return list;
        }
        public ResponseResult<List<OccupationCode>> GetOccupationCodes()
        {
            Log.Information($"GetDistrictCodes");
            var list = new List<OccupationCode>();
            try
            {
                list = _occupationCodeRepository.GetOccupationCodes();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<OccupationCode>>(ex.Message);
            }
            return list;
        }
        public ResponseResult<List<ResponceType>> GetResponceTypes()
        {
            Log.Information($"GetResponceTypes");
            var list = new List<ResponceType>();
            try
            {
                list = _responceTypeRepository.GetResponceTypes();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<ResponceType>>(ex.Message);
            }
            return list;
        }

        public ResponseResult<List<MzHaoming>> GetMzHaomings()
        {
            Log.Information($"GetMzHaomings");
            var list = new List<MzHaoming>();
            try
            {
                list = _mzHaomingRepository.GetMzHaomings();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<MzHaoming>>(ex.Message);
            }
            return list;
        }

        public ResponseResult<List<Patient>> GetPatientByBarcode(string barcode)
        {
            Log.Information($"GetPatientByBarcode");
            var list = new List<Patient>();
            try
            {
                list = _patientRepository.GetPatientByBarcode(barcode);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<Patient>>(ex.Message);
            }
            return list;
        }

        public ResponseResult<List<Patient>> GetPatientByPatientId(string pid)
        {
            Log.Information($"GetPatientByPatientId");
            var list = new List<Patient>();
            try
            {
                list = _patientRepository.GetPatientByPatientId(pid);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<Patient>>(ex.Message);
            }
            return list;
        }

        public ResponseResult<List<BaseRequest>> GetBaseRequests(string unit_sn, string group_sn, string doctor_sn, string clinic_type,
            string week, string day, string ampm, string window_no, string open_flag)
        {
            Log.Information($"GetBaseRequests,{unit_sn},{group_sn},{doctor_sn},{clinic_type},{week},{day},{ampm},{window_no},{open_flag}");
            var list = new List<BaseRequest>();
            try
            {
                list = _baseRequestRepository.GetBaseRequests(unit_sn, group_sn, doctor_sn, clinic_type, week, day, ampm, window_no, open_flag);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<BaseRequest>>(ex.Message);
            }
            return list;
        }

        public ResponseResult<int> EditBaseRequest(string request_sn, string unit_sn, string group_sn, string doctor_sn, string clinic_type,
           string week, string day, string ampm, int totle_num, string window_no, string open_flag, string op_id)
        {
            Log.Information($"EditBaseRequest,{request_sn},{unit_sn},{group_sn},{doctor_sn},{clinic_type},{week},{day},{ampm},{totle_num},{window_no},{open_flag},{op_id}");
            try
            {
                return _baseRequestRepository.EditBaseRequest(request_sn, unit_sn, group_sn, doctor_sn, clinic_type,
            week, day, ampm, totle_num, window_no, open_flag, op_id);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<int>(ex.Message);
            }
        }

        public ResponseResult<int> DeleteBaseRequest(string request_sn)
        {

            Log.Information($"DeleteBaseRequest,{request_sn}");
            try
            {
                return _baseRequestRepository.DeleteBaseRequest(request_sn);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<int>(ex.Message);
            }
        }

        public ResponseResult<BaseRequest> GetBaseRequestsBySN(string request_sn)
        {
            Log.Information($"GetBaseRequestsBySN,{request_sn}");
            try
            {
                return _baseRequestRepository.GetBaseRequestsBySN(request_sn).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<BaseRequest>(ex.Message);
            }
        }

        public ResponseResult<List<BaseRequest>> GetBaseRequestsByWeekDay(string begin, string end, string weeks, int day)
        {

            Log.Information($"GetBaseRequestsByWeekDay,{begin},{end},{weeks},{day}");
            try
            {
                return _baseRequestRepository.GetBaseRequestsByWeekDay(begin, end, weeks, day);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<BaseRequest>>(ex.Message);
            }
        }

        public ResponseResult<int> EditRequest(string record_sn, string request_date,string unit_sn, string group_sn, string doctor_sn, string clinic_type, string request_type,
         string ampm, int totle_num, string window_no, string open_flag, string op_id)
        {
            Log.Information($"EditRequest,{record_sn},{request_date},{unit_sn},{group_sn},{doctor_sn},{clinic_type},{request_type},{ampm},{totle_num},{window_no},{open_flag},{op_id}");
            try
            {
                return _repository.EditRequest(record_sn, request_date,unit_sn, group_sn, doctor_sn, clinic_type, request_type,ampm, totle_num, window_no, open_flag, op_id);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<int>(ex.Message);
            }
        }

        public ResponseResult<List<BaseRequest>> GetRequestsByDate(string begin, string end)
        {

            Log.Information($"GetRequestsByDate,{begin},{end}");
            try
            {
                return _baseRequestRepository.GetRequestsByDate(begin, end);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<BaseRequest>>(ex.Message);
            }
        }

        public ResponseResult<List<BaseRequest>> GetRequestsByParams(string begin, string end, string unit_sn, string group_sn, string doctor_sn, string clinic_type, string req_type,
             string ampm, string window_no, string open_flag)
        {

            Log.Information($"GetRequestsByParams,{begin},{end}, {unit_sn},  {group_sn},  {doctor_sn},  {clinic_type},  {req_type},{ampm},  {window_no},  {open_flag}");
            try
            {
                return _baseRequestRepository.GetRequestsByParams(begin, end,  unit_sn,  group_sn,  doctor_sn,  clinic_type,  req_type,ampm,  window_no,  open_flag);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<BaseRequest>>(ex.Message);
            }
        } 

        public ResponseResult<int> CreateRequestRecord(string begin, string end, string weeks, int day, string op_id)
        {
            Stopwatch wt = new Stopwatch();
            wt.Reset();
            wt.Start();
            Log.Information($"CreateRequestRecord,{begin},{end},{weeks},{day},{op_id}");
            try
            {
                return _repository.CreateRequestRecord(begin, end, weeks, day, op_id);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<int>(ex.Message);
            }
            finally
            {
                wt.Stop();
                Log.Information(string.Format("耗时:{0}", wt.ElapsedMilliseconds));
            }
        }
         

        public ResponseResult<string> GetNewPatientId()
        {

            Log.Information($"GetNewPatientId");
            try
            {
                return _patientRepository.GetNewPatientId();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<string>(ex.Message);
            }

        }

        public ResponseResult<List<ChargeItem>> GetChargeItemsByRecordSN(string record_sn)
        {
            Log.Information($"GetChargeItemsByRecordSN,{record_sn}");
            try
            {
                return _chargeItemRepository.GetChargeItemsByRecordSN(record_sn);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<ChargeItem>>(ex.Message);
            }

        }

        public ResponseResult<int> DeleteSocialNo(string sno)
        {
            Log.Information($"DeleteSocialNo,{sno}");
            try
            {
                return _patientRepository.DeleteSocialNo(sno);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<int>(ex.Message);
            }

        }

        /// <summary>
        /// 更新用户医保信息
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="yb_psn_no"></param>
        /// <param name="yb_insutype"></param>
        /// <param name="yb_insuplc_admdvs"></param>
        /// <returns></returns>
        public ResponseResult<int> UpdateUserYBInfo(string pid,string social_no, string yb_psn_no, string yb_insutype, string yb_insuplc_admdvs)
        {

            Log.Information($"UpdateUserYBInfo,{pid} ,{social_no}, {yb_psn_no}, {yb_insutype}, {yb_insuplc_admdvs}");
            try
            {
                return _patientRepository.UpdateUserYBInfo(pid, social_no, yb_psn_no, yb_insutype, yb_insuplc_admdvs);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<int>(ex.Message);
            }

        }

        /// <summary>
        /// 获取最新机制号
        /// </summary>
        /// <returns></returns>
        public ResponseResult<string> GetNewReceiptMaxSN()
        {

            Log.Information($"GetNewReceiptMaxSN");
            try
            {
                return _patientRepository.GetNewReceiptMaxSN();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<string>(ex.Message);
            }
        }

        public ResponseResult<GhRequest> GetGhRecord(string record_sn)
        {

            Log.Information($"GetGhRecord,{record_sn}");
            try
            {
                return _repository.GetGhRecord(record_sn).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<GhRequest>(ex.Message);
            }
        }


        public ResponseResult<DataSet> GetReportDataByCode(string code, string tb_name)
        {

            Log.Information($"GetReportDataByCode,{code},{tb_name}");
            try
            {
                return _reportDataFastRepository.GetReportDataByCode(code, tb_name);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<DataSet>(ex.Message);
            }
        }
        public ResponseResult<int> UpdateReportDataByCode(string code, byte[] report_com)
        {

            Log.Information($"UpdateReportDataByCode,{code},{report_com.Length}");
            try
            {
                return _reportDataFastRepository.UpdateReportDataByCode(code, report_com);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<int>(ex.Message);
            }
        }
        public ResponseResult<List<ReportData>> GetReportData(string code)
        {

            Log.Information($"GetReportData,{code}");
            try
            {
                return _reportDataFastRepository.GetReportData(code);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<ReportData>>(ex.Message);
            }
        } 
    }
}
