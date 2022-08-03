namespace Client.Forms.Wedgit
{
    partial class EditPwd
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
            this.uiBreadcrumb1 = new Sunny.UI.UIBreadcrumb();
            this.pnl1 = new Sunny.UI.UIPanel();
            this.txtPwd = new Sunny.UI.UITextBox();
            this.txtName = new Sunny.UI.UITextBox();
            this.uiSymbolButton1 = new Sunny.UI.UISymbolButton();
            this.pnl2 = new Sunny.UI.UIPanel();
            this.btn2right = new Sunny.UI.UISymbolButton();
            this.txtpwd2 = new Sunny.UI.UITextBox();
            this.txtpwd1 = new Sunny.UI.UITextBox();
            this.btn2left = new Sunny.UI.UISymbolButton();
            this.pnl3 = new Sunny.UI.UIPanel();
            this.btnok = new Sunny.UI.UISymbolButton();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.pnl1.SuspendLayout();
            this.pnl2.SuspendLayout();
            this.pnl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiBreadcrumb1
            // 
            this.uiBreadcrumb1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiBreadcrumb1.ItemIndex = 0;
            this.uiBreadcrumb1.Items.AddRange(new object[] {
            "验证账户",
            "修改密码",
            "完成修改"});
            this.uiBreadcrumb1.ItemWidth = 120;
            this.uiBreadcrumb1.Location = new System.Drawing.Point(3, 38);
            this.uiBreadcrumb1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiBreadcrumb1.Name = "uiBreadcrumb1";
            this.uiBreadcrumb1.Size = new System.Drawing.Size(420, 29);
            this.uiBreadcrumb1.TabIndex = 0;
            this.uiBreadcrumb1.Text = "uiBreadcrumb1";
            this.uiBreadcrumb1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiBreadcrumb1.ItemIndexChanged += new Sunny.UI.UIBreadcrumb.OnValueChanged(this.uiBreadcrumb1_ItemIndexChanged);
            // 
            // pnl1
            // 
            this.pnl1.Controls.Add(this.uiSymbolButton1);
            this.pnl1.Controls.Add(this.txtPwd);
            this.pnl1.Controls.Add(this.txtName);
            this.pnl1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnl1.Location = new System.Drawing.Point(18, 74);
            this.pnl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnl1.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnl1.Name = "pnl1";
            this.pnl1.Size = new System.Drawing.Size(400, 206);
            this.pnl1.TabIndex = 1;
            this.pnl1.Text = "uiPanel1";
            this.pnl1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnl1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtPwd
            // 
            this.txtPwd.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPwd.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPwd.Location = new System.Drawing.Point(82, 80);
            this.txtPwd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPwd.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.ShowText = false;
            this.txtPwd.Size = new System.Drawing.Size(237, 39);
            this.txtPwd.Symbol = 57452;
            this.txtPwd.TabIndex = 6;
            this.txtPwd.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtPwd.Watermark = "请输入密码";
            this.txtPwd.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtName
            // 
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtName.Location = new System.Drawing.Point(82, 31);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtName.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtName.Name = "txtName";
            this.txtName.ShowText = false;
            this.txtName.Size = new System.Drawing.Size(237, 39);
            this.txtName.Symbol = 61447;
            this.txtName.TabIndex = 5;
            this.txtName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtName.Watermark = "请输入账号";
            this.txtName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiSymbolButton1
            // 
            this.uiSymbolButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton1.Location = new System.Drawing.Point(219, 142);
            this.uiSymbolButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton1.Name = "uiSymbolButton1";
            this.uiSymbolButton1.Size = new System.Drawing.Size(100, 35);
            this.uiSymbolButton1.Symbol = 61518;
            this.uiSymbolButton1.TabIndex = 7;
            this.uiSymbolButton1.Text = "下一步";
            this.uiSymbolButton1.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiSymbolButton1.Click += new System.EventHandler(this.uiSymbolButton1_Click);
            // 
            // pnl2
            // 
            this.pnl2.Controls.Add(this.btn2left);
            this.pnl2.Controls.Add(this.btn2right);
            this.pnl2.Controls.Add(this.txtpwd2);
            this.pnl2.Controls.Add(this.txtpwd1);
            this.pnl2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnl2.Location = new System.Drawing.Point(458, 74);
            this.pnl2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnl2.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnl2.Name = "pnl2";
            this.pnl2.Size = new System.Drawing.Size(400, 206);
            this.pnl2.TabIndex = 8;
            this.pnl2.Text = "uiPanel1";
            this.pnl2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnl2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btn2right
            // 
            this.btn2right.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn2right.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn2right.Location = new System.Drawing.Point(219, 142);
            this.btn2right.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn2right.Name = "btn2right";
            this.btn2right.Size = new System.Drawing.Size(100, 35);
            this.btn2right.Symbol = 61518;
            this.btn2right.TabIndex = 7;
            this.btn2right.Text = "下一步";
            this.btn2right.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn2right.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn2right.Click += new System.EventHandler(this.btn2right_Click);
            // 
            // txtpwd2
            // 
            this.txtpwd2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtpwd2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtpwd2.Location = new System.Drawing.Point(82, 80);
            this.txtpwd2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtpwd2.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtpwd2.Name = "txtpwd2";
            this.txtpwd2.ShowText = false;
            this.txtpwd2.Size = new System.Drawing.Size(237, 39);
            this.txtpwd2.Symbol = 57452;
            this.txtpwd2.TabIndex = 6;
            this.txtpwd2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtpwd2.Watermark = "确认新密码";
            this.txtpwd2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtpwd1
            // 
            this.txtpwd1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtpwd1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtpwd1.Location = new System.Drawing.Point(82, 31);
            this.txtpwd1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtpwd1.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtpwd1.Name = "txtpwd1";
            this.txtpwd1.ShowText = false;
            this.txtpwd1.Size = new System.Drawing.Size(237, 39);
            this.txtpwd1.Symbol = 57452;
            this.txtpwd1.TabIndex = 5;
            this.txtpwd1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtpwd1.Watermark = "新密码";
            this.txtpwd1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btn2left
            // 
            this.btn2left.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn2left.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn2left.Location = new System.Drawing.Point(82, 142);
            this.btn2left.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn2left.Name = "btn2left";
            this.btn2left.Size = new System.Drawing.Size(100, 35);
            this.btn2left.Symbol = 61514;
            this.btn2left.TabIndex = 8;
            this.btn2left.Text = "上一步";
            this.btn2left.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn2left.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btn2left.Click += new System.EventHandler(this.btn2left_Click);
            // 
            // pnl3
            // 
            this.pnl3.Controls.Add(this.uiLabel1);
            this.pnl3.Controls.Add(this.btnok);
            this.pnl3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnl3.Location = new System.Drawing.Point(458, 290);
            this.pnl3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnl3.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnl3.Name = "pnl3";
            this.pnl3.Size = new System.Drawing.Size(400, 206);
            this.pnl3.TabIndex = 9;
            this.pnl3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnl3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnok
            // 
            this.btnok.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnok.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnok.Location = new System.Drawing.Point(219, 141);
            this.btnok.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(100, 35);
            this.btnok.TabIndex = 7;
            this.btnok.Text = "完成";
            this.btnok.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnok.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.ForeColor = System.Drawing.Color.Red;
            this.uiLabel1.Location = new System.Drawing.Point(75, 43);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(244, 62);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.StyleCustomMode = true;
            this.uiLabel1.TabIndex = 8;
            this.uiLabel1.Text = "密码修改成功！";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // EditPwd
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(452, 301);
            this.Controls.Add(this.pnl3);
            this.Controls.Add(this.pnl2);
            this.Controls.Add(this.pnl1);
            this.Controls.Add(this.uiBreadcrumb1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditPwd";
            this.Text = "修改密码(按ESC退出)";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.Load += new System.EventHandler(this.EditPwd_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.EditPwd_KeyUp);
            this.pnl1.ResumeLayout(false);
            this.pnl2.ResumeLayout(false);
            this.pnl3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIBreadcrumb uiBreadcrumb1;
        private Sunny.UI.UIPanel pnl1;
        private Sunny.UI.UISymbolButton uiSymbolButton1;
        private Sunny.UI.UITextBox txtPwd;
        private Sunny.UI.UITextBox txtName;
        private Sunny.UI.UIPanel pnl2;
        private Sunny.UI.UISymbolButton btn2left;
        private Sunny.UI.UISymbolButton btn2right;
        private Sunny.UI.UITextBox txtpwd2;
        private Sunny.UI.UITextBox txtpwd1;
        private Sunny.UI.UIPanel pnl3;
        private Sunny.UI.UISymbolButton btnok;
        private Sunny.UI.UILabel uiLabel1;
    }
}