namespace Client
{
    partial class LsHbwh
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
            this.btnDelete = new Sunny.UI.UISymbolButton();
            this.btnAdd = new Sunny.UI.UISymbolButton();
            this.btnEdit = new Sunny.UI.UISymbolButton();
            this.btnSearch = new Sunny.UI.UISymbolButton();
            this.btnReset = new Sunny.UI.UISymbolButton();
            this.btnExit = new Sunny.UI.UISymbolButton();
            this.lblTitle = new Sunny.UI.UILabel();
            this.cbxRequestType = new Sunny.UI.UIComboBox();
            this.uiLabel7 = new Sunny.UI.UILabel();
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.btnWeek2 = new Sunny.UI.UISymbolButton();
            this.btnWeek1 = new Sunny.UI.UISymbolButton();
            this.txtDate2 = new Sunny.UI.UIDatePicker();
            this.uiLabel9 = new Sunny.UI.UILabel();
            this.txtDate = new Sunny.UI.UIDatePicker();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.txtHaobie = new Sunny.UI.UITextBox();
            this.cbxWinNo = new Sunny.UI.UIComboBox();
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
            this.dgvlist = new Client.ClassLib.RowMergeView();
            this.pnlTitle.SuspendLayout();
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvlist)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTitle.Controls.Add(this.btnDelete);
            this.pnlTitle.Controls.Add(this.btnAdd);
            this.pnlTitle.Controls.Add(this.btnEdit);
            this.pnlTitle.Controls.Add(this.btnSearch);
            this.pnlTitle.Controls.Add(this.btnReset);
            this.pnlTitle.Controls.Add(this.btnExit);
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlTitle.Location = new System.Drawing.Point(2, 5);
            this.pnlTitle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlTitle.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(1228, 45);
            this.pnlTitle.TabIndex = 2;
            this.pnlTitle.Text = null;
            this.pnlTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlTitle.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnDelete
            // 
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelete.Location = new System.Drawing.Point(675, 2);
            this.btnDelete.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 40);
            this.btnDelete.StyleCustomMode = true;
            this.btnDelete.Symbol = 61544;
            this.btnDelete.TabIndex = 33;
            this.btnDelete.Text = "删除";
            this.btnDelete.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelete.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click_1);
            // 
            // btnAdd
            // 
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.Location = new System.Drawing.Point(463, 2);
            this.btnAdd.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 40);
            this.btnAdd.StyleCustomMode = true;
            this.btnAdd.Symbol = 61543;
            this.btnAdd.TabIndex = 32;
            this.btnAdd.Text = "新增";
            this.btnAdd.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEdit.Location = new System.Drawing.Point(569, 2);
            this.btnEdit.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 40);
            this.btnEdit.StyleCustomMode = true;
            this.btnEdit.Symbol = 61508;
            this.btnEdit.TabIndex = 12;
            this.btnEdit.Text = "编辑";
            this.btnEdit.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEdit.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Location = new System.Drawing.Point(251, 2);
            this.btnSearch.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 40);
            this.btnSearch.StyleCustomMode = true;
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
            this.btnReset.Location = new System.Drawing.Point(357, 2);
            this.btnReset.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 40);
            this.btnReset.StyleCustomMode = true;
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
            this.btnExit.Location = new System.Drawing.Point(781, 2);
            this.btnExit.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 40);
            this.btnExit.StyleCustomMode = true;
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
            this.lblTitle.Size = new System.Drawing.Size(165, 35);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "临时号表维护";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
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
            this.cbxRequestType.Location = new System.Drawing.Point(1053, 31);
            this.cbxRequestType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxRequestType.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbxRequestType.Name = "cbxRequestType";
            this.cbxRequestType.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbxRequestType.Size = new System.Drawing.Size(148, 29);
            this.cbxRequestType.TabIndex = 5;
            this.cbxRequestType.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbxRequestType.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel7
            // 
            this.uiLabel7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel7.Location = new System.Drawing.Point(1002, 32);
            this.uiLabel7.Name = "uiLabel7";
            this.uiLabel7.Size = new System.Drawing.Size(44, 23);
            this.uiLabel7.TabIndex = 28;
            this.uiLabel7.Text = "号类";
            this.uiLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel7.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiGroupBox1.Controls.Add(this.btnWeek2);
            this.uiGroupBox1.Controls.Add(this.btnWeek1);
            this.uiGroupBox1.Controls.Add(this.cbxRequestType);
            this.uiGroupBox1.Controls.Add(this.uiLabel7);
            this.uiGroupBox1.Controls.Add(this.txtDate2);
            this.uiGroupBox1.Controls.Add(this.uiLabel9);
            this.uiGroupBox1.Controls.Add(this.txtDate);
            this.uiGroupBox1.Controls.Add(this.uiLabel1);
            this.uiGroupBox1.Controls.Add(this.txtHaobie);
            this.uiGroupBox1.Controls.Add(this.cbxWinNo);
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
            this.uiGroupBox1.Location = new System.Drawing.Point(2, 57);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox1.Size = new System.Drawing.Size(1231, 151);
            this.uiGroupBox1.TabIndex = 4;
            this.uiGroupBox1.Text = "查询条件";
            this.uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiGroupBox1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiGroupBox1.Click += new System.EventHandler(this.uiGroupBox1_Click);
            // 
            // btnWeek2
            // 
            this.btnWeek2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWeek2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnWeek2.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnWeek2.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(203)))), ((int)(((byte)(83)))));
            this.btnWeek2.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnWeek2.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnWeek2.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnWeek2.Location = new System.Drawing.Point(241, 93);
            this.btnWeek2.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnWeek2.Name = "btnWeek2";
            this.btnWeek2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnWeek2.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(203)))), ((int)(((byte)(83)))));
            this.btnWeek2.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnWeek2.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnWeek2.Size = new System.Drawing.Size(102, 29);
            this.btnWeek2.Style = Sunny.UI.UIStyle.Green;
            this.btnWeek2.StyleCustomMode = true;
            this.btnWeek2.Symbol = 125;
            this.btnWeek2.TabIndex = 31;
            this.btnWeek2.Text = "下周";
            this.btnWeek2.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnWeek2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnWeek2.Click += new System.EventHandler(this.btnWeek2_Click);
            // 
            // btnWeek1
            // 
            this.btnWeek1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWeek1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnWeek1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnWeek1.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(203)))), ((int)(((byte)(83)))));
            this.btnWeek1.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnWeek1.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnWeek1.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnWeek1.Location = new System.Drawing.Point(241, 50);
            this.btnWeek1.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnWeek1.Name = "btnWeek1";
            this.btnWeek1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnWeek1.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(203)))), ((int)(((byte)(83)))));
            this.btnWeek1.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnWeek1.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnWeek1.Size = new System.Drawing.Size(102, 29);
            this.btnWeek1.Style = Sunny.UI.UIStyle.Green;
            this.btnWeek1.StyleCustomMode = true;
            this.btnWeek1.Symbol = 262068;
            this.btnWeek1.TabIndex = 30;
            this.btnWeek1.Text = "本周";
            this.btnWeek1.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnWeek1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnWeek1.Click += new System.EventHandler(this.btnWeek1_Click);
            // 
            // txtDate2
            // 
            this.txtDate2.FillColor = System.Drawing.Color.White;
            this.txtDate2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDate2.Location = new System.Drawing.Point(94, 93);
            this.txtDate2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDate2.MaxLength = 10;
            this.txtDate2.MinimumSize = new System.Drawing.Size(63, 0);
            this.txtDate2.Name = "txtDate2";
            this.txtDate2.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.txtDate2.Size = new System.Drawing.Size(124, 29);
            this.txtDate2.SymbolDropDown = 61555;
            this.txtDate2.SymbolNormal = 61555;
            this.txtDate2.TabIndex = 29;
            this.txtDate2.Text = "1900-01-01";
            this.txtDate2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtDate2.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.txtDate2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel9
            // 
            this.uiLabel9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel9.Location = new System.Drawing.Point(69, 94);
            this.uiLabel9.Name = "uiLabel9";
            this.uiLabel9.Size = new System.Drawing.Size(32, 23);
            this.uiLabel9.TabIndex = 28;
            this.uiLabel9.Text = "至";
            this.uiLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel9.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtDate
            // 
            this.txtDate.FillColor = System.Drawing.Color.White;
            this.txtDate.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDate.Location = new System.Drawing.Point(94, 50);
            this.txtDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDate.MaxLength = 10;
            this.txtDate.MinimumSize = new System.Drawing.Size(63, 0);
            this.txtDate.Name = "txtDate";
            this.txtDate.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.txtDate.Size = new System.Drawing.Size(124, 29);
            this.txtDate.SymbolDropDown = 61555;
            this.txtDate.SymbolNormal = 61555;
            this.txtDate.TabIndex = 27;
            this.txtDate.Text = "1900-01-01";
            this.txtDate.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtDate.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.txtDate.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(43, 52);
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
            this.txtHaobie.Location = new System.Drawing.Point(774, 30);
            this.txtHaobie.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtHaobie.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtHaobie.Name = "txtHaobie";
            this.txtHaobie.ShowText = false;
            this.txtHaobie.Size = new System.Drawing.Size(197, 29);
            this.txtHaobie.TabIndex = 25;
            this.txtHaobie.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtHaobie.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txtHaobie.TextChanged += new System.EventHandler(this.txtHaobie_TextChanged);
            this.txtHaobie.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtHaobie_KeyUp);
            this.txtHaobie.Leave += new System.EventHandler(this.txtHaobie_Leave);
            // 
            // cbxWinNo
            // 
            this.cbxWinNo.DataSource = null;
            this.cbxWinNo.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbxWinNo.FillColor = System.Drawing.Color.White;
            this.cbxWinNo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxWinNo.Items.AddRange(new object[] {
            "所有窗口"});
            this.cbxWinNo.Location = new System.Drawing.Point(774, 108);
            this.cbxWinNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxWinNo.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbxWinNo.Name = "cbxWinNo";
            this.cbxWinNo.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbxWinNo.Size = new System.Drawing.Size(197, 29);
            this.cbxWinNo.TabIndex = 23;
            this.cbxWinNo.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbxWinNo.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel6
            // 
            this.uiLabel6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel6.Location = new System.Drawing.Point(723, 108);
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
            this.txtDoct.Location = new System.Drawing.Point(462, 108);
            this.txtDoct.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDoct.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtDoct.Name = "txtDoct";
            this.txtDoct.ShowText = false;
            this.txtDoct.Size = new System.Drawing.Size(213, 29);
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
            this.txtzk.Location = new System.Drawing.Point(462, 69);
            this.txtzk.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtzk.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtzk.Name = "txtzk";
            this.txtzk.ShowText = false;
            this.txtzk.Size = new System.Drawing.Size(213, 29);
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
            this.txtks.Location = new System.Drawing.Point(462, 31);
            this.txtks.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtks.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtks.Name = "txtks";
            this.txtks.ShowText = false;
            this.txtks.Size = new System.Drawing.Size(213, 29);
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
            this.uiLabel10.Location = new System.Drawing.Point(411, 108);
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
            this.uiLabel8.Location = new System.Drawing.Point(411, 73);
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
            this.uiLabel5.Location = new System.Drawing.Point(723, 36);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(46, 23);
            this.uiLabel5.TabIndex = 6;
            this.uiLabel5.Text = "号别";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel5.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.Location = new System.Drawing.Point(411, 36);
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
            this.cbxOpenFlag.Location = new System.Drawing.Point(1053, 69);
            this.cbxOpenFlag.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxOpenFlag.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbxOpenFlag.Name = "cbxOpenFlag";
            this.cbxOpenFlag.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbxOpenFlag.Size = new System.Drawing.Size(148, 29);
            this.cbxOpenFlag.TabIndex = 4;
            this.cbxOpenFlag.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbxOpenFlag.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(1004, 69);
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
            this.cbxSXW.Location = new System.Drawing.Point(774, 69);
            this.cbxSXW.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxSXW.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbxSXW.Name = "cbxSXW";
            this.cbxSXW.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbxSXW.Size = new System.Drawing.Size(197, 29);
            this.cbxSXW.TabIndex = 3;
            this.cbxSXW.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbxSXW.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(723, 73);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(49, 23);
            this.uiLabel2.TabIndex = 2;
            this.uiLabel2.Text = "班次";
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
            this.lblTotalCount.Location = new System.Drawing.Point(12, 673);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(133, 23);
            this.lblTotalCount.TabIndex = 7;
            this.lblTotalCount.Text = "总计：";
            this.lblTotalCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTotalCount.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // dgvlist
            // 
            this.dgvlist.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.dgvlist.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvlist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.dgvlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
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
            this.dgvlist.Location = new System.Drawing.Point(5, 217);
            this.dgvlist.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.dgvlist.MergeColumnNames = null;
            this.dgvlist.Name = "dgvlist";
            this.dgvlist.ReadOnly = true;
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
            this.dgvlist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvlist.ShowGridLine = false;
            this.dgvlist.ShowRect = false;
            this.dgvlist.Size = new System.Drawing.Size(1228, 453);
            this.dgvlist.TabIndex = 8;
            this.dgvlist.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.dgvlist.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvlist_CellContentClick);
            // 
            // LsHbwh
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1235, 702);
            this.Controls.Add(this.dgvlist);
            this.Controls.Add(this.lblTotalCount);
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.pnlTitle);
            this.KeyPreview = true;
            this.Name = "LsHbwh";
            this.PageIndex = 1306;
            this.StyleCustomMode = true;
            this.Text = "临时号表维护";
            this.Load += new System.EventHandler(this.BaseRequest_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BaseWeiHu_KeyDown);
            this.MouseEnter += new System.EventHandler(this.BaseWeiHu_MouseEnter);
            this.pnlTitle.ResumeLayout(false);
            this.uiGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvlist)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIPanel pnlTitle;
        private Sunny.UI.UISymbolButton btnSearch;
        private Sunny.UI.UISymbolButton btnReset;
        private Sunny.UI.UISymbolButton btnExit;
        private Sunny.UI.UILabel lblTitle;
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
        private Sunny.UI.UIComboBox cbxWinNo;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UITextBox txtHaobie;
        private Sunny.UI.UISymbolButton btnEdit;
        private Sunny.UI.UIDatePicker txtDate;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UIComboBox cbxRequestType;
        private Sunny.UI.UIToolTip uiToolTip1;
        private Sunny.UI.UILabel lblTotalCount;
        private Sunny.UI.UIDatePicker txtDate2;
        private Sunny.UI.UILabel uiLabel9;
        private Sunny.UI.UISymbolButton btnWeek2;
        private Sunny.UI.UISymbolButton btnWeek1;
        private Sunny.UI.UISymbolButton btnAdd;
        private ClassLib.RowMergeView dgvlist;
        private Sunny.UI.UISymbolButton btnDelete;
    }
}