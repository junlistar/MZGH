namespace Client.Forms.Pages.zfgl
{
    partial class SelfPay
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTitle = new Sunny.UI.UIPanel();
            this.btnHuajia = new Sunny.UI.UISymbolButton();
            this.btnSearch = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton1 = new Sunny.UI.UISymbolButton();
            this.btnExit = new Sunny.UI.UISymbolButton();
            this.lblTitle = new Sunny.UI.UILabel();
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.cbxRefundStatus = new Sunny.UI.UIComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_pid = new Sunny.UI.UITextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEndDate = new Sunny.UI.UIDatePicker();
            this.txtBeginDate = new Sunny.UI.UIDatePicker();
            this.dgv_paylist = new Sunny.UI.UIDataGridView();
            this.patient_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.his_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patient_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refund_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.charge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cheque_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.opera_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.opera = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cheque_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cheque_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mdtrt_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ipt_otp_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.psn_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yb_insuplc_admdvs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTitle.SuspendLayout();
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_paylist)).BeginInit();
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
            this.pnlTitle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlTitle.Location = new System.Drawing.Point(2, 4);
            this.pnlTitle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlTitle.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(1211, 45);
            this.pnlTitle.TabIndex = 6;
            this.pnlTitle.Text = null;
            this.pnlTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlTitle.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnHuajia
            // 
            this.btnHuajia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuajia.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnHuajia.Location = new System.Drawing.Point(428, 3);
            this.btnHuajia.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnHuajia.Name = "btnHuajia";
            this.btnHuajia.Size = new System.Drawing.Size(100, 40);
            this.btnHuajia.Symbol = 362139;
            this.btnHuajia.TabIndex = 12;
            this.btnHuajia.Text = "退费";
            this.btnHuajia.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnHuajia.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnHuajia.Click += new System.EventHandler(this.btnHuajia_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Location = new System.Drawing.Point(216, 3);
            this.btnSearch.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 40);
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
            this.uiSymbolButton1.Size = new System.Drawing.Size(100, 40);
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
            this.btnExit.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.Location = new System.Drawing.Point(534, 3);
            this.btnExit.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 40);
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
            this.lblTitle.Size = new System.Drawing.Size(120, 35);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "自助支付";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.cbxRefundStatus);
            this.uiGroupBox1.Controls.Add(this.label4);
            this.uiGroupBox1.Controls.Add(this.txt_pid);
            this.uiGroupBox1.Controls.Add(this.label2);
            this.uiGroupBox1.Controls.Add(this.label1);
            this.uiGroupBox1.Controls.Add(this.txtEndDate);
            this.uiGroupBox1.Controls.Add(this.txtBeginDate);
            this.uiGroupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox1.Location = new System.Drawing.Point(3, 55);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox1.Size = new System.Drawing.Size(1211, 117);
            this.uiGroupBox1.TabIndex = 7;
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
            // txt_pid
            // 
            this.txt_pid.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_pid.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_pid.Location = new System.Drawing.Point(421, 29);
            this.txt_pid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_pid.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_pid.Name = "txt_pid";
            this.txt_pid.ShowText = false;
            this.txt_pid.Size = new System.Drawing.Size(150, 29);
            this.txt_pid.TabIndex = 4;
            this.txt_pid.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_pid.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(340, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "患者ID：";
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
            this.his_no,
            this.patient_id,
            this.price_date,
            this.refund_date,
            this.charge,
            this.cheque_no,
            this.opera_name,
            this.opera,
            this.cheque_name,
            this.status,
            this.cheque_type,
            this.mdtrt_id,
            this.ipt_otp_no,
            this.psn_no,
            this.yb_insuplc_admdvs});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_paylist.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_paylist.EnableHeadersVisualStyles = false;
            this.dgv_paylist.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgv_paylist.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            this.dgv_paylist.Location = new System.Drawing.Point(2, 180);
            this.dgv_paylist.Name = "dgv_paylist";
            this.dgv_paylist.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_paylist.RowHeadersDefaultCellStyle = dataGridViewCellStyle7; 
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgv_paylist.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgv_paylist.RowTemplate.Height = 23;
            this.dgv_paylist.SelectedIndex = -1;
            this.dgv_paylist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect; 
            this.dgv_paylist.Size = new System.Drawing.Size(1211, 540);
            this.dgv_paylist.TabIndex = 8;
            this.dgv_paylist.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // patient_name
            // 
            this.patient_name.DataPropertyName = "patient_name";
            this.patient_name.HeaderText = "病人姓名";
            this.patient_name.Name = "patient_name";
            this.patient_name.ReadOnly = true;
            // 
            // his_no
            // 
            this.his_no.DataPropertyName = "his_no";
            this.his_no.HeaderText = "his_no";
            this.his_no.Name = "his_no";
            this.his_no.ReadOnly = true;
            this.his_no.Visible = false;
            // 
            // patient_id
            // 
            this.patient_id.DataPropertyName = "patient_id";
            this.patient_id.HeaderText = "病人ID";
            this.patient_id.Name = "patient_id";
            this.patient_id.ReadOnly = true;
            // 
            // price_date
            // 
            this.price_date.DataPropertyName = "price_date";
            dataGridViewCellStyle3.Format = "F";
            dataGridViewCellStyle3.NullValue = null;
            this.price_date.DefaultCellStyle = dataGridViewCellStyle3;
            this.price_date.HeaderText = "收费时间";
            this.price_date.Name = "price_date";
            this.price_date.ReadOnly = true;
            // 
            // refund_date
            // 
            this.refund_date.DataPropertyName = "refund_date";
            dataGridViewCellStyle4.Format = "F";
            dataGridViewCellStyle4.NullValue = null;
            this.refund_date.DefaultCellStyle = dataGridViewCellStyle4;
            this.refund_date.HeaderText = "退费时间";
            this.refund_date.Name = "refund_date";
            this.refund_date.ReadOnly = true;
            // 
            // charge
            // 
            this.charge.DataPropertyName = "charge";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            this.charge.DefaultCellStyle = dataGridViewCellStyle5;
            this.charge.HeaderText = "金额";
            this.charge.Name = "charge";
            this.charge.ReadOnly = true;
            // 
            // cheque_no
            // 
            this.cheque_no.DataPropertyName = "cheque_no";
            this.cheque_no.HeaderText = "支付号";
            this.cheque_no.Name = "cheque_no";
            this.cheque_no.ReadOnly = true;
            // 
            // opera_name
            // 
            this.opera_name.DataPropertyName = "opera_name";
            this.opera_name.HeaderText = "收费员";
            this.opera_name.Name = "opera_name";
            this.opera_name.ReadOnly = true;
            // 
            // opera
            // 
            this.opera.DataPropertyName = "opera";
            this.opera.HeaderText = "opera";
            this.opera.Name = "opera";
            this.opera.ReadOnly = true;
            this.opera.Visible = false;
            // 
            // cheque_name
            // 
            this.cheque_name.DataPropertyName = "cheque_name";
            this.cheque_name.HeaderText = "支付方式";
            this.cheque_name.Name = "cheque_name";
            this.cheque_name.ReadOnly = true;
            // 
            // status
            // 
            this.status.DataPropertyName = "status";
            this.status.HeaderText = "状态";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // cheque_type
            // 
            this.cheque_type.DataPropertyName = "cheque_type";
            this.cheque_type.HeaderText = "cheque_type";
            this.cheque_type.Name = "cheque_type";
            this.cheque_type.ReadOnly = true;
            this.cheque_type.Visible = false;
            // 
            // mdtrt_id
            // 
            this.mdtrt_id.DataPropertyName = "mdtrt_id";
            this.mdtrt_id.HeaderText = "mdtrt_id";
            this.mdtrt_id.Name = "mdtrt_id";
            this.mdtrt_id.ReadOnly = true;
            this.mdtrt_id.Visible = false;
            // 
            // ipt_otp_no
            // 
            this.ipt_otp_no.DataPropertyName = "ipt_otp_no";
            this.ipt_otp_no.HeaderText = "ipt_otp_no";
            this.ipt_otp_no.Name = "ipt_otp_no";
            this.ipt_otp_no.ReadOnly = true;
            this.ipt_otp_no.Visible = false;
            // 
            // psn_no
            // 
            this.psn_no.DataPropertyName = "psn_no";
            this.psn_no.HeaderText = "psn_no";
            this.psn_no.Name = "psn_no";
            this.psn_no.ReadOnly = true;
            this.psn_no.Visible = false;
            // 
            // yb_insuplc_admdvs
            // 
            this.yb_insuplc_admdvs.DataPropertyName = "yb_insuplc_admdvs";
            this.yb_insuplc_admdvs.HeaderText = "yb_insuplc_admdvs";
            this.yb_insuplc_admdvs.Name = "yb_insuplc_admdvs";
            this.yb_insuplc_admdvs.ReadOnly = true;
            this.yb_insuplc_admdvs.Visible = false;
            // 
            // SelfPay
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1215, 722);
            this.Controls.Add(this.dgv_paylist);
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.pnlTitle);
            this.Name = "SelfPay";
            this.PageIndex = 1603;
            this.Text = "自助支付";
            this.Initialize += new System.EventHandler(this.SelfPay_Initialize);
            this.Load += new System.EventHandler(this.SelfPay_Load);
            this.pnlTitle.ResumeLayout(false);
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_paylist)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIPanel pnlTitle;
        private Sunny.UI.UISymbolButton btnHuajia;
        private Sunny.UI.UISymbolButton btnSearch;
        private Sunny.UI.UISymbolButton uiSymbolButton1;
        private Sunny.UI.UISymbolButton btnExit;
        private Sunny.UI.UILabel lblTitle;
        private Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UIComboBox cbxRefundStatus;
        private System.Windows.Forms.Label label4;
        private Sunny.UI.UITextBox txt_pid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Sunny.UI.UIDatePicker txtEndDate;
        private Sunny.UI.UIDatePicker txtBeginDate;
        private Sunny.UI.UIDataGridView dgv_paylist;
        private System.Windows.Forms.DataGridViewTextBoxColumn patient_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn his_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn patient_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn price_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn refund_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn charge;
        private System.Windows.Forms.DataGridViewTextBoxColumn cheque_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn opera_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn opera;
        private System.Windows.Forms.DataGridViewTextBoxColumn cheque_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn cheque_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn mdtrt_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ipt_otp_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn psn_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn yb_insuplc_admdvs;
    }
}