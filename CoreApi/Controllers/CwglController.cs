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
    public class CwglController : ApiControllerBase
    {
        private readonly IGhDailyReportRepository _ghDailyReportRepository;
        private readonly IReportDataFastRepository _reportDataFastRepository;

        public CwglController(IGhDailyReportRepository ghDailyReportRepository, IReportDataFastRepository reportDataFastRepository)
        {
            _ghDailyReportRepository = ghDailyReportRepository;
            _reportDataFastRepository = reportDataFastRepository;
        }

        [HttpGet]
        public string GetTest()
        {
            return "ok";
        }

        /// <summary>
        /// 挂号日结
        /// </summary>
        /// <param name="opera"></param>
        /// <param name="report_date"></param>
        /// <param name="mz_dept_no"></param>
        /// <returns></returns>
        public ResponseResult<List<string>> GetGhDailyReport(string opera, string report_date, string mz_dept_no)
        {
            Log.Information($"GetGhDailyReport,{opera},{report_date},{mz_dept_no}");
            List<string> list;
            try
            {
                list = _ghDailyReportRepository.GetGhDailyReport(opera, report_date, mz_dept_no);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<string>>(ex.Message);
            }
            return list;
        }



        public ResponseResult<string> GetGhDailyByReportCode(string code, string report_date, string price_opera, string mz_dept_no)
        {
            Log.Information($"GetGhDailyByReportCode,{code},{report_date},{price_opera},{mz_dept_no}");
            try
            {
                var dt = _reportDataFastRepository.GetGhDailyByReportCode(code, report_date, price_opera, mz_dept_no);

                return JsonConvert.SerializeObject(dt, new DataTableConverter());
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<string>(ex.Message);
            }
        }
    }
}
