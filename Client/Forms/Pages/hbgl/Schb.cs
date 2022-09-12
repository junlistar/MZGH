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
using Client.Forms.Wedgit;
using Client.ViewModel;
using log4net;
using Sunny.UI;

namespace Client
{
    public partial class Schb : UIPage
    {
        private static ILog log = LogManager.GetLogger(typeof(Schb));//typeof放当前类

        List<BaseRequestVM> list = null;
        string localweeks = "";
        int localday = -1;
        int current_week = 1;
        string order_asc = "asc";
        public Schb()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
        }



        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreateRequestRecord_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void CreateRequestRecord_MouseEnter(object sender, EventArgs e)
        {
            if (!this.Focused)
            {
                this.Focus();
            }
        }


        private void uiSymbolButton5_Click(object sender, EventArgs e)
        {

        }


        public void SetButtonColor(UIButton obj)
        {
            btnWeek1.Style = UIStyle.Green;
            btnWeek2.Style = UIStyle.Green;
            btnWeek3.Style = UIStyle.Green;
            btnWeek4.Style = UIStyle.Green;
            btnWeek5.Style = UIStyle.Green;

            obj.Style =UIStyle.Orange;
        }

        private void btnWeek1_Click(object sender, EventArgs e)
        {
            SetButtonColor(sender as UIButton);
            current_week = 1;
            var dt_from = DateTime.Now;
            var dt_to = DateTime.Now.AddDays(6 - Convert.ToInt16(DateTime.Now.DayOfWeek) + 1);
            GetRequestData(dt_from, dt_to);
            //GetWeekData();
        }

        public void GetRequestData(DateTime dt_from, DateTime dt_to)
        {

            try
            {
                var begin = dt_from.ToString("yyyy-MM-dd 00:00:00");
                var end = dt_to.ToString("yyyy-MM-dd 23:59:59");

                var param = $"?begin={begin}&end={end}";
                var paramurl = string.Format($"/api/GuaHao/GetRequestsByDate" + param);

                var json = HttpClientUtil.Get(paramurl);

                var result = WebApiHelper.DeserializeObject<ResponseResult<List<BaseRequestVM>>>(json);

                if (result.status == 1)
                {
                    list = result.data;
                    //dgvRequest.Init();
                    dgvRequest.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                    if (list != null)
                    {
                        var ds = list.Select(p => new
                        {
                            request_date_str = p.request_date_str,
                            ampm = p.apstr,
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
                        SetGridTextColor();

                        lblTotalCount.Text = $"总计：{ds.Count} 条";
                    }
                    else
                    {
                        dgvRequest.DataSource = null;
                        lblTotalCount.Text = $"总计：0 条";
                    }
                }
                else
                {
                    UIMessageTip.ShowError(result.message);
                    log.Error(result.message);
                }

            }
            catch (Exception ex)
            {
                UIMessageTip.ShowError(ex.Message);
                log.Error(ex.ToString());
            }

        }

        private void btnWeek2_Click(object sender, EventArgs e)
        {
            SetButtonColor(sender as UIButton);
            GetWeekData(2);
        }

        /// <summary>
        /// 第几周 从1开始标识第一周，2标识第二周
        /// </summary>
        /// <param name="week"></param>
        public void GetWeekData(int week = 1)
        {
            current_week = week;
            var dt_from = DateTime.Now.AddDays(0 - Convert.ToInt16(DateTime.Now.DayOfWeek) + ((week - 1) * 7) + 1);
            var dt_to = DateTime.Now.AddDays(6 - Convert.ToInt16(DateTime.Now.DayOfWeek) + ((week - 1) * 7) + 1);
            GetRequestData(dt_from, dt_to);
        }

        private void btnWeek3_Click(object sender, EventArgs e)
        {
            SetButtonColor(sender as UIButton);
            //第3周数据
            GetWeekData(3);
        }

        private void btnWeek4_Click(object sender, EventArgs e)
        {
            SetButtonColor(sender as UIButton);
            //第4周数据
            GetWeekData(4);
        }
        private void btnWeek5_Click(object sender, EventArgs e)
        {
            SetButtonColor(sender as UIButton);
            //第5周数据
            GetWeekData(5);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        public void SaveData()
        {
            try
            {
                var _message = "";
                DateTime dt_from = DateTime.Now;
                DateTime dt_to = DateTime.Now;
                if (current_week == 1)
                {
                    _message = $"确认生成 本周 \r\n{ GetWeekStr(current_week)} 的号表数据吗？";
                }
                else if (current_week == 2)
                {
                    _message = $"确认生成 下周 \r\n{ GetWeekStr(current_week)} 的号表数据吗？";
                }
                else
                {
                    _message = $"确认生成第 {current_week} 周 \r\n{ GetWeekStr(current_week)} 的号表数据吗？";
                }

                if (!UIMessageDialog.ShowAskDialog(this, _message))
                {
                    return;
                }
                LoadingHelper.ShowLoadingScreen();//显示
                lblmsg.Show();
                btnCreate.Enabled = false;
                Application.DoEvents();

                if (current_week == 1)
                {
                    dt_to = DateTime.Now.AddDays(6 - Convert.ToInt16(DateTime.Now.DayOfWeek) + 1);
                }
                else
                {
                    dt_from = DateTime.Now.AddDays(0 - Convert.ToInt16(DateTime.Now.DayOfWeek) + ((current_week - 1) * 7) + 1);
                    dt_to = DateTime.Now.AddDays(6 - Convert.ToInt16(DateTime.Now.DayOfWeek) + ((current_week - 1) * 7) + 1);
                }

                var begin = dt_from.ToString("yyyy-MM-dd");
                var end = dt_to.ToString("yyyy-MM-dd");

                var d = new
                {
                    begin = begin,
                    end = end,
                    op_id = SessionHelper.uservm.user_mi,
                };

                Task<HttpResponseMessage> task = null;
                string json = "";

                var paramurl = string.Format($"/api/GuaHao/Schb?begin={d.begin}&end={d.end}&op_id={d.op_id}");

                log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);
                task = SessionHelper.MyHttpClient.GetAsync(paramurl);

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
                var result = WebApiHelper.DeserializeObject<ResponseResult<bool>>(json);
                if (result.status == 1)
                {
                    UIMessageTip.ShowOk("操作成功!");

                    //刷新挂号数据
                    GetWeekData(current_week);
                }
                else
                {
                    UIMessageTip.ShowOk("操作失败!");
                    log.Error(result.message);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.ToString());
            }
            finally
            {
                btnCreate.Enabled = true;
                lblmsg.Hide();
                LoadingHelper.CloseForm();
            }
        }

        public void SetGridTextColor()
        {

            foreach (DataGridViewRow row in dgvRequest.Rows)
            {
                //row.Cells["request_date1"].Style.ForeColor = Color.Green;
                //row.Cells["ampm1"].Style.ForeColor = UIColor.Blue;
                //row.Cells["unit_name1"].Style.ForeColor = UIColor.Purple;
                //row.Cells["group_name1"].Style.ForeColor = UIColor.Green;
                //row.Cells["doct_name1"].Style.ForeColor = UIColor.Orange;
                //row.Cells["clinic_name1"].Style.ForeColor = UIColor.Blue;
                //row.Cells["begin_no1"].Style.ForeColor = UIColor.Purple;
                //row.Cells["current_no1"].Style.ForeColor = UIColor.Green;
                //row.Cells["end_no1"].Style.ForeColor = Color.Green;
                //row.Cells["winnostr1"].Style.ForeColor = UIColor.Green;
                //row.Cells["open_flag1"].Style.ForeColor = UIColor.Orange;

                if (row.Cells["open_flag1"].Value != null && row.Cells["open_flag1"].Value.ToString() == "不开放")
                {
                    row.Cells["open_flag1"].Style.ForeColor = Color.Orange;
                }
            }
        }
             

        private void dgvRequest_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //try
            //{
            //    if (e.RowIndex != -1)
            //    {
            //        dgvRequest.Rows[e.RowIndex].Cells["request_date1"].Style.ForeColor = Color.Green;
            //        dgvRequest.Rows[e.RowIndex].Cells["ampm1"].Style.ForeColor = UIColor.Blue;
            //        dgvRequest.Rows[e.RowIndex].Cells["unit_name1"].Style.ForeColor = UIColor.Purple;
            //        dgvRequest.Rows[e.RowIndex].Cells["group_name1"].Style.ForeColor = UIColor.Green;
            //        dgvRequest.Rows[e.RowIndex].Cells["doct_name1"].Style.ForeColor = UIColor.Orange;
            //        dgvRequest.Rows[e.RowIndex].Cells["clinic_name1"].Style.ForeColor = UIColor.Blue;
            //        dgvRequest.Rows[e.RowIndex].Cells["begin_no1"].Style.ForeColor = UIColor.Purple;
            //        dgvRequest.Rows[e.RowIndex].Cells["current_no1"].Style.ForeColor = UIColor.Green;
            //        dgvRequest.Rows[e.RowIndex].Cells["end_no1"].Style.ForeColor = Color.Green;
            //        dgvRequest.Rows[e.RowIndex].Cells["winnostr1"].Style.ForeColor = UIColor.Green;
            //        dgvRequest.Rows[e.RowIndex].Cells["open_flag1"].Style.ForeColor = UIColor.Orange;

            //    }
            //}
            //catch (Exception ex)
            //{
            //    log.Error(ex.Message);
            //    log.Error(ex.ToString());
            //}
        }

        private void dgvRequest_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {
                return;
            }
            var _cIndex = e.ColumnIndex;
            if (list != null && list.Count > 0)
            {
                if (order_asc == "asc")
                {
                    switch (dgvRequest.Columns[e.ColumnIndex].Name)
                    {
                        case "request_date1":
                            list = list.OrderBy(p => p.request_date).ToList();
                            break;
                        case "ampm1":
                            list = list.OrderBy(p => p.ampm).ToList();
                            break;
                        case "unit_name1":
                            list = list.OrderBy(p => p.unit_name).ToList();
                            break;
                        case "doct_name1":
                            list = list.OrderBy(p => p.doct_name).ToList();
                            break;
                        case "clinic_name1":
                            list = list.OrderBy(p => p.clinic_name).ToList();
                            break;
                        case "begin_no1":
                            list = list.OrderBy(p => p.begin_no).ToList();
                            break;
                        case "current_no1":
                            list = list.OrderBy(p => p.current_no).ToList();
                            break;
                        case "end_no1":
                            list = list.OrderBy(p => p.end_no).ToList();
                            break;
                        case "winnostr1":
                            list = list.OrderBy(p => p.winnostr).ToList();
                            break;
                        case "open_flag1":
                            list = list.OrderBy(p => p.open_flag).ToList();
                            break;
                        default:
                            break;
                    }
                    order_asc = "desc";
                }
                else
                {
                    switch (dgvRequest.Columns[e.ColumnIndex].Name)
                    {
                        case "request_date1":
                            list = list.OrderByDescending(p => p.request_date).ToList();
                            break;
                        case "ampm1":
                            list = list.OrderByDescending(p => p.ampm).ToList();
                            break;
                        case "unit_name1":
                            list = list.OrderByDescending(p => p.unit_name).ToList();
                            break;
                        case "doct_name1":
                            list = list.OrderByDescending(p => p.doct_name).ToList();
                            break;
                        case "clinic_name1":
                            list = list.OrderByDescending(p => p.clinic_name).ToList();
                            break;
                        case "begin_no1":
                            list = list.OrderByDescending(p => p.begin_no).ToList();
                            break;
                        case "current_no1":
                            list = list.OrderByDescending(p => p.current_no).ToList();
                            break;
                        case "end_no1":
                            list = list.OrderByDescending(p => p.end_no).ToList();
                            break;
                        case "winnostr1":
                            list = list.OrderByDescending(p => p.winnostr).ToList();
                            break;
                        case "open_flag1":
                            list = list.OrderByDescending(p => p.open_flag).ToList();
                            break;
                        default:
                            break;
                    }
                    order_asc = "asc";
                }
                //标题头 
                dgvRequest.Columns[e.ColumnIndex].HeaderText = AddOrderSymbol(e.ColumnIndex, order_asc);
                 
                var ds = list.Select(p => new
                {
                    request_date_str = p.request_date_str,
                    ampm = p.apstr,
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
                SetColumnWidth();
                SetGridTextColor();
            }
        }
        public void SetColumnWidth()
        { 

            dgvRequest.Columns["request_date1"].Width = 100;
            dgvRequest.Columns["ampm1"].Width = 100;
            dgvRequest.Columns["unit_name1"].Width = 100;
            dgvRequest.Columns["doct_name1"].Width = 100;
            dgvRequest.Columns["clinic_name1"].Width = 100;
            dgvRequest.Columns["begin_no1"].Width = 100;
            dgvRequest.Columns["current_no1"].Width = 100;
            dgvRequest.Columns["end_no1"].Width = 100;
            dgvRequest.Columns["winnostr1"].Width = 100;
            dgvRequest.Columns["open_flag1"].Width = 100; 
        }
        public string AddOrderSymbol(int col_index, string order)
        {
            for (int i = 0; i < dgvRequest.Columns.Count; i++)
            {
                dgvRequest.Columns[i].HeaderText = RemoveOrderSymbol(dgvRequest.Columns[i].HeaderText);
            }

            var text = dgvRequest.Columns[col_index].HeaderText;

            if (order == "asc")
            {
                text += "↑";
            }
            else
            {
                text += "↓";
            }
            return text;
        }

        public string RemoveOrderSymbol(string text)
        {
            return text.Replace("↑", "").Replace("↓", "");
        }

        private void Schb_Initialize(object sender, EventArgs e)
        { 
            btnWeek1.Text = "本周" + "\r\n" + GetWeekStr(1);

            btnWeek2.Text = "下周" + "\r\n" + GetWeekStr(2);

            btnWeek3.Text = "第三周" + "\r\n" + GetWeekStr(3);

            btnWeek4.Text = "第四周" + "\r\n" + GetWeekStr(4);
             
            btnWeek5.Text = "第五周" + "\r\n" + GetWeekStr(5);

            //默认查询
            SetButtonColor(btnWeek1);
            current_week = 1;
            var dt_from = DateTime.Now;
            var dt_to = DateTime.Now.AddDays(6 - Convert.ToInt16(DateTime.Now.DayOfWeek) + 1);
            GetRequestData(dt_from, dt_to);

            dgvRequest.RowsDefaultCellStyle.SelectionBackColor = SessionHelper.dgv_row_seleced_color;

        }

        public string GetWeekStr(int week)
        {
            var dt_from = DateTime.Now.AddDays(0 - Convert.ToInt16(DateTime.Now.DayOfWeek) + ((week - 1) * 7) + 1).ToString("MM-dd");
            if (week==1)
            {
                dt_from = DateTime.Now.ToString("MM-dd");
            }
            var dt_to = DateTime.Now.AddDays(6 - Convert.ToInt16(DateTime.Now.DayOfWeek) + ((week - 1) * 7) + 1).ToString("MM-dd");
            return dt_from + "至" + dt_to;
        }
    }
}
