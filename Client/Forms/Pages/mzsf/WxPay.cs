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
using ThoughtWorks.QRCode.Codec;

namespace Mzsf.Forms.Pages
{
    public partial class WxPay : UIForm
    {
        Image _qrImg;
        string _key;
        string _jine;
        string _out_trade_no;
        public WxPay(string key, string je, string out_trade_no)
        {
            InitializeComponent();
            _key = key;
            _jine = je;
            _out_trade_no = out_trade_no;
        }


        private void WxPay_Load(object sender, EventArgs e)
        {  
            string payQRCordUrl = "http://localhosthttp://localhosthttp://localhosthttp://localhosthttp://localhosthttp://localhosthttp://localhost";

            lblJe.Text = _jine;
             
            if (_key == PayMethod.GetChequeTypeByEnum(PayMethodEnum.Zhifubao))
            {
                lblInfo.Text = "打开支付宝扫码支付";
                this.Text = "支付宝支付";

                try
                {
                    #region 生成付款码地址
                    //var cof = AliConfig.GetConfig();
                    //Factory.SetOptions(cof);
                    //AlipayTradePrecreateResponse response = Factory.Payment.FaceToFace().PreCreate("挂号费", _out_trade_no, _jine);

                    //if (ResponseChecker.Success(response))
                    //{
                    //    payQRCordUrl = response.QrCode; //二维码支付地址
                    //}
                    #endregion
                }
                catch (Exception ex)
                {
                    UIMessageBox.ShowError(ex.ToString());
                }
            }
            else if (_key == PayMethod.GetChequeTypeByEnum(PayMethodEnum.WeiXin))
            {
                lblInfo.Text = "打开微信扫码支付";
                this.Text = "微信支付";

                try
                {
                    #region 生成付款码地址
                    //NativePay nativePay = new NativePay();
                    ////生成扫码支付模式二url
                    //var product_id = "123456789";
                    //payQRCordUrl = nativePay.GetPayUrl(product_id, _out_trade_no);
                    #endregion

                }
                catch (Exception ex)
                {
                    UIMessageBox.ShowError(ex.ToString());
                }
            }
             
            //UIMessageBox.Show("生成付款码地址");

            //初始化二维码生成工具
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            qrCodeEncoder.QRCodeVersion = 0;
            qrCodeEncoder.QRCodeScale = 4;

            //将字符串生成二维码图片
            Bitmap img = qrCodeEncoder.Encode(payQRCordUrl, Encoding.Default);
            this.imgQRCode.Image = img;


        }
    }
}

