using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;
using Client.ClassLib;
using Client.ViewModel;
using Client.Forms.Wedgit;
using System.Configuration;
using log4net;
using Newtonsoft.Json;

namespace Client.Forms.Pages.mzsf
{
    public partial class MzDepositRecord : UIForm
    {
        private static ILog log = LogManager.GetLogger(typeof(MzDepositRecord));//typeof放当前类
        public MzDepositRecord()
        {
            InitializeComponent();
        }

        public string patient_id;

        private void MzDepositRecord_Load(object sender, EventArgs e)
        {
            txt_patientid.Text = patient_id;

            BindData();
            dgv_mzdeposit.RowsDefaultCellStyle.SelectionBackColor = SessionHelper.dgv_row_seleced_color;
        }

        public void BindData()
        {
            var _pid = txt_patientid.Text;
            if (string.IsNullOrWhiteSpace(_pid))
            {
                MessageBox.Show("id为空！");
                return;
            }

            string paramurl = string.Format($"/api/mzsf/GetDepositReceipts?patient_id={_pid}");
            var json = HttpClientUtil.Get(paramurl);


            var result = WebApiHelper.DeserializeObject<ResponseResult<List<MzOrderReceiptVM>>>(json);

            if (result.status == 1)
            {
                if (result.data != null && result.data.Count > 0)
                {
                    var _dat = result.data.Select(p => new
                    {
                        patient_id = p.patient_id,
                        ledger_sn = p.ledger_sn,
                        charge_total = p.charge_total,
                        cash_name = p.cash_name,
                        cash_date = p.cash_date,
                        backfee_date = p.backfee_date
                    }).OrderByDescending(p => p.cash_date).ToList();
                    dgv_mzdeposit.Init();
                    dgv_mzdeposit.DataSource = _dat;
                }

            }
        }

        private void btnxp_Click(object sender, EventArgs e)
        {
            try
            {
                var _index = dgv_mzdeposit.SelectedIndex;
                if (_index >= 0)
                {
                    var _pid = dgv_mzdeposit.Rows[_index].Cells["pid"].Value.ToString();
                    var _ledger_sn = dgv_mzdeposit.Rows[_index].Cells["ledger_sn"].Value.ToString();
                    Print ghprint = new Print(SessionHelper.mzsf_report_code);
                    ghprint._printer = SessionHelper.sf_printer;
                    ghprint._patient_id = _pid;
                    ghprint._ledger_sn = _ledger_sn;
                    ghprint.Show();
                }

            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
            }
        }

        private void btnfp_Click(object sender, EventArgs e)
        {
            try
            {
                var _index = dgv_mzdeposit.SelectedIndex;
                if (_index >= 0)
                {
                    var _pid = dgv_mzdeposit.Rows[_index].Cells["pid"].Value.ToString();
                    var _ledger_sn = dgv_mzdeposit.Rows[_index].Cells["ledger_sn"].Value.ToString();
                    PrintElecBill(_pid, _ledger_sn);
                }

            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
            }
        }

        public void PrintElecBill(string _patientId,string _ledger_sn)
        {
            //补打电子发票
            try
            { 
                var _subsys_id = "mz";

                //查询电子发票记录表  <List<FpData>> GetFpDatasByParams(string patient_id, int ledger_sn, string subsys_id)
                string paramurl = string.Format($"/api/mzsf/GetFpDatasByParams?patient_id={_patientId.ToString()}&ledger_sn={_ledger_sn.ToString()}&subsys_id={_subsys_id}");

                var json = HttpClientUtil.Get(paramurl);

                var result = WebApiHelper.DeserializeObject<ResponseResult<List<FpData>>>(json);

                if (result.status != 1)
                {
                    UIMessageTip.Show(result.message);

                    log.Error(result.message);

                    return;

                }
                if (result.data == null || result.data.Count == 0)
                {
                    UIMessageTip.Show("没有电子发票数据！");

                    log.Error("没有电子发票数据！");

                    return;
                }

                string _billBatchCode = result.data[0].billBatchCode;
                string _billNo = result.data[0].billNo;
                string _random = result.data[0].random;

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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void MzDepositRecord_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
