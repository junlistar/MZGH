using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.ClassLib;
using Sunny.UI;
using log4net;
using Client.ViewModel;

namespace Client.Forms.Wedgit
{
    public partial class ProcessingForm : UIForm
    {
        private static ILog log = LogManager.GetLogger(typeof(ProcessingForm));//typeof放当前类
        public ProcessingForm()
        {
            InitializeComponent();
        }

        private void ProcessingForm_Load(object sender, EventArgs e)
        {
            //加载数据字典
            _demoBGWorker.WorkerReportsProgress = true;
            _demoBGWorker.DoWork += BGWorker_DoWork;
            _demoBGWorker.RunWorkerAsync();
            _demoBGWorker.ProgressChanged += BGWorker_ProgressChanged;
        }


        BackgroundWorker _demoBGWorker = new BackgroundWorker();


        private void BGWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //修改进度条的显示。
            var percent = e.ProgressPercentage;

            //如果有更多的信息需要传递，可以使用 e.UserState 传递一个自定义的类型。
            //这是一个 object 类型的对象，您可以通过它传递任何类型。
            //我们仅把当前 sum 的值通过 e.UserState 传回，并通过显示在窗口上。
            //ResponseResult<bool> result = e.UserState as ResponseResult<bool>;
            string result = e.UserState as string;

            lblMsg.Text = result;
            uiProcessBar1.Value = percent;

            if (percent==100)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        public void BGWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            BackgroundWorker bgWorker = sender as BackgroundWorker;
            //UIMessageTip.Show("BGWorker_DoWork");
            try
            {
                InitDic(bgWorker);
            }
            catch (Exception ex)
            {
                //bgWorker.ReportProgress(2, result);
                MessageBox.Show(ex.Message);
            }

        }

        public void InitDic(BackgroundWorker bgWorker)
        {
            try
            {

                log.Info("初始化数据字典：InitDic");

                bgWorker.ReportProgress(1, "获取用户费别信息");
                //获取用户费别信息 
                string json;
                string paramurl = string.Format($"/api/GuaHao/GetChargeTypes");
                json = HttpClientUtil.Get(paramurl);
                SessionHelper.chargeTypes = WebApiHelper.DeserializeObject<ResponseResult<List<ChargeTypeVM>>>(json).data;

                bgWorker.ReportProgress(3, "获取地区信息");

                //获取地区信息
                json = "";
                paramurl = string.Format($"/api/GuaHao/GetDistrictCodes");
                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                json = HttpClientUtil.Get(paramurl);
                SessionHelper.districtCodes = WebApiHelper.DeserializeObject<ResponseResult<List<DistrictCodeVM>>>(json).data;


                //获取职业信息
                bgWorker.ReportProgress(5, "获取职业信息");
                json = "";
                paramurl = string.Format($"/api/GuaHao/GetOccupationCodes");
                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                json = HttpClientUtil.Get(paramurl);
                SessionHelper.occupationCodes = WebApiHelper.DeserializeObject<ResponseResult<List<OccupationCodeVM>>>(json).data;

                //获取身份信息
                bgWorker.ReportProgress(7, "获取身份信息");
                json = "";
                paramurl = string.Format($"/api/GuaHao/GetResponceTypes");
                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                json = HttpClientUtil.Get(paramurl);
                SessionHelper.responseTypes = WebApiHelper.DeserializeObject<ResponseResult<List<ResponceTypeVM>>>(json).data;


                //获取科室
                bgWorker.ReportProgress(9, "获取科室");
                json = "";
                paramurl = string.Format($"/api/GuaHao/GetUnits");
                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                json = HttpClientUtil.Get(paramurl);
                SessionHelper.units = WebApiHelper.DeserializeObject<ResponseResult<List<UnitVM>>>(json).data;

                //获取号别
                bgWorker.ReportProgress(11, "获取号别");
                json = "";
                paramurl = string.Format($"/api/GuaHao/GetClinicTypes");
                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                json = HttpClientUtil.Get(paramurl);
                SessionHelper.clinicTypes = WebApiHelper.DeserializeObject<ResponseResult<List<ClinicTypeVM>>>(json).data;

                //获取RequestType
                bgWorker.ReportProgress(14, "获取RequestType");
                json = "";
                paramurl = string.Format($"/api/GuaHao/GetRequestTypes");
                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                json = HttpClientUtil.Get(paramurl);
                SessionHelper.requestTypes = WebApiHelper.DeserializeObject<ResponseResult<List<RequestTypeVM>>>(json).data;

                //获取用户
                bgWorker.ReportProgress(17, "获取用户");
                json = "";
                paramurl = string.Format($"/api/GuaHao/GetUserDic");
                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                json = HttpClientUtil.Get(paramurl);
                SessionHelper.userDics = WebApiHelper.DeserializeObject<ResponseResult<List<UserDicVM>>>(json).data;

                //获取挂号时间段
                bgWorker.ReportProgress(20, "获取挂号时间段");
                json = "";
                paramurl = string.Format($"/api/GuaHao/GetRequestHours");
                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                json = HttpClientUtil.Get(paramurl);
                SessionHelper.requestHours = WebApiHelper.DeserializeObject<ResponseResult<List<RequestHourVM>>>(json).data;

                //GetRelativeCodes   
                bgWorker.ReportProgress(30, "获取GRelativeCodes");
                paramurl = string.Format($"/api/GuaHao/GetRelativeCodes");
                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                json = HttpClientUtil.Get(paramurl);

                SessionHelper.relativeCodes = WebApiHelper.DeserializeObject<ResponseResult<List<RelativeCodeVM>>>(json).data;

                //处方模板
                bgWorker.ReportProgress(33, "获取处方模板");
                paramurl = string.Format($"/api/mzsf/GetMzChargePatterns");

                log.Debug("请求接口数据：" + SessionHelper.MyHttpClient.BaseAddress + paramurl);
                json = HttpClientUtil.Get(paramurl);

                var result = WebApiHelper.DeserializeObject<ResponseResult<List<MzChargePatternVM>>>(json);
                if (result.status == 1)
                {
                    SessionHelper.MzChargePatterns = result.data;
                }
                //处方模板详细
                bgWorker.ReportProgress(36, "获取处方模板详细");
                paramurl = string.Format($"/api/mzsf/GetMzPatternDetails");

                log.Debug("请求接口数据：" + SessionHelper.MyHttpClient.BaseAddress + paramurl);
                json = HttpClientUtil.Get(paramurl);

                var detail_result = WebApiHelper.DeserializeObject<ResponseResult<List<MzChargePatternDetailVM>>>(json);
                if (detail_result.status == 1)
                {
                    SessionHelper.MzChargePatternDetails = detail_result.data;
                }
                //处方类型
                bgWorker.ReportProgress(38, "获取处方类型");
                paramurl = string.Format($"/api/mzsf/GetOrderTypes");
                json = HttpClientUtil.Get(paramurl);
                SessionHelper.mzOrderTypes = WebApiHelper.DeserializeObject<ResponseResult<List<OrderTypeVM>>>(json).data;

                //支付类型比较 
                bgWorker.ReportProgress(40, "获取支付类型比较");
                paramurl = string.Format($"/api/GuaHao/GetPageChequeCompares");
                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                json = HttpClientUtil.Get(paramurl);

                SessionHelper.pageChequeCompares = WebApiHelper.DeserializeObject<ResponseResult<List<PageChequeCompareVM>>>(json).data;

                //医保目录类型比较 
                bgWorker.ReportProgress(45, "获取医保目录类型比较");
                paramurl = string.Format($"/api/GuaHao/GetYbhzzdList");
                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                json = HttpClientUtil.Get(paramurl);

                SessionHelper.ybhzCompare = WebApiHelper.DeserializeObject<ResponseResult<List<YbhzzdVM>>>(json).data;

                //医保字典 
                bgWorker.ReportProgress(50, "获取医保字典Insutypes");
                paramurl = string.Format($"/api/YbInfo/GetInsutypes");
                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                json = HttpClientUtil.Get(paramurl);
                SessionHelper.insutypes = WebApiHelper.DeserializeObject<ResponseResult<List<InsutypeVM>>>(json).data;

                bgWorker.ReportProgress(55, "获取医保字典MdtrtCertType");
                paramurl = string.Format($"/api/YbInfo/GetMdtrtCertTypes");
                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                json = HttpClientUtil.Get(paramurl);
                SessionHelper.mdtrtCertTypes = WebApiHelper.DeserializeObject<ResponseResult<List<MdtrtCertTypeVM>>>(json).data;
                bgWorker.ReportProgress(60, "获取医保字典MedType");
                paramurl = string.Format($"/api/YbInfo/GetMedTypes");
                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                json = HttpClientUtil.Get(paramurl);
                SessionHelper.medTypes = WebApiHelper.DeserializeObject<ResponseResult<List<MedTypeVM>>>(json).data;
                bgWorker.ReportProgress(65, "获取医保字典DiagType");
                paramurl = string.Format($"/api/YbInfo/GetDiagTypes");
                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                json = HttpClientUtil.Get(paramurl);
                SessionHelper.diagTypes = WebApiHelper.DeserializeObject<ResponseResult<List<DiagTypeVM>>>(json).data;
                bgWorker.ReportProgress(70, "获取医保字典IcdCode");
                paramurl = string.Format($"/api/YbInfo/GetIcdCodes");
                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                json = HttpClientUtil.Get(paramurl);
                SessionHelper.icdCodes = WebApiHelper.DeserializeObject<ResponseResult<List<IcdCodeVM>>>(json).data;
                bgWorker.ReportProgress(80, "获取医保字典BirctrlType");
                paramurl = string.Format($"/api/YbInfo/GetBirctrlTypes");
                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                json = HttpClientUtil.Get(paramurl);
                SessionHelper.birctrlTypes = WebApiHelper.DeserializeObject<ResponseResult<List<BirctrlTypeVM>>>(json).data;

                //客户端配置 
                bgWorker.ReportProgress(90, "获取客户端配置");
                paramurl = string.Format($"/api/GuaHao/GetMzClientConfig");
                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                json = HttpClientUtil.Get(paramurl);
                MzClientConfigVM mzClientConfig = WebApiHelper.DeserializeObject<ResponseResult<MzClientConfigVM>>(json).data;
                if (mzClientConfig != null)
                {
                    //系统配置信息，医院名称，版本号，挂号搜索词长度配置等
                    SessionHelper.MzClientConfigVM = mzClientConfig;
                }
                else
                {
                    UIMessageTip.Show("没有获取到数据库客户端配置数据");
                    log.Error("没有获取到数据库客户端配置数据");
                }
                bgWorker.ReportProgress(100, "字典加载完毕！");
                
            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
                log.Error(ex.ToString());
            }

            //SessionHelper.pay_xianjin = ConfigurationManager.AppSettings.Get("pay_xianjin");
            //SessionHelper.pay_weixin = ConfigurationManager.AppSettings.Get("pay_weixin");
            //SessionHelper.pay_zhifubao = ConfigurationManager.AppSettings.Get("pay_zhifubao");
            //SessionHelper.pay_yinlian = ConfigurationManager.AppSettings.Get("pay_yinlian");
            //SessionHelper.pay_yibao = ConfigurationManager.AppSettings.Get("pay_yibao");

            //SessionHelper.pay_xianjin = SessionHelper.pageChequeCompares.Where(p=>p.page_code=="1").FirstOrDefault().his_code;
            //SessionHelper.pay_weixin = SessionHelper.pageChequeCompares.Where(p => p.page_code == "1").FirstOrDefault().his_code;
            //SessionHelper.pay_zhifubao = SessionHelper.pageChequeCompares.Where(p => p.page_code == "1").FirstOrDefault().his_code;
            //SessionHelper.pay_yinlian = SessionHelper.pageChequeCompares.Where(p => p.page_code == "1").FirstOrDefault().his_code;
            //SessionHelper.pay_yibao = SessionHelper.pageChequeCompares.Where(p => p.page_code == "1").FirstOrDefault().his_code;
        }

    }
}
