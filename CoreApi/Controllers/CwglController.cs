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
        private readonly IMzsfDailyReportRepository _mzsfDailyReportRepository;
        private readonly IReportDataFastRepository _reportDataFastRepository;

        public CwglController(IGhDailyReportRepository ghDailyReportRepository, IReportDataFastRepository reportDataFastRepository, IMzsfDailyReportRepository mzsfDailyReportRepository)
        {
            _ghDailyReportRepository = ghDailyReportRepository;
            _reportDataFastRepository = reportDataFastRepository;
            _mzsfDailyReportRepository = mzsfDailyReportRepository;
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
        public ResponseResult<bool> SaveGhDaily(string opera)
        {
            Log.Information($"GetGhDailyReport,{opera}");
         
            try
            {
                return _ghDailyReportRepository.SaveGhDaily(opera);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<bool>(ex.Message);
            } 
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
        public ResponseResult<string> GetMzghBill(string code, string patient_id, string times)
        {
            Log.Information($"GetMzghBill,{code},{patient_id},{times}");
            try
            {
                var dt = _reportDataFastRepository.GetMzghBill(code, patient_id, times);

                return JsonConvert.SerializeObject(dt, new DataTableConverter());
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<string>(ex.Message);
            }
        }
        public ResponseResult<string> GetMzsfBill(string code, string patient_id, string ledger_sn)
        {
            Log.Information($"GetMzsfBill,{code},{patient_id},{ledger_sn}");
            try
            {
                var dt = _reportDataFastRepository.GetMzsfBill(code, patient_id, ledger_sn);

                return JsonConvert.SerializeObject(dt, new DataTableConverter());
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<string>(ex.Message);
            }
        }
       public ResponseResult<string> GetMzsfDailyByReportCode(string code, string report_date, string price_opera, string cash_date)
        {
            Log.Information($"GetMzsfDailyByReportCode,{code},{report_date},{price_opera},{cash_date}");
            try
            {
                var dt = _reportDataFastRepository.GetMzsfDailyByReportCode(code, report_date, price_opera, cash_date);

                return JsonConvert.SerializeObject(dt, new DataTableConverter());
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<string>(ex.Message);
            }
        }

        public ResponseResult<List<string>> GetMzsfReport(string opera, string report_date)
        {
            Log.Information($"GetMzsfReport,{opera},{report_date}");
            List<string> list;
            try
            {
                list = _mzsfDailyReportRepository.GetMzsfReport(opera, report_date);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<List<string>>(ex.Message);
            }
            return list;
        }
        public ResponseResult<bool> SaveMzsfDaily(string opera, string cash_date)
        {
            Log.Information($"SaveMzsfDaily,{opera},{cash_date}");
            try
            {
                return _mzsfDailyReportRepository.SaveMzsfDaily(opera, cash_date);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return ErrorResult<bool>(ex.Message);
            }
        }

         
    }
}
