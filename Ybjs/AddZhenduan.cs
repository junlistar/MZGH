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
using YbjsLib.Model;

namespace YbjsLib
{
    public partial class AddZhenduan : UIForm
    { 
        public AddZhenduan()
        {
            InitializeComponent();
        }

        List<IcdCodeVM> icdCodes;

        private void AddZhenduan_Load(object sender, EventArgs e)
        {
            cbxzdlb.DataSource = YBHelper.diagTypeList;
            cbxzdlb.DisplayMember = "name";
            cbxzdlb.ValueMember = "code";

            icdCodes = YBHelper.icdCodes;


            dgvicd.CellClick += dgvicd_CellContentClick; dgvicd.KeyDown += dgvicd_KeyDown;
        }

        UIDataGridView dgvicd = new UIDataGridView();

        private void dgvicd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dgvicd.SelectedIndex != -1)
                {

                    var ev = new DataGridViewCellEventArgs(0, dgvicd.SelectedIndex);

                    dgvicd_CellContentClick(sender, ev);
                }
            }

        }
        private void txt_icdcode_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                //MessageBox.Show(e.KeyCode.ToString());
                if (e.KeyCode == Keys.Down)
                {
                    this.dgvicd.Focus();
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    if (dgvicd.Rows.Count > 0)
                    {

                        var code = dgvicd.Rows[0].Cells["code"].Value.ToString();
                        var name = dgvicd.Rows[0].Cells["name"].Value.ToString();

                        txt_icdcode.TextChanged -= txt_icdcode_TextChanged;
                        txt_icdcode.Text = name;
                        txt_icdcode.TagString = code;
                        txt_icdcode.TextChanged += txt_icdcode_TextChanged;

                        dgvicd.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }
        }

        private void txt_icdcode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //查询科室信息 显示到girdview
                var tb = sender as UITextBox;
                //获取数据 

                if (icdCodes != null && icdCodes.Count > 0)
                {
                    var ipt = txt_icdcode.Text.Trim();

                    dgvicd.Parent = this;
                    dgvicd.Top = tb.Top + tb.Height;
                    dgvicd.Left = tb.Left;
                    dgvicd.Width = 300;
                    dgvicd.Height = 200;
                    dgvicd.BringToFront();
                    dgvicd.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvicd.RowHeadersVisible = false;
                    dgvicd.BackgroundColor = Color.White;
                    dgvicd.ReadOnly = true;


                    List<IcdCodeVM> vm = icdCodes;

                    if (!string.IsNullOrWhiteSpace(ipt))
                    {
                        vm = vm.Where(p => p.py_code.StartsWith(ipt.ToUpper())).ToList();
                    }
                    dgvicd.DataSource = vm;

                    dgvicd.Columns["code"].HeaderText = "编号";
                    dgvicd.Columns["name"].HeaderText = "名称";
                    dgvicd.Columns["py_code"].Visible = false;
                    dgvicd.Columns["d_code"].Visible = false;
                    dgvicd.AutoResizeColumns();

                    dgvicd.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }
        }
        private void dgvicd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    return;
                }
                var obj = sender as UIDataGridView;
                var code = obj.Rows[e.RowIndex].Cells["code"].Value.ToString();
                var name = obj.Rows[e.RowIndex].Cells["name"].Value.ToString();
                txt_icdcode.TextChanged -= txt_icdcode_TextChanged;
                txt_icdcode.Text = code;
                txt_icdname.Text = name;
                txt_icdcode.TagString = code;
                txt_icdcode.TextChanged += txt_icdcode_TextChanged;

                dgvicd.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }
        }

        private void txt_icdcode_Leave(object sender, EventArgs e)
        {
            if (!dgvicd.Focused)
            {
                dgvicd.Hide();
            }
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            Diseinfo diseinfo = new Diseinfo();
            diseinfo.vali_flag = "1";
            diseinfo.diag_code = txt_icdcode.Text;
            diseinfo.diag_name = txt_icdname.Text;
            diseinfo.diag_type = cbxzdlb.SelectedValue.ToString();
            diseinfo.diag_type_name = cbxzdlb.Text;
            diseinfo.vali_flag = "1";
            if (YBHelper.diseinfoList == null)
            {
                YBHelper.diseinfoList = new List<Diseinfo>();
            }

            YBHelper.diseinfoList.Add(diseinfo);
        }
    }
}
