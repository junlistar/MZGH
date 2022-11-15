namespace MainFrame
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.btnLostPwd = new Sunny.UI.UILinkLabel();
            this.btnEditPwd = new Sunny.UI.UILinkLabel();
            this.btnScanLogin = new Sunny.UI.UILinkLabel();
            this.imgQRCode = new System.Windows.Forms.PictureBox();
            this.lblTitle1 = new Sunny.UI.UILabel();
            this.txtSign = new Sunny.UI.UITextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnLogin = new Sunny.UI.UISymbolButton();
            this.txtPwd = new Sunny.UI.UITextBox();
            this.txtName = new Sunny.UI.UITextBox();
            this.uiSymbolLabel1 = new Sunny.UI.UISymbolLabel();
            this.uiSymbolLabel2 = new Sunny.UI.UISymbolLabel();
            this.uiSymbolLabel3 = new Sunny.UI.UISymbolLabel();
            this.uiPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgQRCode)).BeginInit();
            this.SuspendLayout();
            // 
            // uiPanel1
            // 
            this.uiPanel1.Controls.Add(this.btnLostPwd);
            this.uiPanel1.Controls.Add(this.btnEditPwd);
            this.uiPanel1.Controls.Add(this.btnScanLogin);
            this.uiPanel1.Controls.Add(this.imgQRCode);
            this.uiPanel1.Controls.Add(this.lblTitle1);
            this.uiPanel1.Controls.Add(this.txtSign);
            this.uiPanel1.Controls.Add(this.label4);
            this.uiPanel1.Controls.Add(this.btnLogin);
            this.uiPanel1.Controls.Add(this.txtPwd);
            this.uiPanel1.Controls.Add(this.txtName);
            this.uiPanel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel1.Location = new System.Drawing.Point(524, 71);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Radius = 0;
            this.uiPanel1.Size = new System.Drawing.Size(360, 394);
            this.uiPanel1.TabIndex = 1;
            this.uiPanel1.Text = null;
            this.uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiPanel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnLostPwd
            // 
            this.btnLostPwd.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(155)))), ((int)(((byte)(40)))));
            this.btnLostPwd.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLostPwd.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.btnLostPwd.Location = new System.Drawing.Point(231, 275);
            this.btnLostPwd.Name = "btnLostPwd";
            this.btnLostPwd.Size = new System.Drawing.Size(67, 23);
            this.btnLostPwd.TabIndex = 13;
            this.btnLostPwd.TabStop = true;
            this.btnLostPwd.Text = "忘记密码";
            this.btnLostPwd.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnLostPwd.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnEditPwd
            // 
            this.btnEditPwd.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(155)))), ((int)(((byte)(40)))));
            this.btnEditPwd.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEditPwd.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.btnEditPwd.Location = new System.Drawing.Point(151, 275);
            this.btnEditPwd.Name = "btnEditPwd";
            this.btnEditPwd.Size = new System.Drawing.Size(67, 23);
            this.btnEditPwd.TabIndex = 12;
            this.btnEditPwd.TabStop = true;
            this.btnEditPwd.Text = "修改密码";
            this.btnEditPwd.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnEditPwd.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnEditPwd.Click += new System.EventHandler(this.btnEditPwd_Click);
            // 
            // btnScanLogin
            // 
            this.btnScanLogin.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(155)))), ((int)(((byte)(40)))));
            this.btnScanLogin.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnScanLogin.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.btnScanLogin.Location = new System.Drawing.Point(78, 275);
            this.btnScanLogin.Name = "btnScanLogin";
            this.btnScanLogin.Size = new System.Drawing.Size(67, 23);
            this.btnScanLogin.TabIndex = 6;
            this.btnScanLogin.TabStop = true;
            this.btnScanLogin.Text = "扫码登录";
            this.btnScanLogin.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnScanLogin.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnScanLogin.Click += new System.EventHandler(this.btnScanLogin_Click);
            // 
            // imgQRCode
            // 
            this.imgQRCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.imgQRCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgQRCode.Location = new System.Drawing.Point(73, 71);
            this.imgQRCode.Name = "imgQRCode";
            this.imgQRCode.Size = new System.Drawing.Size(223, 195);
            this.imgQRCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgQRCode.TabIndex = 14;
            this.imgQRCode.TabStop = false;
            this.imgQRCode.Visible = false;
            // 
            // lblTitle1
            // 
            this.lblTitle1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblTitle1.Location = new System.Drawing.Point(68, 25);
            this.lblTitle1.Name = "lblTitle1";
            this.lblTitle1.Size = new System.Drawing.Size(237, 30);
            this.lblTitle1.Style = Sunny.UI.UIStyle.Custom;
            this.lblTitle1.StyleCustomMode = true;
            this.lblTitle1.TabIndex = 10;
            this.lblTitle1.Text = "湖北省荆州市中心医院";
            this.lblTitle1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtSign
            // 
            this.txtSign.ButtonSymbol = 61703;
            this.txtSign.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSign.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSign.Location = new System.Drawing.Point(82, 113);
            this.txtSign.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSign.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtSign.Name = "txtSign";
            this.txtSign.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(178)))), ((int)(((byte)(181)))));
            this.txtSign.ShowText = false;
            this.txtSign.Size = new System.Drawing.Size(210, 30);
            this.txtSign.Style = Sunny.UI.UIStyle.Custom;
            this.txtSign.StyleCustomMode = true;
            this.txtSign.Symbol = 62104;
            this.txtSign.TabIndex = 10;
            this.txtSign.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtSign.Watermark = "";
            this.txtSign.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(88, 367);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Copyright 2022 谷翔科技 版权所有";
            // 
            // btnLogin
            // 
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLogin.Location = new System.Drawing.Point(81, 236);
            this.btnLogin.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(210, 30);
            this.btnLogin.Symbol = -1;
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "登录";
            this.btnLogin.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLogin.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPwd
            // 
            this.txtPwd.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPwd.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPwd.Location = new System.Drawing.Point(82, 194);
            this.txtPwd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPwd.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.ShowText = false;
            this.txtPwd.Size = new System.Drawing.Size(210, 30);
            this.txtPwd.Symbol = 57452;
            this.txtPwd.TabIndex = 4;
            this.txtPwd.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtPwd.Watermark = "请输入密码";
            this.txtPwd.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txtPwd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPwd_KeyUp);
            // 
            // txtName
            // 
            this.txtName.ButtonSymbolSize = 39;
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtName.Location = new System.Drawing.Point(82, 154);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtName.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtName.Name = "txtName";
            this.txtName.ShowText = false;
            this.txtName.Size = new System.Drawing.Size(210, 30);
            this.txtName.Symbol = 61447;
            this.txtName.TabIndex = 0;
            this.txtName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtName.Watermark = "请输入账号";
            this.txtName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txtName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyUp);
            // 
            // uiSymbolLabel1
            // 
            this.uiSymbolLabel1.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolLabel1.ForeColor = System.Drawing.Color.Red;
            this.uiSymbolLabel1.Location = new System.Drawing.Point(928, 2);
            this.uiSymbolLabel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolLabel1.Name = "uiSymbolLabel1";
            this.uiSymbolLabel1.Padding = new System.Windows.Forms.Padding(28, 0, 0, 0);
            this.uiSymbolLabel1.Size = new System.Drawing.Size(29, 31);
            this.uiSymbolLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolLabel1.StyleCustomMode = true;
            this.uiSymbolLabel1.Symbol = 61453;
            this.uiSymbolLabel1.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.uiSymbolLabel1.SymbolOffset = new System.Drawing.Point(1, 0);
            this.uiSymbolLabel1.TabIndex = 3;
            this.uiSymbolLabel1.Text = " ";
            this.uiSymbolLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiSymbolLabel1.Click += new System.EventHandler(this.uiSymbolLabel1_Click);
            this.uiSymbolLabel1.MouseEnter += new System.EventHandler(this.uiSymbolLabel1_MouseEnter);
            this.uiSymbolLabel1.MouseLeave += new System.EventHandler(this.uiSymbolLabel1_MouseLeave);
            // 
            // uiSymbolLabel2
            // 
            this.uiSymbolLabel2.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolLabel2.ForeColor = System.Drawing.Color.Red;
            this.uiSymbolLabel2.Location = new System.Drawing.Point(893, 2);
            this.uiSymbolLabel2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolLabel2.Name = "uiSymbolLabel2";
            this.uiSymbolLabel2.Padding = new System.Windows.Forms.Padding(28, 0, 0, 0);
            this.uiSymbolLabel2.Size = new System.Drawing.Size(29, 31);
            this.uiSymbolLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolLabel2.StyleCustomMode = true;
            this.uiSymbolLabel2.Symbol = 362612;
            this.uiSymbolLabel2.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.uiSymbolLabel2.TabIndex = 4;
            this.uiSymbolLabel2.Text = " ";
            this.uiSymbolLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiSymbolLabel2.MouseEnter += new System.EventHandler(this.uiSymbolLabel2_MouseEnter);
            this.uiSymbolLabel2.MouseLeave += new System.EventHandler(this.uiSymbolLabel2_MouseLeave);
            // 
            // uiSymbolLabel3
            // 
            this.uiSymbolLabel3.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolLabel3.ForeColor = System.Drawing.Color.Red;
            this.uiSymbolLabel3.Location = new System.Drawing.Point(858, 2);
            this.uiSymbolLabel3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolLabel3.Name = "uiSymbolLabel3";
            this.uiSymbolLabel3.Padding = new System.Windows.Forms.Padding(28, 0, 0, 0);
            this.uiSymbolLabel3.Size = new System.Drawing.Size(29, 31);
            this.uiSymbolLabel3.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolLabel3.StyleCustomMode = true;
            this.uiSymbolLabel3.Symbol = 61641;
            this.uiSymbolLabel3.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.uiSymbolLabel3.SymbolOffset = new System.Drawing.Point(-2, 0);
            this.uiSymbolLabel3.TabIndex = 5;
            this.uiSymbolLabel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiSymbolLabel3.MouseEnter += new System.EventHandler(this.uiSymbolLabel3_MouseEnter);
            this.uiSymbolLabel3.MouseLeave += new System.EventHandler(this.uiSymbolLabel3_MouseLeave);
            // 
            // Login
            // 
            this.AllowShowTitle = false;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::MainFrame.Properties.Resources.login_bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(960, 540);
            this.Controls.Add(this.uiSymbolLabel3);
            this.Controls.Add(this.uiSymbolLabel2);
            this.Controls.Add(this.uiSymbolLabel1);
            this.Controls.Add(this.uiPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.Padding = new System.Windows.Forms.Padding(0);
            this.ShowTitle = false;
            this.Text = "门诊挂号";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.Load += new System.EventHandler(this.Login_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Login_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Login_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Login_MouseUp);
            this.uiPanel1.ResumeLayout(false);
            this.uiPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgQRCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UITextBox txtName;
        private Sunny.UI.UISymbolButton btnLogin;
        private Sunny.UI.UITextBox txtPwd;
        private Sunny.UI.UITextBox txtSign;
        private Sunny.UI.UILabel lblTitle1;
        private System.Windows.Forms.Label label4;
        private Sunny.UI.UISymbolLabel uiSymbolLabel1;
        private Sunny.UI.UISymbolLabel uiSymbolLabel2;
        private Sunny.UI.UISymbolLabel uiSymbolLabel3;
        private Sunny.UI.UILinkLabel btnLostPwd;
        private Sunny.UI.UILinkLabel btnEditPwd;
        private Sunny.UI.UILinkLabel btnScanLogin;
        private System.Windows.Forms.PictureBox imgQRCode;
    }
}