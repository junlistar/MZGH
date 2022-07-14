namespace Client.Forms.Pages.cwgl
{
    partial class GuahaoRijie
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
            this.btnReset = new Sunny.UI.UISymbolButton();
            this.btnPrint = new Sunny.UI.UISymbolButton();
            this.btnSave = new Sunny.UI.UISymbolButton();
            this.btnRefresh = new Sunny.UI.UISymbolButton();
            this.btnExit = new Sunny.UI.UISymbolButton();
            this.lblTitle = new Sunny.UI.UILabel();
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.cbxStatus = new Sunny.UI.UIComboBox();
            this.btn_jkmx = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton4 = new Sunny.UI.UISymbolButton();
            this.txtDate = new Sunny.UI.UIDatePicker();
            this.uiSymbolButton3 = new Sunny.UI.UISymbolButton();
            this.label2 = new System.Windows.Forms.Label();
            this.uiSymbolButton2 = new Sunny.UI.UISymbolButton();
            this.label1 = new System.Windows.Forms.Label();
            this.previewControl1 = new FastReport.Preview.PreviewControl();
            this.pnlReport = new Sunny.UI.UIPanel();
            this.pnlTitle.SuspendLayout();
            this.uiPanel1.SuspendLayout();
            this.pnlReport.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTitle.Controls.Add(this.btnReset);
            this.pnlTitle.Controls.Add(this.btnPrint);
            this.pnlTitle.Controls.Add(this.btnSave);
            this.pnlTitle.Controls.Add(this.btnRefresh);
            this.pnlTitle.Controls.Add(this.btnExit);
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlTitle.Location = new System.Drawing.Point(13, 14);
            this.pnlTitle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlTitle.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(1224, 66);
            this.pnlTitle.TabIndex = 15;
            this.pnlTitle.Text = null;
            this.pnlTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlTitle.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnReset
            // 
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReset.Location = new System.Drawing.Point(301, 3);
            this.btnReset.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(119, 60);
            this.btnReset.StyleCustomMode = true;
            this.btnReset.Symbol = 61473;
            this.btnReset.TabIndex = 15;
            this.btnReset.Text = "重新";
            this.btnReset.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReset.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.btnPrint.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.btnPrint.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.btnPrint.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.btnPrint.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.btnPrint.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrint.Location = new System.Drawing.Point(542, 3);
            this.btnPrint.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.btnPrint.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.btnPrint.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.btnPrint.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.btnPrint.Size = new System.Drawing.Size(119, 60);
            this.btnPrint.Style = Sunny.UI.UIStyle.Colorful;
            this.btnPrint.StyleCustomMode = true;
            this.btnPrint.Symbol = 61487;
            this.btnPrint.TabIndex = 12;
            this.btnPrint.Text = "打印";
            this.btnPrint.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrint.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(155)))), ((int)(((byte)(40)))));
            this.btnSave.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(155)))), ((int)(((byte)(40)))));
            this.btnSave.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(175)))), ((int)(((byte)(83)))));
            this.btnSave.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(124)))), ((int)(((byte)(32)))));
            this.btnSave.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(124)))), ((int)(((byte)(32)))));
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(426, 3);
            this.btnSave.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSave.Name = "btnSave";
            this.btnSave.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(155)))), ((int)(((byte)(40)))));
            this.btnSave.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(175)))), ((int)(((byte)(83)))));
            this.btnSave.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(124)))), ((int)(((byte)(32)))));
            this.btnSave.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(124)))), ((int)(((byte)(32)))));
            this.btnSave.Size = new System.Drawing.Size(110, 60);
            this.btnSave.Style = Sunny.UI.UIStyle.Orange;
            this.btnSave.StyleCustomMode = true;
            this.btnSave.Symbol = 61639;
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "结算";
            this.btnSave.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnRefresh.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnRefresh.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(203)))), ((int)(((byte)(83)))));
            this.btnRefresh.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnRefresh.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnRefresh.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRefresh.Location = new System.Drawing.Point(185, 3);
            this.btnRefresh.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnRefresh.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(203)))), ((int)(((byte)(83)))));
            this.btnRefresh.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnRefresh.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnRefresh.Size = new System.Drawing.Size(110, 60);
            this.btnRefresh.Style = Sunny.UI.UIStyle.Green;
            this.btnRefresh.StyleCustomMode = true;
            this.btnRefresh.Symbol = 61442;
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "预览";
            this.btnRefresh.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRefresh.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnExit.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnExit.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.btnExit.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnExit.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnExit.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.Location = new System.Drawing.Point(667, 3);
            this.btnExit.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnExit.Name = "btnExit";
            this.btnExit.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnExit.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.btnExit.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnExit.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnExit.Size = new System.Drawing.Size(119, 60);
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
            this.lblTitle.Size = new System.Drawing.Size(134, 51);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "挂号日结";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiPanel1
            // 
            this.uiPanel1.Controls.Add(this.cbxStatus);
            this.uiPanel1.Controls.Add(this.btn_jkmx);
            this.uiPanel1.Controls.Add(this.uiSymbolButton4);
            this.uiPanel1.Controls.Add(this.txtDate);
            this.uiPanel1.Controls.Add(this.uiSymbolButton3);
            this.uiPanel1.Controls.Add(this.label2);
            this.uiPanel1.Controls.Add(this.uiSymbolButton2);
            this.uiPanel1.Controls.Add(this.label1);
            this.uiPanel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel1.Location = new System.Drawing.Point(13, 89);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Size = new System.Drawing.Size(1224, 106);
            this.uiPanel1.TabIndex = 16;
            this.uiPanel1.Text = null;
            this.uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiPanel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cbxStatus
            // 
            this.cbxStatus.DataSource = null;
            this.cbxStatus.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbxStatus.FillColor = System.Drawing.Color.White;
            this.cbxStatus.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxStatus.Location = new System.Drawing.Point(129, 60);
            this.cbxStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxStatus.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbxStatus.Name = "cbxStatus";
            this.cbxStatus.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbxStatus.Size = new System.Drawing.Size(204, 29);
            this.cbxStatus.TabIndex = 3;
            this.cbxStatus.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbxStatus.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btn_jkmx
            // 
            this.btn_jkmx.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_jkmx.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.btn_jkmx.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.btn_jkmx.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.btn_jkmx.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.btn_jkmx.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.btn_jkmx.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_jkmx.Location = new System.Drawing.Point(355, 60);
            this.btn_jkmx.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_jkmx.Name = "btn_jkmx";
            this.btn_jkmx.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.btn_jkmx.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            this.btn_jkmx.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.btn_jkmx.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.btn_jkmx.Size = new System.Drawing.Size(110, 29);
            this.btn_jkmx.Style = Sunny.UI.UIStyle.Gray;
            this.btn_jkmx.StyleCustomMode = true;
            this.btn_jkmx.Symbol = 61568;
            this.btn_jkmx.TabIndex = 20;
            this.btn_jkmx.Text = "缴款明细";
            this.btn_jkmx.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_jkmx.Visible = false;
            this.btn_jkmx.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiSymbolButton4
            // 
            this.uiSymbolButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton4.Location = new System.Drawing.Point(798, 54);
            this.uiSymbolButton4.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton4.Name = "uiSymbolButton4";
            this.uiSymbolButton4.Size = new System.Drawing.Size(141, 35);
            this.uiSymbolButton4.TabIndex = 19;
            this.uiSymbolButton4.Text = "现金支票明细";
            this.uiSymbolButton4.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton4.Visible = false;
            this.uiSymbolButton4.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtDate
            // 
            this.txtDate.FillColor = System.Drawing.Color.White;
            this.txtDate.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDate.Location = new System.Drawing.Point(129, 22);
            this.txtDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDate.MaxLength = 10;
            this.txtDate.MinimumSize = new System.Drawing.Size(63, 0);
            this.txtDate.Name = "txtDate";
            this.txtDate.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.txtDate.ShowToday = true;
            this.txtDate.Size = new System.Drawing.Size(204, 29);
            this.txtDate.SymbolDropDown = 61555;
            this.txtDate.SymbolNormal = 61555;
            this.txtDate.TabIndex = 2;
            this.txtDate.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtDate.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.txtDate.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txtDate.TextChanged += new System.EventHandler(this.txtDate_TextChanged);
            // 
            // uiSymbolButton3
            // 
            this.uiSymbolButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton3.Location = new System.Drawing.Point(651, 54);
            this.uiSymbolButton3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton3.Name = "uiSymbolButton3";
            this.uiSymbolButton3.Size = new System.Drawing.Size(141, 35);
            this.uiSymbolButton3.TabIndex = 18;
            this.uiSymbolButton3.Text = "发票明细";
            this.uiSymbolButton3.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton3.Visible = false;
            this.uiSymbolButton3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "结账状态";
            // 
            // uiSymbolButton2
            // 
            this.uiSymbolButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton2.Location = new System.Drawing.Point(504, 54);
            this.uiSymbolButton2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton2.Name = "uiSymbolButton2";
            this.uiSymbolButton2.Size = new System.Drawing.Size(141, 35);
            this.uiSymbolButton2.TabIndex = 17;
            this.uiSymbolButton2.Text = "废票明细";
            this.uiSymbolButton2.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton2.Visible = false;
            this.uiSymbolButton2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "日期";
            // 
            // previewControl1
            // 
            this.previewControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.previewControl1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.previewControl1.Font = new System.Drawing.Font("宋体", 9F);
            this.previewControl1.Location = new System.Drawing.Point(3, 3);
            this.previewControl1.Name = "previewControl1";
            this.previewControl1.PageOffset = new System.Drawing.Point(10, 10);
            this.previewControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.previewControl1.SaveInitialDirectory = null;
            this.previewControl1.Size = new System.Drawing.Size(1218, 450);
            this.previewControl1.TabIndex = 21;
            this.previewControl1.ToolbarVisible = false;
            this.previewControl1.Visible = false;
            // 
            // pnlReport
            // 
            this.pnlReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlReport.Controls.Add(this.previewControl1);
            this.pnlReport.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlReport.Location = new System.Drawing.Point(13, 205);
            this.pnlReport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlReport.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlReport.Name = "pnlReport";
            this.pnlReport.Size = new System.Drawing.Size(1224, 456);
            this.pnlReport.TabIndex = 17;
            this.pnlReport.Text = "uiPanel2";
            this.pnlReport.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlReport.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // GuahaoRijie
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1250, 675);
            this.Controls.Add(this.pnlReport);
            this.Controls.Add(this.uiPanel1);
            this.Controls.Add(this.pnlTitle);
            this.Name = "GuahaoRijie";
            this.PageIndex = 1201;
            this.Text = "GuahaoRijie";
            this.Load += new System.EventHandler(this.GuahaoRijie_Load);
            this.pnlTitle.ResumeLayout(false);
            this.uiPanel1.ResumeLayout(false);
            this.uiPanel1.PerformLayout();
            this.pnlReport.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIPanel pnlTitle;
        private Sunny.UI.UISymbolButton btnSave;
        private Sunny.UI.UISymbolButton btnRefresh;
        private Sunny.UI.UISymbolButton btnExit;
        private Sunny.UI.UILabel lblTitle;
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UIComboBox cbxStatus;
        private Sunny.UI.UIDatePicker txtDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Sunny.UI.UISymbolButton uiSymbolButton2;
        private Sunny.UI.UISymbolButton uiSymbolButton3;
        private Sunny.UI.UISymbolButton uiSymbolButton4;
        private Sunny.UI.UISymbolButton btn_jkmx;
        private FastReport.Preview.PreviewControl previewControl1;
        private Sunny.UI.UIPanel pnlReport;
        private Sunny.UI.UISymbolButton btnPrint;
        private Sunny.UI.UISymbolButton btnReset;
    }
}