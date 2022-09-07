namespace Client.Forms.Wedgit
{
    partial class YBtuifei
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_psn_no = new Sunny.UI.UITextBox();
            this.txt_mdtrt_id = new Sunny.UI.UITextBox();
            this.txt_setl_id = new Sunny.UI.UITextBox();
            this.btnOK = new Sunny.UI.UIButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "医保人员编号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "医保交易编号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(98, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "医保结算编号";
            // 
            // txt_psn_no
            // 
            this.txt_psn_no.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_psn_no.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_psn_no.Location = new System.Drawing.Point(221, 90);
            this.txt_psn_no.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_psn_no.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_psn_no.Name = "txt_psn_no";
            this.txt_psn_no.ShowText = false;
            this.txt_psn_no.Size = new System.Drawing.Size(252, 29);
            this.txt_psn_no.TabIndex = 3;
            this.txt_psn_no.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_psn_no.Watermark = "psn_no";
            this.txt_psn_no.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txt_mdtrt_id
            // 
            this.txt_mdtrt_id.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_mdtrt_id.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_mdtrt_id.Location = new System.Drawing.Point(221, 131);
            this.txt_mdtrt_id.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_mdtrt_id.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_mdtrt_id.Name = "txt_mdtrt_id";
            this.txt_mdtrt_id.ShowText = false;
            this.txt_mdtrt_id.Size = new System.Drawing.Size(252, 29);
            this.txt_mdtrt_id.TabIndex = 4;
            this.txt_mdtrt_id.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_mdtrt_id.Watermark = "mdtrt_id";
            this.txt_mdtrt_id.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txt_setl_id
            // 
            this.txt_setl_id.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_setl_id.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_setl_id.Location = new System.Drawing.Point(221, 170);
            this.txt_setl_id.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_setl_id.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_setl_id.Name = "txt_setl_id";
            this.txt_setl_id.ShowText = false;
            this.txt_setl_id.Size = new System.Drawing.Size(252, 29);
            this.txt_setl_id.TabIndex = 4;
            this.txt_setl_id.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_setl_id.Watermark = "setl_id";
            this.txt_setl_id.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnOK
            // 
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(221, 226);
            this.btnOK.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 35);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "确定";
            this.btnOK.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // YBtuifei
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(584, 310);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txt_setl_id);
            this.Controls.Add(this.txt_mdtrt_id);
            this.Controls.Add(this.txt_psn_no);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "YBtuifei";
            this.Text = "医保退费";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.YBtuifei_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Sunny.UI.UITextBox txt_psn_no;
        private Sunny.UI.UITextBox txt_mdtrt_id;
        private Sunny.UI.UITextBox txt_setl_id;
        private Sunny.UI.UIButton btnOK;
    }
}