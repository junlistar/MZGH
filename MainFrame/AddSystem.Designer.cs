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
            this.btnSave = new Sunny.UI.UISymbolButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.uiSymbolButton1 = new Sunny.UI.UISymbolButton();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.uiLabel7 = new Sunny.UI.UILabel();
            this.uiLabel8 = new Sunny.UI.UILabel();
            this.uiLabel9 = new Sunny.UI.UILabel();
            this.uiLabel10 = new Sunny.UI.UILabel();
            this.uiLabel11 = new Sunny.UI.UILabel();
            this.uiLabel12 = new Sunny.UI.UILabel();
            this.txt_syscode = new Sunny.UI.UITextBox();
            this.txt_sysname = new Sunny.UI.UITextBox();
            this.txt_filepath = new Sunny.UI.UITextBox();
            this.txt_sysdesc = new Sunny.UI.UITextBox();
            this.txt_filetype = new Sunny.UI.UIComboBox();
            this.txt_sysno = new Sunny.UI.UITextBox();
            this.txt_iconpath = new Sunny.UI.UITextBox();
            this.txt_openmode = new Sunny.UI.UIComboBox();
            this.txt_updateurl = new Sunny.UI.UITextBox();
            this.txt_relative_path = new Sunny.UI.UITextBox();
            this.txt_sysgroup = new Sunny.UI.UIComboBox();
            this.cbx_sysid = new Sunny.UI.UIComboBox();
            this.uiLine1 = new Sunny.UI.UILine();
            this.cbx_groupno = new Sunny.UI.UIComboBox();
            this.uiLabel13 = new Sunny.UI.UILabel();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(715, 386);
            this.btnSave.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 36);
            this.btnSave.Symbol = 61639;
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "保存";
            this.btnSave.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // uiSymbolButton1
            // 
            this.uiSymbolButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uiSymbolButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton1.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton1.Location = new System.Drawing.Point(811, 386);
            this.uiSymbolButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton1.Name = "uiSymbolButton1";
            this.uiSymbolButton1.Size = new System.Drawing.Size(90, 36);
            this.uiSymbolButton1.Symbol = 61453;
            this.uiSymbolButton1.TabIndex = 21;
            this.uiSymbolButton1.Text = "取消";
            this.uiSymbolButton1.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiSymbolButton1.Click += new System.EventHandler(this.uiSymbolButton1_Click);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(27, 65);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(88, 23);
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "系统标识";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(27, 104);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(88, 23);
            this.uiLabel2.TabIndex = 1;
            this.uiLabel2.Text = "系统名称";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(27, 143);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(88, 23);
            this.uiLabel3.TabIndex = 2;
            this.uiLabel3.Text = "文件路径";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.Location = new System.Drawing.Point(455, 102);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(90, 23);
            this.uiLabel4.TabIndex = 3;
            this.uiLabel4.Text = "文件类型";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel4.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel5.Location = new System.Drawing.Point(27, 303);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(88, 23);
            this.uiLabel5.TabIndex = 4;
            this.uiLabel5.Text = "系统描述";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel5.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel6
            // 
            this.uiLabel6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel6.Location = new System.Drawing.Point(709, 65);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(75, 23);
            this.uiLabel6.TabIndex = 9;
            this.uiLabel6.Text = "系统序号";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel6.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel7
            // 
            this.uiLabel7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel7.Location = new System.Drawing.Point(455, 142);
            this.uiLabel7.Name = "uiLabel7";
            this.uiLabel7.Size = new System.Drawing.Size(90, 23);
            this.uiLabel7.TabIndex = 10;
            this.uiLabel7.Text = "系统图标";
            this.uiLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel7.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel8
            // 
            this.uiLabel8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel8.Location = new System.Drawing.Point(709, 100);
            this.uiLabel8.Name = "uiLabel8";
            this.uiLabel8.Size = new System.Drawing.Size(75, 23);
            this.uiLabel8.TabIndex = 11;
            this.uiLabel8.Text = "打开方式";
            this.uiLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel8.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel9
            // 
            this.uiLabel9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel9.Location = new System.Drawing.Point(27, 266);
            this.uiLabel9.Name = "uiLabel9";
            this.uiLabel9.Size = new System.Drawing.Size(88, 23);
            this.uiLabel9.TabIndex = 12;
            this.uiLabel9.Text = "更新地址";
            this.uiLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel9.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel10
            // 
            this.uiLabel10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel10.Location = new System.Drawing.Point(455, 182);
            this.uiLabel10.Name = "uiLabel10";
            this.uiLabel10.Size = new System.Drawing.Size(97, 23);
            this.uiLabel10.TabIndex = 13;
            this.uiLabel10.Text = "子系统目录";
            this.uiLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel10.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel11
            // 
            this.uiLabel11.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel11.Location = new System.Drawing.Point(455, 65);
            this.uiLabel11.Name = "uiLabel11";
            this.uiLabel11.Size = new System.Drawing.Size(90, 23);
            this.uiLabel11.TabIndex = 14;
            this.uiLabel11.Text = "系统分组";
            this.uiLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel11.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel12
            // 
            this.uiLabel12.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel12.Location = new System.Drawing.Point(25, 186);
            this.uiLabel12.Name = "uiLabel12";
            this.uiLabel12.Size = new System.Drawing.Size(90, 23);
            this.uiLabel12.TabIndex = 16;
            this.uiLabel12.Text = "系统ID";
            this.uiLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel12.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txt_syscode
            // 
            this.txt_syscode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_syscode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_syscode.Location = new System.Drawing.Point(122, 61);
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
            // txt_sysname
            // 
            this.txt_sysname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_sysname.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_sysname.Location = new System.Drawing.Point(122, 100);
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
            // txt_filepath
            // 
            this.txt_filepath.ButtonSymbol = 61717;
            this.txt_filepath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_filepath.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_filepath.Location = new System.Drawing.Point(122, 139);
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
            // txt_sysdesc
            // 
            this.txt_sysdesc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_sysdesc.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_sysdesc.Location = new System.Drawing.Point(122, 301);
            this.txt_sysdesc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_sysdesc.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_sysdesc.Name = "txt_sysdesc";
            this.txt_sysdesc.ShowText = false;
            this.txt_sysdesc.Size = new System.Drawing.Size(798, 29);
            this.txt_sysdesc.TabIndex = 7;
            this.txt_sysdesc.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_sysdesc.Watermark = "";
            this.txt_sysdesc.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txt_filetype
            // 
            this.txt_filetype.DataSource = null;
            this.txt_filetype.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.txt_filetype.FillColor = System.Drawing.Color.White;
            this.txt_filetype.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_filetype.Items.AddRange(new object[] {
            "DLL",
            "EXE"});
            this.txt_filetype.Location = new System.Drawing.Point(552, 98);
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
            // txt_sysno
            // 
            this.txt_sysno.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_sysno.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_sysno.Location = new System.Drawing.Point(791, 61);
            this.txt_sysno.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_sysno.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_sysno.Name = "txt_sysno";
            this.txt_sysno.ShowText = false;
            this.txt_sysno.Size = new System.Drawing.Size(129, 29);
            this.txt_sysno.TabIndex = 6;
            this.txt_sysno.Text = "0";
            this.txt_sysno.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_sysno.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.txt_sysno.Watermark = "";
            this.txt_sysno.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txt_iconpath
            // 
            this.txt_iconpath.ButtonSymbol = 61717;
            this.txt_iconpath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_iconpath.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_iconpath.Location = new System.Drawing.Point(552, 139);
            this.txt_iconpath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_iconpath.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_iconpath.Name = "txt_iconpath";
            this.txt_iconpath.ShowButton = true;
            this.txt_iconpath.ShowText = false;
            this.txt_iconpath.Size = new System.Drawing.Size(368, 29);
            this.txt_iconpath.TabIndex = 7;
            this.txt_iconpath.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_iconpath.Watermark = "";
            this.txt_iconpath.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txt_iconpath.ButtonClick += new System.EventHandler(this.txt_iconpath_ButtonClick);
            // 
            // txt_openmode
            // 
            this.txt_openmode.DataSource = null;
            this.txt_openmode.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.txt_openmode.FillColor = System.Drawing.Color.White;
            this.txt_openmode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_openmode.Items.AddRange(new object[] {
            "程序内嵌入",
            "外部打开"});
            this.txt_openmode.Location = new System.Drawing.Point(791, 98);
            this.txt_openmode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_openmode.MinimumSize = new System.Drawing.Size(63, 0);
            this.txt_openmode.Name = "txt_openmode";
            this.txt_openmode.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.txt_openmode.Size = new System.Drawing.Size(129, 29);
            this.txt_openmode.TabIndex = 9;
            this.txt_openmode.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_openmode.Watermark = "";
            this.txt_openmode.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txt_updateurl
            // 
            this.txt_updateurl.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_updateurl.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_updateurl.Location = new System.Drawing.Point(122, 262);
            this.txt_updateurl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_updateurl.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_updateurl.Name = "txt_updateurl";
            this.txt_updateurl.ShowText = false;
            this.txt_updateurl.Size = new System.Drawing.Size(798, 29);
            this.txt_updateurl.TabIndex = 8;
            this.txt_updateurl.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_updateurl.Watermark = "";
            this.txt_updateurl.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txt_relative_path
            // 
            this.txt_relative_path.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_relative_path.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_relative_path.Location = new System.Drawing.Point(552, 179);
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
            // txt_sysgroup
            // 
            this.txt_sysgroup.DataSource = null;
            this.txt_sysgroup.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.txt_sysgroup.FillColor = System.Drawing.Color.White;
            this.txt_sysgroup.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_sysgroup.Items.AddRange(new object[] {
            "门诊业务",
            "住院业务",
            "医技业务",
            "数据查询",
            "系统维护",
            "字典维护"});
            this.txt_sysgroup.Location = new System.Drawing.Point(552, 61);
            this.txt_sysgroup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_sysgroup.MinimumSize = new System.Drawing.Size(63, 0);
            this.txt_sysgroup.Name = "txt_sysgroup";
            this.txt_sysgroup.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.txt_sysgroup.Size = new System.Drawing.Size(150, 29);
            this.txt_sysgroup.TabIndex = 15;
            this.txt_sysgroup.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_sysgroup.Watermark = "";
            this.txt_sysgroup.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cbx_sysid
            // 
            this.cbx_sysid.DataSource = null;
            this.cbx_sysid.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbx_sysid.FillColor = System.Drawing.Color.White;
            this.cbx_sysid.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_sysid.Items.AddRange(new object[] {
            "DLL",
            "EXE"});
            this.cbx_sysid.Location = new System.Drawing.Point(122, 182);
            this.cbx_sysid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbx_sysid.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbx_sysid.Name = "cbx_sysid";
            this.cbx_sysid.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbx_sysid.Size = new System.Drawing.Size(307, 29);
            this.cbx_sysid.TabIndex = 17;
            this.cbx_sysid.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbx_sysid.Watermark = "";
            this.cbx_sysid.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLine1
            // 
            this.uiLine1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiLine1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine1.Location = new System.Drawing.Point(3, 362);
            this.uiLine1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(944, 15);
            this.uiLine1.TabIndex = 22;
            this.uiLine1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cbx_groupno
            // 
            this.cbx_groupno.DataSource = null;
            this.cbx_groupno.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbx_groupno.FillColor = System.Drawing.Color.White;
            this.cbx_groupno.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_groupno.Items.AddRange(new object[] {
            "DLL",
            "EXE"});
            this.cbx_groupno.Location = new System.Drawing.Point(122, 221);
            this.cbx_groupno.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbx_groupno.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbx_groupno.Name = "cbx_groupno";
            this.cbx_groupno.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbx_groupno.Size = new System.Drawing.Size(307, 29);
            this.cbx_groupno.TabIndex = 19;
            this.cbx_groupno.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbx_groupno.Watermark = "";
            this.cbx_groupno.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel13
            // 
            this.uiLabel13.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel13.Location = new System.Drawing.Point(25, 225);
            this.uiLabel13.Name = "uiLabel13";
            this.uiLabel13.Size = new System.Drawing.Size(90, 23);
            this.uiLabel13.TabIndex = 18;
            this.uiLabel13.Text = "药房";
            this.uiLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel13.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // AddSystem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(947, 441);
            this.Controls.Add(this.cbx_groupno);
            this.Controls.Add(this.uiLabel13);
            this.Controls.Add(this.uiLine1);
            this.Controls.Add(this.cbx_sysid);
            this.Controls.Add(this.uiSymbolButton1);
            this.Controls.Add(this.uiLabel12);
            this.Controls.Add(this.txt_sysgroup);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.uiLabel11);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.txt_relative_path);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.uiLabel10);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.txt_updateurl);
            this.Controls.Add(this.uiLabel4);
            this.Controls.Add(this.uiLabel9);
            this.Controls.Add(this.uiLabel5);
            this.Controls.Add(this.txt_openmode);
            this.Controls.Add(this.txt_syscode);
            this.Controls.Add(this.uiLabel8);
            this.Controls.Add(this.txt_sysname);
            this.Controls.Add(this.txt_iconpath);
            this.Controls.Add(this.txt_filepath);
            this.Controls.Add(this.uiLabel7);
            this.Controls.Add(this.txt_sysdesc);
            this.Controls.Add(this.txt_sysno);
            this.Controls.Add(this.txt_filetype);
            this.Controls.Add(this.uiLabel6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddSystem";
            this.Text = "编辑";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.Load += new System.EventHandler(this.AddSystem_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Sunny.UI.UISymbolButton btnSave;
        private Sunny.UI.UISymbolButton uiSymbolButton1;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UILabel uiLabel8;
        private Sunny.UI.UILabel uiLabel9;
        private Sunny.UI.UILabel uiLabel10;
        private Sunny.UI.UILabel uiLabel11;
        private Sunny.UI.UILabel uiLabel12;
        private Sunny.UI.UITextBox txt_syscode;
        private Sunny.UI.UITextBox txt_sysname;
        private Sunny.UI.UITextBox txt_filepath;
        private Sunny.UI.UITextBox txt_sysdesc;
        private Sunny.UI.UIComboBox txt_filetype;
        private Sunny.UI.UITextBox txt_sysno;
        private Sunny.UI.UITextBox txt_iconpath;
        private Sunny.UI.UIComboBox txt_openmode;
        private Sunny.UI.UITextBox txt_updateurl;
        private Sunny.UI.UITextBox txt_relative_path;
        private Sunny.UI.UIComboBox txt_sysgroup;
        private Sunny.UI.UIComboBox cbx_sysid;
        private Sunny.UI.UILine uiLine1;
        private Sunny.UI.UIComboBox cbx_groupno;
        private Sunny.UI.UILabel uiLabel13;
    }
}