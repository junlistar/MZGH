using Microsoft.AspNetCore.Mvc;
//using Data.IRepository; 
using Data.Helpers;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using Data.Entities;
using Data.Entities.Mzsf;
using Data.IRepository;
using Data.IRepository.Mzsf;

namespace CoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MzsfController : ApiControllerBase
    {
        private readonly IUserLoginRepository _userLoginRepository;
        private readonly IClinicTypeRepository _clinicTypeRepository;
        private readonly IUserDicRepository _userDicRepository;
        private readonly IChargeTypeRepository _chargeTypeRepository;
        private readonly IDistrictCodeRepository _districtCodeRepository;
        private readonly IOccupationCodeRepository _occupationCodeRepository;
        private readonly IResponceTypeRepository _responceTypeRepository;
        private readonly IChargeItemRepository _chargeItemRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IMzOrderRepository _mzOrderRepository;
        private readonly IMzVisitRepository _mzVisitRepository;
        private readonly ICprChargesRepository _cprChargesRepository;
        private readonly IUnitRepository _unitRepository;
        private readonly IMzOrderReceiptRepository _mzOrderReceiptRepository;
        private readonly IMzDepositRepository _mzDepositRepository;
        private readonly IOrderTypeRepository _orderTypeRepository;
        private readonly IMzOrderItemRepository _mzOrderItemRepository;
        private readonly IFpDataRepository _fpDataRepository;
        private readonly IMzThridPayRepository _mzThirdPayRepository;



        public MzsfController(IUserLoginRepository userLoginRepository, IClinicTypeRepository clinicTypeRepository,
             IUserDicRepository userDicRepository, IChargeTypeRepository chargeTypeRepository, IDistrictCodeRepository districtCodeRepository,
            IOccupationCodeRepository occupationCodeRepository, IResponceTypeRepository responceTypeRepository, IChargeItemRepository chargeItemRepository,
            IPatientRepository patientRepository, IMzOrderRepository mzOrderRepository, ICprChargesRepository cprChargesRepository,
            IUnitRepository unitRepository, IMzVisitRepository mzVisitRepository, IMzOrderReceiptRepository mzOrderReceiptRepository,
            IMzDepositRepository mzDepositRepository, IOrderTypeRepository orderTypeRepository, IMzOrderItemRepository mzOrderItemRepository,
            IFpDataRepository fpDataRepository, IMzThridPayRepository mzThirdPayRepository)
        {
            _userLoginRepository = userLoginRepository;
            _clinicTypeRepository = clinicTypeRepository;
            _userDicRepository = userDicRepository;
            _chargeTypeRepository = chargeTypeRepository;
            _districtCodeRepository = districtCodeRepository;
            _occupationCodeRepository = occupationCodeRepository;
            _responceTypeRepository = responceTypeRepository;
            _chargeItemRepository = chargeItemRepository;
            _patientRepository = patientRepository;
            _mzOrderRepository = mzOrderRepository;
            _cprChargesRepository = cprChargesRepository;
            _unitRepository = unitRepository;
            _mzVisitRepository = mzVisitRepository;
            _mzOrderReceiptRepository = mzOrderReceiptRepository;
            _mzDepositRepository = mzDepositRepository;
            _orderTypeRepository = orderTypeRepository;
            _mzOrderItemRepository = mzOrderItemRepository;
            _fpDataRepository = fpDataRepository;
            _mzThirdPayRepository = mzThirdPayRepository;
        }



        [HttpGet]
        public string GetTest()
        {
            return "ok";
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
        public ResponseResult<List<MzVisit>> GetMzVisitsByDate(string patient_id, string begin, string end)
        {
            Log.Information($"GetMzVisitsByDate,{patient_id},{begin},{end}");
            var list = new List<MzVisit>();
            try
            {
                list = _mzVisitRepository.GetMzVisitsByDate(patient_id, begin, end);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<MzVisit>>(ex.Message);
            }
            return list;
        }

        public ResponseResult<List<MzVisit>> CreateVisitRecord(string haoming_code, string patient_id, int times, int expertflag, string unit_sn, string doctor_sn)
        {
            Log.Information($"GetMzVisitsByDate,{haoming_code},{patient_id},{patient_id},{times},{expertflag},{unit_sn}, {doctor_sn}");
            var list = new List<MzVisit>();
            try
            {
                list = _mzVisitRepository.CreateVisitRecord(haoming_code, patient_id, times, expertflag, unit_sn, doctor_sn);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<MzVisit>>(ex.Message);
            }
            return list;
        }


        public ResponseResult<List<MzOrder>> GetMzOrdersByPatientId(string patient_id, int times)
        {
            Log.Information($"GetMzOrdersByPatientId,{patient_id},{times}");
            var list = new List<MzOrder>();
            try
            {
                list = _mzOrderRepository.GetMzOrdersByPatientId(patient_id, times);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<MzOrder>>(ex.Message);
            }
            return list;
        }
        public ResponseResult<List<CprCharges>> GetCprCharges(string patient_id, int times, string charge_status)
        {
            Log.Information($"GetCprCharges,{patient_id},{times},{charge_status}");
            var list = new List<CprCharges>();
            try
            {
                list = _cprChargesRepository.GetCprCharges(patient_id, times, charge_status);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<CprCharges>>(ex.Message);
            }
            return list;
        }
        public ResponseResult<List<CprCharges>> GetDrugDetails(string p_id, int ledger_sn, string tbl_flag)
        {
            Log.Information($"GetDrugDetails,{p_id},{ledger_sn},{tbl_flag}");
            var list = new List<CprCharges>();
            try
            {
                list = _cprChargesRepository.GetDrugDetails(p_id, ledger_sn, tbl_flag);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<CprCharges>>(ex.Message);
            }
            return list;
        }

        public ResponseResult<List<Unit>> GetUnits()
        {
            Log.Information($"GetUnits");
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

        public ResponseResult<int> Pay(string patient_id, int times, string pay_string, string order_no_str, string opera)
        {
            Log.Information($"Pay,{patient_id},{times},{pay_string},{order_no_str},{opera}");
            try
            {
                return _mzOrderRepository.Pay(patient_id, times, pay_string, order_no_str, opera);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<int>(ex.Message);
            }
        }
        public ResponseResult<List<MzOrderReceipt>> GetReceipts(string cash_opera, string begin_date, string end_date, string bar_code, string status)
        {
            Log.Information($"GetReceipts,{cash_opera},{begin_date},{end_date},{bar_code},{status}");
            try
            {
                return _mzOrderReceiptRepository.GetReceipts(cash_opera, begin_date, end_date, bar_code, status);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<MzOrderReceipt>>(ex.Message);
            }
        }

        public ResponseResult<List<MzDeposit>> GetMzDepositsByPatientId(string patient_id, int ledger_sn)
        {
            Log.Information($"GetMzDepositsByPatientId,{patient_id},{ledger_sn}");
            try
            {
                return _mzDepositRepository.GetMzDepositsByPatientId(patient_id, ledger_sn);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<MzDeposit>>(ex.Message);
            }

        }

        public ResponseResult<bool> BackFee(string opera, string pid, int ledger_sn, string receipt_sn, string receipt_no, string cheque_cash, string isall = "1")
        {
            Log.Information($"BackFee,{opera},{pid},{ledger_sn},{receipt_sn},{receipt_no},{cheque_cash},{isall}");
            try
            {
                return _mzOrderRepository.BackFee(opera, pid, ledger_sn, receipt_sn, receipt_no, cheque_cash, isall);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<bool>(ex.Message);
            }
        }
        public ResponseResult<bool> BackFeePart(string opera, string pid, int ledger_sn, string receipt_sn, string receipt_no, string cheque_cash, string refund_item_str)
        {
            Log.Information($"BackFeePart,{opera},{pid},{ledger_sn},{receipt_sn},{receipt_no},{cheque_cash},{refund_item_str}");
            try
            {
                return _mzOrderRepository.BackFeePart(opera, pid, ledger_sn, receipt_sn, receipt_no, cheque_cash, refund_item_str);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<bool>(ex.Message);
            }
        }

        public ResponseResult<bool> SaveOrder(string patient_id, int times, string order_string, string opera)
        {
            Log.Information($"SaveOrder,{patient_id},{times},{order_string},{opera}");
            try
            {
                return _mzOrderRepository.SaveOrder(patient_id, times, order_string, opera);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<bool>(ex.Message);
            }
        }

        public ResponseResult<bool> CallCprCharges(string user_mi, string patient_id, int times, string status)
        {
            Log.Information($"CallCprCharges,{user_mi},{patient_id},{times},{status}");
            try
            {
                return _cprChargesRepository.CallCprCharges(user_mi, patient_id, times, status);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<bool>(ex.Message);
            }
        }
        public ResponseResult<List<OrderType>> GetOrderTypes()
        {
            Log.Information($"GetOrderTypes,");
            try
            {
                return _orderTypeRepository.GetOrderTypes();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<OrderType>>(ex.Message);
            }
        }


        public ResponseResult<List<MzOrderItem>> GetMzOrderItem(string order_type, string py_code)
        {
            Log.Information($"GetMzOrderItem,{order_type},{py_code}");
            try
            {
                return _mzOrderItemRepository.GetMzOrderItem(order_type, py_code);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<MzOrderItem>>(ex.Message);
            }
        }
        public ResponseResult<bool> AddFpData(string patient_id, int ledger_sn, string billBatchCode, string billNo, string random, string createTime, string billQRCode, string pictureUrl, string pictureNetUrl, string subsys_id)
        {
            Log.Information($"AddFpData,{patient_id},{ledger_sn},{billBatchCode},{billNo},{random},{createTime},{billQRCode},{pictureUrl},{pictureNetUrl},{subsys_id}");
            try
            {
                return _fpDataRepository.AddFpData(patient_id, ledger_sn, billBatchCode, billNo, random, createTime, billQRCode, pictureUrl, pictureNetUrl, subsys_id);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<bool>(ex.Message);
            }
        }
        public ResponseResult<List<FpData>> GetFpDatasByParams(string patient_id, int ledger_sn, string subsys_id)
        {
            Log.Information($"GetFpDatasByParams,{patient_id},{ledger_sn},{subsys_id}");
            try
            {
                return _fpDataRepository.GetFpDatasByParams(patient_id, ledger_sn, subsys_id);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<FpData>>(ex.Message);
            }
        }
        public ResponseResult<int> AddMzThridPay(string patient_id, string cheque_type, string cheque_no, string mdtrt_id, string ipt_otp_no, string psn_no, string yb_insuplc_admdvs, string charge, string price_date, string opera)
        {
            Log.Information($"AddMzThridPay,{patient_id},{cheque_type},{cheque_no},{mdtrt_id},{ipt_otp_no},{psn_no},{yb_insuplc_admdvs},{charge},{price_date},{opera}");
            try
            {
                return _mzThirdPayRepository.AddMzThridPay(patient_id, cheque_type, cheque_no, mdtrt_id, ipt_otp_no, psn_no, yb_insuplc_admdvs, charge,price_date, opera);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<int>(ex.Message);
            }
        }

        public ResponseResult<int> RefundMzThridPay(string patient_id, string cheque_type, string cheque_no, string charge, string price_date)
        {
            Log.Information($"RefundMzThridPay,{patient_id},{cheque_type},{cheque_no},{charge},{price_date}");
            try
            {
                return _mzThirdPayRepository.RefundMzThridPay(patient_id, cheque_type, cheque_no, charge, price_date);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<int>(ex.Message);
            }
        } 

    }
}
