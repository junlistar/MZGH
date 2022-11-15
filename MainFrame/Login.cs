using log4net;
using MainFrame.Common;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace MainFrame
{
    public partial class Login : UIForm
    {
        private static ILog log = LogManager.GetLogger(typeof(Login));//typeof放当前类
        public bool IsLogin = false;
        Color iconColor = Color.FromArgb(48, 48, 48);


        public Login()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var username = txtName.Text.Trim();
            var password = txtPwd.Text.Trim();

            if (string.IsNullOrWhiteSpace(username))
            {
                UIMessageTip.ShowWarning("请输入登录名!"); txtName.Focus();
                return;
            }

            try
            {
                //IsLogin = true;
                //this.Close();
                 
                string json = "";
                string paramurl = string.Format($"/api/GuaHao/GetLoginUser?uname={username}&pwd={password}");

                log.InfoFormat(SessionHelper.MyHttpClient.BaseAddress + paramurl);

                json = HttpClientUtil.Get(paramurl);

                var result = HttpClientUtil.DeserializeObject<ResponseResult<List<LoginUsersVM>>>(json);
                if (result.status == 1)
                {

                    if (result.data != null && result.data.Count > 0)
                    {
                        SessionHelper.uservm = result.data[0];
                        IsLogin = true;
                        this.Close();
                    }
                    else
                    {
                        UIMessageTip.ShowWarning(" 登录名或密码有误!");
                        return;
                    }
                }
                else
                {
                    UIMessageTip.ShowWarning(result.message);
                    log.Error(result.message);
                }

            }
            catch (Exception ex)
            {
                if (ex.InnerException!=null)
                {
                    log.Error(ex.ToString());
                    if (ex.InnerException.InnerException!=null)
                    { 
                        UIMessageTip.ShowError(ex.InnerException.InnerException.Message);
                    }
                    else
                    { 
                        UIMessageTip.ShowError(ex.InnerException.Message);
                    }
                }
                else
                { 
                    log.Error(ex.ToString());
                    UIMessageTip.ShowError(ex.Message);
                }
            }
        }

        private void txtName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtPwd.Focus();
            }
        }

        private void txtPwd_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

            txtName.Focus();
        }

        private void uiSymbolLabel1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uiSymbolLabel1_MouseEnter(object sender, EventArgs e)
        {
            uiSymbolLabel1.SymbolColor = Color.Red;
        }

        private void uiSymbolLabel1_MouseLeave(object sender, EventArgs e)
        {
            uiSymbolLabel1.SymbolColor = iconColor;
        }

        private void uiSymbolLabel2_Click(object sender, EventArgs e)
        {
        }

        private void uiSymbolLabel2_MouseEnter(object sender, EventArgs e)
        {

            uiSymbolLabel2.SymbolColor = Color.Red;
        }

        private void uiSymbolLabel2_MouseLeave(object sender, EventArgs e)
        {
            uiSymbolLabel2.SymbolColor = iconColor;
        }

        private void uiSymbolLabel3_MouseEnter(object sender, EventArgs e)
        {
            uiSymbolLabel3.SymbolColor = Color.Red;
        }

        private void uiSymbolLabel3_MouseLeave(object sender, EventArgs e)
        {
            uiSymbolLabel3.SymbolColor = iconColor;
        }
        private Point mouseLocation;//表示鼠标对于窗口左上角的坐标的负数
        private bool isDragging;//标识鼠标是否按下
        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseLocation = new Point(-e.X, -e.Y);
                //表示鼠标当前位置相对于窗口左上角的坐标，
                //并取负数,这里的e是参数，
                //可以获取鼠标位置
                isDragging = true;//标识鼠标已经按下
            }
        }

        private void Login_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point newMouseLocation = MousePosition;
                //获取鼠标当前位置
                newMouseLocation.Offset(mouseLocation.X, mouseLocation.Y);
                //用鼠标当前位置加上鼠标相较于窗体左上角的
                //坐标的负数，也就获取到了新的窗体左上角位置
                Location = newMouseLocation;//设置新的窗体左上角位置
            }
        }

        private void Login_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                isDragging = false;//鼠标已抬起，标识为false
            }

        }

        private void btnScanLogin_Click(object sender, EventArgs e)
        {
            if (btnScanLogin.Text == "扫码登录")
            {
                //扫码登录  获取手机号登录

                string _url = "12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890";


                //初始化二维码生成工具
                //QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                //qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                //qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                //qrCodeEncoder.QRCodeVersion = 0;
                //qrCodeEncoder.QRCodeScale = 4;

                ////将字符串生成二维码图片
                //Bitmap img = qrCodeEncoder.Encode(_url, Encoding.Default);
                //imgQRCode.Image = img;
                //imgQRCode.Show();
                imgQRCode.BringToFront();
                txtSign.Hide();
                txtName.Hide();
                txtPwd.Hide();
                btnLogin.Hide();

                btnScanLogin.Text = "账号登录";
            }
            else
            {
                imgQRCode.Hide();
                txtSign.Show();
                txtName.Show();
                txtPwd.Show();
                btnLogin.Show();
                btnScanLogin.Text = "扫码登录";
            }


        }

        private void btnEditPwd_Click(object sender, EventArgs e)
        {
            //EditPwd editPwd = new EditPwd();
            //editPwd.ShowDialog();
        }
    }
}
