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
    public class SubSystemController : ApiControllerBase
    {
        private readonly ISubSystemRepository _subSystemRepository; 

        public SubSystemController(ISubSystemRepository subSystemRepository)
        {
            _subSystemRepository = subSystemRepository; 
        }

        [HttpGet]
        public string GetTest()
        {
            return "ok";
        }

        
        public ResponseResult<List<SubSystem>> GetSubSystems()
        {
            Log.Information($"GetSubSystems,");
            try
            {
                return _subSystemRepository.GetSubSystems();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<SubSystem>>(ex.Message);
            }
        }

        public ResponseResult<bool> UpdateSubSystem()
        {
            Log.Information($"UpdateSubSystem,");
            try
            {   //获取RequestBody流
                StreamReader sr = new StreamReader(Request.Body, Encoding.GetEncoding("UTF-8"));
                string strData = sr.ReadToEndAsync().Result;
                Log.Information($"============== {strData}");
                return _subSystemRepository.UpdateSubSystem(strData);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<bool>(ex.Message);
            }
        } 
    }
}
