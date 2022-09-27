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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.lblTitle = new Sunny.UI.UILabel();
            this.btnSave = new Sunny.UI.UISymbolButton();
            this.btnExit = new Sunny.UI.UISymbolButton();
            this.btnAdd = new Sunny.UI.UISymbolButton();
            this.btnDel = new Sunny.UI.UISymbolButton();
            this.uiPanel2 = new Sunny.UI.UIPanel();
            this.cbxflag = new Sunny.UI.UIComboBox();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.txtstep = new Sunny.UI.UITextBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.txtend = new Sunny.UI.UITextBox();
            this.txtbegin = new Sunny.UI.UITextBox();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.dgvlist = new Sunny.UI.UIDataGridView();
            this.opera = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.happen_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.start_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.current_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.end_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.step_length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleted_flag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleted_flag_str = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.uiPanel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiPanel1.TabIndex = 0;
            this.uiPanel1.Text = null;
            this.uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiPanel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(15, 7);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(145, 31);
            this.lblTitle.Style = Sunny.UI.UIStyle.Custom;
            this.lblTitle.TabIndex = 14;
            this.lblTitle.Text = "发票号初始";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
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
            this.btnSave.Style = Sunny.UI.UIStyle.Custom;
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
            this.btnExit.Style = Sunny.UI.UIStyle.Custom;
            this.btnExit.Symbol = 61579;
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "退出";
            this.btnExit.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.Location = new System.Drawing.Point(187, 4);
            this.btnAdd.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 40);
            this.btnAdd.Style = Sunny.UI.UIStyle.Custom;
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
            this.btnDel.Style = Sunny.UI.UIStyle.Custom;
            this.btnDel.Symbol = 61544;
            this.btnDel.TabIndex = 10;
            this.btnDel.Text = "删除";
            this.btnDel.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDel.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
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
            this.uiPanel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiPanel2.TabIndex = 1;
            this.uiPanel2.Text = null;
            this.uiPanel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiPanel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
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
            this.cbxflag.Style = Sunny.UI.UIStyle.Custom;
            this.cbxflag.TabIndex = 5;
            this.cbxflag.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbxflag.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.cbxflag.SelectedIndexChanged += new System.EventHandler(this.cbxflag_SelectedIndexChanged);
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.Location = new System.Drawing.Point(541, 17);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(44, 23);
            this.uiLabel4.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel4.TabIndex = 6;
            this.uiLabel4.Text = "状态";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel4.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
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
            this.txtstep.Style = Sunny.UI.UIStyle.Custom;
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
            this.uiLabel3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel3.TabIndex = 4;
            this.uiLabel3.Text = "递增值";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
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
            this.txtend.Style = Sunny.UI.UIStyle.Custom;
            this.txtend.TabIndex = 3;
            this.txtend.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtend.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txtend.Leave += new System.EventHandler(this.txtend_Leave);
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
            this.txtbegin.Style = Sunny.UI.UIStyle.Custom;
            this.txtbegin.TabIndex = 2;
            this.txtbegin.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtbegin.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txtbegin.Leave += new System.EventHandler(this.txtbegin_Leave);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(222, 17);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(64, 23);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 1;
            this.uiLabel2.Text = "结束号";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(20, 17);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(64, 23);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "起始号";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
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
            this.opera,
            this.happen_date,
            this.start_no,
            this.current_no,
            this.end_no,
            this.step_length,
            this.deleted_flag,
            this.deleted_flag_str});
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
            this.dgvlist.Location = new System.Drawing.Point(4, 160);
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
            this.dgvlist.Size = new System.Drawing.Size(741, 168);
            this.dgvlist.Style = Sunny.UI.UIStyle.Custom;
            this.dgvlist.StyleCustomMode = true;
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
            this.deleted_flag.Visible = false;
            // 
            // deleted_flag_str
            // 
            this.deleted_flag_str.DataPropertyName = "deleted_flag_str";
            this.deleted_flag_str.HeaderText = "使用状态";
            this.deleted_flag_str.Name = "deleted_flag_str";
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
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "发票号初始";
            this.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(95)))), ((int)(((byte)(145)))));
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
        private System.Windows.Forms.DataGridViewTextBoxColumn deleted_flag_str;
    }
}