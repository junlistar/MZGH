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
    public class UserController : ApiControllerBase
    {
        private readonly IMzPatientSfzRepository _mzPatientSfzRepository;
        private readonly ISfzInfoRepository _sfzInfoRepository;
        private readonly IYbkInfoRepository _ybkInfoRepository;

        public UserController(IMzPatientSfzRepository mzPatientSfzRepository, ISfzInfoRepository sfzInfoRepository, IYbkInfoRepository ybkInfoRepository)
        {
            _mzPatientSfzRepository = mzPatientSfzRepository;
            _sfzInfoRepository = sfzInfoRepository;
            _ybkInfoRepository = ybkInfoRepository;
        }

        [HttpGet]
        public string GetTest()
        {
            return "ok";
        }

        /// <summary>
        /// 查询病人Id关联身份证信息
        /// </summary>
        /// <param name="patient_id"></param>
        /// <returns></returns>
        public ResponseResult<List<MzPatientSfz>> GetDataBySfzId(string sfz_id)
        {
            Log.Information($"GetDataBySfzId,{sfz_id}");
            List<MzPatientSfz> list;
            try
            {
                list = _mzPatientSfzRepository.GetDataBySfzId(sfz_id);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<MzPatientSfz>>(ex.Message);
            }
            return list;
        }

        public ResponseResult<bool> UpdateSfzInfo(string name, string sex, string address, string folk, string birthday, string card_no)
        {
            Log.Information($"UpdateSfzInfo,{name},{sex},{address},{folk},{birthday},{card_no}");
            try
            {
                return _sfzInfoRepository.UpdateSfzInfo(name, sex, address, address, folk, birthday, card_no);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<bool>(ex.Message);
            }
        }
        public ResponseResult<bool> UpdateUserBaseInfo(string pid, string name, string sex, string marry_code, string birthday, string tel, string relation_name, string relation_code,
             string home_street, string opera)
        {
            Log.Information($"UpdateUserBaseInfo,{pid},{name},{sex},{marry_code},{birthday},{tel},{relation_name},{relation_code},{home_street},{opera}");
            try
            {
                return _sfzInfoRepository.UpdateUserBaseInfo(pid, name, sex, marry_code, birthday, tel, relation_name, relation_code, home_street, opera);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<bool>(ex.Message);
            }
        }

        public ResponseResult<bool> UpdateYbkInfo(string psn_no, string psn_cert_type, string certno, string psn_name, string gend, string naty, string brdy, int age)
        {
            Log.Information($"UpdateYbkInfo,{psn_no},{psn_cert_type},{certno},{psn_name},{gend},{naty},{brdy},{age}");
            try
            {
                return _ybkInfoRepository.UpdateYbkInfo(psn_no, psn_cert_type, certno, psn_name, gend, naty, brdy, age);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<bool>(ex.Message);
            }
        }
        public static T DeserializeObject<T>(string json)
        {
            JavaScriptSerializer Serializer = new JavaScriptSerializer();
            T objs = default(T);
            try
            {
                objs = Serializer.Deserialize<T>(json);
            }
            catch (Exception ex)
            {
                //LogHelper.Error("JSONHelper.DeserializeObject 转换对象失败。", ex);
                throw new Exception("JSONHelper.DeserializeObject<T>(string json): " + ex.Message);
            }
            return objs;

        }
        public ResponseResult<bool> UpdateYbkInfoAll()
        {
            Log.Information($"UpdateYbkInfoAll");
            try
            {
                //获取RequestBody流
                StreamReader sr = new StreamReader(Request.Body, Encoding.GetEncoding("UTF-8"));
                //异步读取从当前位置到流结尾的所有字符，并将它们作为一个字符串返回。
                string strData = sr.ReadToEndAsync().Result;
                Log.Information($"============== {strData}");

                //YBResponse<UserInfoResponseModel> yBResponse = JsonConvert.DeserializeObject<YBResponse<UserInfoResponseModel>>(jsonStr);
                return _ybkInfoRepository.UpdateYbkInfoAll(strData);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<bool>(ex.Message);
            }
        }
        public ResponseResult<UserInfoResponseModel> GetYbkDetailInfo(string certno)
        {
            Log.Information($"GetYbkDetailInfo");
            try
            {
                return _ybkInfoRepository.GetYbkDetailInfo(certno);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<UserInfoResponseModel>(ex.Message);
            }
        }

    }
}
