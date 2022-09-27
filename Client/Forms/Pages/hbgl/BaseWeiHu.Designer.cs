namespace Client
{
    partial class BaseWeiHu
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTitle = new Sunny.UI.UIPanel();
            this.btnAdd = new Sunny.UI.UISymbolButton();
            this.btnSearch = new Sunny.UI.UISymbolButton();
            this.btnReset = new Sunny.UI.UISymbolButton();
            this.btnExit = new Sunny.UI.UISymbolButton();
            this.lblTitle = new Sunny.UI.UILabel();
            this.dgvlist = new Sunny.UI.UIDataGridView();
            this.record_sn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.request_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.open_flag_str = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apstr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.group_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clinic_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doct_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.req_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.winnostr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.begin_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.current_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toend_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.txt_workroom = new Sunny.UI.UITextBox();
            this.cbxRequestType = new Sunny.UI.UIComboBox();
            this.uiLabel7 = new Sunny.UI.UILabel();
            this.txtDate = new Sunny.UI.UIDatePicker();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.txtHaobie = new Sunny.UI.UITextBox();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.txtDoct = new Sunny.UI.UITextBox();
            this.txtzk = new Sunny.UI.UITextBox();
            this.txtks = new Sunny.UI.UITextBox();
            this.uiLabel10 = new Sunny.UI.UILabel();
            this.uiLabel8 = new Sunny.UI.UILabel();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.cbxOpenFlag = new Sunny.UI.UIComboBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.cbxSXW = new Sunny.UI.UIComboBox();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiToolTip1 = new Sunny.UI.UIToolTip(this.components);
            this.lblTotalCount = new Sunny.UI.UILabel();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvlist)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTitle.Controls.Add(this.btnAdd);
            this.pnlTitle.Controls.Add(this.btnSearch);
            this.pnlTitle.Controls.Add(this.btnReset);
            this.pnlTitle.Controls.Add(this.btnExit);
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlTitle.Location = new System.Drawing.Point(2, 5);
            this.pnlTitle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlTitle.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(1181, 45);
            this.pnlTitle.TabIndex = 2;
            this.pnlTitle.Text = null;
            this.pnlTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlTitle.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnAdd
            // 
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.Location = new System.Drawing.Point(462, 3);
            this.btnAdd.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 40);
            this.btnAdd.Symbol = 61508;
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "编辑";
            this.btnAdd.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Location = new System.Drawing.Point(251, 3);
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
            // btnReset
            // 
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReset.Location = new System.Drawing.Point(356, 3);
            this.btnReset.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 40);
            this.btnReset.Symbol = 61473;
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "重新";
            this.btnReset.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReset.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.Location = new System.Drawing.Point(567, 3);
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
            this.lblTitle.Location = new System.Drawing.Point(45, 3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(165, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "使用号表维护";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // dgvlist
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.dgvlist.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvlist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvlist.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.dgvlist.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvlist.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvlist.ColumnHeadersHeight = 32;
            this.dgvlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvlist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.record_sn,
            this.request_date,
            this.open_flag_str,
            this.apstr,
            this.unit_name,
            this.group_name,
            this.clinic_name,
            this.doct_name,
            this.req_name,
            this.winnostr,
            this.begin_no,
            this.current_no,
            this.toend_no});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvlist.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvlist.EnableHeadersVisualStyles = false;
            this.dgvlist.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvlist.GridColor = System.Drawing.Color.PowderBlue;
            this.dgvlist.Location = new System.Drawing.Point(2, 217);
            this.dgvlist.Name = "dgvlist";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvlist.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvlist.RowHeight = 0;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgvlist.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvlist.RowTemplate.Height = 23;
            this.dgvlist.SelectedIndex = -1;
            this.dgvlist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvlist.ShowGridLine = false;
            this.dgvlist.ShowRect = false;
            this.dgvlist.Size = new System.Drawing.Size(1181, 447);
            this.dgvlist.StyleCustomMode = true;
            this.dgvlist.TabIndex = 3;
            this.dgvlist.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.dgvlist.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvlist_CellClick);
            this.dgvlist.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvlist_CellDoubleClick);
            this.dgvlist.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvlist_RowPostPaint);
            // 
            // record_sn
            // 
            this.record_sn.DataPropertyName = "record_sn";
            this.record_sn.HeaderText = "record_sn";
            this.record_sn.Name = "record_sn";
            this.record_sn.Visible = false;
            // 
            // request_date
            // 
            this.request_date.DataPropertyName = "request_date";
            this.request_date.HeaderText = "日期";
            this.request_date.Name = "request_date";
            // 
            // open_flag_str
            // 
            this.open_flag_str.DataPropertyName = "open_flag_str";
            this.open_flag_str.HeaderText = "开放标志";
            this.open_flag_str.Name = "open_flag_str";
            // 
            // apstr
            // 
            this.apstr.DataPropertyName = "apstr";
            this.apstr.HeaderText = "上下午";
            this.apstr.Name = "apstr";
            // 
            // unit_name
            // 
            this.unit_name.DataPropertyName = "unit_name";
            this.unit_name.HeaderText = "科室";
            this.unit_name.Name = "unit_name";
            // 
            // group_name
            // 
            this.group_name.DataPropertyName = "group_name";
            this.group_name.HeaderText = "专科";
            this.group_name.Name = "group_name";
            this.group_name.Visible = false;
            // 
            // clinic_name
            // 
            this.clinic_name.DataPropertyName = "clinic_name";
            this.clinic_name.HeaderText = "号别";
            this.clinic_name.Name = "clinic_name";
            // 
            // doct_name
            // 
            this.doct_name.DataPropertyName = "doct_name";
            this.doct_name.HeaderText = "医生";
            this.doct_name.Name = "doct_name";
            // 
            // req_name
            // 
            this.req_name.DataPropertyName = "req_name";
            this.req_name.HeaderText = "号类";
            this.req_name.Name = "req_name";
            // 
            // winnostr
            // 
            this.winnostr.DataPropertyName = "winnostr";
            this.winnostr.HeaderText = "诊室";
            this.winnostr.Name = "winnostr";
            // 
            // begin_no
            // 
            this.begin_no.DataPropertyName = "begin_no";
            this.begin_no.HeaderText = "起始号";
            this.begin_no.Name = "begin_no";
            // 
            // current_no
            // 
            this.current_no.DataPropertyName = "current_no";
            this.current_no.HeaderText = "当前号";
            this.current_no.Name = "current_no";
            // 
            // toend_no
            // 
            this.toend_no.DataPropertyName = "end_no";
            this.toend_no.HeaderText = "结束号";
            this.toend_no.Name = "toend_no";
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiGroupBox1.Controls.Add(this.txt_workroom);
            this.uiGroupBox1.Controls.Add(this.cbxRequestType);
            this.uiGroupBox1.Controls.Add(this.uiLabel7);
            this.uiGroupBox1.Controls.Add(this.txtDate);
            this.uiGroupBox1.Controls.Add(this.uiLabel1);
            this.uiGroupBox1.Controls.Add(this.txtHaobie);
            this.uiGroupBox1.Controls.Add(this.uiLabel6);
            this.uiGroupBox1.Controls.Add(this.txtDoct);
            this.uiGroupBox1.Controls.Add(this.txtzk);
            this.uiGroupBox1.Controls.Add(this.txtks);
            this.uiGroupBox1.Controls.Add(this.uiLabel10);
            this.uiGroupBox1.Controls.Add(this.uiLabel8);
            this.uiGroupBox1.Controls.Add(this.uiLabel5);
            this.uiGroupBox1.Controls.Add(this.uiLabel4);
            this.uiGroupBox1.Controls.Add(this.cbxOpenFlag);
            this.uiGroupBox1.Controls.Add(this.uiLabel3);
            this.uiGroupBox1.Controls.Add(this.cbxSXW);
            this.uiGroupBox1.Controls.Add(this.uiLabel2);
            this.uiGroupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox1.Location = new System.Drawing.Point(2, 58);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox1.Size = new System.Drawing.Size(1181, 151);
            this.uiGroupBox1.TabIndex = 4;
            this.uiGroupBox1.Text = "查询条件";
            this.uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiGroupBox1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txt_workroom
            // 
            this.txt_workroom.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_workroom.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_workroom.Location = new System.Drawing.Point(467, 105);
            this.txt_workroom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_workroom.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_workroom.Name = "txt_workroom";
            this.txt_workroom.ShowText = false;
            this.txt_workroom.Size = new System.Drawing.Size(200, 29);
            this.txt_workroom.TabIndex = 29;
            this.txt_workroom.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_workroom.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cbxRequestType
            // 
            this.cbxRequestType.DataSource = null;
            this.cbxRequestType.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbxRequestType.FillColor = System.Drawing.Color.White;
            this.cbxRequestType.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxRequestType.Items.AddRange(new object[] {
            "全部",
            "开放",
            "不开放"});
            this.cbxRequestType.Location = new System.Drawing.Point(761, 29);
            this.cbxRequestType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxRequestType.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbxRequestType.Name = "cbxRequestType";
            this.cbxRequestType.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbxRequestType.Size = new System.Drawing.Size(192, 29);
            this.cbxRequestType.TabIndex = 5;
            this.cbxRequestType.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbxRequestType.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel7
            // 
            this.uiLabel7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel7.Location = new System.Drawing.Point(710, 36);
            this.uiLabel7.Name = "uiLabel7";
            this.uiLabel7.Size = new System.Drawing.Size(44, 23);
            this.uiLabel7.TabIndex = 28;
            this.uiLabel7.Text = "号类";
            this.uiLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel7.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtDate
            // 
            this.txtDate.FillColor = System.Drawing.Color.White;
            this.txtDate.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDate.Location = new System.Drawing.Point(112, 30);
            this.txtDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDate.MaxLength = 10;
            this.txtDate.MinimumSize = new System.Drawing.Size(63, 0);
            this.txtDate.Name = "txtDate";
            this.txtDate.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.txtDate.Size = new System.Drawing.Size(239, 29);
            this.txtDate.SymbolDropDown = 61555;
            this.txtDate.SymbolNormal = 61555;
            this.txtDate.TabIndex = 27;
            this.txtDate.Text = "2022-05-24";
            this.txtDate.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtDate.Value = new System.DateTime(2022, 5, 24, 11, 43, 34, 412);
            this.txtDate.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(61, 34);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(44, 23);
            this.uiLabel1.TabIndex = 26;
            this.uiLabel1.Text = "日期";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtHaobie
            // 
            this.txtHaobie.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtHaobie.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtHaobie.Location = new System.Drawing.Point(467, 29);
            this.txtHaobie.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtHaobie.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtHaobie.Name = "txtHaobie";
            this.txtHaobie.ShowText = false;
            this.txtHaobie.Size = new System.Drawing.Size(200, 29);
            this.txtHaobie.TabIndex = 25;
            this.txtHaobie.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtHaobie.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txtHaobie.TextChanged += new System.EventHandler(this.txtHaobie_TextChanged);
            this.txtHaobie.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtHaobie_KeyUp);
            this.txtHaobie.Leave += new System.EventHandler(this.txtHaobie_Leave);
            // 
            // uiLabel6
            // 
            this.uiLabel6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel6.Location = new System.Drawing.Point(413, 108);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(43, 23);
            this.uiLabel6.TabIndex = 24;
            this.uiLabel6.Text = "诊室";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel6.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtDoct
            // 
            this.txtDoct.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDoct.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDoct.Location = new System.Drawing.Point(761, 70);
            this.txtDoct.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDoct.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtDoct.Name = "txtDoct";
            this.txtDoct.ShowText = false;
            this.txtDoct.Size = new System.Drawing.Size(192, 29);
            this.txtDoct.TabIndex = 20;
            this.txtDoct.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtDoct.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txtDoct.TextChanged += new System.EventHandler(this.txtDoct_TextChanged);
            this.txtDoct.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDoct_KeyUp);
            this.txtDoct.Leave += new System.EventHandler(this.txtDoct_Leave);
            // 
            // txtzk
            // 
            this.txtzk.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtzk.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtzk.Location = new System.Drawing.Point(112, 108);
            this.txtzk.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtzk.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtzk.Name = "txtzk";
            this.txtzk.ShowText = false;
            this.txtzk.Size = new System.Drawing.Size(239, 29);
            this.txtzk.TabIndex = 15;
            this.txtzk.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtzk.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txtzk.TextChanged += new System.EventHandler(this.txtzk_TextChanged);
            this.txtzk.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtzk_KeyUp);
            this.txtzk.Leave += new System.EventHandler(this.txtzk_Leave);
            // 
            // txtks
            // 
            this.txtks.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtks.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtks.Location = new System.Drawing.Point(112, 70);
            this.txtks.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtks.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtks.Name = "txtks";
            this.txtks.ShowText = false;
            this.txtks.Size = new System.Drawing.Size(239, 29);
            this.txtks.TabIndex = 14;
            this.txtks.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtks.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txtks.TextChanged += new System.EventHandler(this.txtks_TextChanged);
            this.txtks.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtks_KeyUp);
            this.txtks.Leave += new System.EventHandler(this.txtks_Leave);
            // 
            // uiLabel10
            // 
            this.uiLabel10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel10.Location = new System.Drawing.Point(710, 70);
            this.uiLabel10.Name = "uiLabel10";
            this.uiLabel10.Size = new System.Drawing.Size(93, 23);
            this.uiLabel10.TabIndex = 11;
            this.uiLabel10.Text = "医生";
            this.uiLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel10.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel8
            // 
            this.uiLabel8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel8.Location = new System.Drawing.Point(61, 112);
            this.uiLabel8.Name = "uiLabel8";
            this.uiLabel8.Size = new System.Drawing.Size(46, 23);
            this.uiLabel8.TabIndex = 9;
            this.uiLabel8.Text = "专科";
            this.uiLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel8.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel5.Location = new System.Drawing.Point(414, 34);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(44, 23);
            this.uiLabel5.TabIndex = 6;
            this.uiLabel5.Text = "号别";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel5.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.Location = new System.Drawing.Point(61, 75);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(44, 23);
            this.uiLabel4.TabIndex = 5;
            this.uiLabel4.Text = "科室";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel4.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cbxOpenFlag
            // 
            this.cbxOpenFlag.DataSource = null;
            this.cbxOpenFlag.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbxOpenFlag.FillColor = System.Drawing.Color.White;
            this.cbxOpenFlag.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxOpenFlag.Items.AddRange(new object[] {
            "全部",
            "开放",
            "不开放"});
            this.cbxOpenFlag.Location = new System.Drawing.Point(761, 111);
            this.cbxOpenFlag.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxOpenFlag.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbxOpenFlag.Name = "cbxOpenFlag";
            this.cbxOpenFlag.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbxOpenFlag.Size = new System.Drawing.Size(192, 29);
            this.cbxOpenFlag.TabIndex = 4;
            this.cbxOpenFlag.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbxOpenFlag.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(712, 111);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(42, 23);
            this.uiLabel3.TabIndex = 4;
            this.uiLabel3.Text = "开放";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cbxSXW
            // 
            this.cbxSXW.DataSource = null;
            this.cbxSXW.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbxSXW.FillColor = System.Drawing.Color.White;
            this.cbxSXW.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxSXW.Location = new System.Drawing.Point(467, 67);
            this.cbxSXW.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxSXW.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbxSXW.Name = "cbxSXW";
            this.cbxSXW.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbxSXW.Size = new System.Drawing.Size(200, 29);
            this.cbxSXW.TabIndex = 3;
            this.cbxSXW.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbxSXW.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(399, 67);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(63, 23);
            this.uiLabel2.TabIndex = 2;
            this.uiLabel2.Text = "上下午";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiToolTip1
            // 
            this.uiToolTip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.uiToolTip1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.uiToolTip1.OwnerDraw = true;
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalCount.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotalCount.Location = new System.Drawing.Point(12, 667);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(133, 33);
            this.lblTotalCount.TabIndex = 7;
            this.lblTotalCount.Text = "总计：";
            this.lblTotalCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTotalCount.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // BaseWeiHu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1186, 706);
            this.Controls.Add(this.lblTotalCount);
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.dgvlist);
            this.Controls.Add(this.pnlTitle);
            this.KeyPreview = true;
            this.Name = "BaseWeiHu";
            this.PageIndex = 1305;
            this.StyleCustomMode = true;
            this.Text = "基础号表维护";
            this.Load += new System.EventHandler(this.BaseRequest_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BaseWeiHu_KeyDown);
            this.MouseEnter += new System.EventHandler(this.BaseWeiHu_MouseEnter);
            this.pnlTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvlist)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIPanel pnlTitle;
        private Sunny.UI.UISymbolButton btnSearch;
        private Sunny.UI.UISymbolButton btnReset;
        private Sunny.UI.UISymbolButton btnExit;
        private Sunny.UI.UILabel lblTitle;
        private Sunny.UI.UIDataGridView dgvlist;
        private Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UITextBox txtDoct;
        private Sunny.UI.UITextBox txtzk;
        private Sunny.UI.UITextBox txtks;
        private Sunny.UI.UILabel uiLabel10;
        private Sunny.UI.UILabel uiLabel8;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UIComboBox cbxOpenFlag;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UIComboBox cbxSXW;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UITextBox txtHaobie;
        private Sunny.UI.UISymbolButton btnAdd;
        private Sunny.UI.UIDatePicker txtDate;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UIComboBox cbxRequestType;
        private Sunny.UI.UIToolTip uiToolTip1;
        private Sunny.UI.UILabel lblTotalCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn record_sn;
        private System.Windows.Forms.DataGridViewTextBoxColumn request_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn open_flag_str;
        private System.Windows.Forms.DataGridViewTextBoxColumn apstr;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn group_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn clinic_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn doct_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn req_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn winnostr;
        private System.Windows.Forms.DataGridViewTextBoxColumn begin_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn current_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn toend_no;
        private Sunny.UI.UITextBox txt_workroom;
    }
}