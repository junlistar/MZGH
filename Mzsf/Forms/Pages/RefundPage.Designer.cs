namespace Mzsf.Forms.Pages
{
    partial class RefundPage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTitle = new Sunny.UI.UIPanel();
            this.btnHuajia = new Sunny.UI.UISymbolButton();
            this.btnSearch = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton1 = new Sunny.UI.UISymbolButton();
            this.btnExit = new Sunny.UI.UISymbolButton();
            this.lblTitle = new Sunny.UI.UILabel();
            this.lblNodata = new System.Windows.Forms.Label();
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.txtFilterValue = new Sunny.UI.UITextBox();
            this.cbxType = new Sunny.UI.UIComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEndDate = new Sunny.UI.UIDatePicker();
            this.txtBeginDate = new Sunny.UI.UIDatePicker();
            this.dgvRefund = new Sunny.UI.UIDataGridView();
            this.uiGroupBox2 = new Sunny.UI.UIGroupBox();
            this.lblCharge = new System.Windows.Forms.Label();
            this.lblPayType = new System.Windows.Forms.Label();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.lblRecriptSn = new System.Windows.Forms.Label();
            this.lblReceiptNo = new System.Windows.Forms.Label();
            this.lblTimes = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPatientId = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvCpr = new Sunny.UI.UIDataGridView();
            this.receipt_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patient_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patient_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_bar_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.times = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cash_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cash_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cheque_type_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receipt_sn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.charge_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.charge_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.report_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkback = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.charge_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.charge_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cf_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caoyao_fu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orig_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.charge_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sum_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.back = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTitle.SuspendLayout();
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefund)).BeginInit();
            this.uiGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCpr)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTitle.Controls.Add(this.btnHuajia);
            this.pnlTitle.Controls.Add(this.btnSearch);
            this.pnlTitle.Controls.Add(this.uiSymbolButton1);
            this.pnlTitle.Controls.Add(this.btnExit);
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Controls.Add(this.lblNodata);
            this.pnlTitle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlTitle.Location = new System.Drawing.Point(13, 4);
            this.pnlTitle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlTitle.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(1151, 66);
            this.pnlTitle.TabIndex = 3;
            this.pnlTitle.Text = null;
            this.pnlTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlTitle.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnHuajia
            // 
            this.btnHuajia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuajia.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnHuajia.Location = new System.Drawing.Point(428, 17);
            this.btnHuajia.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnHuajia.Name = "btnHuajia";
            this.btnHuajia.Size = new System.Drawing.Size(100, 35);
            this.btnHuajia.Symbol = 362139;
            this.btnHuajia.TabIndex = 12;
            this.btnHuajia.Text = "划价";
            this.btnHuajia.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnHuajia.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnHuajia.Click += new System.EventHandler(this.btnHuajia_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Location = new System.Drawing.Point(216, 17);
            this.btnSearch.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 35);
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
            this.uiSymbolButton1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton1.Location = new System.Drawing.Point(322, 17);
            this.uiSymbolButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton1.Name = "uiSymbolButton1";
            this.uiSymbolButton1.Size = new System.Drawing.Size(100, 35);
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
            this.btnExit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.Location = new System.Drawing.Point(536, 17);
            this.btnExit.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(107, 35);
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
            this.lblTitle.Text = "退费";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblNodata
            // 
            this.lblNodata.AutoSize = true;
            this.lblNodata.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.lblNodata.ForeColor = System.Drawing.Color.Red;
            this.lblNodata.Location = new System.Drawing.Point(804, 17);
            this.lblNodata.Name = "lblNodata";
            this.lblNodata.Size = new System.Drawing.Size(182, 31);
            this.lblNodata.TabIndex = 6;
            this.lblNodata.Text = "没有查询到数据";
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.txtFilterValue);
            this.uiGroupBox1.Controls.Add(this.cbxType);
            this.uiGroupBox1.Controls.Add(this.label2);
            this.uiGroupBox1.Controls.Add(this.label1);
            this.uiGroupBox1.Controls.Add(this.txtEndDate);
            this.uiGroupBox1.Controls.Add(this.txtBeginDate);
            this.uiGroupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox1.Location = new System.Drawing.Point(13, 79);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox1.Size = new System.Drawing.Size(811, 117);
            this.uiGroupBox1.TabIndex = 4;
            this.uiGroupBox1.Text = "查询条件";
            this.uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiGroupBox1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFilterValue.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFilterValue.Location = new System.Drawing.Point(286, 81);
            this.txtFilterValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFilterValue.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.ShowText = false;
            this.txtFilterValue.Size = new System.Drawing.Size(150, 29);
            this.txtFilterValue.TabIndex = 5;
            this.txtFilterValue.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtFilterValue.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cbxType
            // 
            this.cbxType.DataSource = null;
            this.cbxType.FillColor = System.Drawing.Color.White;
            this.cbxType.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxType.Location = new System.Drawing.Point(119, 81);
            this.cbxType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxType.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbxType.Name = "cbxType";
            this.cbxType.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbxType.Size = new System.Drawing.Size(150, 29);
            this.cbxType.TabIndex = 4;
            this.cbxType.Text = "uiComboBox1";
            this.cbxType.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbxType.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "查号类型";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "查询日期";
            // 
            // txtEndDate
            // 
            this.txtEndDate.FillColor = System.Drawing.Color.White;
            this.txtEndDate.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtEndDate.Location = new System.Drawing.Point(286, 37);
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
            this.txtBeginDate.Location = new System.Drawing.Point(119, 37);
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
            // dgvRefund
            // 
            this.dgvRefund.AllowUserToAddRows = false;
            this.dgvRefund.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.dgvRefund.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRefund.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRefund.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.dgvRefund.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRefund.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRefund.ColumnHeadersHeight = 32;
            this.dgvRefund.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRefund.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.receipt_no,
            this.patient_name,
            this.patient_id,
            this.p_bar_code,
            this.times,
            this.cash_date,
            this.cash_name,
            this.cheque_type_name,
            this.receipt_sn,
            this.charge_status,
            this.charge_total,
            this.report_date});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRefund.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRefund.EnableHeadersVisualStyles = false;
            this.dgvRefund.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvRefund.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            this.dgvRefund.Location = new System.Drawing.Point(13, 205);
            this.dgvRefund.Name = "dgvRefund";
            this.dgvRefund.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRefund.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgvRefund.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvRefund.RowTemplate.Height = 23;
            this.dgvRefund.SelectedIndex = -1;
            this.dgvRefund.Size = new System.Drawing.Size(860, 289);
            this.dgvRefund.TabIndex = 5;
            this.dgvRefund.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.dgvRefund.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRefund_CellClick);
            this.dgvRefund.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRefund_CellContentClick);
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiGroupBox2.Controls.Add(this.lblCharge);
            this.uiGroupBox2.Controls.Add(this.lblPayType);
            this.uiGroupBox2.Controls.Add(this.lblDateTime);
            this.uiGroupBox2.Controls.Add(this.lblRecriptSn);
            this.uiGroupBox2.Controls.Add(this.lblReceiptNo);
            this.uiGroupBox2.Controls.Add(this.lblTimes);
            this.uiGroupBox2.Controls.Add(this.label12);
            this.uiGroupBox2.Controls.Add(this.lblName);
            this.uiGroupBox2.Controls.Add(this.label10);
            this.uiGroupBox2.Controls.Add(this.label9);
            this.uiGroupBox2.Controls.Add(this.label8);
            this.uiGroupBox2.Controls.Add(this.label7);
            this.uiGroupBox2.Controls.Add(this.label6);
            this.uiGroupBox2.Controls.Add(this.label5);
            this.uiGroupBox2.Controls.Add(this.lblPatientId);
            this.uiGroupBox2.Controls.Add(this.label3);
            this.uiGroupBox2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox2.Location = new System.Drawing.Point(880, 191);
            this.uiGroupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.uiGroupBox2.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox2.Size = new System.Drawing.Size(284, 510);
            this.uiGroupBox2.TabIndex = 6;
            this.uiGroupBox2.Text = "当前所选发票信息";
            this.uiGroupBox2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiGroupBox2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblCharge
            // 
            this.lblCharge.AutoSize = true;
            this.lblCharge.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCharge.ForeColor = System.Drawing.Color.Red;
            this.lblCharge.Location = new System.Drawing.Point(94, 267);
            this.lblCharge.Name = "lblCharge";
            this.lblCharge.Size = new System.Drawing.Size(0, 21);
            this.lblCharge.TabIndex = 15;
            // 
            // lblPayType
            // 
            this.lblPayType.AutoSize = true;
            this.lblPayType.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPayType.ForeColor = System.Drawing.Color.Red;
            this.lblPayType.Location = new System.Drawing.Point(94, 235);
            this.lblPayType.Name = "lblPayType";
            this.lblPayType.Size = new System.Drawing.Size(0, 21);
            this.lblPayType.TabIndex = 14;
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDateTime.ForeColor = System.Drawing.Color.Red;
            this.lblDateTime.Location = new System.Drawing.Point(94, 201);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(0, 21);
            this.lblDateTime.TabIndex = 13;
            // 
            // lblRecriptSn
            // 
            this.lblRecriptSn.AutoSize = true;
            this.lblRecriptSn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRecriptSn.ForeColor = System.Drawing.Color.Red;
            this.lblRecriptSn.Location = new System.Drawing.Point(94, 169);
            this.lblRecriptSn.Name = "lblRecriptSn";
            this.lblRecriptSn.Size = new System.Drawing.Size(0, 21);
            this.lblRecriptSn.TabIndex = 12;
            // 
            // lblReceiptNo
            // 
            this.lblReceiptNo.AutoSize = true;
            this.lblReceiptNo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblReceiptNo.ForeColor = System.Drawing.Color.Red;
            this.lblReceiptNo.Location = new System.Drawing.Point(94, 136);
            this.lblReceiptNo.Name = "lblReceiptNo";
            this.lblReceiptNo.Size = new System.Drawing.Size(0, 21);
            this.lblReceiptNo.TabIndex = 11;
            // 
            // lblTimes
            // 
            this.lblTimes.AutoSize = true;
            this.lblTimes.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTimes.ForeColor = System.Drawing.Color.Red;
            this.lblTimes.Location = new System.Drawing.Point(94, 103);
            this.lblTimes.Name = "lblTimes";
            this.lblTimes.Size = new System.Drawing.Size(0, 21);
            this.lblTimes.TabIndex = 10;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(32, 72);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 21);
            this.label12.TabIndex = 9;
            this.label12.Text = "姓名:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName.ForeColor = System.Drawing.Color.Red;
            this.lblName.Location = new System.Drawing.Point(94, 72);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 21);
            this.lblName.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(32, 235);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 21);
            this.label10.TabIndex = 7;
            this.label10.Text = "支付:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(32, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 21);
            this.label9.TabIndex = 6;
            this.label9.Text = "次数:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 136);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 21);
            this.label8.TabIndex = 5;
            this.label8.Text = "发票号:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 169);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 21);
            this.label7.TabIndex = 4;
            this.label7.Text = "机制号:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 201);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 21);
            this.label6.TabIndex = 3;
            this.label6.Text = "时间:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 267);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 21);
            this.label5.TabIndex = 2;
            this.label5.Text = "金额:";
            // 
            // lblPatientId
            // 
            this.lblPatientId.AutoSize = true;
            this.lblPatientId.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPatientId.ForeColor = System.Drawing.Color.Red;
            this.lblPatientId.Location = new System.Drawing.Point(94, 36);
            this.lblPatientId.Name = "lblPatientId";
            this.lblPatientId.Size = new System.Drawing.Size(0, 21);
            this.lblPatientId.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "病人ID:";
            // 
            // dgvCpr
            // 
            this.dgvCpr.AllowUserToAddRows = false;
            this.dgvCpr.AllowUserToDeleteRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.dgvCpr.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCpr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCpr.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.dgvCpr.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCpr.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvCpr.ColumnHeadersHeight = 32;
            this.dgvCpr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCpr.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chkback,
            this.charge_amount,
            this.charge_name,
            this.cf_amount,
            this.caoyao_fu,
            this.orig_price,
            this.charge_price,
            this.sum_total,
            this.back});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCpr.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvCpr.EnableHeadersVisualStyles = false;
            this.dgvCpr.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvCpr.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            this.dgvCpr.Location = new System.Drawing.Point(13, 501);
            this.dgvCpr.Name = "dgvCpr";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCpr.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgvCpr.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvCpr.RowTemplate.Height = 23;
            this.dgvCpr.SelectedIndex = -1;
            this.dgvCpr.Size = new System.Drawing.Size(860, 200);
            this.dgvCpr.TabIndex = 7;
            this.dgvCpr.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // receipt_no
            // 
            this.receipt_no.DataPropertyName = "receipt_no";
            this.receipt_no.HeaderText = "发票号";
            this.receipt_no.Name = "receipt_no";
            this.receipt_no.ReadOnly = true;
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
            // p_bar_code
            // 
            this.p_bar_code.DataPropertyName = "p_bar_code";
            this.p_bar_code.HeaderText = "磁卡号";
            this.p_bar_code.Name = "p_bar_code";
            this.p_bar_code.ReadOnly = true;
            // 
            // times
            // 
            this.times.DataPropertyName = "times";
            this.times.HeaderText = "账页";
            this.times.Name = "times";
            this.times.ReadOnly = true;
            // 
            // cash_date
            // 
            this.cash_date.DataPropertyName = "cash_date";
            this.cash_date.HeaderText = "收费时间";
            this.cash_date.Name = "cash_date";
            this.cash_date.ReadOnly = true;
            // 
            // cash_name
            // 
            this.cash_name.DataPropertyName = "cash_name";
            this.cash_name.HeaderText = "收费员";
            this.cash_name.Name = "cash_name";
            this.cash_name.ReadOnly = true;
            // 
            // cheque_type_name
            // 
            this.cheque_type_name.DataPropertyName = "cheque_type_name";
            this.cheque_type_name.HeaderText = "支付方式";
            this.cheque_type_name.Name = "cheque_type_name";
            this.cheque_type_name.ReadOnly = true;
            // 
            // receipt_sn
            // 
            this.receipt_sn.DataPropertyName = "receipt_sn";
            this.receipt_sn.HeaderText = "机制号";
            this.receipt_sn.Name = "receipt_sn";
            this.receipt_sn.ReadOnly = true;
            // 
            // charge_status
            // 
            this.charge_status.DataPropertyName = "charge_status";
            this.charge_status.HeaderText = "状态";
            this.charge_status.Name = "charge_status";
            this.charge_status.ReadOnly = true;
            // 
            // charge_total
            // 
            this.charge_total.DataPropertyName = "charge_total";
            this.charge_total.HeaderText = "总额";
            this.charge_total.Name = "charge_total";
            this.charge_total.ReadOnly = true;
            // 
            // report_date
            // 
            this.report_date.DataPropertyName = "report_date";
            this.report_date.HeaderText = "结账日期";
            this.report_date.Name = "report_date";
            this.report_date.ReadOnly = true;
            // 
            // chkback
            // 
            this.chkback.HeaderText = "选择";
            this.chkback.Name = "chkback";
            // 
            // charge_amount
            // 
            this.charge_amount.DataPropertyName = "charge_amount";
            this.charge_amount.HeaderText = "数量";
            this.charge_amount.Name = "charge_amount";
            // 
            // charge_name
            // 
            this.charge_name.DataPropertyName = "charge_name";
            this.charge_name.HeaderText = "项目名称";
            this.charge_name.Name = "charge_name";
            // 
            // cf_amount
            // 
            this.cf_amount.DataPropertyName = "cf_amount";
            this.cf_amount.HeaderText = "处方数量";
            this.cf_amount.Name = "cf_amount";
            // 
            // caoyao_fu
            // 
            this.caoyao_fu.DataPropertyName = "caoyao_fu";
            this.caoyao_fu.HeaderText = "付数";
            this.caoyao_fu.Name = "caoyao_fu";
            // 
            // orig_price
            // 
            this.orig_price.DataPropertyName = "orig_price";
            this.orig_price.HeaderText = "价格(标准)";
            this.orig_price.Name = "orig_price";
            // 
            // charge_price
            // 
            this.charge_price.DataPropertyName = "charge_price";
            this.charge_price.HeaderText = "价格(实收)";
            this.charge_price.Name = "charge_price";
            // 
            // sum_total
            // 
            this.sum_total.DataPropertyName = "sum_total";
            this.sum_total.HeaderText = "合计";
            this.sum_total.Name = "sum_total";
            // 
            // back
            // 
            this.back.DataPropertyName = "back";
            this.back.HeaderText = "退药数量";
            this.back.Name = "back";
            // 
            // RefundPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1177, 713);
            this.Controls.Add(this.dgvCpr);
            this.Controls.Add(this.uiGroupBox2);
            this.Controls.Add(this.dgvRefund);
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.pnlTitle);
            this.Name = "RefundPage";
            this.PageIndex = 1102;
            this.Text = "RefundPage";
            this.Load += new System.EventHandler(this.RefundPage_Load);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefund)).EndInit();
            this.uiGroupBox2.ResumeLayout(false);
            this.uiGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCpr)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIPanel pnlTitle;
        private Sunny.UI.UISymbolButton btnHuajia;
        private Sunny.UI.UISymbolButton btnSearch;
        private Sunny.UI.UISymbolButton uiSymbolButton1;
        private Sunny.UI.UISymbolButton btnExit;
        private Sunny.UI.UILabel lblTitle;
        private System.Windows.Forms.Label lblNodata;
        private Sunny.UI.UIGroupBox uiGroupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Sunny.UI.UIDatePicker txtEndDate;
        private Sunny.UI.UIDatePicker txtBeginDate;
        private Sunny.UI.UITextBox txtFilterValue;
        private Sunny.UI.UIComboBox cbxType;
        private Sunny.UI.UIDataGridView dgvRefund;
        private Sunny.UI.UIGroupBox uiGroupBox2;
        private System.Windows.Forms.Label lblCharge;
        private System.Windows.Forms.Label lblPayType;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Label lblRecriptSn;
        private System.Windows.Forms.Label lblReceiptNo;
        private System.Windows.Forms.Label lblTimes;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPatientId;
        private System.Windows.Forms.Label label3;
        private Sunny.UI.UIDataGridView dgvCpr;
        private System.Windows.Forms.DataGridViewTextBoxColumn receipt_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn patient_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn patient_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_bar_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn times;
        private System.Windows.Forms.DataGridViewTextBoxColumn cash_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn cash_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn cheque_type_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn receipt_sn;
        private System.Windows.Forms.DataGridViewTextBoxColumn charge_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn charge_total;
        private System.Windows.Forms.DataGridViewTextBoxColumn report_date;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkback;
        private System.Windows.Forms.DataGridViewTextBoxColumn charge_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn charge_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn cf_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn caoyao_fu;
        private System.Windows.Forms.DataGridViewTextBoxColumn orig_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn charge_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn sum_total;
        private System.Windows.Forms.DataGridViewTextBoxColumn back;
    }
}