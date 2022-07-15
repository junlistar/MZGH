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
        public ResponseResult<int> AddXTGroup(string group_name, string subsys_id)
        {
            Log.Information($"AddXTGroup,{group_name},{subsys_id}");
            
            try
            {
                return _xTGroupRepository.AddXTGroup(group_name,subsys_id);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<int>(ex.Message);
            }
           
        }
        public ResponseResult<int> DeleteXTGroup(string user_group, string subsys_id)
        {
            Log.Information($"DeleteXTGroup,{user_group},{subsys_id}");

            try
            {
                return _xTGroupRepository.DeleteXTGroup(user_group, subsys_id);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<int>(ex.Message);
            }

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

        public ResponseResult<int> AddXtUser(string user_name, string subsys_id, string pass_word, string user_group, string user_mi)
        {
            Log.Information($"AddXtUser,{user_name},{subsys_id}, {pass_word},{user_group}, {user_mi}");
  
            try
            {
                return _xTUserRepository.AddXtUser(user_name,subsys_id, pass_word,user_group, user_mi);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<int>(ex.Message);
            } 
        }
        public ResponseResult<int> DeleteXtUser(string user_name, string subsys_id, string user_group)
        {
            Log.Information($"DeleteXtUser,{user_name},{subsys_id},{user_group}");

            try
            {
                return _xTUserRepository.DeleteXtUser(user_name,subsys_id, user_group);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<int>(ex.Message);
            }
        }
         
        public ResponseResult<List<XTUserGroup>> GetXTUserGroupsByGroupId(string subsys_id, string user_group)
        {
            Log.Information($"GetXTUserGroupsByGroupId,{subsys_id}");
            List<XTUserGroup> list;
            try
            {
                list = _xTUserGroupRepository.GetXTUserGroupsByGroupId(subsys_id, user_group);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<XTUserGroup>>(ex.Message);
            }
            return list;
        }
        public ResponseResult<List<XTUserGroup>> GetXTUserGroups(string subsys_id)
        {
            Log.Information($"GetXTUserGroups,{subsys_id}");
            List<XTUserGroup> list;
            try
            {
                list = _xTUserGroupRepository.GetXTUserGroups(subsys_id);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<XTUserGroup>>(ex.Message);
            }
            return list;
        }

        public ResponseResult<bool> AddXtUserGroups(string func_str, string subsys_id, string user_group)
        {
            Log.Information($"AddXtUserGroups,{func_str},{subsys_id},{user_group}"); 
            try
            {
                return _xTUserGroupRepository.AddXtUserGroups(func_str,subsys_id, user_group);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<bool>(ex.Message);
            } 
        }
        public ResponseResult<bool> DeleteXtUserGroups(string func_str, string subsys_id, string user_group)
        {
            Log.Information($"DeleteXtUserGroups,{func_str},{subsys_id},{user_group}");
            try
            {
                return _xTUserGroupRepository.DeleteXtUserGroups(func_str, subsys_id, user_group);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<bool>(ex.Message);
            }
        }
        public ResponseResult<bool> AddFuncton(string subsys_id, string func_name, string func_desc, string parent_func, string action_flag)
        {
            Log.Information($"AddFuncton,{subsys_id},{func_name},{func_desc},{parent_func},{action_flag}");
            try
            {
                return _xTUserGroupRepository.AddFuncton(subsys_id, func_name, func_desc,  parent_func, action_flag);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<bool>(ex.Message);
            }
        }
        public ResponseResult<bool> UpdateFuncton(string subsys_id, string func_name, string func_desc, string parent_func, string action_flag)
        {
            Log.Information($"UpdateFuncton,{subsys_id},{func_name},{func_desc},{parent_func},{action_flag}");
            try
            {
                return _xTUserGroupRepository.UpdateFuncton(subsys_id, func_name, func_desc, parent_func, action_flag);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<bool>(ex.Message);
            }
        }
        public ResponseResult<bool> DelFuncton(string subsys_id, string func_name, string func_desc, string action_flag)
        {
            Log.Information($"DelFuncton,{subsys_id},{func_name},{func_desc},{action_flag}");
            try
            {
                return _xTUserGroupRepository.DelFuncton(subsys_id, func_name, func_desc, action_flag);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<bool>(ex.Message);
            }
        }

        public ResponseResult<List<XTUserReport>> GetXTUserReportsByGroupId(string subsys_id, string user_group)
        {
            Log.Information($"GetXTUserReportsByGroupId,{subsys_id}");
            List<XTUserReport> list;
            try
            {
                list = _xTUserReportRepository.GetXTUserReportsByGroupId(subsys_id, user_group);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<XTUserReport>>(ex.Message);
            }
            return list;
        }
        public ResponseResult<List<XTUserReport>> GetXTUserReports(string subsys_id)
        {
            Log.Information($"GetXTUserReports,{subsys_id}");
            List<XTUserReport> list;
            try
            {
                list = _xTUserReportRepository.GetXTUserReports(subsys_id);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<XTUserReport>>(ex.Message);
            }
            return list;
        }

        public ResponseResult<bool> AddXtUserReports(string rep_id, string subsys_id, string user_group)
        {
            Log.Information($"AddXtUserReports,{rep_id},{subsys_id},{user_group}"); 
            try
            {
                return _xTUserReportRepository.AddXtUserReports(rep_id, subsys_id, user_group);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<bool>(ex.Message);
            } 
        }
        public ResponseResult<bool> DelXtUserReports(string rep_id, string subsys_id, string user_group)
        {
            Log.Information($"DelXtUserReports,{rep_id},{subsys_id},{user_group}");
            try
            {
                return _xTUserReportRepository.DelXtUserReports(rep_id, subsys_id, user_group);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<bool>(ex.Message);
            }
        }

    }
}
