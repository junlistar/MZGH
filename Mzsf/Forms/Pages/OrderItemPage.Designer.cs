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
            this.gbx_xm = new Sunny.UI.UIGroupBox();
            this.txtName = new Sunny.UI.UITextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUnit = new Sunny.UI.UITextBox();
            this.txtCharge = new Sunny.UI.UITextBox();
            this.txtAmount = new Sunny.UI.UITextBox();
            this.dgvOrderDetail = new Sunny.UI.UIDataGridView();
            this.item_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.gbx_jglx = new Sunny.UI.UIGroupBox();
            this.txtJglx = new Sunny.UI.UITextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gbx_xm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetail)).BeginInit();
            this.gbx_jglx.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbx_xm
            // 
            this.gbx_xm.Controls.Add(this.txtAmount);
            this.gbx_xm.Controls.Add(this.txtCharge);
            this.gbx_xm.Controls.Add(this.txtUnit);
            this.gbx_xm.Controls.Add(this.label4);
            this.gbx_xm.Controls.Add(this.label3);
            this.gbx_xm.Controls.Add(this.label2);
            this.gbx_xm.Controls.Add(this.label1);
            this.gbx_xm.Controls.Add(this.txtName);
            this.gbx_xm.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbx_xm.Location = new System.Drawing.Point(0, 14);
            this.gbx_xm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbx_xm.MinimumSize = new System.Drawing.Size(1, 1);
            this.gbx_xm.Name = "gbx_xm";
            this.gbx_xm.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.gbx_xm.Size = new System.Drawing.Size(936, 91);
            this.gbx_xm.TabIndex = 0;
            this.gbx_xm.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.gbx_xm.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtName
            // 
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtName.Location = new System.Drawing.Point(19, 49);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtName.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtName.Name = "txtName";
            this.txtName.ShowText = false;
            this.txtName.Size = new System.Drawing.Size(353, 29);
            this.txtName.TabIndex = 0;
            this.txtName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(384, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "执行科室";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(573, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "价格";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(740, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 21);
            this.label4.TabIndex = 4;
            this.label4.Text = "数量";
            // 
            // txtUnit
            // 
            this.txtUnit.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUnit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtUnit.Location = new System.Drawing.Point(388, 49);
            this.txtUnit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUnit.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.ShowText = false;
            this.txtUnit.Size = new System.Drawing.Size(177, 29);
            this.txtUnit.TabIndex = 3;
            this.txtUnit.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtUnit.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtCharge
            // 
            this.txtCharge.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCharge.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCharge.Location = new System.Drawing.Point(577, 49);
            this.txtCharge.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCharge.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtCharge.Name = "txtCharge";
            this.txtCharge.ShowText = false;
            this.txtCharge.Size = new System.Drawing.Size(149, 29);
            this.txtCharge.TabIndex = 4;
            this.txtCharge.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtCharge.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtAmount
            // 
            this.txtAmount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAmount.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAmount.Location = new System.Drawing.Point(744, 49);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAmount.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ShowText = false;
            this.txtAmount.Size = new System.Drawing.Size(149, 29);
            this.txtAmount.TabIndex = 5;
            this.txtAmount.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtAmount.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
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
            this.freq_code});
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
            this.dgvOrderDetail.Location = new System.Drawing.Point(0, 113);
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
            this.dgvOrderDetail.Size = new System.Drawing.Size(1234, 481);
            this.dgvOrderDetail.TabIndex = 1;
            this.dgvOrderDetail.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.dgvOrderDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrderDetail_CellContentClick);
            // 
            // item_no
            // 
            this.item_no.DataPropertyName = "item_no";
            this.item_no.HeaderText = "序号";
            this.item_no.Name = "item_no";
            // 
            // charge_code_lookup
            // 
            this.charge_code_lookup.DataPropertyName = "charge_code_lookup";
            this.charge_code_lookup.HeaderText = "项目名称";
            this.charge_code_lookup.Name = "charge_code_lookup";
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
            // gbx_jglx
            // 
            this.gbx_jglx.Controls.Add(this.label5);
            this.gbx_jglx.Controls.Add(this.txtJglx);
            this.gbx_jglx.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbx_jglx.Location = new System.Drawing.Point(944, 14);
            this.gbx_jglx.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbx_jglx.MinimumSize = new System.Drawing.Size(1, 1);
            this.gbx_jglx.Name = "gbx_jglx";
            this.gbx_jglx.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.gbx_jglx.Size = new System.Drawing.Size(191, 91);
            this.gbx_jglx.TabIndex = 2;
            this.gbx_jglx.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.gbx_jglx.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtJglx
            // 
            this.txtJglx.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtJglx.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtJglx.Location = new System.Drawing.Point(19, 49);
            this.txtJglx.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtJglx.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtJglx.Name = "txtJglx";
            this.txtJglx.ShowText = false;
            this.txtJglx.Size = new System.Drawing.Size(149, 29);
            this.txtJglx.TabIndex = 6;
            this.txtJglx.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtJglx.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 21);
            this.label5.TabIndex = 6;
            this.label5.Text = "加工类型";
            // 
            // OrderItemPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1235, 594);
            this.Controls.Add(this.gbx_jglx);
            this.Controls.Add(this.dgvOrderDetail);
            this.Controls.Add(this.gbx_xm);
            this.Name = "OrderItemPage";
            this.Text = "OrderItemPage";
            this.Load += new System.EventHandler(this.OrderItemPage_Load);
            this.gbx_xm.ResumeLayout(false);
            this.gbx_xm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetail)).EndInit();
            this.gbx_jglx.ResumeLayout(false);
            this.gbx_jglx.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIGroupBox gbx_xm;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Sunny.UI.UITextBox txtName;
        private Sunny.UI.UITextBox txtAmount;
        private Sunny.UI.UITextBox txtCharge;
        private Sunny.UI.UITextBox txtUnit;
        private Sunny.UI.UIDataGridView dgvOrderDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_no;
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
        private Sunny.UI.UIGroupBox gbx_jglx;
        private System.Windows.Forms.Label label5;
        private Sunny.UI.UITextBox txtJglx;
    }
}