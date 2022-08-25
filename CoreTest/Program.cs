using Data.Repository;
using Data.Repository.Mzsf;
using Newtonsoft.Json;
using System;
using System.Security.Cryptography;
using System.Text;

namespace CoreTest
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //var ds =  Data.Helpers.ConfigHelper.GetSectionValue("sql1");

            // var a = 1;
            //GhRefundRepository ghRefundRepository = new GhRefundRepository();
            //var listttt = ghRefundRepository.GetGhRefund("2022-04-22", "00029694400");


            //patient_id=000296936900&ledger_sn=3&cheque_type=12&item_no=3&charge=0.30&opera=00000
            // GhDepositRepository rep = new GhDepositRepository();
            // rep.Refund("000296936900", 3, "12","3",(decimal)0.30, "00000");

            //PatientRepository po = new PatientRepository();
            //po.TestDBConnection();
            //po.GuaHao("000296903300", "4396228", "1-11.9-202204221544463606,14-5-202204221544482643", "00000");

            //123456654323,,乔治,1,2022-04-25,13244445555,,,,01,01
            //po.EditUserInfo("", "421002199007181111", "", "", "李军", "1", "1990-07-18", "13122223333", "120301", "吾悦", "165", "06", "01");
            //EditUserInfo,,42100219900718351X,,,李军,1,1990 - 07 - 18,13122223333,120301,吾悦,165,06,01


            //CreateRequestRecord,2022-05-05,2022-05-06,3,-1,00000
            //BaseRequestRepository _baseRequestRepository = new BaseRequestRepository() ;
            //var list = _baseRequestRepository.GetBaseRequests("","","","","","3","","","");

            //GhRequestRepository rsp = new GhRequestRepository();
            //rsp.CreateRequestRecord("2022-05-24", "2022-05-24", "1", 1, "00040");

            //CreateRequestRecord,2022-05-24,2022-05-24,1,1,00040

            //BaseRequestRepository baseRequestRepository = new BaseRequestRepository();
            //2022-07-20,2022-07-20, %,  %,  %,  %,  01,%,  %,  % 
            // var dt = baseRequestRepository.GetRequestsByParamsV2("2022-07-20", "2022-07-20", "%", "%", "%", "%", "01", "%", "%", "%");

            //baseRequestRepository.GetBaseRequestsByWeekDay("2022-05-30 00:00:00", "2022-05-30 23:59:59", "1", -1);
            // ?begin=&end=&weeks=3&day=-1

            //GhSearchRepository resp = new GhSearchRepository();
            //var list = resp.GhSearchList("2022-05-11", "%","%", "%", "%", "%", "a", "%", "任慧","%" );//GhSearchList,||  ||end

            // ReportDataFastRepository rdf = new ReportDataFastRepository();
            //var sql = rdf.GetSqlByTag(220001);

            //  var ds = rdf.GetReportDataByCode("220001","test");


            //GetRequestsByDate,2022-05-30 00:00:00,2022-05-30 23:59:59 
            //CreateRequestRecord,,2022-05-30,1,1,00040
            // rsp.CreateRequestRecord("2022-05-30", "2022-05-30", "1", 1, "00040");

            MzOrderRepository mzOrderRepository = new MzOrderRepository();
            //http://localhost:5010//api/mzsf/pay?patient_id=000296903300&times=307&pay_string=11-86-202206161056566431&opera=00000
            //patient_id=000296903300&times=317&pay_string=12-292.8-202206201617482429&opera=00000
            //var re = mzOrderRepository.Pay("000296903300", 320, "12-156.34-202206231105297670", "00000");

            //SaveOrder,000296903300,320,02-003528-1,02-003647-1,00000 
            ///api/mzsf/SaveOrder?patient_id=000266966600&times=23&order_string=01-2-702398-**-1,01-2-702398-**-1,01-2-702398-**-2&opera=00000

            var re = mzOrderRepository.SaveOrder("000266966600", 23, "01-2-702398-**-1,01-2-702398-**-1,01-2-702398-**-2", "00000");


            ///api/mzsf/BackFeePart?opera=00000&pid=000296995400&ledger_sn=6&receipt_sn=2581058&receipt_no=1012067632&cheque_cash=;14;11;12&refund_item_str=01-201252-1


            // GhDailyReportRepository ghDailyReport = new GhDailyReportRepository();
            //var re = ghDailyReport.SaveGhDaily("00000");


            //ReportDataFastRepository reportDataFastRepository = new ReportDataFastRepository();
            //reportDataFastRepository.GetMzsfDailyByReportCode("220010","1900-01-01 00:00:00","00000","1");

            // RequestTimeRepository rr = new RequestTimeRepository();
            //var aaa = rr.GetRequestTimes();

            //Schb,2022-07-18,2022-07-24,00000
            //GhRequestRepository ghRequestRepository = new GhRequestRepository();
            //ghRequestRepository.Schb("2022-07-25", "2022-07-31", "00000");


            //btnRePrint_Click();

            //000174985600&times=20&order_string=01-2-700261-**-1&opera=00000
            ////SaveOrder,000174985600,22,01-2-700261--1,00000
            // MzOrderRepository mzOrderRepository = new MzOrderRepository();
            //var rr = mzOrderRepository.SaveOrder("000174985600", 22, "01-2-700261--1", "00000");

            /////api/mzsf/pay?patient_id=000189394100&times=20&pay_string=c-23-202208121512124997,3-44-202208121512158243,1-49-&order_no_str=1&opera=00000
            // var aaa  = mzOrderRepository.Pay("000189394100", 20, "c-23-202208121512124997,3-44-202208121512158243,1-49-", "1", "00000");
            ///api/mzsf/GetFPRegistrationData?patient_id=000174985600&ledger_sn=40&admiss_times=1
            FpDataRepository fpDataRepository = new FpDataRepository();
            var aa =fpDataRepository.GetFPRegistrationData("000174985600", 40, 1);

            Console.WriteLine("Hello World!");
        }


        public static void btnRePrint_Click()
        {
            //补打电子发票
            string ip = "127.0.0.1";
            string port = "13526";
            string dllName = "NontaxIndustry";
            string func = "CallNontaxIndustry";

            string noise = Guid.NewGuid().ToString();

            string appid = "JZSZXYY0561116";
            string key = "08d7323b667db6b93bcb1be7d7";
            string version = "1.0";

            string method = "printElectBill";

            var _data = new
            {
                billBatchCode = "42060120",
                billNo = "0008214465",
                random = "a87b2c",
            };

            var stringA = $"appid={appid}&data={Base64Encode(JsonConvert.SerializeObject(_data))}&noise={noise}";
            var stringSignTemp = stringA + $"&key={key}&version={version}";

            var _sign = GenerateMD5(stringSignTemp).ToUpper();

            var _params = new
            {
                appid = appid,
                data = Base64Encode(JsonConvert.SerializeObject(_data)),
                noise = noise,
                version = version,
                sign = _sign
            };

            var _payload = new
            {
                method = method,
                @params = _params
            };
            string payload = Base64Encode(JsonConvert.SerializeObject(_payload));


            string url = $"http://{ip}:{port}/extend?dllName={dllName}&func={func}&payload={payload}";

        }
        /// <summary>
        /// MD5字符串加密
        /// </summary>
        /// <param name="txt"></param>
        /// <returns>加密后字符串</returns>
        public static string GenerateMD5(string txt)
        {
            using (MD5 mi = MD5.Create())
            {
                byte[] buffer = Encoding.Default.GetBytes(txt);
                //开始加密
                byte[] newBuffer = mi.ComputeHash(buffer);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < newBuffer.Length; i++)
                {
                    sb.Append(newBuffer[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
        public static string Base64Encode(string str)
        {
            var _strBytes = System.Text.Encoding.UTF8.GetBytes(str);
            return System.Convert.ToBase64String(_strBytes);
        }
        public static string Base64Decode(string base64EncodeData)
        {
            var _base64EncodeBytes = System.Convert.FromBase64String(base64EncodeData);
            return System.Text.Encoding.UTF8.GetString(_base64EncodeBytes);
        }
    }
}
