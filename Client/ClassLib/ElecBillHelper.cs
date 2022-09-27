using Client.ViewModel;
using log4net;
using Newtonsoft.Json;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.ClassLib
{
    public enum BillTypeEnum
    {
        GuaHao = 1,
        ShouFei = 2
    } 

    public class ElecBillHelper
    {

        private static ILog log = LogManager.GetLogger(typeof(ElecBillHelper));//typeof放当前类



        public static bool InitCreateElecBillCom(string appid, string key, string weburl, string version, string ip, string port, string dllName, string func)
        {
            log.Debug("初始化电子发票");

            string method = "InitParams";
            string noise = Guid.NewGuid().ToString();

            var _data = new
            {
                url = weburl,
                appkey = key,
                type = "medical",
                testValue = "测试链接",
                printPreview = "0"
            };

            var stringA = $"appid={appid}&data={StringUtil.Base64Encode(JsonConvert.SerializeObject(_data))}&noise={noise}";

            //log.Debug("stringA:" + stringA);
            var stringSignTemp = stringA + $"&key={key}&version={version}";

            //log.Debug("stringSignTemp:" + stringSignTemp);

            var _sign = StringUtil.GenerateMD5(stringSignTemp).ToUpper();

            var _params = new
            {
                appid = appid,
                data = StringUtil.Base64Encode(JsonConvert.SerializeObject(_data)),
                noise = noise,
                version = version,
                sign = _sign
            };

            var _payload = new
            {
                method = method,
                @params = _params
            };
            string payload = StringUtil.Base64Encode(JsonConvert.SerializeObject(_payload));
            string url = $"http://{ip}:{port}/extend?dllName={dllName}&func={func}&payload={payload}";

            var json = HttpClientUtil.Get(url);

            if (json == "T2000")
            {
                return true;
            }
            return false;
        }


        public static bool CreateElecBill(string patient_id, int new_ledger_sn, int times, string je, BillTypeEnum billTypeEnum = BillTypeEnum.GuaHao)
        {
            try
            {

                string ip = ConfigurationManager.AppSettings["ip"];
                string port = ConfigurationManager.AppSettings["port"];
                string dllName = ConfigurationManager.AppSettings["dllName"];
                string func = ConfigurationManager.AppSettings["func"];

                string noise = Guid.NewGuid().ToString();

                string appid = ConfigurationManager.AppSettings["appid"];
                string key = ConfigurationManager.AppSettings["key"];
                string version = ConfigurationManager.AppSettings["version"];

                string weburl = ConfigurationManager.AppSettings["weburl"];
                 
                string placeCode = ConfigurationManager.AppSettings["placeCode"];//开票点编码

                string busNo = DateTime.Now.Ticks.ToString(); //业务流水号
                string totalAmt = je;

                List<ElectBillChargeItem> chargeItemlist = new List<ElectBillChargeItem>();
                List<ElectBillListDetail> electBillListDetails = new List<ElectBillListDetail>();
                List<PayChannelDetail> payChannelDetails = new List<PayChannelDetail>();

                var init_result = ElecBillHelper.InitCreateElecBillCom(appid, key, weburl, version, ip, port, dllName, func);

                if (!init_result)
                {
                    UIMessageTip.Show("初始化电子发票失败");
                    log.Error("初始化电子发票失败");
                    return false;
                }
                 
                string method = "invEBillRegistration";//医疗挂号电子票据开具接口
                string getDataUrl = string.Format($"/api/mzsf/GetFPRegistrationData?patient_id={patient_id}&ledger_sn={new_ledger_sn}&admiss_times={times}");

                if (billTypeEnum == BillTypeEnum.GuaHao)
                {
                    method = "invEBillRegistration";
                    getDataUrl = string.Format($"/api/mzsf/GetFPRegistrationData?patient_id={patient_id}&ledger_sn={new_ledger_sn}&admiss_times={times}");
                }
                else if (billTypeEnum == BillTypeEnum.ShouFei)
                {
                    method = "invoiceEBillOutpatient";
                    getDataUrl = string.Format($"/api/mzsf/GetFPInvoiceEBillOutpatient?patient_id={patient_id}&ledger_sn={new_ledger_sn}&admiss_times={times}");
                }
               
                log.Debug("getDataUrl：" + getDataUrl);
                var json = HttpClientUtil.Get(getDataUrl);
                log.Debug("获取数据：" + json);
                var result = WebApiHelper.DeserializeObject<ResponseResult<FPRegistrationVM>>(json);
                if (result.status != 1)
                {
                    log.Error(result.message);
                    throw new Exception(result.message);
                }
                var _data = new
                {
                    busNo = result.data.MainData.busNo,             //业务流水号
                    busType = result.data.MainData.busType,         //业务标识
                    payer = result.data.MainData.payer,               //患者姓名
                    busDateTime = result.data.MainData.busDateTime,//业务发生时间
                    placeCode = result.data.MainData.placeCode,//开票点编码
                    payee = result.data.MainData.payee,//收费员
                    author = result.data.MainData.author,//票据编制人
                    checker = result.data.MainData.checker,//票据复核人
                    totalAmt = StringUtil.RoundCharge(result.data.MainData.totalAmt),//开票总金额
                    patientNo = result.data.MainData.patientNo,
                    patientId = result.data.MainData.patientId,
                    payerType = result.data.MainData.payerType,//交款人类型 1 个人2单位
                    cardType = result.data.MainData.cardType,//卡类型
                    cardNo = result.data.MainData.cardNo,//卡号
                    age = result.data.MainData.age,
                    sex = result.data.MainData.sex,
                    accountPay = StringUtil.RoundCharge(result.data.MainData.accountPay),//个人账户支付
                    fundPay = StringUtil.RoundCharge(result.data.MainData.fundPay),//医保统筹基金支付
                    otherfundPay = StringUtil.RoundCharge(result.data.MainData.otherfundPay),//其它医保支付
                    ownPay = StringUtil.RoundCharge(result.data.MainData.ownPay),//自费金额
                    selfConceitedAmt = StringUtil.RoundCharge(result.data.MainData.selfConceitedAmt),//个人自负
                    selfPayAmt = StringUtil.RoundCharge(result.data.MainData.selfPayAmt),//个人自付
                    selfCashPay = StringUtil.RoundCharge(result.data.MainData.selfCashPay),//个人现金支付
                    reimbursementAmt = StringUtil.RoundCharge(result.data.MainData.reimbursementAmt),//医保报销总金额
                    payChannelDetail = result.data.PayChannelDetails,//交费渠道列表
                    isArrears = result.data.MainData.isArrears,//是否可流通
                    chargeDetail = result.data.ChargeDetails,
                    listDetail = electBillListDetails,
                    remark = result.data.MainData.remark
                };

                var stringA = $"appid={appid}&data={StringUtil.Base64Encode(JsonConvert.SerializeObject(_data))}&noise={noise}";
                ;
                var stringSignTemp = stringA + $"&key={key}&version={version}";

                var _sign = StringUtil.GenerateMD5(stringSignTemp).ToUpper();

                var _params = new
                {
                    appid = appid,
                    data = StringUtil.Base64Encode(JsonConvert.SerializeObject(_data)),
                    noise = noise,
                    version = version,
                    sign = _sign
                };

                var _payload = new
                {
                    method = method,
                    @params = _params
                };
                string payload = StringUtil.Base64Encode(JsonConvert.SerializeObject(_payload));
                string url = $"http://{ip}:{port}/extend?dllName={dllName}&func={func}&payload={payload}";

                log.Debug(url);
                json = HttpClientUtil.Get(url);

                var response = WebApiHelper.DeserializeObject<ElectBillCommonResponse>(json);

                if (response.data != null)
                {
                    var addbill_resp = StringUtil.Base64Decode(response.data);

                    var _resp = WebApiHelper.DeserializeObject<ElectBillAddResponse>(addbill_resp);
                    var _fpdata = StringUtil.Base64Decode(_resp.message);
                    if (_resp.result == "S0000")
                    {
                        //成功
                        var _entity = WebApiHelper.DeserializeObject<FpData>(_fpdata);
                        //写入电子发票数据到数据库
                        var d = new
                        {
                            patientId = patient_id,
                            ledger_sn = new_ledger_sn,
                            billBatchCode = _entity.billBatchCode,
                            billNo = _entity.billNo,
                            random = _entity.random,
                            createTime = _entity.createTime,
                            billQRCode = _entity.billQRCode,
                            pictureUrl = _entity.pictureUrl,
                            pictureNetUrl = _entity.pictureNetUrl,
                            subsys_id = "mz",
                        };

                        string paramurl = string.Format($"/api/mzsf/AddFpData?patient_id={d.patientId}&ledger_sn={d.ledger_sn}&billBatchCode={d.billBatchCode}&billNo={d.billNo}&random={d.random}&createTime={d.createTime}&billQRCode={d.billQRCode}&pictureUrl={d.pictureUrl}&pictureNetUrl={d.pictureNetUrl}&subsys_id={d.subsys_id}");
                        var _addresult = HttpClientUtil.Get(paramurl);
                        return true;
                    }
                    else
                    {
                        UIMessageTip.ShowError(_fpdata);
                    }
                }
                else
                {
                    UIMessageBox.ShowError("生成电子发票失败,参考日志信息");
                    log.Error(json);
                }
            }
            catch (Exception ex)
            {
                string ermsg = ex.ToString();
                if (ermsg.IndexOf("无法连接") > -1)
                {
                    UIMessageBox.ShowError("生成电子发票失败，请检查财政票据客户端是否运行中");
                }
                else
                {
                    UIMessageBox.ShowError("生成电子发票失败,参考日志信息");
                }
                log.Error(ex.ToString());
            }
            return false;
        }

        public static void PrintElecBill(string billBatchCode, string billNo, string random)
        {
            try
            {
                string _billBatchCode = billBatchCode;
                string _billNo = billNo;
                string _random = random;

                string ip = ConfigurationManager.AppSettings["ip"];
                string port = ConfigurationManager.AppSettings["port"];
                string dllName = ConfigurationManager.AppSettings["dllName"];
                string func = ConfigurationManager.AppSettings["func"];

                string noise = Guid.NewGuid().ToString();

                string appid = ConfigurationManager.AppSettings["appid"];
                string key = ConfigurationManager.AppSettings["key"];
                string version = ConfigurationManager.AppSettings["version"];

                string method = "printElectBill";

                var _data = new
                {
                    billBatchCode = _billBatchCode,
                    billNo = _billNo,
                    random = _random,
                };

                var stringA = $"appid={appid}&data={StringUtil.Base64Encode(JsonConvert.SerializeObject(_data))}&noise={noise}";
                var stringSignTemp = stringA + $"&key={key}&version={version}";

                var _sign = StringUtil.GenerateMD5(stringSignTemp).ToUpper();

                var _params = new
                {
                    appid = appid,
                    data = StringUtil.Base64Encode(JsonConvert.SerializeObject(_data)),
                    noise = noise,
                    version = version,
                    sign = _sign
                };

                var _payload = new
                {
                    method = method,
                    @params = _params
                };
                string payload = StringUtil.Base64Encode(JsonConvert.SerializeObject(_payload));
                string url = $"http://{ip}:{port}/extend?dllName={dllName}&func={func}&payload={payload}";
                //var reslt = HttpClientUtil.Get(url);
                Task.Run(() =>
                {
                    HttpClientUtil.Get(url);
                });
            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
                log.Error("打印电子发票失败！");
                log.Error(ex.Message);
            }

        }
    }
}