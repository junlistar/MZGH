using Microsoft.AspNetCore.Mvc;
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
using System.Net.Http;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;

namespace CoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class YbInfoController : ApiControllerBase
    {
        private readonly IMzWebReportRepository _mzWebReportRepository;  
        private readonly IYbInfoRepository _ybInfoRepository;

        public YbInfoController(IMzWebReportRepository mzWebReportRepository, IYbInfoRepository ybInfoRepository)
        {
            _mzWebReportRepository = mzWebReportRepository;
            _ybInfoRepository = ybInfoRepository;
        }

        [HttpGet]
        public string GetTest()
        {
            return "ok";
        }

      
        public ResponseResult<bool> AddYB1101()
        {
            Log.Information($"AddYB1101,");
            try
            {   //获取RequestBody流
                StreamReader sr = new StreamReader(Request.Body, Encoding.GetEncoding("UTF-8"));
                string strData = sr.ReadToEndAsync().Result;
                Log.Information($"============== {strData}");
                return _ybInfoRepository.AddYB1101(strData);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<bool>(ex.Message);
            }
        }

        public ResponseResult<bool> AddYB2201()
        {
            Log.Information($"AddYB2201,");
            try
            {   //获取RequestBody流
                StreamReader sr = new StreamReader(Request.Body, Encoding.GetEncoding("UTF-8"));
                string strData = sr.ReadToEndAsync().Result;
                Log.Information($"============== {strData}");
                return _ybInfoRepository.AddYB2201(strData);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<bool>(ex.Message);
            }
        }
        public ResponseResult<bool> AddYB2203()
        {
            Log.Information($"AddYB2203,");
            try
            {   //获取RequestBody流
                StreamReader sr = new StreamReader(Request.Body, Encoding.GetEncoding("UTF-8"));
                string strData = sr.ReadToEndAsync().Result;
                Log.Information($"============== {strData}");
                return _ybInfoRepository.AddYB2203(strData);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<bool>(ex.Message);
            }
        }

        public ResponseResult<bool> AddYB2204()
        {
            Log.Information($"AddYB2204,");
            try
            {   //获取RequestBody流
                StreamReader sr = new StreamReader(Request.Body, Encoding.GetEncoding("UTF-8"));
                string strData = sr.ReadToEndAsync().Result;
                Log.Information($"============== {strData}");
                return _ybInfoRepository.AddYB2204(strData);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<bool>(ex.Message);
            }
        }

        public ResponseResult<bool> AddYB2207()
        {
            Log.Information($"AddYB2207,");
            try
            {   //获取RequestBody流
                StreamReader sr = new StreamReader(Request.Body, Encoding.GetEncoding("UTF-8"));
                string strData = sr.ReadToEndAsync().Result;
                Log.Information($"============== {strData}");
                return _ybInfoRepository.AddYB2207(strData);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<bool>(ex.Message);
            }
        }
         
        public ResponseResult<List<Insutype>> GetInsutypes()
        {
            Log.Information($"GetInsutypes,");
            try
            {    
                return _ybInfoRepository.GetInsutypes();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<Insutype>>(ex.Message);
            }
        }
        public ResponseResult<List<MdtrtCertType>> GetMdtrtCertTypes()
        {
            Log.Information($"GetMdtrtCertTypes,");
            try
            {
                return _ybInfoRepository.GetMdtrtCertTypes();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<MdtrtCertType>>(ex.Message);
            }
        }
        public ResponseResult<List<MedType>> GetMedTypes()
        {
            Log.Information($"GetMedTypes,");
            try
            {
                return _ybInfoRepository.GetMedTypes();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<MedType>>(ex.Message);
            }
        }
        public ResponseResult<List<DiagType>> GetDiagTypes()
        {
            Log.Information($"GetDiagTypes,");
            try
            {
                return _ybInfoRepository.GetDiagTypes();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<DiagType>>(ex.Message);
            }
        }
        public ResponseResult<List<IcdCode>> GetIcdCodes()
        {
            Log.Information($"GetIcdCodes,");
            try
            {
                return _ybInfoRepository.GetIcdCodes();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<IcdCode>>(ex.Message);
            }
        }
        public ResponseResult<List<BirctrlType>> GetBirctrlTypes()
        {
            Log.Information($"GetBirctrlTypes,");
            try
            {
                return _ybInfoRepository.GetBirctrlTypes();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<BirctrlType>>(ex.Message);
            }
        }
        public ResponseResult<UserInfoResponseModel> GetYjsUserInfo(string patient_id, int admiss_times)
        {
            Log.Information($"GetYbkDetailInfo");
            try
            {
                return _ybInfoRepository.GetYjsUserInfo(patient_id, admiss_times);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<UserInfoResponseModel>(ex.Message);
            }
        }
    }
}
