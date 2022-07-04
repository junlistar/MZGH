﻿namespace Client.Forms.Pages.cwgl
{
    partial class ShoufeiRijie
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
            this.btnSave = new Sunny.UI.UISymbolButton();
            this.btnRefresh = new Sunny.UI.UISymbolButton();
            this.btnExit = new Sunny.UI.UISymbolButton();
            this.lblTitle = new Sunny.UI.UILabel();
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.txtDate = new Sunny.UI.UIDatetimePicker();
            this.cbxStatus = new Sunny.UI.UIComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_hzrb = new Sunny.UI.UISymbolButton();
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
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(403, 18);
            this.btnSave.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 35);
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
            this.btnRefresh.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRefresh.Location = new System.Drawing.Point(287, 18);
            this.btnRefresh.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 35);
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
            this.btnExit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.Location = new System.Drawing.Point(519, 18);
            this.btnExit.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(119, 35);
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
            this.lblTitle.Text = "收费日结";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiPanel1
            // 
            this.uiPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiPanel1.Controls.Add(this.txtDate);
            this.uiPanel1.Controls.Add(this.btn_hzrb);
            this.uiPanel1.Controls.Add(this.cbxStatus);
            this.uiPanel1.Controls.Add(this.label2);
            this.uiPanel1.Controls.Add(this.label1);
            this.uiPanel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel1.Location = new System.Drawing.Point(13, 89);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Size = new System.Drawing.Size(1224, 107);
            this.uiPanel1.TabIndex = 16;
            this.uiPanel1.Text = null;
            this.uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiPanel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtDate
            // 
            this.txtDate.FillColor = System.Drawing.Color.White;
            this.txtDate.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDate.Location = new System.Drawing.Point(100, 23);
            this.txtDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDate.MaxLength = 19;
            this.txtDate.MinimumSize = new System.Drawing.Size(63, 0);
            this.txtDate.Name = "txtDate";
            this.txtDate.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.txtDate.Size = new System.Drawing.Size(200, 29);
            this.txtDate.SymbolDropDown = 61555;
            this.txtDate.SymbolNormal = 61555;
            this.txtDate.TabIndex = 4;
            this.txtDate.Text = "2022-07-04 09:56:19";
            this.txtDate.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtDate.Value = new System.DateTime(2022, 7, 4, 9, 56, 19, 773);
            this.txtDate.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txtDate.ValueChanged += new Sunny.UI.UIDatetimePicker.OnDateTimeChanged(this.txtDate_ValueChanged);
            // 
            // cbxStatus
            // 
            this.cbxStatus.DataSource = null;
            this.cbxStatus.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbxStatus.FillColor = System.Drawing.Color.White;
            this.cbxStatus.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxStatus.Location = new System.Drawing.Point(100, 66);
            this.cbxStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxStatus.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbxStatus.Name = "cbxStatus";
            this.cbxStatus.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbxStatus.Size = new System.Drawing.Size(200, 29);
            this.cbxStatus.TabIndex = 3;
            this.cbxStatus.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbxStatus.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "结账时间";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "日期";
            // 
            // btn_hzrb
            // 
            this.btn_hzrb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_hzrb.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_hzrb.Location = new System.Drawing.Point(340, 66);
            this.btn_hzrb.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_hzrb.Name = "btn_hzrb";
            this.btn_hzrb.Size = new System.Drawing.Size(112, 29);
            this.btn_hzrb.Symbol = 61568;
            this.btn_hzrb.TabIndex = 20;
            this.btn_hzrb.Text = "汇总日报";
            this.btn_hzrb.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_hzrb.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
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
            this.previewControl1.Size = new System.Drawing.Size(1218, 451);
            this.previewControl1.TabIndex = 21;
            // 
            // pnlReport
            // 
            this.pnlReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlReport.Controls.Add(this.previewControl1);
            this.pnlReport.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlReport.Location = new System.Drawing.Point(13, 204);
            this.pnlReport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlReport.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlReport.Name = "pnlReport";
            this.pnlReport.Size = new System.Drawing.Size(1224, 457);
            this.pnlReport.TabIndex = 22;
            this.pnlReport.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlReport.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // ShoufeiRijie
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1250, 675);
            this.Controls.Add(this.pnlReport);
            this.Controls.Add(this.uiPanel1);
            this.Controls.Add(this.pnlTitle);
            this.Name = "ShoufeiRijie";
            this.PageIndex = 1202;
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Sunny.UI.UISymbolButton btn_hzrb;
        private FastReport.Preview.PreviewControl previewControl1;
        private Sunny.UI.UIDatetimePicker txtDate;
        private Sunny.UI.UIPanel pnlReport;
    }
}