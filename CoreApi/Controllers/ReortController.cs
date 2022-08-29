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
    public class ReportController : ApiControllerBase
    {
        private readonly IMzWebReportRepository _mzWebReportRepository;  

        public ReportController(IMzWebReportRepository mzWebReportRepository )
        {
            _mzWebReportRepository = mzWebReportRepository; 
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
        public ResponseResult<List<MzWebReport>> GetMzWebReports()
        {
            Log.Information($"GetMzWebReports");
            List<MzWebReport> list;
            try
            {
                list = _mzWebReportRepository.GetMzWebReports();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<MzWebReport>>(ex.Message);
            }
            return list;
        }
        public ResponseResult<List<MzWebReport>> GetMzWebReportByCode(string code)
        {
            Log.Information($"GetMzWebReportByCode");
            List<MzWebReport> list;
            try
            {
                list = _mzWebReportRepository.GetMzWebReportByCode(code);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<MzWebReport>>(ex.Message);
            }
            return list;
        }
        public ResponseResult<bool> EditWebReportByJson()
        {
            Log.Information($"EditWebReportByJson,");
            try
            {   //获取RequestBody流
                StreamReader sr = new StreamReader(Request.Body, Encoding.GetEncoding("UTF-8"));
                string strData = sr.ReadToEndAsync().Result;
                Log.Information($"============== {strData}");
                return _mzWebReportRepository.EditMzWebReports(strData);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<bool>(ex.Message);
            }
        } 
    }
}
