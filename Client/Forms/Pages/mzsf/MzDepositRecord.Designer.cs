namespace Client.Forms.Pages.mzsf
{
    partial class MzDepositRecord
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_patientid = new Sunny.UI.UITextBox();
            this.btnSearch = new Sunny.UI.UIButton();
            this.dgv_mzdeposit = new Sunny.UI.UIDataGridView();
            this.btnxp = new Sunny.UI.UIButton();
            this.btnfp = new Sunny.UI.UIButton();
            this.pid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledger_sn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.charge_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cash_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cash_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backfee_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_mzdeposit)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "患者ID";
            // 
            // txt_patientid
            // 
            this.txt_patientid.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_patientid.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_patientid.Location = new System.Drawing.Point(123, 54);
            this.txt_patientid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_patientid.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_patientid.Name = "txt_patientid";
            this.txt_patientid.ShowText = false;
            this.txt_patientid.Size = new System.Drawing.Size(198, 29);
            this.txt_patientid.TabIndex = 1;
            this.txt_patientid.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_patientid.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnSearch
            // 
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Location = new System.Drawing.Point(338, 54);
            this.btnSearch.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(83, 28);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "查询";
            this.btnSearch.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgv_mzdeposit
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.dgv_mzdeposit.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_mzdeposit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_mzdeposit.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.dgv_mzdeposit.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_mzdeposit.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgv_mzdeposit.ColumnHeadersHeight = 32;
            this.dgv_mzdeposit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_mzdeposit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pid,
            this.ledger_sn,
            this.charge_total,
            this.cash_name,
            this.cash_date,
            this.backfee_date});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_mzdeposit.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgv_mzdeposit.EnableHeadersVisualStyles = false;
            this.dgv_mzdeposit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgv_mzdeposit.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            this.dgv_mzdeposit.Location = new System.Drawing.Point(15, 91);
            this.dgv_mzdeposit.Name = "dgv_mzdeposit";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_mzdeposit.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgv_mzdeposit.RowHeight = 0;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgv_mzdeposit.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgv_mzdeposit.RowTemplate.Height = 23;
            this.dgv_mzdeposit.SelectedIndex = -1;
            this.dgv_mzdeposit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_mzdeposit.ShowGridLine = false;
            this.dgv_mzdeposit.ShowRect = false;
            this.dgv_mzdeposit.Size = new System.Drawing.Size(705, 286);
            this.dgv_mzdeposit.TabIndex = 3;
            this.dgv_mzdeposit.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnxp
            // 
            this.btnxp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnxp.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnxp.Location = new System.Drawing.Point(548, 50);
            this.btnxp.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnxp.Name = "btnxp";
            this.btnxp.Size = new System.Drawing.Size(83, 28);
            this.btnxp.TabIndex = 4;
            this.btnxp.Text = "小票打印";
            this.btnxp.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnxp.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnxp.Click += new System.EventHandler(this.btnxp_Click);
            // 
            // btnfp
            // 
            this.btnfp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnfp.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnfp.Location = new System.Drawing.Point(637, 50);
            this.btnfp.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnfp.Name = "btnfp";
            this.btnfp.Size = new System.Drawing.Size(83, 28);
            this.btnfp.TabIndex = 5;
            this.btnfp.Text = "发票打印";
            this.btnfp.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnfp.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnfp.Click += new System.EventHandler(this.btnfp_Click);
            // 
            // pid
            // 
            this.pid.DataPropertyName = "patient_id";
            this.pid.HeaderText = "病人Id";
            this.pid.Name = "pid";
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
            this.charge_total.HeaderText = "总金额";
            this.charge_total.Name = "charge_total";
            // 
            // cash_name
            // 
            this.cash_name.DataPropertyName = "cash_name";
            this.cash_name.HeaderText = "操作员";
            this.cash_name.Name = "cash_name";
            // 
            // cash_date
            // 
            this.cash_date.DataPropertyName = "cash_date";
            this.cash_date.HeaderText = "交款日期";
            this.cash_date.Name = "cash_date";
            // 
            // backfee_date
            // 
            this.backfee_date.DataPropertyName = "backfee_date";
            this.backfee_date.HeaderText = "退款日期";
            this.backfee_date.Name = "backfee_date";
            this.backfee_date.Visible = false;
            // 
            // MzDepositRecord
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(732, 391);
            this.Controls.Add(this.btnfp);
            this.Controls.Add(this.btnxp);
            this.Controls.Add(this.dgv_mzdeposit);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txt_patientid);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MzDepositRecord";
            this.Text = "门诊收费记录";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.Load += new System.EventHandler(this.MzDepositRecord_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MzDepositRecord_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_mzdeposit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Sunny.UI.UITextBox txt_patientid;
        private Sunny.UI.UIButton btnSearch;
        private Sunny.UI.UIDataGridView dgv_mzdeposit;
        private Sunny.UI.UIButton btnxp;
        private Sunny.UI.UIButton btnfp;
        private System.Windows.Forms.DataGridViewTextBoxColumn pid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ledger_sn;
        private System.Windows.Forms.DataGridViewTextBoxColumn charge_total;
        private System.Windows.Forms.DataGridViewTextBoxColumn cash_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn cash_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn backfee_date;
    }
}