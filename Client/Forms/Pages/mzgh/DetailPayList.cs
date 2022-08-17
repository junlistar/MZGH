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
using log4net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Reflection;


namespace Client
{
    public partial class DetailPayList : UIForm
    {
        private static ILog log = LogManager.GetLogger(typeof(DetailPayList));//typeof放当前类
        List<GhRefundPayVM> paylist=new List<GhRefundPayVM>();

        PatientVM _userInfo;
   
        string _datestr = "";
        string _patient_id = "";
        int _times = 0;

        public DetailPayList(PatientVM userInfo, string datestr, string patient_id, int times)
        {
            InitializeComponent();
            _userInfo = userInfo;
            _datestr = datestr;
            _patient_id = patient_id;
            _times = times;
        }

        private void RefundPayList_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        { 
            var paramurl = string.Format($"/api/GuaHao/GetGhRefundPayList?request_date={_datestr}&patient_id={_patient_id}&times={_times}");

            log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
             
            var json = HttpClientUtil.Get(paramurl);

            var result = WebApiHelper.DeserializeObject<ResponseResult<List<GhRefundPayVM>>>(json);
            if (result.status==1)
            {
                paylist = result.data;
                this.dgvpaylist.DataSource = result.data;
                dgvpaylist.AutoGenerateColumns = false;
                this.dgvpaylist.AutoResizeColumns();
            }
            else
            { 
                UIMessageTip.ShowError("查询失败!");
                log.Error(result.message);
            }

        }

        private void btnCacel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        private void dgvpaylist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DetailPayList_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();//退出
                    break;
                default:
                    break;
            }
        }
    }
}
