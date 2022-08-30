namespace Client
{
    partial class RefundPayList
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
            this.dgvpaylist = new Sunny.UI.UIDataGridView();
            this.patient_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledger_sn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.times = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.charge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cheque_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cheque_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cheque_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receipt_sn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receipt_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price_opera = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.btnCancel = new Sunny.UI.UISymbolButton();
            this.btnSave = new Sunny.UI.UISymbolButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvpaylist)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvpaylist
            // 
            this.dgvpaylist.AllowUserToAddRows = false;
            this.dgvpaylist.AllowUserToDeleteRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.dgvpaylist.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvpaylist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvpaylist.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.dgvpaylist.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvpaylist.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvpaylist.ColumnHeadersHeight = 32;
            this.dgvpaylist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvpaylist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.patient_id,
            this.item_no,
            this.ledger_sn,
            this.times,
            this.charge,
            this.cheque_type,
            this.cheque_name,
            this.cheque_no,
            this.receipt_sn,
            this.receipt_no,
            this.price_opera,
            this.price_date});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvpaylist.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvpaylist.EnableHeadersVisualStyles = false;
            this.dgvpaylist.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvpaylist.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            this.dgvpaylist.Location = new System.Drawing.Point(3, 114);
            this.dgvpaylist.MultiSelect = false;
            this.dgvpaylist.Name = "dgvpaylist";
            this.dgvpaylist.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvpaylist.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvpaylist.RowHeight = 0;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgvpaylist.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvpaylist.RowTemplate.Height = 23;
            this.dgvpaylist.SelectedIndex = -1;
            this.dgvpaylist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvpaylist.ShowGridLine = true;
            this.dgvpaylist.ShowRect = false;
            this.dgvpaylist.Size = new System.Drawing.Size(653, 262);
            this.dgvpaylist.TabIndex = 0;
            this.dgvpaylist.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // patient_id
            // 
            this.patient_id.DataPropertyName = "patient_id";
            this.patient_id.HeaderText = "patient_id";
            this.patient_id.Name = "patient_id";
            this.patient_id.ReadOnly = true;
            this.patient_id.Visible = false;
            // 
            // item_no
            // 
            this.item_no.DataPropertyName = "item_no";
            this.item_no.HeaderText = "序号";
            this.item_no.Name = "item_no";
            this.item_no.ReadOnly = true;
            // 
            // ledger_sn
            // 
            this.ledger_sn.DataPropertyName = "ledger_sn";
            this.ledger_sn.HeaderText = "ledger_sn";
            this.ledger_sn.Name = "ledger_sn";
            this.ledger_sn.ReadOnly = true;
            this.ledger_sn.Visible = false;
            // 
            // times
            // 
            this.times.DataPropertyName = "times";
            this.times.HeaderText = "times";
            this.times.Name = "times";
            this.times.ReadOnly = true;
            this.times.Visible = false;
            // 
            // charge
            // 
            this.charge.DataPropertyName = "charge";
            this.charge.HeaderText = "金额";
            this.charge.Name = "charge";
            this.charge.ReadOnly = true;
            // 
            // cheque_type
            // 
            this.cheque_type.DataPropertyName = "cheque_type";
            this.cheque_type.HeaderText = "支付类型";
            this.cheque_type.Name = "cheque_type";
            this.cheque_type.ReadOnly = true;
            this.cheque_type.Visible = false;
            // 
            // cheque_name
            // 
            this.cheque_name.DataPropertyName = "cheque_name";
            this.cheque_name.HeaderText = "支付类型";
            this.cheque_name.Name = "cheque_name";
            this.cheque_name.ReadOnly = true;
            // 
            // cheque_no
            // 
            this.cheque_no.DataPropertyName = "cheque_no";
            this.cheque_no.HeaderText = "发票号";
            this.cheque_no.Name = "cheque_no";
            this.cheque_no.ReadOnly = true;
            // 
            // receipt_sn
            // 
            this.receipt_sn.DataPropertyName = "receipt_sn";
            this.receipt_sn.HeaderText = "receipt_sn";
            this.receipt_sn.Name = "receipt_sn";
            this.receipt_sn.ReadOnly = true;
            this.receipt_sn.Visible = false;
            // 
            // receipt_no
            // 
            this.receipt_no.DataPropertyName = "receipt_no";
            this.receipt_no.HeaderText = "receipt_no";
            this.receipt_no.Name = "receipt_no";
            this.receipt_no.ReadOnly = true;
            this.receipt_no.Visible = false;
            // 
            // price_opera
            // 
            this.price_opera.DataPropertyName = "price_opera";
            this.price_opera.HeaderText = "操作人员";
            this.price_opera.Name = "price_opera";
            this.price_opera.ReadOnly = true;
            // 
            // price_date
            // 
            this.price_date.DataPropertyName = "price_date";
            this.price_date.HeaderText = "支付时间";
            this.price_date.Name = "price_date";
            this.price_date.ReadOnly = true;
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(3, 88);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(94, 23);
            this.uiLabel1.TabIndex = 3;
            this.uiLabel1.Text = "支付信息";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(127, 51);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(403, 32);
            this.uiLabel2.TabIndex = 4;
            this.uiLabel2.Text = "是否确认退款？";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(503, 393);
            this.btnCancel.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Radius = 1;
            this.btnCancel.Size = new System.Drawing.Size(104, 34);
            this.btnCancel.StyleCustomMode = true;
            this.btnCancel.Symbol = 61453;
            this.btnCancel.TabIndex = 44;
            this.btnCancel.Text = "取消";
            this.btnCancel.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnCancel.Click += new System.EventHandler(this.btnCacel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(384, 393);
            this.btnSave.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 34);
            this.btnSave.StyleCustomMode = true;
            this.btnSave.TabIndex = 43;
            this.btnSave.Text = "确定";
            this.btnSave.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnSave.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // RefundPayList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(670, 450);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.dgvpaylist);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RefundPayList";
            this.StyleCustomMode = true;
            this.Text = "确认退款（按ESC退出）";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.Load += new System.EventHandler(this.RefundPayList_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.RefundPayList_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dgvpaylist)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIDataGridView dgvpaylist;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn patient_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn ledger_sn;
        private System.Windows.Forms.DataGridViewTextBoxColumn times;
        private System.Windows.Forms.DataGridViewTextBoxColumn charge;
        private System.Windows.Forms.DataGridViewTextBoxColumn cheque_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn cheque_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn cheque_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn receipt_sn;
        private System.Windows.Forms.DataGridViewTextBoxColumn receipt_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn price_opera;
        private System.Windows.Forms.DataGridViewTextBoxColumn price_date;
        private Sunny.UI.UISymbolButton btnCancel;
        private Sunny.UI.UISymbolButton btnSave;
    }
}