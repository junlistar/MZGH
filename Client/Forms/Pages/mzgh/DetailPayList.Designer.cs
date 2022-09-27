namespace Client
{
    partial class DetailPayList
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
            this.btnCacel = new Sunny.UI.UIButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvpaylist)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvpaylist
            // 
            this.dgvpaylist.AllowUserToAddRows = false;
            this.dgvpaylist.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.dgvpaylist.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvpaylist.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.dgvpaylist.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvpaylist.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvpaylist.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvpaylist.EnableHeadersVisualStyles = false;
            this.dgvpaylist.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvpaylist.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            this.dgvpaylist.Location = new System.Drawing.Point(3, 50);
            this.dgvpaylist.Name = "dgvpaylist";
            this.dgvpaylist.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvpaylist.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvpaylist.RowHeight = 0;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgvpaylist.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvpaylist.RowTemplate.Height = 23;
            this.dgvpaylist.SelectedIndex = -1;
            this.dgvpaylist.ShowGridLine = true;
            this.dgvpaylist.ShowRect = false;
            this.dgvpaylist.Size = new System.Drawing.Size(794, 262);
            this.dgvpaylist.Style = Sunny.UI.UIStyle.Custom;
            this.dgvpaylist.TabIndex = 0;
            this.dgvpaylist.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.dgvpaylist.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvpaylist_CellContentClick);
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
            this.cheque_no.HeaderText = "订单号";
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
            // btnCacel
            // 
            this.btnCacel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCacel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCacel.Location = new System.Drawing.Point(673, 318);
            this.btnCacel.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnCacel.Name = "btnCacel";
            this.btnCacel.Size = new System.Drawing.Size(100, 35);
            this.btnCacel.Style = Sunny.UI.UIStyle.Custom;
            this.btnCacel.TabIndex = 2;
            this.btnCacel.Text = "返回";
            this.btnCacel.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCacel.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnCacel.Click += new System.EventHandler(this.btnCacel_Click);
            // 
            // DetailPayList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 367);
            this.Controls.Add(this.btnCacel);
            this.Controls.Add(this.dgvpaylist);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DetailPayList";
            this.Style = Sunny.UI.UIStyle.Custom;
            this.StyleCustomMode = true;
            this.Text = "支付详情";
            this.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(95)))), ((int)(((byte)(145)))));
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 367);
            this.Load += new System.EventHandler(this.RefundPayList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DetailPayList_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvpaylist)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIDataGridView dgvpaylist;
        private Sunny.UI.UIButton btnCacel;
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
    }
}