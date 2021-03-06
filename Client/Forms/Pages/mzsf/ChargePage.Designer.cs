namespace Mzsf.Forms.Pages
{
    partial class ChargePage
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
            this.pnlTitle = new Sunny.UI.UIPanel();
            this.uiButton1 = new Sunny.UI.UIButton();
            this.btnSave = new Sunny.UI.UISymbolButton();
            this.btnHuajia = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton1 = new Sunny.UI.UISymbolButton();
            this.btnExit = new Sunny.UI.UISymbolButton();
            this.lblTitle = new Sunny.UI.UILabel();
            this.lblNodata = new System.Windows.Forms.Label();
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtdistrict = new Sunny.UI.UITextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTimes = new System.Windows.Forms.Label();
            this.txtHicno = new Sunny.UI.UITextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTel = new Sunny.UI.UITextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDoct = new Sunny.UI.UITextBox();
            this.txtUnit = new Sunny.UI.UITextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbxChargeTypes = new Sunny.UI.UIComboBox();
            this.cbxResponseType = new Sunny.UI.UIComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSex = new Sunny.UI.UITextBox();
            this.txtAge = new Sunny.UI.UITextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new Sunny.UI.UITextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCode = new Sunny.UI.UITextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.uiTabControl1 = new Sunny.UI.UITabControl();
            this.uiGroupBox2 = new Sunny.UI.UIGroupBox();
            this.btnYBK = new Sunny.UI.UISymbolButton();
            this.btnIDCard = new Sunny.UI.UISymbolButton();
            this.btnSFZ = new Sunny.UI.UISymbolButton();
            this.btnCika = new Sunny.UI.UISymbolButton();
            this.uiLine1 = new Sunny.UI.UILine();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxOrderType = new Sunny.UI.UIComboBox();
            this.btnAddOrder = new Sunny.UI.UISymbolButton();
            this.pblSum = new Sunny.UI.UIPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.lblOrderItemCount = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblOrderCharge = new System.Windows.Forms.Label();
            this.lblOrderTotalCharge = new System.Windows.Forms.Label();
            this.pnlAddOrder = new Sunny.UI.UIPanel();
            this.pnlTitle.SuspendLayout();
            this.uiGroupBox1.SuspendLayout();
            this.uiGroupBox2.SuspendLayout();
            this.pblSum.SuspendLayout();
            this.pnlAddOrder.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTitle.Controls.Add(this.uiButton1);
            this.pnlTitle.Controls.Add(this.btnSave);
            this.pnlTitle.Controls.Add(this.btnHuajia);
            this.pnlTitle.Controls.Add(this.uiSymbolButton1);
            this.pnlTitle.Controls.Add(this.btnExit);
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Controls.Add(this.lblNodata);
            this.pnlTitle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlTitle.Location = new System.Drawing.Point(13, 14);
            this.pnlTitle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlTitle.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(1225, 66);
            this.pnlTitle.TabIndex = 2;
            this.pnlTitle.Text = null;
            this.pnlTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlTitle.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiButton1
            // 
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton1.Location = new System.Drawing.Point(989, 16);
            this.uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(100, 35);
            this.uiButton1.TabIndex = 14;
            this.uiButton1.Text = "测试打印";
            this.uiButton1.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton1.Visible = false;
            this.uiButton1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(155)))), ((int)(((byte)(40)))));
            this.btnSave.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(155)))), ((int)(((byte)(40)))));
            this.btnSave.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(175)))), ((int)(((byte)(83)))));
            this.btnSave.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(124)))), ((int)(((byte)(32)))));
            this.btnSave.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(124)))), ((int)(((byte)(32)))));
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(1095, 3);
            this.btnSave.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSave.Name = "btnSave";
            this.btnSave.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(155)))), ((int)(((byte)(40)))));
            this.btnSave.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(175)))), ((int)(((byte)(83)))));
            this.btnSave.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(124)))), ((int)(((byte)(32)))));
            this.btnSave.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(124)))), ((int)(((byte)(32)))));
            this.btnSave.Size = new System.Drawing.Size(107, 60);
            this.btnSave.Style = Sunny.UI.UIStyle.Orange;
            this.btnSave.StyleCustomMode = true;
            this.btnSave.Symbol = 61639;
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "保存";
            this.btnSave.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Visible = false;
            this.btnSave.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnHuajia
            // 
            this.btnHuajia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuajia.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.btnHuajia.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.btnHuajia.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.btnHuajia.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.btnHuajia.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.btnHuajia.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnHuajia.Location = new System.Drawing.Point(371, 3);
            this.btnHuajia.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnHuajia.Name = "btnHuajia";
            this.btnHuajia.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.btnHuajia.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.btnHuajia.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.btnHuajia.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.btnHuajia.Size = new System.Drawing.Size(100, 60);
            this.btnHuajia.Style = Sunny.UI.UIStyle.Colorful;
            this.btnHuajia.StyleCustomMode = true;
            this.btnHuajia.Symbol = 362139;
            this.btnHuajia.TabIndex = 12;
            this.btnHuajia.Text = "划价";
            this.btnHuajia.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnHuajia.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnHuajia.Click += new System.EventHandler(this.btnHuajia_Click);
            // 
            // uiSymbolButton1
            // 
            this.uiSymbolButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.uiSymbolButton1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.uiSymbolButton1.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(203)))), ((int)(((byte)(83)))));
            this.uiSymbolButton1.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.uiSymbolButton1.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.uiSymbolButton1.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton1.Location = new System.Drawing.Point(265, 3);
            this.uiSymbolButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton1.Name = "uiSymbolButton1";
            this.uiSymbolButton1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.uiSymbolButton1.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(203)))), ((int)(((byte)(83)))));
            this.uiSymbolButton1.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.uiSymbolButton1.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.uiSymbolButton1.Size = new System.Drawing.Size(100, 60);
            this.uiSymbolButton1.Style = Sunny.UI.UIStyle.Green;
            this.uiSymbolButton1.StyleCustomMode = true;
            this.uiSymbolButton1.Symbol = 61473;
            this.uiSymbolButton1.TabIndex = 10;
            this.uiSymbolButton1.Text = "重新";
            this.uiSymbolButton1.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiSymbolButton1.Click += new System.EventHandler(this.uiSymbolButton1_Click);
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnExit.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnExit.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.btnExit.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnExit.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnExit.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.Location = new System.Drawing.Point(477, 3);
            this.btnExit.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnExit.Name = "btnExit";
            this.btnExit.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnExit.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.btnExit.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnExit.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnExit.Size = new System.Drawing.Size(107, 60);
            this.btnExit.Style = Sunny.UI.UIStyle.Red;
            this.btnExit.StyleCustomMode = true;
            this.btnExit.Symbol = 61579;
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "退出";
            this.btnExit.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(45, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(120, 51);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "划价收费";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblNodata
            // 
            this.lblNodata.AutoSize = true;
            this.lblNodata.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.lblNodata.ForeColor = System.Drawing.Color.Red;
            this.lblNodata.Location = new System.Drawing.Point(720, 21);
            this.lblNodata.Name = "lblNodata";
            this.lblNodata.Size = new System.Drawing.Size(182, 31);
            this.lblNodata.TabIndex = 6;
            this.lblNodata.Text = "没有查询到数据";
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.label14);
            this.uiGroupBox1.Controls.Add(this.txtdistrict);
            this.uiGroupBox1.Controls.Add(this.label1);
            this.uiGroupBox1.Controls.Add(this.lblTimes);
            this.uiGroupBox1.Controls.Add(this.txtHicno);
            this.uiGroupBox1.Controls.Add(this.label12);
            this.uiGroupBox1.Controls.Add(this.txtTel);
            this.uiGroupBox1.Controls.Add(this.label11);
            this.uiGroupBox1.Controls.Add(this.label10);
            this.uiGroupBox1.Controls.Add(this.txtDoct);
            this.uiGroupBox1.Controls.Add(this.txtUnit);
            this.uiGroupBox1.Controls.Add(this.label9);
            this.uiGroupBox1.Controls.Add(this.cbxChargeTypes);
            this.uiGroupBox1.Controls.Add(this.cbxResponseType);
            this.uiGroupBox1.Controls.Add(this.label7);
            this.uiGroupBox1.Controls.Add(this.label6);
            this.uiGroupBox1.Controls.Add(this.txtSex);
            this.uiGroupBox1.Controls.Add(this.txtAge);
            this.uiGroupBox1.Controls.Add(this.label4);
            this.uiGroupBox1.Controls.Add(this.txtName);
            this.uiGroupBox1.Controls.Add(this.label3);
            this.uiGroupBox1.Controls.Add(this.txtCode);
            this.uiGroupBox1.Controls.Add(this.label2);
            this.uiGroupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox1.Location = new System.Drawing.Point(303, 90);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox1.Size = new System.Drawing.Size(743, 197);
            this.uiGroupBox1.TabIndex = 3;
            this.uiGroupBox1.Text = "患者信息";
            this.uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiGroupBox1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(341, 73);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(42, 21);
            this.label14.TabIndex = 23;
            this.label14.Text = "性别";
            // 
            // txtdistrict
            // 
            this.txtdistrict.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtdistrict.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtdistrict.Location = new System.Drawing.Point(68, 108);
            this.txtdistrict.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtdistrict.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtdistrict.Name = "txtdistrict";
            this.txtdistrict.ReadOnly = true;
            this.txtdistrict.ShowText = false;
            this.txtdistrict.Size = new System.Drawing.Size(170, 29);
            this.txtdistrict.TabIndex = 21;
            this.txtdistrict.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtdistrict.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 21);
            this.label1.TabIndex = 22;
            this.label1.Text = "地区";
            // 
            // lblTimes
            // 
            this.lblTimes.AutoSize = true;
            this.lblTimes.Location = new System.Drawing.Point(483, 152);
            this.lblTimes.Name = "lblTimes";
            this.lblTimes.Size = new System.Drawing.Size(74, 21);
            this.lblTimes.TabIndex = 20;
            this.lblTimes.Text = "来访号：";
            // 
            // txtHicno
            // 
            this.txtHicno.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtHicno.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtHicno.Location = new System.Drawing.Point(68, 69);
            this.txtHicno.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtHicno.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtHicno.Name = "txtHicno";
            this.txtHicno.ReadOnly = true;
            this.txtHicno.ShowText = false;
            this.txtHicno.Size = new System.Drawing.Size(170, 29);
            this.txtHicno.TabIndex = 5;
            this.txtHicno.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtHicno.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 73);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 21);
            this.label12.TabIndex = 6;
            this.label12.Text = "身份证";
            // 
            // txtTel
            // 
            this.txtTel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTel.Location = new System.Drawing.Point(487, 69);
            this.txtTel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTel.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtTel.Name = "txtTel";
            this.txtTel.ReadOnly = true;
            this.txtTel.ShowText = false;
            this.txtTel.Size = new System.Drawing.Size(149, 29);
            this.txtTel.TabIndex = 5;
            this.txtTel.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtTel.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(447, 73);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 21);
            this.label11.TabIndex = 14;
            this.label11.Text = "手机";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 152);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 21);
            this.label10.TabIndex = 13;
            this.label10.Text = "科室";
            // 
            // txtDoct
            // 
            this.txtDoct.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDoct.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDoct.Location = new System.Drawing.Point(290, 147);
            this.txtDoct.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDoct.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtDoct.Name = "txtDoct";
            this.txtDoct.ReadOnly = true;
            this.txtDoct.ShowText = false;
            this.txtDoct.Size = new System.Drawing.Size(150, 29);
            this.txtDoct.TabIndex = 12;
            this.txtDoct.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtDoct.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtUnit
            // 
            this.txtUnit.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUnit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtUnit.Location = new System.Drawing.Point(68, 147);
            this.txtUnit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUnit.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.ReadOnly = true;
            this.txtUnit.ShowText = false;
            this.txtUnit.Size = new System.Drawing.Size(170, 29);
            this.txtUnit.TabIndex = 11;
            this.txtUnit.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtUnit.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(245, 152);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 21);
            this.label9.TabIndex = 10;
            this.label9.Text = "医生";
            // 
            // cbxChargeTypes
            // 
            this.cbxChargeTypes.DataSource = null;
            this.cbxChargeTypes.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbxChargeTypes.FillColor = System.Drawing.Color.White;
            this.cbxChargeTypes.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxChargeTypes.Location = new System.Drawing.Point(487, 108);
            this.cbxChargeTypes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxChargeTypes.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbxChargeTypes.Name = "cbxChargeTypes";
            this.cbxChargeTypes.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbxChargeTypes.ReadOnly = true;
            this.cbxChargeTypes.Size = new System.Drawing.Size(149, 29);
            this.cbxChargeTypes.TabIndex = 2;
            this.cbxChargeTypes.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbxChargeTypes.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cbxResponseType
            // 
            this.cbxResponseType.DataSource = null;
            this.cbxResponseType.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbxResponseType.FillColor = System.Drawing.Color.White;
            this.cbxResponseType.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxResponseType.Location = new System.Drawing.Point(290, 108);
            this.cbxResponseType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxResponseType.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbxResponseType.Name = "cbxResponseType";
            this.cbxResponseType.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbxResponseType.ReadOnly = true;
            this.cbxResponseType.Size = new System.Drawing.Size(150, 29);
            this.cbxResponseType.TabIndex = 2;
            this.cbxResponseType.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbxResponseType.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(447, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 21);
            this.label7.TabIndex = 8;
            this.label7.Text = "费别";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(245, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 21);
            this.label6.TabIndex = 7;
            this.label6.Text = "身份";
            // 
            // txtSex
            // 
            this.txtSex.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSex.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSex.Location = new System.Drawing.Point(387, 69);
            this.txtSex.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSex.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtSex.Name = "txtSex";
            this.txtSex.ReadOnly = true;
            this.txtSex.ShowText = false;
            this.txtSex.Size = new System.Drawing.Size(53, 29);
            this.txtSex.TabIndex = 5;
            this.txtSex.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtSex.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtAge
            // 
            this.txtAge.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAge.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAge.Location = new System.Drawing.Point(290, 69);
            this.txtAge.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAge.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtAge.Name = "txtAge";
            this.txtAge.ReadOnly = true;
            this.txtAge.ShowText = false;
            this.txtAge.Size = new System.Drawing.Size(49, 29);
            this.txtAge.TabIndex = 4;
            this.txtAge.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtAge.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(245, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 21);
            this.label4.TabIndex = 5;
            this.label4.Text = "年龄";
            // 
            // txtName
            // 
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtName.Location = new System.Drawing.Point(290, 30);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtName.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.ShowText = false;
            this.txtName.Size = new System.Drawing.Size(150, 29);
            this.txtName.TabIndex = 4;
            this.txtName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(245, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "姓名";
            // 
            // txtCode
            // 
            this.txtCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCode.Location = new System.Drawing.Point(68, 31);
            this.txtCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCode.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.ShowText = false;
            this.txtCode.Size = new System.Drawing.Size(170, 29);
            this.txtCode.TabIndex = 3;
            this.txtCode.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtCode.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txtCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "卡号";
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(349, 40);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 21);
            this.lblMsg.TabIndex = 19;
            // 
            // uiTabControl1
            // 
            this.uiTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.uiTabControl1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTabControl1.ItemSize = new System.Drawing.Size(150, 40);
            this.uiTabControl1.Location = new System.Drawing.Point(12, 357);
            this.uiTabControl1.MainPage = "";
            this.uiTabControl1.Name = "uiTabControl1";
            this.uiTabControl1.SelectedIndex = 0;
            this.uiTabControl1.Size = new System.Drawing.Size(1226, 268);
            this.uiTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uiTabControl1.TabIndex = 4;
            this.uiTabControl1.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTabControl1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiTabControl1.BeforeRemoveTabPage += new Sunny.UI.UITabControl.OnBeforeRemoveTabPage(this.uiTabControl1_BeforeRemoveTabPage);
            this.uiTabControl1.SelectedIndexChanged += new System.EventHandler(this.uiTabControl1_SelectedIndexChanged);
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.Controls.Add(this.btnYBK);
            this.uiGroupBox2.Controls.Add(this.btnIDCard);
            this.uiGroupBox2.Controls.Add(this.btnSFZ);
            this.uiGroupBox2.Controls.Add(this.btnCika);
            this.uiGroupBox2.Controls.Add(this.lblMsg);
            this.uiGroupBox2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox2.Location = new System.Drawing.Point(13, 90);
            this.uiGroupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.uiGroupBox2.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox2.Size = new System.Drawing.Size(282, 197);
            this.uiGroupBox2.TabIndex = 14;
            this.uiGroupBox2.Text = "刷卡查询";
            this.uiGroupBox2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiGroupBox2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiGroupBox2.Click += new System.EventHandler(this.uiGroupBox2_Click);
            // 
            // btnYBK
            // 
            this.btnYBK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYBK.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnYBK.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnYBK.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(203)))), ((int)(((byte)(83)))));
            this.btnYBK.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnYBK.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnYBK.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnYBK.Location = new System.Drawing.Point(138, 110);
            this.btnYBK.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnYBK.Name = "btnYBK";
            this.btnYBK.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnYBK.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(203)))), ((int)(((byte)(83)))));
            this.btnYBK.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnYBK.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnYBK.Size = new System.Drawing.Size(120, 37);
            this.btnYBK.Style = Sunny.UI.UIStyle.Green;
            this.btnYBK.StyleCustomMode = true;
            this.btnYBK.Symbol = 62140;
            this.btnYBK.TabIndex = 33;
            this.btnYBK.Text = "医保卡";
            this.btnYBK.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnYBK.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnYBK.Click += new System.EventHandler(this.btnYBK_Click);
            // 
            // btnIDCard
            // 
            this.btnIDCard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIDCard.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnIDCard.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnIDCard.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(203)))), ((int)(((byte)(83)))));
            this.btnIDCard.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnIDCard.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnIDCard.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnIDCard.Location = new System.Drawing.Point(138, 60);
            this.btnIDCard.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnIDCard.Name = "btnIDCard";
            this.btnIDCard.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnIDCard.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(203)))), ((int)(((byte)(83)))));
            this.btnIDCard.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnIDCard.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnIDCard.Size = new System.Drawing.Size(120, 38);
            this.btnIDCard.Style = Sunny.UI.UIStyle.Green;
            this.btnIDCard.StyleCustomMode = true;
            this.btnIDCard.Symbol = 62140;
            this.btnIDCard.TabIndex = 34;
            this.btnIDCard.Text = "I D 卡";
            this.btnIDCard.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnIDCard.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnIDCard.Click += new System.EventHandler(this.btnIDCard_Click);
            // 
            // btnSFZ
            // 
            this.btnSFZ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSFZ.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnSFZ.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnSFZ.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(203)))), ((int)(((byte)(83)))));
            this.btnSFZ.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnSFZ.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnSFZ.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSFZ.Location = new System.Drawing.Point(12, 110);
            this.btnSFZ.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSFZ.Name = "btnSFZ";
            this.btnSFZ.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnSFZ.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(203)))), ((int)(((byte)(83)))));
            this.btnSFZ.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnSFZ.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnSFZ.Size = new System.Drawing.Size(120, 37);
            this.btnSFZ.Style = Sunny.UI.UIStyle.Green;
            this.btnSFZ.StyleCustomMode = true;
            this.btnSFZ.Symbol = 62140;
            this.btnSFZ.TabIndex = 32;
            this.btnSFZ.Text = "身份证";
            this.btnSFZ.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSFZ.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnSFZ.Click += new System.EventHandler(this.btnSFZ_Click);
            // 
            // btnCika
            // 
            this.btnCika.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCika.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnCika.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnCika.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(203)))), ((int)(((byte)(83)))));
            this.btnCika.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnCika.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnCika.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCika.Location = new System.Drawing.Point(12, 60);
            this.btnCika.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnCika.Name = "btnCika";
            this.btnCika.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnCika.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(203)))), ((int)(((byte)(83)))));
            this.btnCika.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnCika.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnCika.Size = new System.Drawing.Size(120, 38);
            this.btnCika.Style = Sunny.UI.UIStyle.Green;
            this.btnCika.StyleCustomMode = true;
            this.btnCika.Symbol = 62140;
            this.btnCika.TabIndex = 31;
            this.btnCika.Text = "磁   卡";
            this.btnCika.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCika.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnCika.Click += new System.EventHandler(this.btnCika_Click);
            // 
            // uiLine1
            // 
            this.uiLine1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiLine1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine1.Location = new System.Drawing.Point(12, 295);
            this.uiLine1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(1226, 10);
            this.uiLine1.TabIndex = 15;
            this.uiLine1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 21);
            this.label5.TabIndex = 24;
            this.label5.Text = "处方类型";
            // 
            // cbxOrderType
            // 
            this.cbxOrderType.DataSource = null;
            this.cbxOrderType.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbxOrderType.FillColor = System.Drawing.Color.White;
            this.cbxOrderType.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxOrderType.Location = new System.Drawing.Point(89, 6);
            this.cbxOrderType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxOrderType.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbxOrderType.Name = "cbxOrderType";
            this.cbxOrderType.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbxOrderType.Size = new System.Drawing.Size(150, 29);
            this.cbxOrderType.TabIndex = 25;
            this.cbxOrderType.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbxOrderType.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnAddOrder
            // 
            this.btnAddOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddOrder.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddOrder.Location = new System.Drawing.Point(254, 6);
            this.btnAddOrder.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnAddOrder.Name = "btnAddOrder";
            this.btnAddOrder.Size = new System.Drawing.Size(100, 29);
            this.btnAddOrder.Symbol = 362139;
            this.btnAddOrder.TabIndex = 26;
            this.btnAddOrder.Text = "增处方";
            this.btnAddOrder.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddOrder.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnAddOrder.Click += new System.EventHandler(this.btnAddOrder_Click);
            // 
            // pblSum
            // 
            this.pblSum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pblSum.Controls.Add(this.label8);
            this.pblSum.Controls.Add(this.lblOrderItemCount);
            this.pblSum.Controls.Add(this.label13);
            this.pblSum.Controls.Add(this.label16);
            this.pblSum.Controls.Add(this.lblOrderCharge);
            this.pblSum.Controls.Add(this.lblOrderTotalCharge);
            this.pblSum.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pblSum.Location = new System.Drawing.Point(12, 633);
            this.pblSum.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pblSum.MinimumSize = new System.Drawing.Size(1, 1);
            this.pblSum.Name = "pblSum";
            this.pblSum.Size = new System.Drawing.Size(643, 48);
            this.pblSum.TabIndex = 30;
            this.pblSum.Text = null;
            this.pblSum.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pblSum.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 21);
            this.label8.TabIndex = 7;
            this.label8.Text = "处方金额(元)：";
            // 
            // lblOrderItemCount
            // 
            this.lblOrderItemCount.AutoSize = true;
            this.lblOrderItemCount.ForeColor = System.Drawing.Color.Red;
            this.lblOrderItemCount.Location = new System.Drawing.Point(320, 3);
            this.lblOrderItemCount.Name = "lblOrderItemCount";
            this.lblOrderItemCount.Size = new System.Drawing.Size(19, 21);
            this.lblOrderItemCount.TabIndex = 12;
            this.lblOrderItemCount.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(37, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 21);
            this.label13.TabIndex = 8;
            this.label13.Text = "总计(元)：";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(224, 3);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(90, 21);
            this.label16.TabIndex = 11;
            this.label16.Text = "细目合计：";
            // 
            // lblOrderCharge
            // 
            this.lblOrderCharge.AutoSize = true;
            this.lblOrderCharge.ForeColor = System.Drawing.Color.Red;
            this.lblOrderCharge.Location = new System.Drawing.Point(127, 3);
            this.lblOrderCharge.Name = "lblOrderCharge";
            this.lblOrderCharge.Size = new System.Drawing.Size(41, 21);
            this.lblOrderCharge.TabIndex = 9;
            this.lblOrderCharge.Text = "0.00";
            // 
            // lblOrderTotalCharge
            // 
            this.lblOrderTotalCharge.AutoSize = true;
            this.lblOrderTotalCharge.ForeColor = System.Drawing.Color.Red;
            this.lblOrderTotalCharge.Location = new System.Drawing.Point(127, 24);
            this.lblOrderTotalCharge.Name = "lblOrderTotalCharge";
            this.lblOrderTotalCharge.Size = new System.Drawing.Size(41, 21);
            this.lblOrderTotalCharge.TabIndex = 10;
            this.lblOrderTotalCharge.Text = "0.00";
            // 
            // pnlAddOrder
            // 
            this.pnlAddOrder.Controls.Add(this.btnAddOrder);
            this.pnlAddOrder.Controls.Add(this.label5);
            this.pnlAddOrder.Controls.Add(this.cbxOrderType);
            this.pnlAddOrder.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlAddOrder.Location = new System.Drawing.Point(13, 308);
            this.pnlAddOrder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlAddOrder.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlAddOrder.Name = "pnlAddOrder";
            this.pnlAddOrder.Size = new System.Drawing.Size(1225, 41);
            this.pnlAddOrder.TabIndex = 31;
            this.pnlAddOrder.Text = null;
            this.pnlAddOrder.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlAddOrder.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // ChargePage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1259, 686);
            this.Controls.Add(this.pnlAddOrder);
            this.Controls.Add(this.pblSum);
            this.Controls.Add(this.uiLine1);
            this.Controls.Add(this.uiGroupBox2);
            this.Controls.Add(this.uiTabControl1);
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.pnlTitle);
            this.Name = "ChargePage";
            this.PageIndex = 1101;
            this.Text = "划价收费";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ChargePage_FormClosed);
            this.Load += new System.EventHandler(this.ChargePage_Load);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox1.PerformLayout();
            this.uiGroupBox2.ResumeLayout(false);
            this.uiGroupBox2.PerformLayout();
            this.pblSum.ResumeLayout(false);
            this.pblSum.PerformLayout();
            this.pnlAddOrder.ResumeLayout(false);
            this.pnlAddOrder.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIPanel pnlTitle;
        private Sunny.UI.UISymbolButton uiSymbolButton1;
        private Sunny.UI.UISymbolButton btnExit;
        private Sunny.UI.UILabel lblTitle;
        private Sunny.UI.UIGroupBox uiGroupBox1;
        private System.Windows.Forms.Label label10;
        private Sunny.UI.UITextBox txtDoct;
        private Sunny.UI.UITextBox txtUnit;
        private System.Windows.Forms.Label label9;
        private Sunny.UI.UIComboBox cbxChargeTypes;
        private Sunny.UI.UIComboBox cbxResponseType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private Sunny.UI.UITextBox txtSex;
        private Sunny.UI.UITextBox txtAge;
        private System.Windows.Forms.Label lblNodata;
        private System.Windows.Forms.Label label4;
        private Sunny.UI.UITextBox txtName;
        private System.Windows.Forms.Label label3;
        private Sunny.UI.UITextBox txtCode;
        private System.Windows.Forms.Label label2;
        private Sunny.UI.UITextBox txtTel;
        private System.Windows.Forms.Label label11;
        private Sunny.UI.UITextBox txtHicno;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Label lblTimes;
        private Sunny.UI.UITextBox txtdistrict;
        private System.Windows.Forms.Label label1;
        private Sunny.UI.UITabControl uiTabControl1;
        private Sunny.UI.UISymbolButton btnHuajia;
        private Sunny.UI.UIGroupBox uiGroupBox2;
        private System.Windows.Forms.Label label14;
        private Sunny.UI.UILine uiLine1;
        private System.Windows.Forms.Label label5;
        private Sunny.UI.UIComboBox cbxOrderType;
        private Sunny.UI.UISymbolButton btnAddOrder;
        private Sunny.UI.UIPanel pblSum;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblOrderItemCount;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblOrderCharge;
        private System.Windows.Forms.Label lblOrderTotalCharge;
        private Sunny.UI.UISymbolButton btnSave;
        private Sunny.UI.UISymbolButton btnIDCard;
        private Sunny.UI.UISymbolButton btnCika;
        private Sunny.UI.UISymbolButton btnYBK;
        private Sunny.UI.UISymbolButton btnSFZ;
        private Sunny.UI.UIPanel pnlAddOrder;
        private Sunny.UI.UIButton uiButton1;
    }
}