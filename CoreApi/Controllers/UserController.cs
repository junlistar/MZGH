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
    public class UserController : ApiControllerBase
    {
        private readonly IMzPatientSfzRepository _mzPatientSfzRepository; 

        public UserController(IMzPatientSfzRepository mzPatientSfzRepository)
        {
            _mzPatientSfzRepository = mzPatientSfzRepository;
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
        public ResponseResult<List<MzPatientSfz>> GetDataByPatientId(string patient_id)
        {
            Log.Information($"GetDataByPatientId,{patient_id}");
            List<MzPatientSfz> list;
            try
            {
                list = _mzPatientSfzRepository.GetDataByPatientId(patient_id);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<MzPatientSfz>>(ex.Message);
            }
            return list;
        }
      
         
    }
}
