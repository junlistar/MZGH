namespace Client.Forms.Pages.hbgl
{
    partial class RequestTime
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
            this.pnlTitle = new Sunny.UI.UIPanel();
            this.btnAdd = new Sunny.UI.UISymbolButton();
            this.btnDel = new Sunny.UI.UISymbolButton();
            this.btnRefresh = new Sunny.UI.UISymbolButton();
            this.btnTuichu = new Sunny.UI.UISymbolButton();
            this.lblTitle = new Sunny.UI.UILabel();
            this.dgvRequestTime = new Sunny.UI.UIDataGridView();
            this.Section_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Section_number_comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ampm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.start_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.end_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.cbx_ampm = new Sunny.UI.UIComboBox();
            this.txt_end_time = new Sunny.UI.UITimePicker();
            this.txt_start_time = new Sunny.UI.UITimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_section = new Sunny.UI.UITextBox();
            this.btnSave = new Sunny.UI.UISymbolButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtComment = new Sunny.UI.UITextBox();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequestTime)).BeginInit();
            this.uiPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTitle.Controls.Add(this.btnAdd);
            this.pnlTitle.Controls.Add(this.btnDel);
            this.pnlTitle.Controls.Add(this.btnRefresh);
            this.pnlTitle.Controls.Add(this.btnTuichu);
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlTitle.Location = new System.Drawing.Point(4, 4);
            this.pnlTitle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlTitle.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(1243, 45);
            this.pnlTitle.TabIndex = 14;
            this.pnlTitle.Text = null;
            this.pnlTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlTitle.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnAdd
            // 
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.Location = new System.Drawing.Point(393, 3);
            this.btnAdd.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 40);
            this.btnAdd.Style = Sunny.UI.UIStyle.DarkBlue;
            this.btnAdd.StyleCustomMode = true;
            this.btnAdd.Symbol = 61543;
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "新增";
            this.btnAdd.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(155)))), ((int)(((byte)(40)))));
            this.btnDel.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(155)))), ((int)(((byte)(40)))));
            this.btnDel.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(175)))), ((int)(((byte)(83)))));
            this.btnDel.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(124)))), ((int)(((byte)(32)))));
            this.btnDel.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(124)))), ((int)(((byte)(32)))));
            this.btnDel.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDel.Location = new System.Drawing.Point(499, 3);
            this.btnDel.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnDel.Name = "btnDel";
            this.btnDel.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(155)))), ((int)(((byte)(40)))));
            this.btnDel.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(175)))), ((int)(((byte)(83)))));
            this.btnDel.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(124)))), ((int)(((byte)(32)))));
            this.btnDel.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(124)))), ((int)(((byte)(32)))));
            this.btnDel.Size = new System.Drawing.Size(100, 40);
            this.btnDel.Style = Sunny.UI.UIStyle.Orange;
            this.btnDel.StyleCustomMode = true;
            this.btnDel.Symbol = 61532;
            this.btnDel.TabIndex = 11;
            this.btnDel.Text = "删除";
            this.btnDel.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDel.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
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
            this.btnRefresh.Location = new System.Drawing.Point(287, 3);
            this.btnRefresh.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnRefresh.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(203)))), ((int)(((byte)(83)))));
            this.btnRefresh.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnRefresh.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnRefresh.Size = new System.Drawing.Size(100, 40);
            this.btnRefresh.Style = Sunny.UI.UIStyle.Green;
            this.btnRefresh.StyleCustomMode = true;
            this.btnRefresh.Symbol = 61473;
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRefresh.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnTuichu
            // 
            this.btnTuichu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTuichu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.btnTuichu.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.btnTuichu.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.btnTuichu.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.btnTuichu.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.btnTuichu.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTuichu.Location = new System.Drawing.Point(605, 3);
            this.btnTuichu.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnTuichu.Name = "btnTuichu";
            this.btnTuichu.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.btnTuichu.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.btnTuichu.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.btnTuichu.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.btnTuichu.Size = new System.Drawing.Size(100, 40);
            this.btnTuichu.Style = Sunny.UI.UIStyle.Colorful;
            this.btnTuichu.StyleCustomMode = true;
            this.btnTuichu.Symbol = 61579;
            this.btnTuichu.TabIndex = 8;
            this.btnTuichu.Text = "退出";
            this.btnTuichu.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTuichu.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnTuichu.Click += new System.EventHandler(this.uiSymbolButton2_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(45, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(134, 35);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "分时段维护";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // dgvRequestTime
            // 
            this.dgvRequestTime.AllowUserToAddRows = false;
            this.dgvRequestTime.AllowUserToDeleteRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.dgvRequestTime.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvRequestTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvRequestTime.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.dgvRequestTime.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRequestTime.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvRequestTime.ColumnHeadersHeight = 32;
            this.dgvRequestTime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRequestTime.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Section_number,
            this.Section_number_comment,
            this.ampm,
            this.start_time,
            this.end_time});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRequestTime.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvRequestTime.EnableHeadersVisualStyles = false;
            this.dgvRequestTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvRequestTime.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            this.dgvRequestTime.Location = new System.Drawing.Point(4, 53);
            this.dgvRequestTime.Name = "dgvRequestTime";
            this.dgvRequestTime.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRequestTime.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvRequestTime.RowHeight = 0;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgvRequestTime.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvRequestTime.RowTemplate.Height = 23;
            this.dgvRequestTime.SelectedIndex = -1;
            this.dgvRequestTime.ShowGridLine = false;
            this.dgvRequestTime.ShowRect = false;
            this.dgvRequestTime.Size = new System.Drawing.Size(647, 541);
            this.dgvRequestTime.TabIndex = 15;
            this.dgvRequestTime.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.dgvRequestTime.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRequestHour_CellClick);
            // 
            // Section_number
            // 
            this.Section_number.DataPropertyName = "Section_number";
            this.Section_number.HeaderText = "序号";
            this.Section_number.Name = "Section_number";
            this.Section_number.ReadOnly = true;
            // 
            // Section_number_comment
            // 
            this.Section_number_comment.DataPropertyName = "Section_number_comment";
            this.Section_number_comment.HeaderText = "描述";
            this.Section_number_comment.Name = "Section_number_comment";
            this.Section_number_comment.ReadOnly = true;
            // 
            // ampm
            // 
            this.ampm.DataPropertyName = "ampm";
            this.ampm.HeaderText = "代码";
            this.ampm.Name = "ampm";
            this.ampm.ReadOnly = true;
            // 
            // start_time
            // 
            this.start_time.DataPropertyName = "start_time";
            this.start_time.HeaderText = "开始时间";
            this.start_time.Name = "start_time";
            this.start_time.ReadOnly = true;
            // 
            // end_time
            // 
            this.end_time.DataPropertyName = "end_time";
            this.end_time.HeaderText = "结束时间";
            this.end_time.Name = "end_time";
            this.end_time.ReadOnly = true;
            // 
            // uiPanel1
            // 
            this.uiPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiPanel1.Controls.Add(this.cbx_ampm);
            this.uiPanel1.Controls.Add(this.txt_end_time);
            this.uiPanel1.Controls.Add(this.txt_start_time);
            this.uiPanel1.Controls.Add(this.label5);
            this.uiPanel1.Controls.Add(this.txt_section);
            this.uiPanel1.Controls.Add(this.btnSave);
            this.uiPanel1.Controls.Add(this.label4);
            this.uiPanel1.Controls.Add(this.label3);
            this.uiPanel1.Controls.Add(this.label2);
            this.uiPanel1.Controls.Add(this.label1);
            this.uiPanel1.Controls.Add(this.txtComment);
            this.uiPanel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel1.Location = new System.Drawing.Point(658, 55);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Size = new System.Drawing.Size(589, 537);
            this.uiPanel1.TabIndex = 16;
            this.uiPanel1.Text = null;
            this.uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiPanel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cbx_ampm
            // 
            this.cbx_ampm.DataSource = null;
            this.cbx_ampm.FillColor = System.Drawing.Color.White;
            this.cbx_ampm.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_ampm.Location = new System.Drawing.Point(230, 135);
            this.cbx_ampm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbx_ampm.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbx_ampm.Name = "cbx_ampm";
            this.cbx_ampm.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbx_ampm.Size = new System.Drawing.Size(215, 39);
            this.cbx_ampm.TabIndex = 1;
            this.cbx_ampm.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbx_ampm.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txt_end_time
            // 
            this.txt_end_time.FillColor = System.Drawing.Color.White;
            this.txt_end_time.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_end_time.Location = new System.Drawing.Point(230, 237);
            this.txt_end_time.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_end_time.MaxLength = 8;
            this.txt_end_time.MinimumSize = new System.Drawing.Size(63, 0);
            this.txt_end_time.Name = "txt_end_time";
            this.txt_end_time.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.txt_end_time.Size = new System.Drawing.Size(215, 40);
            this.txt_end_time.SymbolDropDown = 61555;
            this.txt_end_time.SymbolNormal = 61555;
            this.txt_end_time.TabIndex = 18;
            this.txt_end_time.Text = "10:35:17";
            this.txt_end_time.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_end_time.Value = new System.DateTime(2022, 7, 11, 10, 35, 17, 479);
            this.txt_end_time.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txt_start_time
            // 
            this.txt_start_time.FillColor = System.Drawing.Color.White;
            this.txt_start_time.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_start_time.Location = new System.Drawing.Point(230, 187);
            this.txt_start_time.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_start_time.MaxLength = 8;
            this.txt_start_time.MinimumSize = new System.Drawing.Size(63, 0);
            this.txt_start_time.Name = "txt_start_time";
            this.txt_start_time.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.txt_start_time.Size = new System.Drawing.Size(215, 40);
            this.txt_start_time.SymbolDropDown = 61555;
            this.txt_start_time.SymbolNormal = 61555;
            this.txt_start_time.TabIndex = 17;
            this.txt_start_time.Text = "10:35:17";
            this.txt_start_time.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_start_time.Value = new System.DateTime(2022, 7, 11, 10, 35, 17, 479);
            this.txt_start_time.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(138, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 30);
            this.label5.TabIndex = 16;
            this.label5.Text = "序号：";
            // 
            // txt_section
            // 
            this.txt_section.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_section.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_section.Location = new System.Drawing.Point(230, 85);
            this.txt_section.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_section.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_section.Name = "txt_section";
            this.txt_section.ShowText = false;
            this.txt_section.Size = new System.Drawing.Size(215, 37);
            this.txt_section.TabIndex = 15;
            this.txt_section.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_section.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(230, 379);
            this.btnSave.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(215, 44);
            this.btnSave.Symbol = 61508;
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "保存";
            this.btnSave.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(94, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 30);
            this.label4.TabIndex = 5;
            this.label4.Text = "结束小时：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(94, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 30);
            this.label3.TabIndex = 4;
            this.label3.Text = "开始小时：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(138, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 30);
            this.label2.TabIndex = 3;
            this.label2.Text = "代码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(138, 294);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "描述：";
            // 
            // txtComment
            // 
            this.txtComment.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtComment.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtComment.Location = new System.Drawing.Point(230, 292);
            this.txtComment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtComment.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtComment.Name = "txtComment";
            this.txtComment.ShowText = false;
            this.txtComment.Size = new System.Drawing.Size(215, 39);
            this.txtComment.TabIndex = 1;
            this.txtComment.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtComment.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // RequestTime
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1251, 606);
            this.Controls.Add(this.uiPanel1);
            this.Controls.Add(this.dgvRequestTime);
            this.Controls.Add(this.pnlTitle);
            this.Name = "RequestTime";
            this.PageIndex = 1302;
            this.Text = "RequestHour";
            this.Load += new System.EventHandler(this.RequestHour_Load);
            this.pnlTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequestTime)).EndInit();
            this.uiPanel1.ResumeLayout(false);
            this.uiPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIPanel pnlTitle;
        private Sunny.UI.UISymbolButton btnRefresh;
        private Sunny.UI.UISymbolButton btnTuichu;
        private Sunny.UI.UILabel lblTitle;
        private Sunny.UI.UIDataGridView dgvRequestTime;
        private Sunny.UI.UISymbolButton btnDel;
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UISymbolButton btnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Sunny.UI.UITextBox txtComment;
        private Sunny.UI.UISymbolButton btnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Section_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Section_number_comment;
        private System.Windows.Forms.DataGridViewTextBoxColumn ampm;
        private System.Windows.Forms.DataGridViewTextBoxColumn start_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn end_time;
        private Sunny.UI.UITimePicker txt_end_time;
        private Sunny.UI.UITimePicker txt_start_time;
        private System.Windows.Forms.Label label5;
        private Sunny.UI.UITextBox txt_section;
        private Sunny.UI.UIComboBox cbx_ampm;
    }
}