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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.btnExit = new Sunny.UI.UISymbolButton();
            this.btnTuikuan = new Sunny.UI.UISymbolButton();
            this.btnBufenTuikuan = new Sunny.UI.UIButton();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvCpr = new Sunny.UI.UIDataGridView();
            this.ckall = new Sunny.UI.UICheckBox();
            this.chkback = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.charge_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.charge_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cf_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caoyao_fu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orig_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.charge_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sum_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.back = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.charge_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.order_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.confirm_flag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeposit)).BeginInit();
            this.uiPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCpr)).BeginInit();
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
            this.uiPanel1.Size = new System.Drawing.Size(934, 63);
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
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.dgvDeposit.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDeposit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDeposit.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.dgvDeposit.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDeposit.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDeposit.ColumnHeadersHeight = 32;
            this.dgvDeposit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDeposit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cheque_name,
            this.amount,
            this.charge,
            this.refund_charge});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDeposit.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDeposit.EnableHeadersVisualStyles = false;
            this.dgvDeposit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvDeposit.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            this.dgvDeposit.Location = new System.Drawing.Point(4, 166);
            this.dgvDeposit.Name = "dgvDeposit";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDeposit.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDeposit.RowHeight = 0;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgvDeposit.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDeposit.RowTemplate.Height = 23;
            this.dgvDeposit.SelectedIndex = -1;
            this.dgvDeposit.ShowGridLine = false;
            this.dgvDeposit.ShowRect = false;
            this.dgvDeposit.Size = new System.Drawing.Size(934, 125);
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
            this.uiPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiPanel2.Controls.Add(this.btnExit);
            this.uiPanel2.Controls.Add(this.btnTuikuan);
            this.uiPanel2.Controls.Add(this.btnBufenTuikuan);
            this.uiPanel2.Controls.Add(this.label1);
            this.uiPanel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel2.Location = new System.Drawing.Point(4, 40);
            this.uiPanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel2.Name = "uiPanel2";
            this.uiPanel2.Size = new System.Drawing.Size(934, 45);
            this.uiPanel2.TabIndex = 7;
            this.uiPanel2.Text = null;
            this.uiPanel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiPanel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.Location = new System.Drawing.Point(289, 2);
            this.btnExit.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(103, 40);
            this.btnExit.Symbol = 61579;
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "退出";
            this.btnExit.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnTuikuan
            // 
            this.btnTuikuan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTuikuan.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTuikuan.Location = new System.Drawing.Point(183, 3);
            this.btnTuikuan.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnTuikuan.Name = "btnTuikuan";
            this.btnTuikuan.Size = new System.Drawing.Size(100, 39);
            this.btnTuikuan.TabIndex = 12;
            this.btnTuikuan.Text = "退款";
            this.btnTuikuan.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTuikuan.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnTuikuan.Click += new System.EventHandler(this.btnTuikuan_Click);
            // 
            // btnBufenTuikuan
            // 
            this.btnBufenTuikuan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBufenTuikuan.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.btnBufenTuikuan.Location = new System.Drawing.Point(770, 2);
            this.btnBufenTuikuan.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnBufenTuikuan.Name = "btnBufenTuikuan";
            this.btnBufenTuikuan.Size = new System.Drawing.Size(100, 40);
            this.btnBufenTuikuan.TabIndex = 10;
            this.btnBufenTuikuan.Text = "部分退款";
            this.btnBufenTuikuan.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBufenTuikuan.Visible = false;
            this.btnBufenTuikuan.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnBufenTuikuan.Click += new System.EventHandler(this.btnBufenTuikuan_Click);
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
            // dgvCpr
            // 
            this.dgvCpr.AllowUserToAddRows = false;
            this.dgvCpr.AllowUserToDeleteRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.dgvCpr.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCpr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCpr.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.dgvCpr.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCpr.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvCpr.ColumnHeadersHeight = 32;
            this.dgvCpr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCpr.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chkback,
            this.charge_amount,
            this.charge_name,
            this.cf_amount,
            this.caoyao_fu,
            this.orig_price,
            this.charge_price,
            this.sum_total,
            this.back,
            this.charge_code,
            this.order_type,
            this.confirm_flag});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCpr.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvCpr.EnableHeadersVisualStyles = false;
            this.dgvCpr.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvCpr.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            this.dgvCpr.Location = new System.Drawing.Point(4, 297);
            this.dgvCpr.Name = "dgvCpr";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCpr.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvCpr.RowHeight = 0;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgvCpr.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvCpr.RowTemplate.Height = 23;
            this.dgvCpr.SelectedIndex = -1;
            this.dgvCpr.ShowGridLine = false;
            this.dgvCpr.ShowRect = false;
            this.dgvCpr.Size = new System.Drawing.Size(934, 325);
            this.dgvCpr.TabIndex = 9;
            this.dgvCpr.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.dgvCpr.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCpr_CellClick);
            // 
            // ckall
            // 
            this.ckall.BackColor = System.Drawing.Color.Transparent;
            this.ckall.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckall.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckall.Location = new System.Drawing.Point(6, 298);
            this.ckall.MinimumSize = new System.Drawing.Size(1, 1);
            this.ckall.Name = "ckall";
            this.ckall.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.ckall.Size = new System.Drawing.Size(73, 30);
            this.ckall.TabIndex = 14;
            this.ckall.Text = "全选";
            this.ckall.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ckall.CheckedChanged += new System.EventHandler(this.ckall_CheckedChanged);
            // 
            // chkback
            // 
            this.chkback.HeaderText = "";
            this.chkback.Name = "chkback";
            this.chkback.TrueValue = "True";
            this.chkback.Width = 88;
            // 
            // charge_amount
            // 
            this.charge_amount.DataPropertyName = "charge_amount";
            this.charge_amount.HeaderText = "数量";
            this.charge_amount.Name = "charge_amount";
            // 
            // charge_name
            // 
            this.charge_name.DataPropertyName = "charge_name";
            this.charge_name.HeaderText = "项目名称";
            this.charge_name.Name = "charge_name";
            // 
            // cf_amount
            // 
            this.cf_amount.DataPropertyName = "cf_amount";
            this.cf_amount.HeaderText = "处方数量";
            this.cf_amount.Name = "cf_amount";
            // 
            // caoyao_fu
            // 
            this.caoyao_fu.DataPropertyName = "caoyao_fu";
            this.caoyao_fu.HeaderText = "付数";
            this.caoyao_fu.Name = "caoyao_fu";
            // 
            // orig_price
            // 
            this.orig_price.DataPropertyName = "orig_price";
            this.orig_price.HeaderText = "价格(标准)";
            this.orig_price.Name = "orig_price";
            // 
            // charge_price
            // 
            this.charge_price.DataPropertyName = "charge_price";
            this.charge_price.HeaderText = "价格(实收)";
            this.charge_price.Name = "charge_price";
            // 
            // sum_total
            // 
            this.sum_total.DataPropertyName = "sum_total";
            this.sum_total.HeaderText = "合计";
            this.sum_total.Name = "sum_total";
            // 
            // back
            // 
            this.back.DataPropertyName = "back";
            this.back.HeaderText = "退药数量";
            this.back.Name = "back";
            // 
            // charge_code
            // 
            this.charge_code.DataPropertyName = "charge_code";
            this.charge_code.HeaderText = "charge_code";
            this.charge_code.Name = "charge_code";
            this.charge_code.Visible = false;
            // 
            // order_type
            // 
            this.order_type.DataPropertyName = "order_type";
            this.order_type.HeaderText = "order_type";
            this.order_type.Name = "order_type";
            this.order_type.Visible = false;
            // 
            // confirm_flag
            // 
            this.confirm_flag.DataPropertyName = "confirm_flag";
            this.confirm_flag.HeaderText = "confirm_flag";
            this.confirm_flag.Name = "confirm_flag";
            this.confirm_flag.Visible = false;
            // 
            // RefundConfirm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(942, 625);
            this.Controls.Add(this.ckall);
            this.Controls.Add(this.dgvCpr);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvCpr)).EndInit();
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
        private Sunny.UI.UIButton btnBufenTuikuan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cheque_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn charge;
        private System.Windows.Forms.DataGridViewTextBoxColumn refund_charge;
        private Sunny.UI.UIDataGridView dgvCpr;
        private Sunny.UI.UISymbolButton btnTuikuan;
        private Sunny.UI.UISymbolButton btnExit;
        private Sunny.UI.UICheckBox ckall;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkback;
        private System.Windows.Forms.DataGridViewTextBoxColumn charge_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn charge_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn cf_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn caoyao_fu;
        private System.Windows.Forms.DataGridViewTextBoxColumn orig_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn charge_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn sum_total;
        private System.Windows.Forms.DataGridViewTextBoxColumn back;
        private System.Windows.Forms.DataGridViewTextBoxColumn charge_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn order_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn confirm_flag;
    }
}