﻿namespace Client.Forms.Pages.zfgl
{
    partial class YBPay
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTitle = new Sunny.UI.UIPanel();
            this.btnUpdateStatus = new Sunny.UI.UISymbolButton();
            this.btnSearch = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton1 = new Sunny.UI.UISymbolButton();
            this.btnExit = new Sunny.UI.UISymbolButton();
            this.lblTitle = new Sunny.UI.UILabel();
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.cbxRefundStatus = new Sunny.UI.UIComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBarcode = new Sunny.UI.UITextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEndDate = new Sunny.UI.UIDatePicker();
            this.txtBeginDate = new Sunny.UI.UIDatePicker();
            this.dgv_paylist = new Sunny.UI.UIDataGridView();
            this.patient_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patient_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledger_sn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.charge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cheque_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price_opera = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cheque_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.depo_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mz_dept_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cheque_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTitle.SuspendLayout();
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_paylist)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTitle.Controls.Add(this.btnUpdateStatus);
            this.pnlTitle.Controls.Add(this.btnSearch);
            this.pnlTitle.Controls.Add(this.uiSymbolButton1);
            this.pnlTitle.Controls.Add(this.btnExit);
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlTitle.Location = new System.Drawing.Point(4, 3);
            this.pnlTitle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlTitle.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(1200, 66);
            this.pnlTitle.TabIndex = 4;
            this.pnlTitle.Text = null;
            this.pnlTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlTitle.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnUpdateStatus
            // 
            this.btnUpdateStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateStatus.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(155)))), ((int)(((byte)(40)))));
            this.btnUpdateStatus.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(155)))), ((int)(((byte)(40)))));
            this.btnUpdateStatus.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(175)))), ((int)(((byte)(83)))));
            this.btnUpdateStatus.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(124)))), ((int)(((byte)(32)))));
            this.btnUpdateStatus.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(124)))), ((int)(((byte)(32)))));
            this.btnUpdateStatus.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUpdateStatus.Location = new System.Drawing.Point(428, 3);
            this.btnUpdateStatus.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnUpdateStatus.Name = "btnUpdateStatus";
            this.btnUpdateStatus.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(155)))), ((int)(((byte)(40)))));
            this.btnUpdateStatus.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(175)))), ((int)(((byte)(83)))));
            this.btnUpdateStatus.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(124)))), ((int)(((byte)(32)))));
            this.btnUpdateStatus.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(124)))), ((int)(((byte)(32)))));
            this.btnUpdateStatus.Size = new System.Drawing.Size(102, 60);
            this.btnUpdateStatus.Style = Sunny.UI.UIStyle.Orange;
            this.btnUpdateStatus.StyleCustomMode = true;
            this.btnUpdateStatus.Symbol = 61641;
            this.btnUpdateStatus.TabIndex = 13;
            this.btnUpdateStatus.Text = "修改状态";
            this.btnUpdateStatus.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUpdateStatus.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
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
            this.btnSearch.Location = new System.Drawing.Point(216, 3);
            this.btnSearch.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnSearch.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(203)))), ((int)(((byte)(83)))));
            this.btnSearch.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnSearch.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnSearch.Size = new System.Drawing.Size(100, 60);
            this.btnSearch.Style = Sunny.UI.UIStyle.Green;
            this.btnSearch.StyleCustomMode = true;
            this.btnSearch.Symbol = 61442;
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "查询";
            this.btnSearch.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // uiSymbolButton1
            // 
            this.uiSymbolButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton1.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton1.Location = new System.Drawing.Point(322, 3);
            this.uiSymbolButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton1.Name = "uiSymbolButton1";
            this.uiSymbolButton1.Size = new System.Drawing.Size(100, 60);
            this.uiSymbolButton1.StyleCustomMode = true;
            this.uiSymbolButton1.Symbol = 61473;
            this.uiSymbolButton1.TabIndex = 10;
            this.uiSymbolButton1.Text = "重新";
            this.uiSymbolButton1.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
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
            this.btnExit.Location = new System.Drawing.Point(536, 3);
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
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(45, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(120, 51);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "医保支付";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.cbxRefundStatus);
            this.uiGroupBox1.Controls.Add(this.label4);
            this.uiGroupBox1.Controls.Add(this.txtBarcode);
            this.uiGroupBox1.Controls.Add(this.label2);
            this.uiGroupBox1.Controls.Add(this.label1);
            this.uiGroupBox1.Controls.Add(this.txtEndDate);
            this.uiGroupBox1.Controls.Add(this.txtBeginDate);
            this.uiGroupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox1.Location = new System.Drawing.Point(4, 79);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox1.Size = new System.Drawing.Size(1200, 117);
            this.uiGroupBox1.TabIndex = 5;
            this.uiGroupBox1.Text = "查询条件";
            this.uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiGroupBox1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cbxRefundStatus
            // 
            this.cbxRefundStatus.DataSource = null;
            this.cbxRefundStatus.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbxRefundStatus.FillColor = System.Drawing.Color.White;
            this.cbxRefundStatus.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxRefundStatus.Items.AddRange(new object[] {
            "全部",
            "收费",
            "退款"});
            this.cbxRefundStatus.Location = new System.Drawing.Point(421, 68);
            this.cbxRefundStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxRefundStatus.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbxRefundStatus.Name = "cbxRefundStatus";
            this.cbxRefundStatus.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbxRefundStatus.Size = new System.Drawing.Size(150, 29);
            this.cbxRefundStatus.TabIndex = 6;
            this.cbxRefundStatus.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbxRefundStatus.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(324, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 21);
            this.label4.TabIndex = 5;
            this.label4.Text = "收费状态：";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBarcode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBarcode.Location = new System.Drawing.Point(421, 29);
            this.txtBarcode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBarcode.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.ShowText = false;
            this.txtBarcode.Size = new System.Drawing.Size(150, 29);
            this.txtBarcode.TabIndex = 4;
            this.txtBarcode.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtBarcode.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(340, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "磁卡号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "查询日期";
            // 
            // txtEndDate
            // 
            this.txtEndDate.FillColor = System.Drawing.Color.White;
            this.txtEndDate.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtEndDate.Location = new System.Drawing.Point(125, 68);
            this.txtEndDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEndDate.MaxLength = 10;
            this.txtEndDate.MinimumSize = new System.Drawing.Size(63, 0);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.txtEndDate.Size = new System.Drawing.Size(150, 29);
            this.txtEndDate.SymbolDropDown = 61555;
            this.txtEndDate.SymbolNormal = 61555;
            this.txtEndDate.TabIndex = 1;
            this.txtEndDate.Text = "2022-06-16";
            this.txtEndDate.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtEndDate.Value = new System.DateTime(2022, 6, 16, 13, 8, 4, 132);
            this.txtEndDate.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtBeginDate
            // 
            this.txtBeginDate.FillColor = System.Drawing.Color.White;
            this.txtBeginDate.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBeginDate.Location = new System.Drawing.Point(125, 29);
            this.txtBeginDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBeginDate.MaxLength = 10;
            this.txtBeginDate.MinimumSize = new System.Drawing.Size(63, 0);
            this.txtBeginDate.Name = "txtBeginDate";
            this.txtBeginDate.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.txtBeginDate.Size = new System.Drawing.Size(150, 29);
            this.txtBeginDate.SymbolDropDown = 61555;
            this.txtBeginDate.SymbolNormal = 61555;
            this.txtBeginDate.TabIndex = 0;
            this.txtBeginDate.Text = "2022-06-16";
            this.txtBeginDate.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtBeginDate.Value = new System.DateTime(2022, 6, 16, 13, 8, 4, 132);
            this.txtBeginDate.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // dgv_paylist
            // 
            this.dgv_paylist.AllowUserToAddRows = false;
            this.dgv_paylist.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.dgv_paylist.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_paylist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_paylist.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.dgv_paylist.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_paylist.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_paylist.ColumnHeadersHeight = 32;
            this.dgv_paylist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_paylist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.patient_name,
            this.patient_id,
            this.ledger_sn,
            this.price_date,
            this.charge,
            this.cheque_no,
            this.price_opera,
            this.cheque_name,
            this.depo_status,
            this.mz_dept_no,
            this.cheque_type});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_paylist.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_paylist.EnableHeadersVisualStyles = false;
            this.dgv_paylist.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgv_paylist.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            this.dgv_paylist.Location = new System.Drawing.Point(4, 204);
            this.dgv_paylist.Name = "dgv_paylist";
            this.dgv_paylist.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_paylist.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_paylist.RowHeight = 0;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgv_paylist.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_paylist.RowTemplate.Height = 23;
            this.dgv_paylist.SelectedIndex = -1;
            this.dgv_paylist.ShowGridLine = false;
            this.dgv_paylist.ShowRect = false;
            this.dgv_paylist.Size = new System.Drawing.Size(1200, 490);
            this.dgv_paylist.TabIndex = 6;
            this.dgv_paylist.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // patient_name
            // 
            this.patient_name.DataPropertyName = "patient_name";
            this.patient_name.HeaderText = "病人姓名";
            this.patient_name.Name = "patient_name";
            this.patient_name.ReadOnly = true;
            // 
            // patient_id
            // 
            this.patient_id.DataPropertyName = "patient_id";
            this.patient_id.HeaderText = "病人ID";
            this.patient_id.Name = "patient_id";
            this.patient_id.ReadOnly = true;
            // 
            // ledger_sn
            // 
            this.ledger_sn.DataPropertyName = "ledger_sn";
            this.ledger_sn.HeaderText = "账页";
            this.ledger_sn.Name = "ledger_sn";
            this.ledger_sn.ReadOnly = true;
            // 
            // price_date
            // 
            this.price_date.DataPropertyName = "price_date";
            this.price_date.HeaderText = "收费时间";
            this.price_date.Name = "price_date";
            this.price_date.ReadOnly = true;
            // 
            // charge
            // 
            this.charge.DataPropertyName = "charge";
            this.charge.HeaderText = "金额";
            this.charge.Name = "charge";
            this.charge.ReadOnly = true;
            // 
            // cheque_no
            // 
            this.cheque_no.DataPropertyName = "cheque_no";
            this.cheque_no.HeaderText = "流水号";
            this.cheque_no.Name = "cheque_no";
            this.cheque_no.ReadOnly = true;
            // 
            // price_opera
            // 
            this.price_opera.DataPropertyName = "price_opera";
            this.price_opera.HeaderText = "收费员";
            this.price_opera.Name = "price_opera";
            this.price_opera.ReadOnly = true;
            // 
            // cheque_name
            // 
            this.cheque_name.DataPropertyName = "cheque_name";
            this.cheque_name.HeaderText = "支付方式";
            this.cheque_name.Name = "cheque_name";
            this.cheque_name.ReadOnly = true;
            // 
            // depo_status
            // 
            this.depo_status.DataPropertyName = "depo_status";
            this.depo_status.HeaderText = "状态";
            this.depo_status.Name = "depo_status";
            this.depo_status.ReadOnly = true;
            // 
            // mz_dept_no
            // 
            this.mz_dept_no.DataPropertyName = "mz_dept_no";
            this.mz_dept_no.HeaderText = "mz_dept_no";
            this.mz_dept_no.Name = "mz_dept_no";
            this.mz_dept_no.ReadOnly = true;
            this.mz_dept_no.Visible = false;
            // 
            // cheque_type
            // 
            this.cheque_type.DataPropertyName = "cheque_type";
            this.cheque_type.HeaderText = "cheque_type";
            this.cheque_type.Name = "cheque_type";
            this.cheque_type.ReadOnly = true;
            this.cheque_type.Visible = false;
            // 
            // YBPay
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1210, 706);
            this.Controls.Add(this.dgv_paylist);
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.pnlTitle);
            this.Name = "YBPay";
            this.PageIndex = 1601;
            this.Text = "YBPay";
            this.Initialize += new System.EventHandler(this.YBPay_Initialize);
            this.pnlTitle.ResumeLayout(false);
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_paylist)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIPanel pnlTitle;
        private Sunny.UI.UISymbolButton btnUpdateStatus;
        private Sunny.UI.UISymbolButton btnSearch;
        private Sunny.UI.UISymbolButton uiSymbolButton1;
        private Sunny.UI.UISymbolButton btnExit;
        private Sunny.UI.UILabel lblTitle;
        private Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UIComboBox cbxRefundStatus;
        private System.Windows.Forms.Label label4;
        private Sunny.UI.UITextBox txtBarcode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Sunny.UI.UIDatePicker txtEndDate;
        private Sunny.UI.UIDatePicker txtBeginDate;
        private Sunny.UI.UIDataGridView dgv_paylist;
        private System.Windows.Forms.DataGridViewTextBoxColumn patient_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn patient_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ledger_sn;
        private System.Windows.Forms.DataGridViewTextBoxColumn price_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn charge;
        private System.Windows.Forms.DataGridViewTextBoxColumn cheque_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn price_opera;
        private System.Windows.Forms.DataGridViewTextBoxColumn cheque_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn depo_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn mz_dept_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn cheque_type;
    }
}