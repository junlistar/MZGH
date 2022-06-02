namespace Client
{
    partial class BaseRequest
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
            this.pnltop = new Sunny.UI.UIPanel();
            this.btnEdit = new Sunny.UI.UISymbolButton();
            this.btnDelete = new Sunny.UI.UISymbolButton();
            this.btnAdd = new Sunny.UI.UISymbolButton();
            this.btnSearch = new Sunny.UI.UISymbolButton();
            this.btnReset = new Sunny.UI.UISymbolButton();
            this.btnExit = new Sunny.UI.UISymbolButton();
            this.lblTitle = new Sunny.UI.UILabel();
            this.dgvlist = new Sunny.UI.UIDataGridView();
            this.request_sn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.group_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doct_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clinic_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weekstr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.daystr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apstr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totle_num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.winnostr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.open_flag_str = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.op_date_str = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.txtHaobie = new Sunny.UI.UITextBox();
            this.cbxWinNo = new Sunny.UI.UIComboBox();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.cbxWeek = new Sunny.UI.UIComboBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.txtDoct = new Sunny.UI.UITextBox();
            this.txtzk = new Sunny.UI.UITextBox();
            this.txtks = new Sunny.UI.UITextBox();
            this.cbxDay = new Sunny.UI.UIComboBox();
            this.uiLabel10 = new Sunny.UI.UILabel();
            this.uiLabel8 = new Sunny.UI.UILabel();
            this.uiLabel7 = new Sunny.UI.UILabel();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.cbxOpenFlag = new Sunny.UI.UIComboBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.cbxSXW = new Sunny.UI.UIComboBox();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiPagination1 = new Sunny.UI.UIPagination();
            this.lblTotalCount = new Sunny.UI.UILabel();
            this.pnltop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvlist)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnltop
            // 
            this.pnltop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnltop.Controls.Add(this.btnEdit);
            this.pnltop.Controls.Add(this.btnDelete);
            this.pnltop.Controls.Add(this.btnAdd);
            this.pnltop.Controls.Add(this.btnSearch);
            this.pnltop.Controls.Add(this.btnReset);
            this.pnltop.Controls.Add(this.btnExit);
            this.pnltop.Controls.Add(this.lblTitle);
            this.pnltop.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.pnltop.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.pnltop.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnltop.Location = new System.Drawing.Point(12, 5);
            this.pnltop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnltop.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnltop.Name = "pnltop";
            this.pnltop.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.pnltop.Size = new System.Drawing.Size(1289, 66);
            this.pnltop.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.pnltop.TabIndex = 2;
            this.pnltop.Text = null;
            this.pnltop.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnEdit
            // 
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnEdit.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnEdit.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.btnEdit.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.btnEdit.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.btnEdit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEdit.Location = new System.Drawing.Point(569, 17);
            this.btnEdit.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnEdit.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.btnEdit.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.btnEdit.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.btnEdit.Size = new System.Drawing.Size(100, 35);
            this.btnEdit.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.btnEdit.Symbol = 61508;
            this.btnEdit.TabIndex = 14;
            this.btnEdit.Text = "编辑(F6)";
            this.btnEdit.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnDelete.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnDelete.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.btnDelete.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.btnDelete.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.btnDelete.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelete.Location = new System.Drawing.Point(675, 17);
            this.btnDelete.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnDelete.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.btnDelete.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.btnDelete.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.btnDelete.Size = new System.Drawing.Size(100, 35);
            this.btnDelete.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.btnDelete.Symbol = 61544;
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "删除(F7)";
            this.btnDelete.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnAdd.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnAdd.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.btnAdd.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.btnAdd.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.btnAdd.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.Location = new System.Drawing.Point(463, 17);
            this.btnAdd.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnAdd.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.btnAdd.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.btnAdd.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.btnAdd.Size = new System.Drawing.Size(100, 35);
            this.btnAdd.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.btnAdd.Symbol = 61543;
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "新增(F5)";
            this.btnAdd.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnSearch.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnSearch.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.btnSearch.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.btnSearch.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Location = new System.Drawing.Point(251, 17);
            this.btnSearch.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnSearch.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.btnSearch.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.btnSearch.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.btnSearch.Size = new System.Drawing.Size(100, 35);
            this.btnSearch.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.btnSearch.Symbol = 61442;
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "查询(F1)";
            this.btnSearch.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnReset
            // 
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnReset.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnReset.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.btnReset.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.btnReset.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.btnReset.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReset.Location = new System.Drawing.Point(357, 17);
            this.btnReset.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnReset.Name = "btnReset";
            this.btnReset.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnReset.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.btnReset.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.btnReset.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.btnReset.Size = new System.Drawing.Size(100, 35);
            this.btnReset.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.btnReset.Symbol = 61473;
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "重新(F2)";
            this.btnReset.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnExit.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnExit.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.btnExit.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.btnExit.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.btnExit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.Location = new System.Drawing.Point(781, 17);
            this.btnExit.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnExit.Name = "btnExit";
            this.btnExit.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnExit.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.btnExit.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.btnExit.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.btnExit.Size = new System.Drawing.Size(107, 35);
            this.btnExit.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.btnExit.Symbol = 61579;
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "退出(F4)";
            this.btnExit.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(45, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(165, 51);
            this.lblTitle.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "基础号表维护";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvlist
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.dgvlist.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvlist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvlist.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.dgvlist.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvlist.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvlist.ColumnHeadersHeight = 32;
            this.dgvlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvlist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.request_sn,
            this.unit_name,
            this.group_name,
            this.doct_name,
            this.clinic_name,
            this.weekstr,
            this.daystr,
            this.apstr,
            this.totle_num,
            this.winnostr,
            this.open_flag_str,
            this.op_date_str});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(234)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvlist.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvlist.EnableHeadersVisualStyles = false;
            this.dgvlist.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvlist.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(164)))), ((int)(((byte)(152)))));
            this.dgvlist.Location = new System.Drawing.Point(12, 240);
            this.dgvlist.Name = "dgvlist";
            this.dgvlist.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvlist.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(234)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgvlist.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvlist.RowTemplate.Height = 23;
            this.dgvlist.SelectedIndex = -1;
            this.dgvlist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvlist.ShowGridLine = true;
            this.dgvlist.Size = new System.Drawing.Size(1290, 356);
            this.dgvlist.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.dgvlist.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.dgvlist.TabIndex = 3;
            // 
            // request_sn
            // 
            this.request_sn.DataPropertyName = "request_sn";
            this.request_sn.HeaderText = "request_sn";
            this.request_sn.Name = "request_sn";
            this.request_sn.Visible = false;
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
            // 
            // doct_name
            // 
            this.doct_name.DataPropertyName = "doct_name";
            this.doct_name.HeaderText = "医生姓名";
            this.doct_name.Name = "doct_name";
            // 
            // clinic_name
            // 
            this.clinic_name.DataPropertyName = "clinic_name";
            this.clinic_name.HeaderText = "号别";
            this.clinic_name.Name = "clinic_name";
            // 
            // weekstr
            // 
            this.weekstr.DataPropertyName = "weekstr";
            this.weekstr.HeaderText = "周";
            this.weekstr.Name = "weekstr";
            // 
            // daystr
            // 
            this.daystr.DataPropertyName = "daystr";
            this.daystr.HeaderText = "天";
            this.daystr.Name = "daystr";
            // 
            // apstr
            // 
            this.apstr.DataPropertyName = "apstr";
            this.apstr.HeaderText = "上下午";
            this.apstr.Name = "apstr";
            // 
            // totle_num
            // 
            this.totle_num.DataPropertyName = "totle_num";
            this.totle_num.HeaderText = "总号数";
            this.totle_num.Name = "totle_num";
            // 
            // winnostr
            // 
            this.winnostr.DataPropertyName = "winnostr";
            this.winnostr.HeaderText = "窗口号";
            this.winnostr.Name = "winnostr";
            // 
            // open_flag_str
            // 
            this.open_flag_str.DataPropertyName = "open_flag_str";
            this.open_flag_str.HeaderText = "开放标志";
            this.open_flag_str.Name = "open_flag_str";
            // 
            // op_date_str
            // 
            this.op_date_str.DataPropertyName = "op_date_str";
            this.op_date_str.HeaderText = "操作时间";
            this.op_date_str.Name = "op_date_str";
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiGroupBox1.Controls.Add(this.txtHaobie);
            this.uiGroupBox1.Controls.Add(this.cbxWinNo);
            this.uiGroupBox1.Controls.Add(this.uiLabel6);
            this.uiGroupBox1.Controls.Add(this.cbxWeek);
            this.uiGroupBox1.Controls.Add(this.uiLabel1);
            this.uiGroupBox1.Controls.Add(this.txtDoct);
            this.uiGroupBox1.Controls.Add(this.txtzk);
            this.uiGroupBox1.Controls.Add(this.txtks);
            this.uiGroupBox1.Controls.Add(this.cbxDay);
            this.uiGroupBox1.Controls.Add(this.uiLabel10);
            this.uiGroupBox1.Controls.Add(this.uiLabel8);
            this.uiGroupBox1.Controls.Add(this.uiLabel7);
            this.uiGroupBox1.Controls.Add(this.uiLabel5);
            this.uiGroupBox1.Controls.Add(this.uiLabel4);
            this.uiGroupBox1.Controls.Add(this.cbxOpenFlag);
            this.uiGroupBox1.Controls.Add(this.uiLabel3);
            this.uiGroupBox1.Controls.Add(this.cbxSXW);
            this.uiGroupBox1.Controls.Add(this.uiLabel2);
            this.uiGroupBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.uiGroupBox1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.uiGroupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox1.Location = new System.Drawing.Point(13, 81);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.uiGroupBox1.Size = new System.Drawing.Size(1288, 151);
            this.uiGroupBox1.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.uiGroupBox1.TabIndex = 4;
            this.uiGroupBox1.Text = "查询条件";
            this.uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtHaobie
            // 
            this.txtHaobie.ButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.txtHaobie.ButtonFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.txtHaobie.ButtonFillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.txtHaobie.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.txtHaobie.ButtonRectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.txtHaobie.ButtonRectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.txtHaobie.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtHaobie.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.txtHaobie.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtHaobie.Location = new System.Drawing.Point(483, 32);
            this.txtHaobie.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtHaobie.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtHaobie.Name = "txtHaobie";
            this.txtHaobie.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.txtHaobie.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.txtHaobie.ShowText = false;
            this.txtHaobie.Size = new System.Drawing.Size(202, 29);
            this.txtHaobie.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.txtHaobie.TabIndex = 25;
            this.txtHaobie.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtHaobie.TextChanged += new System.EventHandler(this.txtHaobie_TextChanged);
            this.txtHaobie.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtHaobie_KeyUp);
            this.txtHaobie.Leave += new System.EventHandler(this.txtHaobie_Leave);
            // 
            // cbxWinNo
            // 
            this.cbxWinNo.DataSource = null;
            this.cbxWinNo.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbxWinNo.FillColor = System.Drawing.Color.White;
            this.cbxWinNo.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.cbxWinNo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxWinNo.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(234)))), ((int)(((byte)(232)))));
            this.cbxWinNo.Items.AddRange(new object[] {
            "所有窗口"});
            this.cbxWinNo.ItemSelectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.cbxWinNo.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.cbxWinNo.Location = new System.Drawing.Point(485, 111);
            this.cbxWinNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxWinNo.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbxWinNo.Name = "cbxWinNo";
            this.cbxWinNo.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbxWinNo.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.cbxWinNo.Size = new System.Drawing.Size(200, 29);
            this.cbxWinNo.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.cbxWinNo.TabIndex = 23;
            this.cbxWinNo.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel6
            // 
            this.uiLabel6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel6.Location = new System.Drawing.Point(417, 111);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(63, 23);
            this.uiLabel6.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.uiLabel6.TabIndex = 24;
            this.uiLabel6.Text = "窗口号";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxWeek
            // 
            this.cbxWeek.DataSource = null;
            this.cbxWeek.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbxWeek.FillColor = System.Drawing.Color.White;
            this.cbxWeek.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.cbxWeek.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxWeek.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(234)))), ((int)(((byte)(232)))));
            this.cbxWeek.Items.AddRange(new object[] {
            "第一周",
            "第二周",
            "第三周",
            "第四周"});
            this.cbxWeek.ItemSelectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.cbxWeek.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.cbxWeek.Location = new System.Drawing.Point(761, 31);
            this.cbxWeek.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxWeek.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbxWeek.Name = "cbxWeek";
            this.cbxWeek.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbxWeek.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.cbxWeek.Size = new System.Drawing.Size(192, 29);
            this.cbxWeek.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.cbxWeek.TabIndex = 5;
            this.cbxWeek.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(724, 74);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(26, 23);
            this.uiLabel1.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.uiLabel1.TabIndex = 22;
            this.uiLabel1.Text = "天";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDoct
            // 
            this.txtDoct.ButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.txtDoct.ButtonFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.txtDoct.ButtonFillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.txtDoct.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.txtDoct.ButtonRectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.txtDoct.ButtonRectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.txtDoct.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDoct.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.txtDoct.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDoct.Location = new System.Drawing.Point(106, 111);
            this.txtDoct.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDoct.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtDoct.Name = "txtDoct";
            this.txtDoct.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.txtDoct.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.txtDoct.ShowText = false;
            this.txtDoct.Size = new System.Drawing.Size(285, 29);
            this.txtDoct.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.txtDoct.TabIndex = 20;
            this.txtDoct.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtDoct.TextChanged += new System.EventHandler(this.txtDoct_TextChanged);
            this.txtDoct.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDoct_KeyUp);
            this.txtDoct.Leave += new System.EventHandler(this.txtDoct_Leave);
            // 
            // txtzk
            // 
            this.txtzk.ButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.txtzk.ButtonFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.txtzk.ButtonFillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.txtzk.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.txtzk.ButtonRectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.txtzk.ButtonRectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.txtzk.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtzk.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.txtzk.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtzk.Location = new System.Drawing.Point(106, 70);
            this.txtzk.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtzk.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtzk.Name = "txtzk";
            this.txtzk.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.txtzk.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.txtzk.ShowText = false;
            this.txtzk.Size = new System.Drawing.Size(285, 29);
            this.txtzk.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.txtzk.TabIndex = 15;
            this.txtzk.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtzk.TextChanged += new System.EventHandler(this.txtzk_TextChanged);
            this.txtzk.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtzk_KeyUp);
            this.txtzk.Leave += new System.EventHandler(this.txtzk_Leave);
            // 
            // txtks
            // 
            this.txtks.ButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.txtks.ButtonFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.txtks.ButtonFillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.txtks.ButtonRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.txtks.ButtonRectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.txtks.ButtonRectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(109)))));
            this.txtks.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtks.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.txtks.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtks.Location = new System.Drawing.Point(106, 32);
            this.txtks.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtks.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtks.Name = "txtks";
            this.txtks.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.txtks.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.txtks.ShowText = false;
            this.txtks.Size = new System.Drawing.Size(285, 29);
            this.txtks.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.txtks.TabIndex = 14;
            this.txtks.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtks.TextChanged += new System.EventHandler(this.txtks_TextChanged);
            this.txtks.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtks_KeyUp);
            this.txtks.Leave += new System.EventHandler(this.txtks_Leave);
            // 
            // cbxDay
            // 
            this.cbxDay.DataSource = null;
            this.cbxDay.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbxDay.FillColor = System.Drawing.Color.White;
            this.cbxDay.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.cbxDay.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxDay.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(234)))), ((int)(((byte)(232)))));
            this.cbxDay.Items.AddRange(new object[] {
            "星期一",
            "星期二",
            "星期三",
            "星期四",
            "星期五",
            "星期六",
            "星期日"});
            this.cbxDay.ItemSelectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.cbxDay.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.cbxDay.Location = new System.Drawing.Point(761, 68);
            this.cbxDay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxDay.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbxDay.Name = "cbxDay";
            this.cbxDay.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbxDay.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.cbxDay.Size = new System.Drawing.Size(192, 29);
            this.cbxDay.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.cbxDay.TabIndex = 4;
            this.cbxDay.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel10
            // 
            this.uiLabel10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel10.Location = new System.Drawing.Point(55, 111);
            this.uiLabel10.Name = "uiLabel10";
            this.uiLabel10.Size = new System.Drawing.Size(93, 23);
            this.uiLabel10.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.uiLabel10.TabIndex = 11;
            this.uiLabel10.Text = "医生";
            this.uiLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel8
            // 
            this.uiLabel8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel8.Location = new System.Drawing.Point(55, 74);
            this.uiLabel8.Name = "uiLabel8";
            this.uiLabel8.Size = new System.Drawing.Size(46, 23);
            this.uiLabel8.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.uiLabel8.TabIndex = 9;
            this.uiLabel8.Text = "专科";
            this.uiLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel7
            // 
            this.uiLabel7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel7.Location = new System.Drawing.Point(724, 33);
            this.uiLabel7.Name = "uiLabel7";
            this.uiLabel7.Size = new System.Drawing.Size(30, 23);
            this.uiLabel7.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.uiLabel7.TabIndex = 8;
            this.uiLabel7.Text = "周";
            this.uiLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel5.Location = new System.Drawing.Point(432, 37);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(44, 23);
            this.uiLabel5.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.uiLabel5.TabIndex = 6;
            this.uiLabel5.Text = "号别";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.Location = new System.Drawing.Point(55, 37);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(44, 23);
            this.uiLabel4.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.uiLabel4.TabIndex = 5;
            this.uiLabel4.Text = "科室";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxOpenFlag
            // 
            this.cbxOpenFlag.DataSource = null;
            this.cbxOpenFlag.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbxOpenFlag.FillColor = System.Drawing.Color.White;
            this.cbxOpenFlag.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.cbxOpenFlag.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxOpenFlag.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(234)))), ((int)(((byte)(232)))));
            this.cbxOpenFlag.Items.AddRange(new object[] {
            "全部",
            "开放",
            "不开放"});
            this.cbxOpenFlag.ItemSelectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.cbxOpenFlag.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.cbxOpenFlag.Location = new System.Drawing.Point(761, 111);
            this.cbxOpenFlag.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxOpenFlag.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbxOpenFlag.Name = "cbxOpenFlag";
            this.cbxOpenFlag.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbxOpenFlag.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.cbxOpenFlag.Size = new System.Drawing.Size(192, 29);
            this.cbxOpenFlag.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.cbxOpenFlag.TabIndex = 4;
            this.cbxOpenFlag.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(712, 111);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(42, 23);
            this.uiLabel3.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.uiLabel3.TabIndex = 4;
            this.uiLabel3.Text = "开放";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxSXW
            // 
            this.cbxSXW.DataSource = null;
            this.cbxSXW.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbxSXW.FillColor = System.Drawing.Color.White;
            this.cbxSXW.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.cbxSXW.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxSXW.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(234)))), ((int)(((byte)(232)))));
            this.cbxSXW.ItemSelectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.cbxSXW.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.cbxSXW.Location = new System.Drawing.Point(485, 70);
            this.cbxSXW.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxSXW.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbxSXW.Name = "cbxSXW";
            this.cbxSXW.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbxSXW.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.cbxSXW.Size = new System.Drawing.Size(200, 29);
            this.cbxSXW.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.cbxSXW.TabIndex = 3;
            this.cbxSXW.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(417, 70);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(63, 23);
            this.uiLabel2.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.uiLabel2.TabIndex = 2;
            this.uiLabel2.Text = "上下午";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiPagination1
            // 
            this.uiPagination1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.uiPagination1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.uiPagination1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.uiPagination1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPagination1.Location = new System.Drawing.Point(125, 598);
            this.uiPagination1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPagination1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPagination1.Name = "uiPagination1";
            this.uiPagination1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.uiPagination1.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiPagination1.ShowText = false;
            this.uiPagination1.Size = new System.Drawing.Size(601, 35);
            this.uiPagination1.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.uiPagination1.TabIndex = 5;
            this.uiPagination1.Text = "uiPagination1";
            this.uiPagination1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiPagination1.PageChanged += new Sunny.UI.UIPagination.OnPageChangeEventHandler(this.uiPagination1_PageChanged);
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalCount.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotalCount.Location = new System.Drawing.Point(9, 599);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(116, 33);
            this.lblTotalCount.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.lblTotalCount.TabIndex = 6;
            this.lblTotalCount.Text = "总计：";
            this.lblTotalCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BaseRequest
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1314, 635);
            this.Controls.Add(this.lblTotalCount);
            this.Controls.Add(this.uiPagination1);
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.dgvlist);
            this.Controls.Add(this.pnltop);
            this.KeyPreview = true;
            this.Name = "BaseRequest";
            this.PageIndex = 1003;
            this.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.Text = "基础号表维护";
            this.Load += new System.EventHandler(this.BaseRequest_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BaseRequest_KeyDown);
            this.MouseEnter += new System.EventHandler(this.BaseRequest_MouseEnter);
            this.pnltop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvlist)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIPanel pnltop;
        private Sunny.UI.UISymbolButton btnSearch;
        private Sunny.UI.UISymbolButton btnReset;
        private Sunny.UI.UISymbolButton btnExit;
        private Sunny.UI.UILabel lblTitle;
        private Sunny.UI.UIDataGridView dgvlist;
        private Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UITextBox txtDoct;
        private Sunny.UI.UITextBox txtzk;
        private Sunny.UI.UITextBox txtks;
        private Sunny.UI.UIComboBox cbxDay;
        private Sunny.UI.UILabel uiLabel10;
        private Sunny.UI.UILabel uiLabel8;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UIComboBox cbxOpenFlag;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UIComboBox cbxSXW;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UIComboBox cbxWinNo;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UIComboBox cbxWeek;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITextBox txtHaobie;
        private Sunny.UI.UISymbolButton btnDelete;
        private Sunny.UI.UISymbolButton btnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn request_sn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn group_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn doct_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn clinic_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn weekstr;
        private System.Windows.Forms.DataGridViewTextBoxColumn daystr;
        private System.Windows.Forms.DataGridViewTextBoxColumn apstr;
        private System.Windows.Forms.DataGridViewTextBoxColumn totle_num;
        private System.Windows.Forms.DataGridViewTextBoxColumn winnostr;
        private System.Windows.Forms.DataGridViewTextBoxColumn open_flag_str;
        private System.Windows.Forms.DataGridViewTextBoxColumn op_date_str;
        private Sunny.UI.UIPagination uiPagination1;
        private Sunny.UI.UILabel lblTotalCount;
        private Sunny.UI.UISymbolButton btnEdit;
    }
}