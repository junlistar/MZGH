namespace Client.Forms.Pages.mzgh
{
    partial class GhDepositRecord
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnfp = new Sunny.UI.UIButton();
            this.btnxp = new Sunny.UI.UIButton();
            this.btnSearch = new Sunny.UI.UIButton();
            this.txt_patientid = new Sunny.UI.UITextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_mzdeposit = new Sunny.UI.UIDataGridView();
            this.pid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.times = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledger_sn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.charge_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cash_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_mzdeposit)).BeginInit();
            this.SuspendLayout();
            // 
            // btnfp
            // 
            this.btnfp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnfp.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnfp.Location = new System.Drawing.Point(644, 54);
            this.btnfp.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnfp.Name = "btnfp";
            this.btnfp.Size = new System.Drawing.Size(83, 28);
            this.btnfp.Style = Sunny.UI.UIStyle.Custom;
            this.btnfp.TabIndex = 10;
            this.btnfp.Text = "发票打印";
            this.btnfp.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnfp.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnfp.Click += new System.EventHandler(this.btnfp_Click);
            // 
            // btnxp
            // 
            this.btnxp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnxp.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnxp.Location = new System.Drawing.Point(733, 54);
            this.btnxp.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnxp.Name = "btnxp";
            this.btnxp.Size = new System.Drawing.Size(83, 28);
            this.btnxp.Style = Sunny.UI.UIStyle.Custom;
            this.btnxp.TabIndex = 9;
            this.btnxp.Text = "小票打印";
            this.btnxp.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnxp.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnxp.Click += new System.EventHandler(this.btnxp_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Location = new System.Drawing.Point(310, 54);
            this.btnSearch.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(83, 28);
            this.btnSearch.Style = Sunny.UI.UIStyle.Custom;
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "查询";
            this.btnSearch.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txt_patientid
            // 
            this.txt_patientid.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_patientid.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_patientid.Location = new System.Drawing.Point(95, 54);
            this.txt_patientid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_patientid.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_patientid.Name = "txt_patientid";
            this.txt_patientid.ShowText = false;
            this.txt_patientid.Size = new System.Drawing.Size(198, 29);
            this.txt_patientid.Style = Sunny.UI.UIStyle.Custom;
            this.txt_patientid.TabIndex = 7;
            this.txt_patientid.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_patientid.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "患者ID";
            // 
            // dgv_mzdeposit
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.dgv_mzdeposit.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_mzdeposit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_mzdeposit.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.dgv_mzdeposit.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_mzdeposit.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_mzdeposit.ColumnHeadersHeight = 32;
            this.dgv_mzdeposit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_mzdeposit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pid,
            this.times,
            this.ledger_sn,
            this.charge_total,
            this.cash_name,
            this.price_date});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_mzdeposit.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_mzdeposit.EnableHeadersVisualStyles = false;
            this.dgv_mzdeposit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgv_mzdeposit.GridColor = System.Drawing.Color.PowderBlue;
            this.dgv_mzdeposit.Location = new System.Drawing.Point(16, 91);
            this.dgv_mzdeposit.Name = "dgv_mzdeposit";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_mzdeposit.RowHeadersDefaultCellStyle = dataGridViewCellStyle5; 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgv_mzdeposit.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_mzdeposit.RowTemplate.Height = 23;
            this.dgv_mzdeposit.SelectedIndex = -1;
            this.dgv_mzdeposit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect; 
            this.dgv_mzdeposit.Size = new System.Drawing.Size(800, 286);
            this.dgv_mzdeposit.Style = Sunny.UI.UIStyle.Custom;
            this.dgv_mzdeposit.StyleCustomMode = true;
            this.dgv_mzdeposit.TabIndex = 11;
            this.dgv_mzdeposit.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // pid
            // 
            this.pid.DataPropertyName = "patient_id";
            this.pid.HeaderText = "病人Id";
            this.pid.Name = "pid";
            // 
            // times
            // 
            this.times.DataPropertyName = "times";
            this.times.HeaderText = "账页次数";
            this.times.Name = "times";
            // 
            // ledger_sn
            // 
            this.ledger_sn.DataPropertyName = "ledger_sn";
            this.ledger_sn.HeaderText = "交款次数";
            this.ledger_sn.Name = "ledger_sn";
            // 
            // charge_total
            // 
            this.charge_total.DataPropertyName = "charge_total";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.charge_total.DefaultCellStyle = dataGridViewCellStyle3;
            this.charge_total.HeaderText = "总金额";
            this.charge_total.Name = "charge_total";
            // 
            // cash_name
            // 
            this.cash_name.DataPropertyName = "cash_name";
            this.cash_name.HeaderText = "操作员";
            this.cash_name.Name = "cash_name";
            // 
            // price_date
            // 
            this.price_date.DataPropertyName = "cash_date";
            this.price_date.HeaderText = "交款日期";
            this.price_date.Name = "price_date";
            // 
            // GhDepositRecord
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(832, 391);
            this.Controls.Add(this.dgv_mzdeposit);
            this.Controls.Add(this.btnfp);
            this.Controls.Add(this.btnxp);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txt_patientid);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GhDepositRecord";
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "挂号收费记录";
            this.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(95)))), ((int)(((byte)(145)))));
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.Load += new System.EventHandler(this.GhDepositRecord_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GhDepositRecord_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_mzdeposit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunny.UI.UIButton btnfp;
        private Sunny.UI.UIButton btnxp;
        private Sunny.UI.UIButton btnSearch;
        private Sunny.UI.UITextBox txt_patientid;
        private System.Windows.Forms.Label label1;
        private Sunny.UI.UIDataGridView dgv_mzdeposit;
        private System.Windows.Forms.DataGridViewTextBoxColumn pid;
        private System.Windows.Forms.DataGridViewTextBoxColumn times;
        private System.Windows.Forms.DataGridViewTextBoxColumn ledger_sn;
        private System.Windows.Forms.DataGridViewTextBoxColumn charge_total;
        private System.Windows.Forms.DataGridViewTextBoxColumn cash_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn price_date;
    }
}