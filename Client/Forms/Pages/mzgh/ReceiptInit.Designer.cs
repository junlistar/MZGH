namespace Client.Forms.Pages.mzgh
{
    partial class ReceiptInit
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle46 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle47 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle48 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle49 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle50 = new System.Windows.Forms.DataGridViewCellStyle();
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.btnAdd = new Sunny.UI.UISymbolButton();
            this.btnDel = new Sunny.UI.UISymbolButton();
            this.btnSave = new Sunny.UI.UISymbolButton();
            this.btnExit = new Sunny.UI.UISymbolButton();
            this.lblTitle = new Sunny.UI.UILabel();
            this.uiPanel2 = new Sunny.UI.UIPanel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.txtbegin = new Sunny.UI.UITextBox();
            this.txtend = new Sunny.UI.UITextBox();
            this.txtstep = new Sunny.UI.UITextBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.cbxflag = new Sunny.UI.UIComboBox();
            this.dgvlist = new Sunny.UI.UIDataGridView();
            this.opera = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.happen_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.start_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.current_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.end_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.step_length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleted_flag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiPanel1.SuspendLayout();
            this.uiPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvlist)).BeginInit();
            this.SuspendLayout();
            // 
            // uiPanel1
            // 
            this.uiPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiPanel1.Controls.Add(this.lblTitle);
            this.uiPanel1.Controls.Add(this.btnSave);
            this.uiPanel1.Controls.Add(this.btnExit);
            this.uiPanel1.Controls.Add(this.btnAdd);
            this.uiPanel1.Controls.Add(this.btnDel);
            this.uiPanel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel1.Location = new System.Drawing.Point(4, 39);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Size = new System.Drawing.Size(741, 47);
            this.uiPanel1.TabIndex = 0;
            this.uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiPanel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnAdd
            // 
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.Location = new System.Drawing.Point(187, 4);
            this.btnAdd.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 40);
            this.btnAdd.StyleCustomMode = true;
            this.btnAdd.Symbol = 61543;
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "增加";
            this.btnAdd.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDel.Location = new System.Drawing.Point(293, 4);
            this.btnDel.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(100, 40);
            this.btnDel.StyleCustomMode = true;
            this.btnDel.Symbol = 61544;
            this.btnDel.TabIndex = 10;
            this.btnDel.Text = "删除";
            this.btnDel.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDel.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(399, 4);
            this.btnSave.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 40);
            this.btnSave.StyleCustomMode = true;
            this.btnSave.Symbol = 61487;
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "保存";
            this.btnSave.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.Location = new System.Drawing.Point(505, 4);
            this.btnExit.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 40);
            this.btnExit.StyleCustomMode = true;
            this.btnExit.Symbol = 61579;
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "退出";
            this.btnExit.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(15, 7);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(145, 31);
            this.lblTitle.TabIndex = 14;
            this.lblTitle.Text = "发票号初始";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiPanel2
            // 
            this.uiPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiPanel2.Controls.Add(this.cbxflag);
            this.uiPanel2.Controls.Add(this.uiLabel4);
            this.uiPanel2.Controls.Add(this.txtstep);
            this.uiPanel2.Controls.Add(this.uiLabel3);
            this.uiPanel2.Controls.Add(this.txtend);
            this.uiPanel2.Controls.Add(this.txtbegin);
            this.uiPanel2.Controls.Add(this.uiLabel2);
            this.uiPanel2.Controls.Add(this.uiLabel1);
            this.uiPanel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel2.Location = new System.Drawing.Point(4, 95);
            this.uiPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel2.Name = "uiPanel2";
            this.uiPanel2.Size = new System.Drawing.Size(741, 56);
            this.uiPanel2.TabIndex = 1;
            this.uiPanel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiPanel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(20, 17);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(64, 23);
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "起始号";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(222, 17);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(64, 23);
            this.uiLabel2.TabIndex = 1;
            this.uiLabel2.Text = "结束号";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtbegin
            // 
            this.txtbegin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtbegin.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtbegin.Location = new System.Drawing.Point(88, 14);
            this.txtbegin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtbegin.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtbegin.Name = "txtbegin";
            this.txtbegin.ShowText = false;
            this.txtbegin.Size = new System.Drawing.Size(122, 29);
            this.txtbegin.TabIndex = 2;
            this.txtbegin.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtbegin.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txtbegin.Leave += new System.EventHandler(this.txtbegin_Leave);
            // 
            // txtend
            // 
            this.txtend.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtend.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtend.Location = new System.Drawing.Point(282, 14);
            this.txtend.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtend.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtend.Name = "txtend";
            this.txtend.ShowText = false;
            this.txtend.Size = new System.Drawing.Size(122, 29);
            this.txtend.TabIndex = 3;
            this.txtend.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtend.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txtend.Leave += new System.EventHandler(this.txtend_Leave);
            // 
            // txtstep
            // 
            this.txtstep.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtstep.DoubleValue = 1D;
            this.txtstep.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtstep.IntValue = 1;
            this.txtstep.Location = new System.Drawing.Point(484, 14);
            this.txtstep.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtstep.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtstep.Name = "txtstep";
            this.txtstep.ShowText = false;
            this.txtstep.Size = new System.Drawing.Size(40, 29);
            this.txtstep.TabIndex = 4;
            this.txtstep.Text = "1";
            this.txtstep.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtstep.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.txtstep.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txtstep.Leave += new System.EventHandler(this.txtstep_Leave);
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(413, 17);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(64, 23);
            this.uiLabel3.TabIndex = 4;
            this.uiLabel3.Text = "递增值";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.Location = new System.Drawing.Point(541, 17);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(44, 23);
            this.uiLabel4.TabIndex = 6;
            this.uiLabel4.Text = "状态";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel4.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cbxflag
            // 
            this.cbxflag.DataSource = null;
            this.cbxflag.FillColor = System.Drawing.Color.White;
            this.cbxflag.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxflag.Items.AddRange(new object[] {
            "当前使用",
            "已删除"});
            this.cbxflag.Location = new System.Drawing.Point(583, 14);
            this.cbxflag.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxflag.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbxflag.Name = "cbxflag";
            this.cbxflag.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbxflag.Size = new System.Drawing.Size(150, 29);
            this.cbxflag.TabIndex = 5;
            this.cbxflag.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbxflag.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.cbxflag.SelectedIndexChanged += new System.EventHandler(this.cbxflag_SelectedIndexChanged);
            // 
            // dgvlist
            // 
            dataGridViewCellStyle46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.dgvlist.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle46;
            this.dgvlist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvlist.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.dgvlist.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle47.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle47.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle47.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle47.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle47.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle47.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvlist.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle47;
            this.dgvlist.ColumnHeadersHeight = 32;
            this.dgvlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvlist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.opera,
            this.happen_date,
            this.start_no,
            this.current_no,
            this.end_no,
            this.step_length,
            this.deleted_flag});
            dataGridViewCellStyle48.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle48.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle48.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle48.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle48.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle48.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle48.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvlist.DefaultCellStyle = dataGridViewCellStyle48;
            this.dgvlist.EnableHeadersVisualStyles = false;
            this.dgvlist.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvlist.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            this.dgvlist.Location = new System.Drawing.Point(4, 160);
            this.dgvlist.Name = "dgvlist";
            dataGridViewCellStyle49.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle49.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle49.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle49.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle49.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle49.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvlist.RowHeadersDefaultCellStyle = dataGridViewCellStyle49;
            this.dgvlist.RowHeight = 0;
            dataGridViewCellStyle50.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle50.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle50.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle50.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle50.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgvlist.RowsDefaultCellStyle = dataGridViewCellStyle50;
            this.dgvlist.RowTemplate.Height = 23;
            this.dgvlist.SelectedIndex = -1;
            this.dgvlist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvlist.ShowGridLine = false;
            this.dgvlist.ShowRect = false;
            this.dgvlist.Size = new System.Drawing.Size(741, 168);
            this.dgvlist.TabIndex = 2;
            this.dgvlist.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // opera
            // 
            this.opera.DataPropertyName = "opera";
            this.opera.HeaderText = "操作员";
            this.opera.Name = "opera";
            this.opera.Visible = false;
            // 
            // happen_date
            // 
            this.happen_date.DataPropertyName = "happen_date";
            this.happen_date.HeaderText = "发生时间";
            this.happen_date.Name = "happen_date";
            // 
            // start_no
            // 
            this.start_no.DataPropertyName = "start_no";
            this.start_no.HeaderText = "起始号";
            this.start_no.Name = "start_no";
            // 
            // current_no
            // 
            this.current_no.DataPropertyName = "current_no";
            this.current_no.HeaderText = "当前号";
            this.current_no.Name = "current_no";
            // 
            // end_no
            // 
            this.end_no.DataPropertyName = "end_no";
            this.end_no.HeaderText = "结束号";
            this.end_no.Name = "end_no";
            // 
            // step_length
            // 
            this.step_length.DataPropertyName = "step_length";
            this.step_length.HeaderText = "递增值";
            this.step_length.Name = "step_length";
            // 
            // deleted_flag
            // 
            this.deleted_flag.DataPropertyName = "deleted_flag";
            this.deleted_flag.HeaderText = "状态";
            this.deleted_flag.Name = "deleted_flag";
            // 
            // ReceiptInit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(749, 341);
            this.Controls.Add(this.dgvlist);
            this.Controls.Add(this.uiPanel2);
            this.Controls.Add(this.uiPanel1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReceiptInit";
            this.Text = "发票号初始";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.Load += new System.EventHandler(this.ReceiptInit_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ReceiptInit_KeyUp);
            this.uiPanel1.ResumeLayout(false);
            this.uiPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvlist)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UISymbolButton btnSave;
        private Sunny.UI.UISymbolButton btnExit;
        private Sunny.UI.UISymbolButton btnAdd;
        private Sunny.UI.UISymbolButton btnDel;
        private Sunny.UI.UILabel lblTitle;
        private Sunny.UI.UIPanel uiPanel2;
        private Sunny.UI.UITextBox txtstep;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UITextBox txtend;
        private Sunny.UI.UITextBox txtbegin;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIComboBox cbxflag;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UIDataGridView dgvlist;
        private System.Windows.Forms.DataGridViewTextBoxColumn opera;
        private System.Windows.Forms.DataGridViewTextBoxColumn happen_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn start_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn current_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn end_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn step_length;
        private System.Windows.Forms.DataGridViewTextBoxColumn deleted_flag;
    }
}