﻿namespace Mzsf.Forms.Pages
{
    partial class RefundConfirm
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
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.lblTuikuan = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblZongji = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvDeposit = new Sunny.UI.UIDataGridView();
            this.cheque_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.charge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refund_charge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiPanel2 = new Sunny.UI.UIPanel();
            this.btnExit = new Sunny.UI.UIButton();
            this.btnBufenTuikuan = new Sunny.UI.UIButton();
            this.btnTuikuan = new Sunny.UI.UIButton();
            this.label1 = new System.Windows.Forms.Label();
            this.uiPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeposit)).BeginInit();
            this.uiPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiPanel1
            // 
            this.uiPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiPanel1.Controls.Add(this.lblTuikuan);
            this.uiPanel1.Controls.Add(this.label5);
            this.uiPanel1.Controls.Add(this.lblZongji);
            this.uiPanel1.Controls.Add(this.label6);
            this.uiPanel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel1.Location = new System.Drawing.Point(4, 95);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Size = new System.Drawing.Size(745, 63);
            this.uiPanel1.TabIndex = 5;
            this.uiPanel1.Text = null;
            this.uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiPanel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblTuikuan
            // 
            this.lblTuikuan.AutoSize = true;
            this.lblTuikuan.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.lblTuikuan.ForeColor = System.Drawing.Color.Red;
            this.lblTuikuan.Location = new System.Drawing.Point(570, 17);
            this.lblTuikuan.Name = "lblTuikuan";
            this.lblTuikuan.Size = new System.Drawing.Size(70, 35);
            this.lblTuikuan.TabIndex = 7;
            this.lblTuikuan.Text = "0.00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.label5.Location = new System.Drawing.Point(369, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(195, 35);
            this.label5.TabIndex = 6;
            this.label5.Text = "应退金额(￥)：";
            // 
            // lblZongji
            // 
            this.lblZongji.AutoSize = true;
            this.lblZongji.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.lblZongji.ForeColor = System.Drawing.Color.Red;
            this.lblZongji.Location = new System.Drawing.Point(213, 17);
            this.lblZongji.Name = "lblZongji";
            this.lblZongji.Size = new System.Drawing.Size(70, 35);
            this.lblZongji.TabIndex = 5;
            this.lblZongji.Text = "0.00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.label6.Location = new System.Drawing.Point(12, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(195, 35);
            this.label6.TabIndex = 4;
            this.label6.Text = "发票金额(￥)：";
            // 
            // dgvDeposit
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.dgvDeposit.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDeposit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDeposit.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.dgvDeposit.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDeposit.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvDeposit.ColumnHeadersHeight = 32;
            this.dgvDeposit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDeposit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cheque_name,
            this.amount,
            this.charge,
            this.refund_charge});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDeposit.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDeposit.EnableHeadersVisualStyles = false;
            this.dgvDeposit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvDeposit.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            this.dgvDeposit.Location = new System.Drawing.Point(4, 166);
            this.dgvDeposit.Name = "dgvDeposit";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDeposit.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvDeposit.RowHeight = 0;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgvDeposit.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvDeposit.RowTemplate.Height = 23;
            this.dgvDeposit.SelectedIndex = -1;
            this.dgvDeposit.ShowGridLine = false;
            this.dgvDeposit.ShowRect = false;
            this.dgvDeposit.Size = new System.Drawing.Size(745, 288);
            this.dgvDeposit.TabIndex = 6;
            this.dgvDeposit.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cheque_name
            // 
            this.cheque_name.DataPropertyName = "cheque_name";
            this.cheque_name.HeaderText = "付款类型";
            this.cheque_name.Name = "cheque_name";
            // 
            // amount
            // 
            this.amount.DataPropertyName = "amount";
            this.amount.HeaderText = "本次金额";
            this.amount.Name = "amount";
            this.amount.Visible = false;
            // 
            // charge
            // 
            this.charge.DataPropertyName = "charge";
            this.charge.HeaderText = "原收金额";
            this.charge.Name = "charge";
            // 
            // refund_charge
            // 
            this.refund_charge.DataPropertyName = "refund_charge";
            this.refund_charge.HeaderText = "应退金额";
            this.refund_charge.Name = "refund_charge";
            // 
            // uiPanel2
            // 
            this.uiPanel2.Controls.Add(this.btnExit);
            this.uiPanel2.Controls.Add(this.btnBufenTuikuan);
            this.uiPanel2.Controls.Add(this.btnTuikuan);
            this.uiPanel2.Controls.Add(this.label1);
            this.uiPanel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel2.Location = new System.Drawing.Point(4, 40);
            this.uiPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel2.Name = "uiPanel2";
            this.uiPanel2.Size = new System.Drawing.Size(745, 45);
            this.uiPanel2.TabIndex = 7;
            this.uiPanel2.Text = null;
            this.uiPanel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiPanel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.btnExit.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.btnExit.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.btnExit.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.btnExit.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.btnExit.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.Location = new System.Drawing.Point(369, 2);
            this.btnExit.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnExit.Name = "btnExit";
            this.btnExit.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.btnExit.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.btnExit.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.btnExit.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(152)))), ((int)(((byte)(138)))));
            this.btnExit.Size = new System.Drawing.Size(100, 40);
            this.btnExit.Style = Sunny.UI.UIStyle.Colorful;
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "退出";
            this.btnExit.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnBufenTuikuan
            // 
            this.btnBufenTuikuan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBufenTuikuan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(0)))));
            this.btnBufenTuikuan.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(0)))));
            this.btnBufenTuikuan.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(51)))));
            this.btnBufenTuikuan.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(148)))), ((int)(((byte)(0)))));
            this.btnBufenTuikuan.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(148)))), ((int)(((byte)(0)))));
            this.btnBufenTuikuan.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBufenTuikuan.Location = new System.Drawing.Point(263, 2);
            this.btnBufenTuikuan.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnBufenTuikuan.Name = "btnBufenTuikuan";
            this.btnBufenTuikuan.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(0)))));
            this.btnBufenTuikuan.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(51)))));
            this.btnBufenTuikuan.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(148)))), ((int)(((byte)(0)))));
            this.btnBufenTuikuan.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(148)))), ((int)(((byte)(0)))));
            this.btnBufenTuikuan.Size = new System.Drawing.Size(100, 40);
            this.btnBufenTuikuan.Style = Sunny.UI.UIStyle.LayuiOrange;
            this.btnBufenTuikuan.TabIndex = 10;
            this.btnBufenTuikuan.Text = "部分退款";
            this.btnBufenTuikuan.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBufenTuikuan.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnBufenTuikuan.Click += new System.EventHandler(this.btnBufenTuikuan_Click);
            // 
            // btnTuikuan
            // 
            this.btnTuikuan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTuikuan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnTuikuan.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnTuikuan.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(203)))), ((int)(((byte)(83)))));
            this.btnTuikuan.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnTuikuan.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnTuikuan.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTuikuan.Location = new System.Drawing.Point(157, 2);
            this.btnTuikuan.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnTuikuan.Name = "btnTuikuan";
            this.btnTuikuan.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnTuikuan.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(203)))), ((int)(((byte)(83)))));
            this.btnTuikuan.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnTuikuan.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnTuikuan.Size = new System.Drawing.Size(100, 40);
            this.btnTuikuan.Style = Sunny.UI.UIStyle.Green;
            this.btnTuikuan.StyleCustomMode = true;
            this.btnTuikuan.TabIndex = 9;
            this.btnTuikuan.Text = "全部退款";
            this.btnTuikuan.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTuikuan.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnTuikuan.Click += new System.EventHandler(this.btnTuikuan_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.label1.Location = new System.Drawing.Point(21, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 35);
            this.label1.TabIndex = 8;
            this.label1.Text = "退款";
            // 
            // RefundConfirm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(753, 465);
            this.Controls.Add(this.uiPanel2);
            this.Controls.Add(this.dgvDeposit);
            this.Controls.Add(this.uiPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RefundConfirm";
            this.Text = "退款";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 753, 465);
            this.Load += new System.EventHandler(this.RefundConfirm_Load);
            this.uiPanel1.ResumeLayout(false);
            this.uiPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeposit)).EndInit();
            this.uiPanel2.ResumeLayout(false);
            this.uiPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UIDataGridView dgvDeposit;
        private System.Windows.Forms.Label lblTuikuan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblZongji;
        private System.Windows.Forms.Label label6;
        private Sunny.UI.UIPanel uiPanel2;
        private Sunny.UI.UIButton btnExit;
        private Sunny.UI.UIButton btnBufenTuikuan;
        private Sunny.UI.UIButton btnTuikuan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cheque_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn charge;
        private System.Windows.Forms.DataGridViewTextBoxColumn refund_charge;
    }
}