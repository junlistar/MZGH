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
        private readonly ISubSystemGroupRepository _subSystemGroupRepository;

        public SubSystemController(ISubSystemRepository subSystemRepository, ISubSystemGroupRepository subSystemGroupRepository)
        {
            _subSystemRepository = subSystemRepository;
            _subSystemGroupRepository = subSystemGroupRepository;
        }

        [HttpGet]
        public string GetTest()
        {
            return "ok 1208";
        }

        [HttpGet]
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
        [HttpGet]
        public ResponseResult<bool> DeleteSubSystem(string sys_code)
        {
            Log.Information($"DeleteSubSystem,{sys_code}");
            try
            {
                return _subSystemRepository.DeleteSubSystem(sys_code);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<bool>(ex.Message);
            }
        }
        [HttpGet]
        public ResponseResult<List<SubSystemGroup>> GetSubSystemGroups()
        {
            Log.Information($"GetSubSystemGroups,");
            try
            {
                return _subSystemGroupRepository.GetSubSystemGroups();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<SubSystemGroup>>(ex.Message);
            }
        }
        [HttpGet]
        public ResponseResult<List<YpGroup>> GetGroupNames()
        {
            Log.Information($"GetGroupNames,");
            try
            {
                return _subSystemGroupRepository.GetGroupNames();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<YpGroup>>(ex.Message);
            }
        }
        [HttpGet]
        public ResponseResult<List<string>> GetSubsysIds(string user_name)
        {
            Log.Information($"GetSubsysIds,");
            try
            {
                return _subSystemGroupRepository.GetSubsysIds(user_name);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<string>>(ex.Message);
            }
        }

        public ResponseResult<bool> UpdateSubSystemGroup()
        {
            Log.Information($"UpdateSubSystemGroup,");
            try
            {   //获取RequestBody流
                StreamReader sr = new StreamReader(Request.Body, Encoding.GetEncoding("UTF-8"));
                string strData = sr.ReadToEndAsync().Result;
                Log.Information($"============== {strData}");
                return _subSystemGroupRepository.UpdateSubSystemGroup(strData);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<bool>(ex.Message);
            }
        }
        [HttpGet]

        public ResponseResult<bool> DeleteSubSystemGroup(string sys_code)
        {
            Log.Information($"DeleteSubSystemGroup,{sys_code}");
            try
            {
                return _subSystemGroupRepository.DeleteSubSystemGroup(sys_code);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<bool>(ex.Message);
            }
        }
        public ResponseResult<bool> UpdateMainClientConfig()
        {
            Log.Information($"UpdateMainClientConfig,");
            try
            {   //获取RequestBody流
                StreamReader sr = new StreamReader(Request.Body, Encoding.GetEncoding("UTF-8"));
                string strData = sr.ReadToEndAsync().Result;
                Log.Information($"============== {strData}");
                return _subSystemRepository.UpdateMainClientConfig(strData);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<bool>(ex.Message);
            }
        }
        [HttpGet]
        public ResponseResult<MainClientConfig> GetMainClientConfig()
        {
            Log.Information($"GetMainClientConfig");
            try
            {
                return _subSystemRepository.GetMainClientConfig();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<MainClientConfig>(ex.Message);
            }
        }

    }
}
