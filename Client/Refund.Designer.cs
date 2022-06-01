namespace Client
{
    partial class Refund
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.lblName = new Sunny.UI.UILabel();
            this.lblSex = new Sunny.UI.UILabel();
            this.lblAge = new Sunny.UI.UILabel();
            this.dgvDeposit = new Sunny.UI.UIDataGridView();
            this.gh_date_str = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.group_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doctor_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ampm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.times = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledger_sn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.charge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clinic_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cheque_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.visit_flag_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cheque_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cheque_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receipt_sn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.dtprq = new Sunny.UI.UIDatePicker();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.txtCode = new Sunny.UI.UITextBox();
            this.pnlTitle = new Sunny.UI.UIPanel();
            this.btnCashRefund = new Sunny.UI.UISymbolButton();
            this.lblhidid = new Sunny.UI.UILabel();
            this.uiSymbolButton1 = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton2 = new Sunny.UI.UISymbolButton();
            this.btnTuihao = new Sunny.UI.UISymbolButton();
            this.lblTitle = new Sunny.UI.UILabel();
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.uiGroupBox2 = new Sunny.UI.UIGroupBox();
            this.lblSno = new Sunny.UI.UILabel();
            this.uiLabel6 = new Sunny.UI.UILabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeposit)).BeginInit();
            this.pnlTitle.SuspendLayout();
            this.uiGroupBox1.SuspendLayout();
            this.uiGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(42, 32);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(66, 23);
            this.uiLabel1.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "姓名：";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(42, 62);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(63, 23);
            this.uiLabel2.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.uiLabel2.TabIndex = 1;
            this.uiLabel2.Text = "性别：";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(196, 62);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(58, 23);
            this.uiLabel3.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.uiLabel3.TabIndex = 2;
            this.uiLabel3.Text = "年龄：";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName.Location = new System.Drawing.Point(123, 32);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(206, 23);
            this.lblName.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.lblName.TabIndex = 3;
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblName.Click += new System.EventHandler(this.lblName_Click);
            // 
            // lblSex
            // 
            this.lblSex.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSex.Location = new System.Drawing.Point(123, 63);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(67, 23);
            this.lblSex.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.lblSex.TabIndex = 4;
            this.lblSex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAge
            // 
            this.lblAge.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAge.Location = new System.Drawing.Point(260, 62);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(69, 23);
            this.lblAge.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.lblAge.TabIndex = 5;
            this.lblAge.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAge.Click += new System.EventHandler(this.lblAge_Click);
            // 
            // dgvDeposit
            // 
            this.dgvDeposit.AllowUserToAddRows = false;
            this.dgvDeposit.AllowUserToDeleteRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.dgvDeposit.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDeposit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDeposit.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.dgvDeposit.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDeposit.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvDeposit.ColumnHeadersHeight = 32;
            this.dgvDeposit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDeposit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gh_date_str,
            this.unit_name,
            this.group_name,
            this.doctor_name,
            this.ampm,
            this.times,
            this.ledger_sn,
            this.charge,
            this.clinic_name,
            this.cheque_name,
            this.visit_flag_name,
            this.cheque_type,
            this.cheque_no,
            this.item_no,
            this.receipt_sn});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(234)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDeposit.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDeposit.EnableHeadersVisualStyles = false;
            this.dgvDeposit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvDeposit.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(164)))), ((int)(((byte)(152)))));
            this.dgvDeposit.Location = new System.Drawing.Point(4, 279);
            this.dgvDeposit.Name = "dgvDeposit";
            this.dgvDeposit.ReadOnly = true;
            this.dgvDeposit.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDeposit.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(234)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgvDeposit.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvDeposit.RowTemplate.Height = 23;
            this.dgvDeposit.SelectedIndex = -1;
            this.dgvDeposit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDeposit.ShowGridLine = true;
            this.dgvDeposit.Size = new System.Drawing.Size(1060, 363);
            this.dgvDeposit.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.dgvDeposit.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.dgvDeposit.TabIndex = 6;
            this.dgvDeposit.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeposit_CellDoubleClick);
            this.dgvDeposit.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvDeposit_RowPrePaint);
            // 
            // gh_date_str
            // 
            this.gh_date_str.DataPropertyName = "gh_date_str";
            this.gh_date_str.HeaderText = "挂号时间";
            this.gh_date_str.Name = "gh_date_str";
            this.gh_date_str.ReadOnly = true;
            // 
            // unit_name
            // 
            this.unit_name.DataPropertyName = "unit_name";
            this.unit_name.HeaderText = "挂号专科";
            this.unit_name.Name = "unit_name";
            this.unit_name.ReadOnly = true;
            // 
            // group_name
            // 
            this.group_name.DataPropertyName = "group_name";
            this.group_name.HeaderText = "科室";
            this.group_name.Name = "group_name";
            this.group_name.ReadOnly = true;
            // 
            // doctor_name
            // 
            this.doctor_name.DataPropertyName = "doctor_name";
            this.doctor_name.HeaderText = "医生";
            this.doctor_name.Name = "doctor_name";
            this.doctor_name.ReadOnly = true;
            // 
            // ampm
            // 
            this.ampm.DataPropertyName = "ampmstr";
            this.ampm.HeaderText = "上/下午";
            this.ampm.Name = "ampm";
            this.ampm.ReadOnly = true;
            // 
            // times
            // 
            this.times.DataPropertyName = "times";
            this.times.HeaderText = "挂号次数";
            this.times.Name = "times";
            this.times.ReadOnly = true;
            // 
            // ledger_sn
            // 
            this.ledger_sn.DataPropertyName = "ledger_sn";
            this.ledger_sn.HeaderText = "ledger_sn";
            this.ledger_sn.Name = "ledger_sn";
            this.ledger_sn.ReadOnly = true;
            this.ledger_sn.Visible = false;
            // 
            // charge
            // 
            this.charge.DataPropertyName = "charge";
            this.charge.HeaderText = "金额";
            this.charge.Name = "charge";
            this.charge.ReadOnly = true;
            // 
            // clinic_name
            // 
            this.clinic_name.DataPropertyName = "clinic_name";
            this.clinic_name.HeaderText = "号类";
            this.clinic_name.Name = "clinic_name";
            this.clinic_name.ReadOnly = true;
            // 
            // cheque_name
            // 
            this.cheque_name.DataPropertyName = "cheque_name";
            this.cheque_name.HeaderText = "支付类型";
            this.cheque_name.Name = "cheque_name";
            this.cheque_name.ReadOnly = true;
            this.cheque_name.Visible = false;
            // 
            // visit_flag_name
            // 
            this.visit_flag_name.DataPropertyName = "visit_flag_name";
            this.visit_flag_name.HeaderText = "挂号状态";
            this.visit_flag_name.Name = "visit_flag_name";
            this.visit_flag_name.ReadOnly = true;
            // 
            // cheque_type
            // 
            this.cheque_type.DataPropertyName = "cheque_type";
            this.cheque_type.HeaderText = "cheque_type";
            this.cheque_type.Name = "cheque_type";
            this.cheque_type.ReadOnly = true;
            this.cheque_type.Visible = false;
            // 
            // cheque_no
            // 
            this.cheque_no.DataPropertyName = "cheque_no";
            this.cheque_no.HeaderText = "cheque_no";
            this.cheque_no.Name = "cheque_no";
            this.cheque_no.ReadOnly = true;
            this.cheque_no.Visible = false;
            // 
            // item_no
            // 
            this.item_no.DataPropertyName = "item_no";
            this.item_no.HeaderText = "item_no";
            this.item_no.Name = "item_no";
            this.item_no.ReadOnly = true;
            this.item_no.Visible = false;
            // 
            // receipt_sn
            // 
            this.receipt_sn.DataPropertyName = "receipt_sn";
            this.receipt_sn.HeaderText = "receipt_sn";
            this.receipt_sn.Name = "receipt_sn";
            this.receipt_sn.ReadOnly = true;
            this.receipt_sn.Visible = false;
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.Location = new System.Drawing.Point(36, 41);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(54, 23);
            this.uiLabel4.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.uiLabel4.TabIndex = 9;
            this.uiLabel4.Text = "日期";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtprq
            // 
            this.dtprq.FillColor = System.Drawing.Color.White;
            this.dtprq.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.dtprq.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtprq.Location = new System.Drawing.Point(97, 38);
            this.dtprq.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtprq.MaxLength = 10;
            this.dtprq.MinimumSize = new System.Drawing.Size(63, 0);
            this.dtprq.Name = "dtprq";
            this.dtprq.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.dtprq.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.dtprq.ShowToday = true;
            this.dtprq.Size = new System.Drawing.Size(209, 29);
            this.dtprq.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.dtprq.SymbolDropDown = 61555;
            this.dtprq.SymbolNormal = 61555;
            this.dtprq.TabIndex = 10;
            this.dtprq.Text = "2022-04-18";
            this.dtprq.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.dtprq.Value = new System.DateTime(2022, 4, 18, 0, 0, 0, 0);
            this.dtprq.ValueChanged += new Sunny.UI.UIDatePicker.OnDateTimeChanged(this.dtprq_ValueChanged);
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel5.Location = new System.Drawing.Point(36, 80);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(45, 23);
            this.uiLabel5.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.uiLabel5.TabIndex = 11;
            this.uiLabel5.Text = "卡号";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCode
            // 
            this.txtCode.ButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.txtCode.ButtonFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.txtCode.ButtonFillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.txtCode.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.txtCode.ButtonRectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.txtCode.ButtonRectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.txtCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCode.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.txtCode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCode.Location = new System.Drawing.Point(97, 79);
            this.txtCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCode.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtCode.Name = "txtCode";
            this.txtCode.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.txtCode.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.txtCode.ShowText = false;
            this.txtCode.Size = new System.Drawing.Size(209, 29);
            this.txtCode.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.txtCode.TabIndex = 12;
            this.txtCode.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtCode.TextChanged += new System.EventHandler(this.txtCode_TextChanged);
            this.txtCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyUp);
            // 
            // pnlTitle
            // 
            this.pnlTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTitle.Controls.Add(this.btnCashRefund);
            this.pnlTitle.Controls.Add(this.lblhidid);
            this.pnlTitle.Controls.Add(this.uiSymbolButton1);
            this.pnlTitle.Controls.Add(this.uiSymbolButton2);
            this.pnlTitle.Controls.Add(this.btnTuihao);
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.pnlTitle.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.pnlTitle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlTitle.Location = new System.Drawing.Point(4, 40);
            this.pnlTitle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlTitle.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.pnlTitle.Size = new System.Drawing.Size(1060, 66);
            this.pnlTitle.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.pnlTitle.TabIndex = 13;
            this.pnlTitle.Text = null;
            this.pnlTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCashRefund
            // 
            this.btnCashRefund.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCashRefund.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnCashRefund.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnCashRefund.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.btnCashRefund.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.btnCashRefund.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.btnCashRefund.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCashRefund.Location = new System.Drawing.Point(407, 17);
            this.btnCashRefund.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnCashRefund.Name = "btnCashRefund";
            this.btnCashRefund.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnCashRefund.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.btnCashRefund.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.btnCashRefund.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.btnCashRefund.Size = new System.Drawing.Size(116, 35);
            this.btnCashRefund.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.btnCashRefund.Symbol = 62005;
            this.btnCashRefund.TabIndex = 16;
            this.btnCashRefund.Text = "现金退(F3)";
            this.btnCashRefund.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCashRefund.Click += new System.EventHandler(this.btnCashRefund_Click);
            // 
            // lblhidid
            // 
            this.lblhidid.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblhidid.Location = new System.Drawing.Point(845, 33);
            this.lblhidid.Name = "lblhidid";
            this.lblhidid.Size = new System.Drawing.Size(100, 23);
            this.lblhidid.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.lblhidid.TabIndex = 15;
            this.lblhidid.Text = "uiLabel6";
            this.lblhidid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblhidid.Visible = false;
            // 
            // uiSymbolButton1
            // 
            this.uiSymbolButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.uiSymbolButton1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.uiSymbolButton1.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.uiSymbolButton1.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.uiSymbolButton1.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.uiSymbolButton1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton1.Location = new System.Drawing.Point(174, 17);
            this.uiSymbolButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton1.Name = "uiSymbolButton1";
            this.uiSymbolButton1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.uiSymbolButton1.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.uiSymbolButton1.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.uiSymbolButton1.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.uiSymbolButton1.Size = new System.Drawing.Size(110, 35);
            this.uiSymbolButton1.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.uiSymbolButton1.Symbol = 61473;
            this.uiSymbolButton1.TabIndex = 10;
            this.uiSymbolButton1.Text = "重新(F1)";
            this.uiSymbolButton1.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton1.Click += new System.EventHandler(this.uiSymbolButton1_Click);
            // 
            // uiSymbolButton2
            // 
            this.uiSymbolButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.uiSymbolButton2.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.uiSymbolButton2.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.uiSymbolButton2.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.uiSymbolButton2.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.uiSymbolButton2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton2.Location = new System.Drawing.Point(529, 17);
            this.uiSymbolButton2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton2.Name = "uiSymbolButton2";
            this.uiSymbolButton2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.uiSymbolButton2.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.uiSymbolButton2.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.uiSymbolButton2.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.uiSymbolButton2.Size = new System.Drawing.Size(119, 35);
            this.uiSymbolButton2.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.uiSymbolButton2.Symbol = 61579;
            this.uiSymbolButton2.TabIndex = 8;
            this.uiSymbolButton2.Text = "退出(F4)";
            this.uiSymbolButton2.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton2.Click += new System.EventHandler(this.uiSymbolButton2_Click);
            // 
            // btnTuihao
            // 
            this.btnTuihao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTuihao.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnTuihao.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnTuihao.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.btnTuihao.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.btnTuihao.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.btnTuihao.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTuihao.Location = new System.Drawing.Point(290, 17);
            this.btnTuihao.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnTuihao.Name = "btnTuihao";
            this.btnTuihao.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnTuihao.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.btnTuihao.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.btnTuihao.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.btnTuihao.Size = new System.Drawing.Size(111, 35);
            this.btnTuihao.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.btnTuihao.Symbol = 62005;
            this.btnTuihao.TabIndex = 7;
            this.btnTuihao.Text = "退号(F2)";
            this.btnTuihao.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTuihao.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(45, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(70, 51);
            this.lblTitle.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "退号";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.uiGroupBox1.Controls.Add(this.uiLabel4);
            this.uiGroupBox1.Controls.Add(this.dtprq);
            this.uiGroupBox1.Controls.Add(this.txtCode);
            this.uiGroupBox1.Controls.Add(this.uiLabel5);
            this.uiGroupBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.uiGroupBox1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.uiGroupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox1.Location = new System.Drawing.Point(73, 128);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.uiGroupBox1.Size = new System.Drawing.Size(408, 128);
            this.uiGroupBox1.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.uiGroupBox1.TabIndex = 14;
            this.uiGroupBox1.Text = "查询条件";
            this.uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.uiGroupBox2.Controls.Add(this.lblSno);
            this.uiGroupBox2.Controls.Add(this.uiLabel6);
            this.uiGroupBox2.Controls.Add(this.uiLabel1);
            this.uiGroupBox2.Controls.Add(this.lblName);
            this.uiGroupBox2.Controls.Add(this.uiLabel2);
            this.uiGroupBox2.Controls.Add(this.lblSex);
            this.uiGroupBox2.Controls.Add(this.lblAge);
            this.uiGroupBox2.Controls.Add(this.uiLabel3);
            this.uiGroupBox2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.uiGroupBox2.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.uiGroupBox2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox2.Location = new System.Drawing.Point(507, 128);
            this.uiGroupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.uiGroupBox2.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.uiGroupBox2.Size = new System.Drawing.Size(426, 128);
            this.uiGroupBox2.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.uiGroupBox2.TabIndex = 15;
            this.uiGroupBox2.Text = "用户信息";
            this.uiGroupBox2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiGroupBox2.Click += new System.EventHandler(this.uiGroupBox2_Click);
            // 
            // lblSno
            // 
            this.lblSno.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSno.Location = new System.Drawing.Point(123, 92);
            this.lblSno.Name = "lblSno";
            this.lblSno.Size = new System.Drawing.Size(230, 23);
            this.lblSno.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.lblSno.TabIndex = 7;
            this.lblSno.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel6
            // 
            this.uiLabel6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel6.Location = new System.Drawing.Point(27, 92);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(75, 23);
            this.uiLabel6.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.uiLabel6.TabIndex = 6;
            this.uiLabel6.Text = "身份证：";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Refund
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1068, 645);
            this.ControlBoxFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.Controls.Add(this.uiGroupBox2);
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.pnlTitle);
            this.Controls.Add(this.dgvDeposit);
            this.KeyPreview = true;
            this.Name = "Refund";
            this.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.Text = "退号";
            this.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.Load += new System.EventHandler(this.Refund_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Refund_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeposit)).EndInit();
            this.pnlTitle.ResumeLayout(false);
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel lblName;
        private Sunny.UI.UILabel lblSex;
        private Sunny.UI.UILabel lblAge;
        private Sunny.UI.UIDataGridView dgvDeposit;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UIDatePicker dtprq;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UITextBox txtCode;
        private Sunny.UI.UIPanel pnlTitle;
        private Sunny.UI.UISymbolButton uiSymbolButton1;
        private Sunny.UI.UISymbolButton uiSymbolButton2;
        private Sunny.UI.UISymbolButton btnTuihao;
        private Sunny.UI.UILabel lblTitle;
        private Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UILabel lblhidid;
        private Sunny.UI.UIGroupBox uiGroupBox2;
        private Sunny.UI.UISymbolButton btnCashRefund;
        private Sunny.UI.UILabel lblSno;
        private Sunny.UI.UILabel uiLabel6;
        private System.Windows.Forms.DataGridViewTextBoxColumn gh_date_str;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn group_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn doctor_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn ampm;
        private System.Windows.Forms.DataGridViewTextBoxColumn times;
        private System.Windows.Forms.DataGridViewTextBoxColumn ledger_sn;
        private System.Windows.Forms.DataGridViewTextBoxColumn charge;
        private System.Windows.Forms.DataGridViewTextBoxColumn clinic_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn cheque_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn visit_flag_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn cheque_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn cheque_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn receipt_sn;
    }
}