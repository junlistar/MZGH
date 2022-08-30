namespace Client.Forms.Pages.yhbb
{
    partial class UserReport
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
            this.lblpnltile = new Sunny.UI.UITitlePanel();
            this.tv_reports = new Sunny.UI.UITreeView();
            this.previewControl1 = new FastReport.Preview.PreviewControl();
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.lbl_times = new System.Windows.Forms.Label();
            this.txt_tims = new Sunny.UI.UITextBox();
            this.lbl_patientid = new System.Windows.Forms.Label();
            this.txt_patientid = new Sunny.UI.UITextBox();
            this.pnlTitle = new Sunny.UI.UIPanel();
            this.btnPrint = new Sunny.UI.UISymbolButton();
            this.btnSearch = new Sunny.UI.UISymbolButton();
            this.btnExit = new Sunny.UI.UISymbolButton();
            this.lblTitle = new Sunny.UI.UILabel();
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.lblpnltile.SuspendLayout();
            this.uiGroupBox1.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            this.uiPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblpnltile
            // 
            this.lblpnltile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblpnltile.Controls.Add(this.tv_reports);
            this.lblpnltile.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblpnltile.Location = new System.Drawing.Point(4, 60);
            this.lblpnltile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblpnltile.MinimumSize = new System.Drawing.Size(1, 1);
            this.lblpnltile.Name = "lblpnltile";
            this.lblpnltile.Padding = new System.Windows.Forms.Padding(0, 35, 0, 0);
            this.lblpnltile.ShowText = false;
            this.lblpnltile.Size = new System.Drawing.Size(280, 661);
            this.lblpnltile.TabIndex = 23;
            this.lblpnltile.Text = "用户报表";
            this.lblpnltile.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.lblpnltile.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblpnltile.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // tv_reports
            // 
            this.tv_reports.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tv_reports.FillColor = System.Drawing.Color.White;
            this.tv_reports.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tv_reports.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.tv_reports.Location = new System.Drawing.Point(4, 39);
            this.tv_reports.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tv_reports.MinimumSize = new System.Drawing.Size(1, 1);
            this.tv_reports.Name = "tv_reports";
            this.tv_reports.ShowLines = true;
            this.tv_reports.ShowText = false;
            this.tv_reports.Size = new System.Drawing.Size(272, 617);
            this.tv_reports.TabIndex = 0;
            this.tv_reports.Text = "uiTreeView3";
            this.tv_reports.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.tv_reports.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.tv_reports.Click += new System.EventHandler(this.tv_reports_Click);
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
            this.previewControl1.Size = new System.Drawing.Size(858, 549);
            this.previewControl1.TabIndex = 24;
            this.previewControl1.ToolbarVisible = false;
            this.previewControl1.Visible = false;
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiGroupBox1.Controls.Add(this.lbl_times);
            this.uiGroupBox1.Controls.Add(this.txt_tims);
            this.uiGroupBox1.Controls.Add(this.lbl_patientid);
            this.uiGroupBox1.Controls.Add(this.txt_patientid);
            this.uiGroupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox1.Location = new System.Drawing.Point(292, 56);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox1.Size = new System.Drawing.Size(864, 98);
            this.uiGroupBox1.TabIndex = 25;
            this.uiGroupBox1.Text = "查询条件";
            this.uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiGroupBox1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lbl_times
            // 
            this.lbl_times.AutoSize = true;
            this.lbl_times.Location = new System.Drawing.Point(261, 44);
            this.lbl_times.Name = "lbl_times";
            this.lbl_times.Size = new System.Drawing.Size(78, 21);
            this.lbl_times.TabIndex = 3;
            this.lbl_times.Text = "就诊次数:";
            // 
            // txt_tims
            // 
            this.txt_tims.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_tims.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_tims.Location = new System.Drawing.Point(346, 41);
            this.txt_tims.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_tims.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_tims.Name = "txt_tims";
            this.txt_tims.ShowText = false;
            this.txt_tims.Size = new System.Drawing.Size(150, 29);
            this.txt_tims.TabIndex = 2;
            this.txt_tims.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_tims.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.txt_tims.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lbl_patientid
            // 
            this.lbl_patientid.AutoSize = true;
            this.lbl_patientid.Location = new System.Drawing.Point(25, 44);
            this.lbl_patientid.Name = "lbl_patientid";
            this.lbl_patientid.Size = new System.Drawing.Size(63, 21);
            this.lbl_patientid.TabIndex = 1;
            this.lbl_patientid.Text = "患者ID:";
            // 
            // txt_patientid
            // 
            this.txt_patientid.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_patientid.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_patientid.Location = new System.Drawing.Point(95, 41);
            this.txt_patientid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_patientid.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_patientid.Name = "txt_patientid";
            this.txt_patientid.ShowText = false;
            this.txt_patientid.Size = new System.Drawing.Size(150, 29);
            this.txt_patientid.TabIndex = 0;
            this.txt_patientid.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_patientid.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // pnlTitle
            // 
            this.pnlTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTitle.Controls.Add(this.btnPrint);
            this.pnlTitle.Controls.Add(this.btnSearch);
            this.pnlTitle.Controls.Add(this.btnExit);
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlTitle.Location = new System.Drawing.Point(4, 5);
            this.pnlTitle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlTitle.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(1152, 45);
            this.pnlTitle.TabIndex = 26;
            this.pnlTitle.Text = null;
            this.pnlTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlTitle.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnPrint
            // 
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(155)))), ((int)(((byte)(40)))));
            this.btnPrint.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(155)))), ((int)(((byte)(40)))));
            this.btnPrint.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(175)))), ((int)(((byte)(83)))));
            this.btnPrint.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(124)))), ((int)(((byte)(32)))));
            this.btnPrint.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(124)))), ((int)(((byte)(32)))));
            this.btnPrint.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrint.Location = new System.Drawing.Point(397, 3);
            this.btnPrint.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(155)))), ((int)(((byte)(40)))));
            this.btnPrint.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(175)))), ((int)(((byte)(83)))));
            this.btnPrint.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(124)))), ((int)(((byte)(32)))));
            this.btnPrint.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(124)))), ((int)(((byte)(32)))));
            this.btnPrint.Size = new System.Drawing.Size(100, 40);
            this.btnPrint.Style = Sunny.UI.UIStyle.Orange;
            this.btnPrint.StyleCustomMode = true;
            this.btnPrint.Symbol = 61487;
            this.btnPrint.TabIndex = 13;
            this.btnPrint.Text = "打印";
            this.btnPrint.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrint.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnSearch.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnSearch.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(203)))), ((int)(((byte)(83)))));
            this.btnSearch.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnSearch.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Location = new System.Drawing.Point(291, 3);
            this.btnSearch.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnSearch.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(203)))), ((int)(((byte)(83)))));
            this.btnSearch.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnSearch.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnSearch.Size = new System.Drawing.Size(100, 40);
            this.btnSearch.Style = Sunny.UI.UIStyle.Green;
            this.btnSearch.StyleCustomMode = true;
            this.btnSearch.Symbol = 61573;
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "查询";
            this.btnSearch.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.btnExit.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.btnExit.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.btnExit.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.btnExit.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.btnExit.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.Location = new System.Drawing.Point(503, 3);
            this.btnExit.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnExit.Name = "btnExit";
            this.btnExit.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.btnExit.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.btnExit.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.btnExit.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.btnExit.Size = new System.Drawing.Size(100, 40);
            this.btnExit.Style = Sunny.UI.UIStyle.Colorful;
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
            this.lblTitle.Location = new System.Drawing.Point(29, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(301, 35);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "综合统计报表";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiPanel1
            // 
            this.uiPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiPanel1.Controls.Add(this.previewControl1);
            this.uiPanel1.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel1.Location = new System.Drawing.Point(292, 164);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Size = new System.Drawing.Size(864, 557);
            this.uiPanel1.TabIndex = 27;
            this.uiPanel1.Text = null;
            this.uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiPanel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // UserReport
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1159, 735);
            this.Controls.Add(this.uiPanel1);
            this.Controls.Add(this.pnlTitle);
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.lblpnltile);
            this.Name = "UserReport";
            this.PageIndex = 1401;
            this.Text = "综合统计报表";
            this.Initialize += new System.EventHandler(this.UserReport_Initialize);
            this.lblpnltile.ResumeLayout(false);
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox1.PerformLayout();
            this.pnlTitle.ResumeLayout(false);
            this.uiPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UITitlePanel lblpnltile;
        private Sunny.UI.UITreeView tv_reports;
        private FastReport.Preview.PreviewControl previewControl1;
        private Sunny.UI.UIGroupBox uiGroupBox1;
        private System.Windows.Forms.Label lbl_times;
        private Sunny.UI.UITextBox txt_tims;
        private System.Windows.Forms.Label lbl_patientid;
        private Sunny.UI.UITextBox txt_patientid;
        private Sunny.UI.UIPanel pnlTitle;
        private Sunny.UI.UISymbolButton btnSearch;
        private Sunny.UI.UISymbolButton btnExit;
        private Sunny.UI.UILabel lblTitle;
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UISymbolButton btnPrint;
    }
}