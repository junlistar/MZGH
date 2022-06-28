using Client.ViewModel;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class SelctClinic : UIForm
    {
        private List<GHRequestVM> list = new List<GHRequestVM>();
        string patientId = "";
        public SelctClinic(List<GHRequestVM> _list,string _patientId)
        {
            InitializeComponent();
            this.list = _list;
            patientId = _patientId;
        }
        private void SelctClinic_Load(object sender, EventArgs e)
        {
            Color cur_color = (this as UIForm).RectColor;
            pnlClinic.RectColor = Color.Transparent;

            #region 绑定可选科室信息

            pnlClinic.Controls.Clear();
            int left = 0, top = 0;
            int btnWidth = 220;
            int btnHeight = 60;
            int btnmargin = 25;
            int leftmargin = 50;

            int textsize = 11;
              
            int rowCount =2;
            for (int i = 0; i < list.Count; i++)
            {
                UIButton btn1 = new UIButton();
                btn1.Style = UIStyle.LayuiGreen;
                btn1.Width = btnWidth;
                btn1.Height = btnHeight;
                btn1.Text = list[i].clinic_name;
                btn1.TagString = list[i].record_sn;

                //处理剩余号数
                btn1.TipsText = (list[i].end_no - list[i].current_no + 1).ToString();
                btn1.ShowTips = true;
                btn1.TipsColor = Color.FromArgb(80, 160, 255);// Color.Blue;

                if (!string.IsNullOrEmpty(list[i].doctor_name))
                {
                    btn1.Text+= "\r\n"+list[i].doctor_name;
                }
                btn1.Text += " (￥" + list[i].je +"元)";
                //if (btn1.Text.Length > 8)
                //{
                //    btn1.Text = list[i].clinic_name.Substring(0,8)+ "\r\n"+ list[i].clinic_name.Substring(8);
                //   // btn1.Font = new Font("微软雅黑", 8);
                //}

                if (i % rowCount == 0)
                {
                    left = 0;
                }

                if (left != 0)
                {
                    left += (int)(btn1.Width + btnmargin);
                }
                else
                {
                    left = (pnlClinic.Width - (rowCount * btn1.Width + (rowCount - 1) * btnmargin)) / 2;
                    if (left < 0)
                    {
                        left = 0;
                    }
                    if (top != 0)
                    {
                        top += (int)(btn1.Height * 1.5);
                    }
                    else
                    {
                        top = btn1.Height;
                    }
                }
                btn1.FillColor = cur_color;
                btn1.Top = top;
                btn1.Left = left;
                btn1.Click += btnClinic_Click;
                pnlClinic.Controls.Add(btn1);
            }

            #endregion
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 选择医生，进行挂号操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClinic_Click(object sender, EventArgs e)
        {


            var btn = sender as UIButton;
            foreach (var item in list)
            {
                if (item.record_sn == btn.TagString)
                {
                    //JKZL fe = new JKZL(item, patientId);
                    //fe.ShowDialog();

                    SelectPayType fe = new SelectPayType(item, patientId);
                    fe.ShowDialog();
                }

            }


            this.Close();
        }
    }
}
