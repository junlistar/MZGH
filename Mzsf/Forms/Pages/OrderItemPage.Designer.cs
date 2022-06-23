namespace Mzsf.Forms.Pages
{
    partial class OrderItemPage
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
            this.dgvOrderDetail = new Sunny.UI.UIDataGridView();
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.txtAmount = new Sunny.UI.UITextBox();
            this.txtCharge = new Sunny.UI.UITextBox();
            this.txtUnit = new Sunny.UI.UITextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new Sunny.UI.UITextBox();
            this.item_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.charge_code_lookup_str = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.charge_code_lookup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exec_SN_lookup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.charge_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.charge_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caoyao_fu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fybl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yongfa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dosage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.freq_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parent_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetail)).BeginInit();
            this.uiPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvOrderDetail
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.dgvOrderDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOrderDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrderDetail.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.dgvOrderDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrderDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOrderDetail.ColumnHeadersHeight = 32;
            this.dgvOrderDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvOrderDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.item_no,
            this.charge_code_lookup_str,
            this.charge_code_lookup,
            this.exec_SN_lookup,
            this.charge_price,
            this.charge_amount,
            this.caoyao_fu,
            this.total_price,
            this.fybl,
            this.yongfa,
            this.comment,
            this.dosage,
            this.freq_code,
            this.parent_no,
            this.code});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOrderDetail.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvOrderDetail.EnableHeadersVisualStyles = false;
            this.dgvOrderDetail.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvOrderDetail.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            this.dgvOrderDetail.Location = new System.Drawing.Point(0, 89);
            this.dgvOrderDetail.Name = "dgvOrderDetail";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrderDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgvOrderDetail.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvOrderDetail.RowTemplate.Height = 23;
            this.dgvOrderDetail.SelectedIndex = -1;
            this.dgvOrderDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrderDetail.Size = new System.Drawing.Size(1234, 446);
            this.dgvOrderDetail.TabIndex = 1;
            this.dgvOrderDetail.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.dgvOrderDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrderDetail_CellClick);
            this.dgvOrderDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrderDetail_CellContentClick);
            this.dgvOrderDetail.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvOrderDetail_RowPostPaint);
            // 
            // uiPanel1
            // 
            this.uiPanel1.Controls.Add(this.txtAmount);
            this.uiPanel1.Controls.Add(this.txtCharge);
            this.uiPanel1.Controls.Add(this.txtUnit);
            this.uiPanel1.Controls.Add(this.label4);
            this.uiPanel1.Controls.Add(this.label3);
            this.uiPanel1.Controls.Add(this.label2);
            this.uiPanel1.Controls.Add(this.label1);
            this.uiPanel1.Controls.Add(this.txtName);
            this.uiPanel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel1.Location = new System.Drawing.Point(0, 3);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Size = new System.Drawing.Size(936, 78);
            this.uiPanel1.TabIndex = 3;
            this.uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiPanel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtAmount
            // 
            this.txtAmount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAmount.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAmount.Location = new System.Drawing.Point(741, 36);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAmount.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ShowText = false;
            this.txtAmount.Size = new System.Drawing.Size(149, 29);
            this.txtAmount.TabIndex = 13;
            this.txtAmount.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtAmount.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            this.txtAmount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyUp);
            // 
            // txtCharge
            // 
            this.txtCharge.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCharge.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCharge.Location = new System.Drawing.Point(574, 36);
            this.txtCharge.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCharge.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtCharge.Name = "txtCharge";
            this.txtCharge.ReadOnly = true;
            this.txtCharge.ShowText = false;
            this.txtCharge.Size = new System.Drawing.Size(149, 29);
            this.txtCharge.TabIndex = 11;
            this.txtCharge.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtCharge.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtUnit
            // 
            this.txtUnit.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUnit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtUnit.Location = new System.Drawing.Point(385, 36);
            this.txtUnit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUnit.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.ReadOnly = true;
            this.txtUnit.ShowText = false;
            this.txtUnit.Size = new System.Drawing.Size(177, 29);
            this.txtUnit.TabIndex = 9;
            this.txtUnit.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtUnit.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(737, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 21);
            this.label4.TabIndex = 12;
            this.label4.Text = "数量";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(570, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 21);
            this.label3.TabIndex = 10;
            this.label3.Text = "价格";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(381, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 8;
            this.label2.Text = "执行科室";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = "名称";
            // 
            // txtName
            // 
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtName.Location = new System.Drawing.Point(16, 36);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtName.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtName.Name = "txtName";
            this.txtName.ShowText = false;
            this.txtName.Size = new System.Drawing.Size(353, 29);
            this.txtName.TabIndex = 6;
            this.txtName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // item_no
            // 
            this.item_no.DataPropertyName = "item_no";
            this.item_no.HeaderText = "序号";
            this.item_no.Name = "item_no";
            // 
            // charge_code_lookup_str
            // 
            this.charge_code_lookup_str.DataPropertyName = "charge_code_lookup_str";
            this.charge_code_lookup_str.HeaderText = "项目名称";
            this.charge_code_lookup_str.Name = "charge_code_lookup_str";
            // 
            // charge_code_lookup
            // 
            this.charge_code_lookup.DataPropertyName = "charge_code_lookup";
            this.charge_code_lookup.HeaderText = "项目名称1";
            this.charge_code_lookup.Name = "charge_code_lookup";
            this.charge_code_lookup.Visible = false;
            // 
            // exec_SN_lookup
            // 
            this.exec_SN_lookup.DataPropertyName = "exec_SN_lookup";
            this.exec_SN_lookup.HeaderText = "执行科室";
            this.exec_SN_lookup.Name = "exec_SN_lookup";
            // 
            // charge_price
            // 
            this.charge_price.DataPropertyName = "charge_price";
            this.charge_price.HeaderText = "价格";
            this.charge_price.Name = "charge_price";
            // 
            // charge_amount
            // 
            this.charge_amount.DataPropertyName = "charge_amount";
            this.charge_amount.HeaderText = "数量";
            this.charge_amount.Name = "charge_amount";
            // 
            // caoyao_fu
            // 
            this.caoyao_fu.DataPropertyName = "caoyao_fu";
            this.caoyao_fu.HeaderText = "付数";
            this.caoyao_fu.Name = "caoyao_fu";
            // 
            // total_price
            // 
            this.total_price.DataPropertyName = "total_price";
            this.total_price.HeaderText = "合计";
            this.total_price.Name = "total_price";
            // 
            // fybl
            // 
            this.fybl.DataPropertyName = "fybl";
            this.fybl.HeaderText = "费用比例";
            this.fybl.Name = "fybl";
            // 
            // yongfa
            // 
            this.yongfa.DataPropertyName = "yongfa";
            this.yongfa.HeaderText = "用法";
            this.yongfa.Name = "yongfa";
            // 
            // comment
            // 
            this.comment.DataPropertyName = "comment";
            this.comment.HeaderText = "嘱托";
            this.comment.Name = "comment";
            // 
            // dosage
            // 
            this.dosage.DataPropertyName = "dosage";
            this.dosage.HeaderText = "单次用量";
            this.dosage.Name = "dosage";
            // 
            // freq_code
            // 
            this.freq_code.DataPropertyName = "freq_code";
            this.freq_code.HeaderText = "执行频率";
            this.freq_code.Name = "freq_code";
            // 
            // parent_no
            // 
            this.parent_no.DataPropertyName = "parent_no";
            this.parent_no.HeaderText = "parent_no";
            this.parent_no.Name = "parent_no";
            this.parent_no.Visible = false;
            // 
            // code
            // 
            this.code.DataPropertyName = "code";
            this.code.HeaderText = "code";
            this.code.Name = "code";
            this.code.Visible = false;
            // 
            // OrderItemPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1235, 594);
            this.Controls.Add(this.uiPanel1);
            this.Controls.Add(this.dgvOrderDetail);
            this.KeyPreview = true;
            this.Name = "OrderItemPage";
            this.Text = "OrderItemPage";
            this.Load += new System.EventHandler(this.OrderItemPage_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OrderItemPage_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetail)).EndInit();
            this.uiPanel1.ResumeLayout(false);
            this.uiPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UIDataGridView dgvOrderDetail;
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UITextBox txtAmount;
        private Sunny.UI.UITextBox txtCharge;
        private Sunny.UI.UITextBox txtUnit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Sunny.UI.UITextBox txtName;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn charge_code_lookup_str;
        private System.Windows.Forms.DataGridViewTextBoxColumn charge_code_lookup;
        private System.Windows.Forms.DataGridViewTextBoxColumn exec_SN_lookup;
        private System.Windows.Forms.DataGridViewTextBoxColumn charge_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn charge_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn caoyao_fu;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn fybl;
        private System.Windows.Forms.DataGridViewTextBoxColumn yongfa;
        private System.Windows.Forms.DataGridViewTextBoxColumn comment;
        private System.Windows.Forms.DataGridViewTextBoxColumn dosage;
        private System.Windows.Forms.DataGridViewTextBoxColumn freq_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn parent_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
    }
}