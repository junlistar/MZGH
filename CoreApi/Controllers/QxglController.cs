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
using Data.IRepository; 

namespace CoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class QxglController : ApiControllerBase
    {
        private readonly IXTGroupRepository _xTGroupRepository; 
        private readonly IXTUserRepository _xTUserRepository;
        private readonly IXTUserGroupRepository _xTUserGroupRepository;
        private readonly IXTUserReportRepository _xTUserReportRepository;

        public QxglController(IXTGroupRepository xTGroupRepository, IXTUserRepository xTUserRepository,
            IXTUserGroupRepository xTUserGroupRepository, IXTUserReportRepository xTUserReportRepository)
        {
            _xTGroupRepository = xTGroupRepository;
            _xTUserRepository = xTUserRepository;
            _xTUserGroupRepository = xTUserGroupRepository;
            _xTUserReportRepository = xTUserReportRepository;
        }

        [HttpGet]
        public string GetTest()
        {
            return "ok";
        }

         
        public ResponseResult<List<XTGroup>> GetXTGroupsBySysId(string subsys_id)
        {
            Log.Information($"GetXTGroupsBySysId,{subsys_id}");
            List<XTGroup> list;
            try
            {
                list = _xTGroupRepository.GetXTGroupsBySysId(subsys_id);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<XTGroup>>(ex.Message);
            }
            return list;
        }
        public ResponseResult<List<XTUser>> GetXTUsersBySysId(string subsys_id, string user_group)
        {
            Log.Information($"GetXTUsersBySysId,{subsys_id}");
            List<XTUser> list;
            try
            {
                list = _xTUserRepository.GetXTUsersBySysId(subsys_id, user_group);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<XTUser>>(ex.Message);
            }
            return list;
        }

        public ResponseResult<List<XTUserGroup>> GetXTUserGroupsBySysId(string subsys_id, string user_group)
        {
            Log.Information($"GetXTUserGroupsBySysId,{subsys_id}");
            List<XTUserGroup> list;
            try
            {
                list = _xTUserGroupRepository.GetXTUserGroupsBySysId(subsys_id, user_group);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<XTUserGroup>>(ex.Message);
            }
            return list;
        }
        public ResponseResult<List<XTUserReport>> GetXTUserReportsBySysId(string subsys_id, string user_group)
        {
            Log.Information($"GetXTUserReportsBySysId,{subsys_id}");
            List<XTUserReport> list;
            try
            {
                list = _xTUserReportRepository.GetXTUserReportsBySysId(subsys_id, user_group);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<XTUserReport>>(ex.Message);
            }
            return list;
        }
         

    }
}
