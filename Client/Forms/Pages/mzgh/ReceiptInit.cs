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
using log4net;
using Client.ClassLib;
using Client.ViewModel;

namespace Client.Forms.Pages.mzgh
{
    public partial class ReceiptInit : UIForm
    {
        private static ILog log = LogManager.GetLogger(typeof(ReceiptInit));
        List<GhOpReceiptVM> list;

        public ReceiptInit()
        {
            InitializeComponent();
        }

        private void ReceiptInit_Load(object sender, EventArgs e)
        {
            StyleHelper.SetGridColor(dgvlist);//设置样式
            BindData();
        }

        public void BindData()
        {
            string paramurl = string.Format($"/api/GuaHao/GetOpReceipts?opera={SessionHelper.uservm.user_mi}");

            log.Debug("请求接口数据：" + SessionHelper.MyHttpClient.BaseAddress + paramurl);

            var json = HttpClientUtil.Get(paramurl);

            var result = WebApiHelper.DeserializeObject<ResponseResult<List<GhOpReceiptVM>>>(json);
            if (result.status == 1)
            {
                list = result.data;
                BindDgv();
            }
        }

        public void BindDgv()
        {
            var _dat = list.Select(p => new
            {
                opera = p.@operator,
                happen_date = p.happen_date,
                start_no = p.start_no,
                current_no = p.current_no,
                end_no = p.end_no,
                step_length = p.step_length,
                deleted_flag = p.deleted_flag,
                deleted_flag_str = p.deleted_flag_str,
            }).ToList();
            dgvlist.DataSource = _dat;
            dgvlist.AutoResizeColumns();

            var _index = dgvlist.Rows.Count;
            if (_index > 0)
            {
                //this.dgvlist.CurrentCell = this.dgvlist[1, _index - 1];
                //UIMessageTip.Show(this.dgvlist.BindingContext[this.dgvlist.DataSource].Position.ToString());
                this.dgvlist.BindingContext[this.dgvlist.DataSource].Position =  _index - 1;
                //dgvlist.SelectedIndex = _index - 1;
                // dgvlist.Rows[_index - 1].Selected = true;
            }
            dgvlist.RowsDefaultCellStyle.SelectionBackColor = SessionHelper.dgv_row_seleced_color;
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReceiptInit_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //var _rowCount = dgvlist.Rows.Count;
            //if (_rowCount>0)
            //{

            //}
            //dgvlist.Rows.Add();

            btnSave.Enabled = true;

            if (list != null && list.Count > 0 && string.IsNullOrEmpty(list[list.Count - 1].@operator))
            {
                return;
            }

            var _vm = new GhOpReceiptVM();
            _vm.happen_date = DateTime.Now;
            _vm.deleted_flag = "0";
            _vm.report_flag = "0";
            list.Add(_vm);
            BindDgv();

            //绑定界面
            txtbegin.Focus();
            txtstep.Text = "1";
            cbxflag.Text = "当前使用";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (list != null && string.IsNullOrEmpty(list[list.Count - 1].@operator))
                {
                    if (string.IsNullOrEmpty(list[list.Count - 1].start_no))
                    {
                        UIMessageTip.ShowWarning("数据不能为空");
                        txtbegin.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(list[list.Count - 1].end_no))
                    {
                        UIMessageTip.ShowWarning("数据不能为空");
                        txtend.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(cbxflag.Text))
                    {
                        UIMessageTip.ShowWarning("数据不能为空");
                        cbxflag.Focus();
                        return;
                    }
                    //保存数据 

                    var paramurl = string.Format($"/api/GuaHao/EditOpReceipt");
                    list[list.Count - 1].@operator = SessionHelper.uservm.user_mi;
                    var json = HttpClientUtil.PostJSON(paramurl, list[list.Count - 1]);
                    var result1 = WebApiHelper.DeserializeObject<ResponseResult<bool>>(json);
                    if (result1.status == 1)
                    {
                        UIMessageTip.Show("保存成功");
                    }
                    else
                    {
                        UIMessageTip.ShowError(result1.message);
                    }
                }
            }
            catch (Exception ex)
            {
                UIMessageTip.ShowError(ex.Message);
                log.Error(ex.ToString());
            }
        }

        private void txtbegin_Leave(object sender, EventArgs e)
        {
            var _begin = txtbegin.Text.PadLeft(10, '0');
            if (list != null && string.IsNullOrEmpty(list[list.Count - 1].@operator))
            {
                list[list.Count - 1].start_no = _begin;
                list[list.Count - 1].current_no = _begin;
                BindDgv();
            }
        }

        private void txtend_Leave(object sender, EventArgs e)
        {
            var _begin = txtend.Text.PadLeft(10, '0');
            if (list != null && string.IsNullOrEmpty(list[list.Count - 1].@operator))
            {
                list[list.Count - 1].end_no = _begin;
                BindDgv();
            }
        }

        private void txtstep_Leave(object sender, EventArgs e)
        {
            var _begin = int.Parse(txtstep.Text);
            if (list != null && string.IsNullOrEmpty(list[list.Count - 1].@operator))
            {
                list[list.Count - 1].step_length = _begin;
                BindDgv();
            }
        }

        private void cbxflag_SelectedIndexChanged(object sender, EventArgs e)
        {
            var _val = "0";
            if (cbxflag.Text == "当前使用")
            {
                _val = "0";
            }
            else if (cbxflag.Text == "已删除")
            {
                _val = "1";
            }
            if (list != null && string.IsNullOrEmpty(list[list.Count - 1].@operator))
            {
                list[list.Count - 1].deleted_flag = _val;
                BindDgv();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {

                var _index = dgvlist.SelectedIndex;
                if (_index != -1)
                {
                    if (UIMessageDialog.ShowAskDialog(this, "是否确定删除数据？"))
                    {
                        var paramurl = string.Format($"/api/GuaHao/DeleteOpReceipt");
                        list[list.Count - 1].@operator = SessionHelper.uservm.user_mi;
                        var json = HttpClientUtil.PostJSON(paramurl, list[_index]);
                        var result1 = WebApiHelper.DeserializeObject<ResponseResult<bool>>(json);
                        if (result1.status == 1)
                        {
                            UIMessageTip.Show("删除成功"); BindData();
                        }
                        else
                        {
                            UIMessageTip.ShowError(result1.message);
                        }
                    }
                }
                else
                {
                    UIMessageTip.ShowWarning("没有数据！");
                }
            }
            catch (Exception ex)
            {
                UIMessageTip.ShowError(ex.Message);
                log.Error(ex.ToString());
            }
        }
    }
}
