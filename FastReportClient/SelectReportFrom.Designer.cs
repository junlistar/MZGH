namespace FastReportClient
{
    partial class SelectReportFrom
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.report_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.report_sql = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.short_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.long_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtcode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.dgvparams = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvparams)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.report_code,
            this.report_sql,
            this.short_name,
            this.long_name});
            this.dataGridView1.Location = new System.Drawing.Point(27, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(369, 287);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // report_code
            // 
            this.report_code.DataPropertyName = "report_code";
            this.report_code.HeaderText = "报表号";
            this.report_code.Name = "report_code";
            this.report_code.ReadOnly = true;
            // 
            // report_sql
            // 
            this.report_sql.DataPropertyName = "report_sql";
            this.report_sql.HeaderText = "report_sql";
            this.report_sql.Name = "report_sql";
            this.report_sql.ReadOnly = true;
            this.report_sql.Visible = false;
            // 
            // short_name
            // 
            this.short_name.DataPropertyName = "short_name";
            this.short_name.HeaderText = "报表名称";
            this.short_name.Name = "short_name";
            this.short_name.ReadOnly = true;
            // 
            // long_name
            // 
            this.long_name.DataPropertyName = "long_name";
            this.long_name.HeaderText = "long_name";
            this.long_name.Name = "long_name";
            this.long_name.ReadOnly = true;
            this.long_name.Visible = false;
            // 
            // txtcode
            // 
            this.txtcode.Location = new System.Drawing.Point(72, 23);
            this.txtcode.Name = "txtcode";
            this.txtcode.Size = new System.Drawing.Size(195, 21);
            this.txtcode.TabIndex = 1;
            this.txtcode.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "报表号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(294, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "报表名称";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(353, 23);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(435, 21);
            this.txtName.TabIndex = 4;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // dgvparams
            // 
            this.dgvparams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvparams.Location = new System.Drawing.Point(419, 50);
            this.dgvparams.Name = "dgvparams";
            this.dgvparams.RowTemplate.Height = 23;
            this.dgvparams.Size = new System.Drawing.Size(369, 287);
            this.dgvparams.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(551, 354);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 33);
            this.button1.TabIndex = 6;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(664, 354);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 33);
            this.button2.TabIndex = 7;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SelectReportFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 399);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvparams);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtcode);
            this.Controls.Add(this.dataGridView1);
            this.Name = "SelectReportFrom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择报表";
            this.Load += new System.EventHandler(this.SelectReportFrom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvparams)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.DataGridView dgvparams;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn report_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn report_sql;
        private System.Windows.Forms.DataGridViewTextBoxColumn short_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn long_name;
    }
}