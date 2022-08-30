namespace Client.Forms.Pages.yhbb
{
    partial class WebReportEdit
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_name = new Sunny.UI.UITextBox();
            this.txt_url = new Sunny.UI.UITextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_code = new Sunny.UI.UITextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new Sunny.UI.UISymbolButton();
            this.btnSave = new Sunny.UI.UISymbolButton();
            this.label4 = new System.Windows.Forms.Label();
            this.chk_openflag = new Sunny.UI.UICheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "报表名称";
            // 
            // txt_name
            // 
            this.txt_name.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_name.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_name.Location = new System.Drawing.Point(154, 105);
            this.txt_name.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_name.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_name.Name = "txt_name";
            this.txt_name.ShowText = false;
            this.txt_name.Size = new System.Drawing.Size(436, 29);
            this.txt_name.TabIndex = 1;
            this.txt_name.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_name.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txt_url
            // 
            this.txt_url.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_url.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_url.Location = new System.Drawing.Point(154, 144);
            this.txt_url.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_url.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_url.Name = "txt_url";
            this.txt_url.ShowText = false;
            this.txt_url.Size = new System.Drawing.Size(436, 29);
            this.txt_url.TabIndex = 4;
            this.txt_url.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_url.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Web链接地址";
            // 
            // txt_code
            // 
            this.txt_code.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_code.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_code.Location = new System.Drawing.Point(154, 66);
            this.txt_code.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_code.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_code.Name = "txt_code";
            this.txt_code.ReadOnly = true;
            this.txt_code.ShowText = false;
            this.txt_code.Size = new System.Drawing.Size(436, 29);
            this.txt_code.TabIndex = 4;
            this.txt_code.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_code.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "报表编号";
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(485, 236);
            this.btnCancel.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 33);
            this.btnCancel.StyleCustomMode = true;
            this.btnCancel.Symbol = 61453;
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "取消";
            this.btnCancel.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(382, 236);
            this.btnSave.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(97, 32);
            this.btnSave.StyleCustomMode = true;
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "保存";
            this.btnSave.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(69, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 21);
            this.label4.TabIndex = 16;
            this.label4.Text = "是否启用";
            // 
            // chk_openflag
            // 
            this.chk_openflag.Checked = true;
            this.chk_openflag.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chk_openflag.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chk_openflag.Location = new System.Drawing.Point(150, 189);
            this.chk_openflag.MinimumSize = new System.Drawing.Size(1, 1);
            this.chk_openflag.Name = "chk_openflag";
            this.chk_openflag.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.chk_openflag.Size = new System.Drawing.Size(23, 29);
            this.chk_openflag.TabIndex = 19;
            this.chk_openflag.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // WebReportEdit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(653, 296);
            this.Controls.Add(this.chk_openflag);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txt_code);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_url);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WebReportEdit";
            this.Text = "Web报表编辑";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.Load += new System.EventHandler(this.WebReportEdit_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.WebReportEdit_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Sunny.UI.UITextBox txt_name;
        private Sunny.UI.UITextBox txt_url;
        private System.Windows.Forms.Label label2;
        private Sunny.UI.UITextBox txt_code;
        private System.Windows.Forms.Label label3;
        private Sunny.UI.UISymbolButton btnCancel;
        private Sunny.UI.UISymbolButton btnSave;
        private System.Windows.Forms.Label label4;
        private Sunny.UI.UICheckBox chk_openflag;
    }
}