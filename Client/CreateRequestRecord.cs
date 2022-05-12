using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.ClassLib;
using Client.ViewModel;
using log4net;
using Sunny.UI;

namespace Client
{
    public partial class CreateRequestRecord : UIPage
    {
        private static ILog log = LogManager.GetLogger(typeof(BaseRequest));//typeof放当前类
        static HttpClient client = null;
        List<BaseRequestVM> list = null;
        string localweeks = "";
        int localday =-1;
        public CreateRequestRecord()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var from = txtFrom.Value.Date;
            var to = txtTo.Value.Date;

            if (from>to)
            {
                UIMessageTip.ShowError("开始日期不能大于结束日期！");
                return;
            }

            DateTime start = Convert.ToDateTime(from.ToShortDateString());
            DateTime end = Convert.ToDateTime(to.ToShortDateString());

            TimeSpan sp = end.Subtract(start);
             
            if (sp.Days>35)
            {
                UIMessageTip.ShowWarning("日期区间相差太大，建议选择一个月之内的日期！");
                return;
            }

            List<RecordTimeSpan> list = new List<RecordTimeSpan>();
            bool flag = true;

            do
            {
                RecordTimeSpan ts = new RecordTimeSpan();

                DateTime startWeek = from.AddDays(1 - Convert.ToInt32(from.DayOfWeek.ToString("d")));  //本周周一

                DateTime endWeek = startWeek.AddDays(6);  //本周周日 

                if (from> startWeek )
                {
                    ts.from = from.ToShortDateString();
                    ts.from_day = Client.ClassLib.DataTimeUtil.GetDayFromEnum(from.DayOfWeek);
                }
                else
                {
                    ts.from = startWeek.ToShortDateString();
                    ts.from_day = Client.ClassLib.DataTimeUtil.GetDayFromEnum(startWeek.DayOfWeek);
                }

                if (to< endWeek)
                {
                    flag = false;
                    ts.to = to.ToShortDateString();

                    ts.to_day = Client.ClassLib.DataTimeUtil.GetDayFromEnum(to.DayOfWeek);
                }
                else
                {
                    ts.to = endWeek.ToShortDateString();
                    ts.to_day = Client.ClassLib.DataTimeUtil.GetDayFromEnum(endWeek.DayOfWeek);

                    from = endWeek.AddDays(1);
                }

                ts.week = "选择";
                ts.day = "选择";

                list.Add(ts);


            } while (flag);
            if (txtFrom.Value.Date.ToShortDateString()!= txtTo.Value.Date.ToShortDateString())
            {
                this.dgvDate.Columns["day"].Visible = false;
            }
            else
            {
                this.dgvDate.Columns["day"].Visible = true;
            }
            this.dgvDate.DataSource = list;

        }
        UIListBox listday = new UIListBox();

        UIListBox uiListBox1 = new UIListBox();
        int crow = 0; int ccol = 0;
        private void dgvDate_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { 
            crow = e.RowIndex;
            ccol = e.ColumnIndex;

            //点击的周
            if (e.ColumnIndex==4)
            {
                 
                uiListBox1.Items.Add("第一周");
                uiListBox1.Items.Add("第二周");
                uiListBox1.Items.Add("第三周");
                uiListBox1.Items.Add("第四周");
                uiListBox1.Items.Add("第五周");
                uiListBox1.Items.Add("第六周");
                uiListBox1.Items.Add("第七周");
                uiListBox1.Items.Add("第八周");

                uiListBox1.Style = UIStyle.LayuiGreen;
                uiListBox1.Parent = this;
                uiListBox1.Top = dgvDate.Top+  55 + (23 * (e.RowIndex));
                uiListBox1.Width = 100;
                uiListBox1.Left = 445;
                uiListBox1.BringToFront();
                uiListBox1.SelectedIndexChanged -= Cbx_SelectedIndexChanged;
                uiListBox1.SelectedIndexChanged += Cbx_SelectedIndexChanged;
                uiListBox1.Show();
            }
            else if (e.ColumnIndex == 5)
            {
                //点击的天

                listday.Items.Add("星期一");
                listday.Items.Add("星期二");
                listday.Items.Add("星期三");
                listday.Items.Add("星期四");
                listday.Items.Add("星期五");
                listday.Items.Add("星期六");
                listday.Items.Add("星期日");
                listday.Style = UIStyle.LayuiGreen;
                listday.Parent = this;
                listday.Top = dgvDate.Top + 55 + (23 * (e.RowIndex));
                listday.Width = 100;
                listday.Left = 545;
                listday.BringToFront();
                listday.SelectedIndexChanged -= Listday_SelectedIndexChanged;
                listday.SelectedIndexChanged += Listday_SelectedIndexChanged;
                listday.Show();
            }
        }

        private void Listday_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvDate.Rows[crow].Cells[ccol].Value = listday.SelectedItem.ToString();
            listday.Hide();
            InitData();
        }

        private void Cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            dgvDate.Rows[crow].Cells[ccol].Value = uiListBox1.SelectedItem.ToString();
            uiListBox1.Hide(); InitData();
        }

        public void InitData()
        {
            List<string> lis = new List<string>();
            var weeks = "";
            int day = -1; 

            if (this.dgvDate.Columns["day"].Visible)
            {

                var _week = dgvDate.Rows[0].Cells["week"].Value.ToString();
                var _day = dgvDate.Rows[0].Cells["day"].Value.ToString();
                if ((_week == "选择") || (_day == "选择"))
                { 
                    return;
                }
                weeks = DataTimeUtil.GetIntByWeekStr(_week).ToString();
                day = DataTimeUtil.GetIntByDayStr(_day);
            }
            else if (dgvDate.Rows.Count > 0)
            {

                for (int i = 0; i < dgvDate.Rows.Count; i++)
                {
                    var _week = dgvDate.Rows[i].Cells["week"].Value.ToString();
                    if (_week == "选择")
                    { 
                        return;
                    }
                    var _tmp = DataTimeUtil.GetIntByWeekStr(_week).ToString();
                    //if (!lis.Contains(_tmp))
                    //{
                    //    lis.Add(_tmp); 
                    //} 

                    lis.Add(_tmp);
                }
                weeks = string.Join(",", lis); 
            }
            else
            {
                return;
            }
            //UIMessageTip.Show($"查询{ weeks},{day}");
            localweeks = weeks;
            localday = day;
            try
            {

                var begin = txtFrom.Value.ToString("yyyy-MM-dd 00:00:00");
                var end = txtTo.Value.ToString("yyyy-MM-dd 23:59:59");
                 
                Task<HttpResponseMessage> task = null;
                string json = "";

                var param = $"?begin={begin}&end={end}&weeks={weeks}&day={day}";
                string paramurl = string.Format($"/api/GuaHao/GetBaseRequestsByWeekDay" + param); 

                log.Info(client.BaseAddress + paramurl);
                task = client.GetAsync(paramurl);

                task.Wait();
                var response = task.Result;
                if (response.IsSuccessStatusCode)
                {
                    var read = response.Content.ReadAsStringAsync();
                    read.Wait();
                    json = read.Result;
                }
                else
                {
                    log.Error(response.ReasonPhrase);
                }

                list = WebApiHelper.DeserializeObject<ResponseResult<List<BaseRequestVM>>>(json).data;
                if (list != null && list.Count > 0)
                {
                    var ds = list.Select(p => new
                    { 
                        
                        weekstr = p.weekstr,
                        daystr = p.daystr,
                        apstr = p.apstr,
                        unit_name = p.unit_name,
                        group_name = p.group_name,
                        doct_name = p.doct_name,
                        clinic_name = p.clinic_name,
                        totle_num = p.totle_num,
                        winnostr = p.winnostr, 
                    }).ToList();
                    dgvbase.DataSource = ds;
                    dgvbase.AutoResizeColumns();
                }
                else
                {
                    var tmp = new List<BaseRequestVM>();
                    var ds = tmp.Select(p => new { 
                        weekstr,
                        daystr,
                        apstr,
                        unit_name,
                        group_name,
                        doct_name,
                        clinic_name,
                        totle_num,
                        winnostr, 
                    }).ToList();
                    dgvbase.DataSource = ds;
                }



                param = $"?begin={begin}&end={end}";
                paramurl = string.Format($"/api/GuaHao/GetRequestsByDate" + param);

                log.Info(client.BaseAddress + paramurl);
                task = client.GetAsync(paramurl);

                task.Wait();
                response = task.Result;
                if (response.IsSuccessStatusCode)
                {
                    var read = response.Content.ReadAsStringAsync();
                    read.Wait();
                    json = read.Result;
                }
                else
                {
                    log.Error(response.ReasonPhrase);
                }

                list = WebApiHelper.DeserializeObject<ResponseResult<List<BaseRequestVM>>>(json).data;

                if (list != null && list.Count > 0)
                {
                    var ds = list.Select(p => new
                    {
                        request_date_str = p.request_date_str,
                        ampm = p.ampm, 
                        unit_name = p.unit_name,
                        group_name = p.group_name,
                        doct_name = p.doct_name,
                        clinic_name = p.clinic_name,
                        begin_no = p.begin_no,
                        current_no = p.current_no,
                        end_no = p.end_no,
                        winnostr = p.winnostr,
                        open_flag = p.open_flag,
                    }).ToList();
                    dgvRequest.DataSource = ds;
                    dgvRequest.AutoResizeColumns();
                }
                else
                {
                    //var tmp = new List<BaseRequestVM>();
                    //var ds = tmp.Select(p => new
                    //{
                    //    request_date,
                    //    ampm,
                    //    unit_name,
                    //    group_name,
                    //    doct_name,
                    //    clinic_name,
                    //    begin_no,
                    //    current_no,
                    //    totle_num,
                    //    winnostr,
                    //    open_flag_str
                    //}).ToList();
                    //dgvRequest.DataSource = ds;
                    dgvRequest.DataSource =null;
                }


            }
            catch (Exception ex)
            {
                UIMessageBox.ShowError(ex.Message);
                log.Error(ex.InnerException.ToString());
            }


        }

        private void CreateRequestRecord_Load(object sender, EventArgs e)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings.Get("apihost"));


            InitUI();

        }

        public void InitUI()
        { 
            txtFrom.Text = DateTime.Now.AddDays(7).ToShortDateString();
            txtTo.Text = DateTime.Now.AddDays(7).ToShortDateString();


            dgvbase.DataSource = null;
            dgvRequest.DataSource = null;

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            InitUI();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {

                var begin = txtFrom.Value.ToString("yyyy-MM-dd");
                var end = txtTo.Value.ToString("yyyy-MM-dd");

                if (string.IsNullOrEmpty(localweeks))
                {
                    UIMessageTip.ShowWarning("没有数据，请输入完整查询条件!");
                    return;
                }

                string json = ""; string paramurl = "";


                //根据patientId查找已存在的病人
                Task<HttpResponseMessage> task = null;
                json = ""; 
                  
                var d = new
                {
                    begin = begin,
                    end = end,
                    weeks = localweeks,
                    day = localday,
                    op_id = SessionHelper.uservm.user_mi,
                };
                var data = WebApiHelper.SerializeObject(d); HttpContent httpContent = new StringContent(data);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");//begin, string end, string weeks, int day, string op_id
                paramurl = string.Format($"/api/GuaHao/CreateRequestRecord?begin={d.begin}&end={d.end}&weeks={d.weeks}&day={d.day}&op_id={d.op_id}");

                string res = client.PostAsync(paramurl, httpContent).Result.Content.ReadAsStringAsync().Result;
                var responseJson = WebApiHelper.DeserializeObject<ResponseResult<int>>(res).data;

                if (responseJson == 1 || responseJson == 2)
                { 
                    UIMessageTip.ShowOk("操作成功!");
                    //刷新挂号数据
                    InitData();
                }
                else
                {
                    UIMessageTip.ShowOk("操作失败!");
                }

               // this.Close();

            }
            catch (Exception ex)
            {
                log.Debug(ex.Message);
            }
        }

        private void uiGroupBox1_Click(object sender, EventArgs e)
        {

        } 

        private void txtFrom_ValueChanged(object sender, DateTime value)
        {
            List<RecordTimeSpan> list = new List<RecordTimeSpan>();
            this.dgvDate.DataSource = list;
             
            localweeks = "";
            localday = -1;
        }
    }
}
