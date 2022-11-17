namespace MainFrame
{
    partial class AddSystem
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
            this.btnRegist = new Sunny.UI.UISymbolButton();
            this.btnSave = new Sunny.UI.UISymbolButton();
            this.btnEdit = new Sunny.UI.UISymbolButton();
            this.btnDelete = new Sunny.UI.UISymbolButton();
            this.btnAdd = new Sunny.UI.UISymbolButton();
            this.btnSearch = new Sunny.UI.UISymbolButton();
            this.btnExit = new Sunny.UI.UISymbolButton();
            this.dgvlist = new Sunny.UI.UIDataGridView();
            this.sys_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sys_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sys_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.file_path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.file_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.open_mode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.icon_path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiPanel2 = new Sunny.UI.UIPanel();
            this.txt_openmode = new Sunny.UI.UIComboBox();
            this.uiLabel8 = new Sunny.UI.UILabel();
            this.txt_iconpath = new Sunny.UI.UITextBox();
            this.uiLabel7 = new Sunny.UI.UILabel();
            this.txt_sysno = new Sunny.UI.UITextBox();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.txt_filetype = new Sunny.UI.UIComboBox();
            this.txt_sysdesc = new Sunny.UI.UITextBox();
            this.txt_filepath = new Sunny.UI.UITextBox();
            this.txt_sysname = new Sunny.UI.UITextBox();
            this.txt_syscode = new Sunny.UI.UITextBox();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.uiLabel9 = new Sunny.UI.UILabel();
            this.txt_updateurl = new Sunny.UI.UITextBox();
            this.uiLabel10 = new Sunny.UI.UILabel();
            this.txt_relative_path = new Sunny.UI.UITextBox();
            this.uiPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvlist)).BeginInit();
            this.uiPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiPanel1
            // 
            this.uiPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiPanel1.Controls.Add(this.btnRegist);
            this.uiPanel1.Controls.Add(this.btnSave);
            this.uiPanel1.Controls.Add(this.btnEdit);
            this.uiPanel1.Controls.Add(this.btnDelete);
            this.uiPanel1.Controls.Add(this.btnAdd);
            this.uiPanel1.Controls.Add(this.btnSearch);
            this.uiPanel1.Controls.Add(this.btnExit);
            this.uiPanel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel1.Location = new System.Drawing.Point(4, 39);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Size = new System.Drawing.Size(940, 48);
            this.uiPanel1.TabIndex = 0;
            this.uiPanel1.Text = null;
            this.uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiPanel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnRegist
            // 
            this.btnRegist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegist.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRegist.Location = new System.Drawing.Point(523, 3);
            this.btnRegist.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnRegist.Name = "btnRegist";
            this.btnRegist.Size = new System.Drawing.Size(100, 40);
            this.btnRegist.Symbol = 61573;
            this.btnRegist.TabIndex = 21;
            this.btnRegist.Text = "注册";
            this.btnRegist.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRegist.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnRegist.Click += new System.EventHandler(this.btnRegist_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(419, 3);
            this.btnSave.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 40);
            this.btnSave.Symbol = 61639;
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "保存";
            this.btnSave.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEdit.Location = new System.Drawing.Point(211, 3);
            this.btnEdit.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 40);
            this.btnEdit.Symbol = 61508;
            this.btnEdit.TabIndex = 19;
            this.btnEdit.Text = "编辑";
            this.btnEdit.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEdit.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelete.Location = new System.Drawing.Point(315, 3);
            this.btnDelete.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 40);
            this.btnDelete.Symbol = 61544;
            this.btnDelete.TabIndex = 18;
            this.btnDelete.Text = "删除";
            this.btnDelete.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelete.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.Location = new System.Drawing.Point(107, 3);
            this.btnAdd.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 40);
            this.btnAdd.Symbol = 61543;
            this.btnAdd.TabIndex = 17;
            this.btnAdd.Text = "新增";
            this.btnAdd.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Location = new System.Drawing.Point(3, 3);
            this.btnSearch.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 40);
            this.btnSearch.Symbol = 61442;
            this.btnSearch.TabIndex = 16;
            this.btnSearch.Text = "查询";
            this.btnSearch.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.Location = new System.Drawing.Point(627, 3);
            this.btnExit.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 40);
            this.btnExit.Symbol = 61579;
            this.btnExit.TabIndex = 15;
            this.btnExit.Text = "退出";
            this.btnExit.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dgvlist
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.dgvlist.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvlist.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.dgvlist.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvlist.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvlist.ColumnHeadersHeight = 32;
            this.dgvlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvlist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sys_no,
            this.sys_code,
            this.sys_name,
            this.file_path,
            this.file_type,
            this.open_mode,
            this.icon_path});
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
            this.dgvlist.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            this.dgvlist.Location = new System.Drawing.Point(4, 307);
            this.dgvlist.Name = "dgvlist";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvlist.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgvlist.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvlist.RowTemplate.Height = 23;
            this.dgvlist.ScrollBarRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.dgvlist.SelectedIndex = -1;
            this.dgvlist.Size = new System.Drawing.Size(940, 272);
            this.dgvlist.TabIndex = 1;
            this.dgvlist.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // sys_no
            // 
            this.sys_no.DataPropertyName = "sys_no";
            this.sys_no.HeaderText = "序号";
            this.sys_no.Name = "sys_no";
            // 
            // sys_code
            // 
            this.sys_code.DataPropertyName = "sys_code";
            this.sys_code.HeaderText = "系统标识";
            this.sys_code.Name = "sys_code";
            // 
            // sys_name
            // 
            this.sys_name.DataPropertyName = "sys_name";
            this.sys_name.HeaderText = "系统名称";
            this.sys_name.Name = "sys_name";
            // 
            // file_path
            // 
            this.file_path.DataPropertyName = "file_path";
            this.file_path.HeaderText = "文件路径";
            this.file_path.Name = "file_path";
            // 
            // file_type
            // 
            this.file_type.DataPropertyName = "file_type";
            this.file_type.HeaderText = "文件类型";
            this.file_type.Name = "file_type";
            // 
            // open_mode
            // 
            this.open_mode.DataPropertyName = "open_mode_str";
            this.open_mode.HeaderText = "打开方式";
            this.open_mode.Name = "open_mode";
            // 
            // icon_path
            // 
            this.icon_path.DataPropertyName = "icon_path";
            this.icon_path.HeaderText = "图标路径";
            this.icon_path.Name = "icon_path";
            // 
            // uiPanel2
            // 
            this.uiPanel2.Controls.Add(this.txt_relative_path);
            this.uiPanel2.Controls.Add(this.uiLabel10);
            this.uiPanel2.Controls.Add(this.txt_updateurl);
            this.uiPanel2.Controls.Add(this.uiLabel9);
            this.uiPanel2.Controls.Add(this.txt_openmode);
            this.uiPanel2.Controls.Add(this.uiLabel8);
            this.uiPanel2.Controls.Add(this.txt_iconpath);
            this.uiPanel2.Controls.Add(this.uiLabel7);
            this.uiPanel2.Controls.Add(this.txt_sysno);
            this.uiPanel2.Controls.Add(this.uiLabel6);
            this.uiPanel2.Controls.Add(this.txt_filetype);
            this.uiPanel2.Controls.Add(this.txt_sysdesc);
            this.uiPanel2.Controls.Add(this.txt_filepath);
            this.uiPanel2.Controls.Add(this.txt_sysname);
            this.uiPanel2.Controls.Add(this.txt_syscode);
            this.uiPanel2.Controls.Add(this.uiLabel5);
            this.uiPanel2.Controls.Add(this.uiLabel4);
            this.uiPanel2.Controls.Add(this.uiLabel3);
            this.uiPanel2.Controls.Add(this.uiLabel2);
            this.uiPanel2.Controls.Add(this.uiLabel1);
            this.uiPanel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel2.Location = new System.Drawing.Point(4, 90);
            this.uiPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel2.Name = "uiPanel2";
            this.uiPanel2.Size = new System.Drawing.Size(940, 209);
            this.uiPanel2.TabIndex = 2;
            this.uiPanel2.Text = null;
            this.uiPanel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiPanel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txt_openmode
            // 
            this.txt_openmode.DataSource = null;
            this.txt_openmode.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.txt_openmode.Enabled = false;
            this.txt_openmode.FillColor = System.Drawing.Color.White;
            this.txt_openmode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_openmode.Items.AddRange(new object[] {
            "程序内嵌入",
            "外部打开"});
            this.txt_openmode.Location = new System.Drawing.Point(540, 87);
            this.txt_openmode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_openmode.MinimumSize = new System.Drawing.Size(63, 0);
            this.txt_openmode.Name = "txt_openmode";
            this.txt_openmode.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.txt_openmode.Size = new System.Drawing.Size(150, 29);
            this.txt_openmode.TabIndex = 9;
            this.txt_openmode.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_openmode.Watermark = "";
            this.txt_openmode.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel8
            // 
            this.uiLabel8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel8.Location = new System.Drawing.Point(444, 87);
            this.uiLabel8.Name = "uiLabel8";
            this.uiLabel8.Size = new System.Drawing.Size(75, 23);
            this.uiLabel8.TabIndex = 11;
            this.uiLabel8.Text = "打开方式";
            this.uiLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel8.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txt_iconpath
            // 
            this.txt_iconpath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_iconpath.Enabled = false;
            this.txt_iconpath.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_iconpath.Location = new System.Drawing.Point(540, 126);
            this.txt_iconpath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_iconpath.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_iconpath.Name = "txt_iconpath";
            this.txt_iconpath.ShowText = false;
            this.txt_iconpath.Size = new System.Drawing.Size(368, 29);
            this.txt_iconpath.TabIndex = 7;
            this.txt_iconpath.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_iconpath.Watermark = "";
            this.txt_iconpath.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel7
            // 
            this.uiLabel7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel7.Location = new System.Drawing.Point(443, 129);
            this.uiLabel7.Name = "uiLabel7";
            this.uiLabel7.Size = new System.Drawing.Size(90, 23);
            this.uiLabel7.TabIndex = 10;
            this.uiLabel7.Text = "系统图标";
            this.uiLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel7.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txt_sysno
            // 
            this.txt_sysno.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_sysno.Enabled = false;
            this.txt_sysno.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_sysno.Location = new System.Drawing.Point(540, 9);
            this.txt_sysno.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_sysno.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_sysno.Name = "txt_sysno";
            this.txt_sysno.ShowText = false;
            this.txt_sysno.Size = new System.Drawing.Size(150, 29);
            this.txt_sysno.TabIndex = 6;
            this.txt_sysno.Text = "0";
            this.txt_sysno.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_sysno.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.txt_sysno.Watermark = "";
            this.txt_sysno.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel6
            // 
            this.uiLabel6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel6.Location = new System.Drawing.Point(443, 12);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(90, 23);
            this.uiLabel6.TabIndex = 9;
            this.uiLabel6.Text = "系统序号";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel6.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txt_filetype
            // 
            this.txt_filetype.DataSource = null;
            this.txt_filetype.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.txt_filetype.Enabled = false;
            this.txt_filetype.FillColor = System.Drawing.Color.White;
            this.txt_filetype.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_filetype.Items.AddRange(new object[] {
            "DLL",
            "EXE"});
            this.txt_filetype.Location = new System.Drawing.Point(540, 46);
            this.txt_filetype.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_filetype.MinimumSize = new System.Drawing.Size(63, 0);
            this.txt_filetype.Name = "txt_filetype";
            this.txt_filetype.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.txt_filetype.Size = new System.Drawing.Size(150, 29);
            this.txt_filetype.TabIndex = 8;
            this.txt_filetype.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_filetype.Watermark = "";
            this.txt_filetype.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txt_sysdesc
            // 
            this.txt_sysdesc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_sysdesc.Enabled = false;
            this.txt_sysdesc.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_sysdesc.Location = new System.Drawing.Point(110, 126);
            this.txt_sysdesc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_sysdesc.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_sysdesc.Name = "txt_sysdesc";
            this.txt_sysdesc.ShowText = false;
            this.txt_sysdesc.Size = new System.Drawing.Size(307, 29);
            this.txt_sysdesc.TabIndex = 7;
            this.txt_sysdesc.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_sysdesc.Watermark = "";
            this.txt_sysdesc.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txt_filepath
            // 
            this.txt_filepath.ButtonSymbol = 61717;
            this.txt_filepath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_filepath.Enabled = false;
            this.txt_filepath.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_filepath.Location = new System.Drawing.Point(110, 87);
            this.txt_filepath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_filepath.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_filepath.Name = "txt_filepath";
            this.txt_filepath.ShowButton = true;
            this.txt_filepath.ShowText = false;
            this.txt_filepath.Size = new System.Drawing.Size(307, 29);
            this.txt_filepath.TabIndex = 7;
            this.txt_filepath.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_filepath.Watermark = "";
            this.txt_filepath.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txt_filepath.ButtonClick += new System.EventHandler(this.txtFilePath_ButtonClick);
            // 
            // txt_sysname
            // 
            this.txt_sysname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_sysname.Enabled = false;
            this.txt_sysname.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_sysname.Location = new System.Drawing.Point(110, 48);
            this.txt_sysname.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_sysname.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_sysname.Name = "txt_sysname";
            this.txt_sysname.ShowText = false;
            this.txt_sysname.Size = new System.Drawing.Size(307, 29);
            this.txt_sysname.TabIndex = 6;
            this.txt_sysname.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_sysname.Watermark = "";
            this.txt_sysname.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txt_syscode
            // 
            this.txt_syscode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_syscode.Enabled = false;
            this.txt_syscode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_syscode.Location = new System.Drawing.Point(110, 9);
            this.txt_syscode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_syscode.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_syscode.Name = "txt_syscode";
            this.txt_syscode.ShowText = false;
            this.txt_syscode.Size = new System.Drawing.Size(307, 29);
            this.txt_syscode.TabIndex = 5;
            this.txt_syscode.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_syscode.Watermark = "";
            this.txt_syscode.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel5.Location = new System.Drawing.Point(15, 128);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(100, 23);
            this.uiLabel5.TabIndex = 4;
            this.uiLabel5.Text = "系统描述";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel5.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.Location = new System.Drawing.Point(443, 50);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(90, 23);
            this.uiLabel4.TabIndex = 3;
            this.uiLabel4.Text = "文件类型";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel4.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(15, 91);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(100, 23);
            this.uiLabel3.TabIndex = 2;
            this.uiLabel3.Text = "文件路径";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(15, 52);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(100, 23);
            this.uiLabel2.TabIndex = 1;
            this.uiLabel2.Text = "系统名称";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(15, 13);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(88, 23);
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "系统标识";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // uiLabel9
            // 
            this.uiLabel9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel9.Location = new System.Drawing.Point(15, 169);
            this.uiLabel9.Name = "uiLabel9";
            this.uiLabel9.Size = new System.Drawing.Size(88, 23);
            this.uiLabel9.TabIndex = 12;
            this.uiLabel9.Text = "更新地址";
            this.uiLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel9.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txt_updateurl
            // 
            this.txt_updateurl.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_updateurl.Enabled = false;
            this.txt_updateurl.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_updateurl.Location = new System.Drawing.Point(110, 165);
            this.txt_updateurl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_updateurl.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_updateurl.Name = "txt_updateurl";
            this.txt_updateurl.ShowText = false;
            this.txt_updateurl.Size = new System.Drawing.Size(307, 29);
            this.txt_updateurl.TabIndex = 8;
            this.txt_updateurl.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_updateurl.Watermark = "";
            this.txt_updateurl.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel10
            // 
            this.uiLabel10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel10.Location = new System.Drawing.Point(443, 169);
            this.uiLabel10.Name = "uiLabel10";
            this.uiLabel10.Size = new System.Drawing.Size(97, 23);
            this.uiLabel10.TabIndex = 13;
            this.uiLabel10.Text = "子系统目录";
            this.uiLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel10.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txt_relative_path
            // 
            this.txt_relative_path.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_relative_path.Enabled = false;
            this.txt_relative_path.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_relative_path.Location = new System.Drawing.Point(540, 167);
            this.txt_relative_path.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_relative_path.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_relative_path.Name = "txt_relative_path";
            this.txt_relative_path.ShowText = false;
            this.txt_relative_path.Size = new System.Drawing.Size(368, 29);
            this.txt_relative_path.TabIndex = 8;
            this.txt_relative_path.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_relative_path.Watermark = "";
            this.txt_relative_path.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // AddSystem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(948, 582);
            this.Controls.Add(this.uiPanel2);
            this.Controls.Add(this.dgvlist);
            this.Controls.Add(this.uiPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddSystem";
            this.Text = "子系统模块功能注册";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.Load += new System.EventHandler(this.AddSystem_Load);
            this.uiPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvlist)).EndInit();
            this.uiPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UISymbolButton btnEdit;
        private Sunny.UI.UISymbolButton btnDelete;
        private Sunny.UI.UISymbolButton btnAdd;
        private Sunny.UI.UISymbolButton btnSearch;
        private Sunny.UI.UISymbolButton btnExit;
        private Sunny.UI.UIDataGridView dgvlist;
        private Sunny.UI.UIPanel uiPanel2;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIComboBox txt_filetype;
        private Sunny.UI.UITextBox txt_sysdesc;
        private Sunny.UI.UITextBox txt_filepath;
        private Sunny.UI.UITextBox txt_sysname;
        private Sunny.UI.UITextBox txt_syscode;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Sunny.UI.UIComboBox txt_openmode;
        private Sunny.UI.UILabel uiLabel8;
        private Sunny.UI.UITextBox txt_iconpath;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UITextBox txt_sysno;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UISymbolButton btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn sys_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn sys_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn sys_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn file_path;
        private System.Windows.Forms.DataGridViewTextBoxColumn file_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn open_mode;
        private System.Windows.Forms.DataGridViewTextBoxColumn icon_path;
        private Sunny.UI.UISymbolButton btnRegist;
        private Sunny.UI.UITextBox txt_updateurl;
        private Sunny.UI.UILabel uiLabel9;
        private Sunny.UI.UITextBox txt_relative_path;
        private Sunny.UI.UILabel uiLabel10;
    }
}