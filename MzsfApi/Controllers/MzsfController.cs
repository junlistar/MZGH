﻿using Microsoft.AspNetCore.Mvc;
using MzsfData.IRepository;
using MzsfData.Helpers;
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
using MzsfData.Entities;

namespace MzsfApi.Controllers
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
        

        public MzsfController(IUserLoginRepository userLoginRepository, IClinicTypeRepository clinicTypeRepository,
             IUserDicRepository userDicRepository, IChargeTypeRepository chargeTypeRepository, IDistrictCodeRepository districtCodeRepository,
            IOccupationCodeRepository occupationCodeRepository, IResponceTypeRepository responceTypeRepository,IChargeItemRepository chargeItemRepository,
            IPatientRepository patientRepository, IMzOrderRepository mzOrderRepository, ICprChargesRepository cprChargesRepository, 
            IUnitRepository unitRepository, IMzVisitRepository mzVisitRepository, IMzOrderReceiptRepository mzOrderReceiptRepository)
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
        public ResponseResult<List<MzVisit>> GetMzVisitsByDate(string patient_id, string begin, string end) {
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

        public ResponseResult<bool> Pay(string patient_id, int times, string pay_string, string opera)
        {
            Log.Information($"Pay,{patient_id},{times},{pay_string},{opera}");
            try
            {
                return _mzOrderRepository.Pay(patient_id,  times,  pay_string,  opera);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<bool>(ex.Message);
            } 
        }
        public ResponseResult<List<MzOrderReceipt>> GetReceipts(string cash_opera, string begin_date, string end_date)
        {
            Log.Information($"GetReceipts,{cash_opera},{begin_date},{end_date}");
            try
            {
                return _mzOrderReceiptRepository.GetReceipts(cash_opera, begin_date, end_date);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<MzOrderReceipt>>(ex.Message);
            }
        }
    }
}
