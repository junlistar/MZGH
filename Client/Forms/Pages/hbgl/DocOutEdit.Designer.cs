namespace Client.Forms.Pages.hbgl
{
    partial class DocOutEdit
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
            this.txtDate2 = new Sunny.UI.UIDatePicker();
            this.uiLabel9 = new Sunny.UI.UILabel();
            this.txtDate = new Sunny.UI.UIDatePicker();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.txtDoct = new Sunny.UI.UITextBox();
            this.uiLabel10 = new Sunny.UI.UILabel();
            this.uiSymbolButton1 = new Sunny.UI.UISymbolButton();
            this.btnClose = new Sunny.UI.UISymbolButton();
            this.uiLine1 = new Sunny.UI.UILine();
            this.chk_status = new Sunny.UI.UICheckBox();
            this.lblErrorMsg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDate2
            // 
            this.txtDate2.FillColor = System.Drawing.Color.White;
            this.txtDate2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDate2.Location = new System.Drawing.Point(309, 134);
            this.txtDate2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDate2.MaxLength = 10;
            this.txtDate2.MinimumSize = new System.Drawing.Size(63, 0);
            this.txtDate2.Name = "txtDate2";
            this.txtDate2.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.txtDate2.Size = new System.Drawing.Size(124, 29);
            this.txtDate2.SymbolDropDown = 61555;
            this.txtDate2.SymbolNormal = 61555;
            this.txtDate2.TabIndex = 3;
            this.txtDate2.Text = "1900-01-01";
            this.txtDate2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtDate2.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.txtDate2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel9
            // 
            this.uiLabel9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel9.Location = new System.Drawing.Point(284, 135);
            this.uiLabel9.Name = "uiLabel9";
            this.uiLabel9.Size = new System.Drawing.Size(32, 23);
            this.uiLabel9.TabIndex = 36;
            this.uiLabel9.Text = "至";
            this.uiLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel9.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtDate
            // 
            this.txtDate.FillColor = System.Drawing.Color.White;
            this.txtDate.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDate.Location = new System.Drawing.Point(148, 132);
            this.txtDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDate.MaxLength = 10;
            this.txtDate.MinimumSize = new System.Drawing.Size(63, 0);
            this.txtDate.Name = "txtDate";
            this.txtDate.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.txtDate.Size = new System.Drawing.Size(124, 29);
            this.txtDate.SymbolDropDown = 61555;
            this.txtDate.SymbolNormal = 61555;
            this.txtDate.TabIndex = 2;
            this.txtDate.Text = "1900-01-01";
            this.txtDate.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtDate.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.txtDate.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(51, 134);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(90, 23);
            this.uiLabel1.TabIndex = 34;
            this.uiLabel1.Text = "停诊日期：";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtDoct
            // 
            this.txtDoct.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDoct.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDoct.Location = new System.Drawing.Point(148, 87);
            this.txtDoct.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDoct.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtDoct.Name = "txtDoct";
            this.txtDoct.ShowText = false;
            this.txtDoct.Size = new System.Drawing.Size(285, 29);
            this.txtDoct.TabIndex = 1;
            this.txtDoct.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtDoct.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txtDoct.TextChanged += new System.EventHandler(this.txtDoct_TextChanged);
            this.txtDoct.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDoct_KeyUp);
            this.txtDoct.Leave += new System.EventHandler(this.txtDoct_Leave);
            // 
            // uiLabel10
            // 
            this.uiLabel10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel10.Location = new System.Drawing.Point(51, 87);
            this.uiLabel10.Name = "uiLabel10";
            this.uiLabel10.Size = new System.Drawing.Size(93, 23);
            this.uiLabel10.TabIndex = 38;
            this.uiLabel10.Text = "停诊医生：";
            this.uiLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel10.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiSymbolButton1
            // 
            this.uiSymbolButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton1.Location = new System.Drawing.Point(254, 260);
            this.uiSymbolButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton1.Name = "uiSymbolButton1";
            this.uiSymbolButton1.Size = new System.Drawing.Size(100, 35);
            this.uiSymbolButton1.TabIndex = 40;
            this.uiSymbolButton1.Text = "确定";
            this.uiSymbolButton1.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiSymbolButton1.Click += new System.EventHandler(this.uiSymbolButton1_Click);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(371, 260);
            this.btnClose.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 35);
            this.btnClose.Symbol = 61453;
            this.btnClose.TabIndex = 41;
            this.btnClose.Text = "取消";
            this.btnClose.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // uiLine1
            // 
            this.uiLine1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine1.Location = new System.Drawing.Point(3, 225);
            this.uiLine1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(504, 29);
            this.uiLine1.TabIndex = 42;
            this.uiLine1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // chk_status
            // 
            this.chk_status.Checked = true;
            this.chk_status.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chk_status.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chk_status.Location = new System.Drawing.Point(440, 135);
            this.chk_status.MinimumSize = new System.Drawing.Size(1, 1);
            this.chk_status.Name = "chk_status";
            this.chk_status.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.chk_status.Size = new System.Drawing.Size(150, 29);
            this.chk_status.TabIndex = 43;
            this.chk_status.Text = "是否启用";
            this.chk_status.Visible = false;
            this.chk_status.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblErrorMsg
            // 
            this.lblErrorMsg.AutoSize = true;
            this.lblErrorMsg.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMsg.Location = new System.Drawing.Point(51, 187);
            this.lblErrorMsg.Name = "lblErrorMsg";
            this.lblErrorMsg.Size = new System.Drawing.Size(90, 21);
            this.lblErrorMsg.TabIndex = 44;
            this.lblErrorMsg.Text = "冲突日期：";
            // 
            // DocOutEdit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(510, 319);
            this.Controls.Add(this.lblErrorMsg);
            this.Controls.Add(this.chk_status);
            this.Controls.Add(this.uiLine1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.uiSymbolButton1);
            this.Controls.Add(this.txtDoct);
            this.Controls.Add(this.uiLabel10);
            this.Controls.Add(this.txtDate2);
            this.Controls.Add(this.uiLabel9);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.uiLabel1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DocOutEdit";
            this.Text = "医生停诊编辑";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.Load += new System.EventHandler(this.DocOutEdit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DocOutEdit_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunny.UI.UIDatePicker txtDate2;
        private Sunny.UI.UILabel uiLabel9;
        private Sunny.UI.UIDatePicker txtDate;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITextBox txtDoct;
        private Sunny.UI.UILabel uiLabel10;
        private Sunny.UI.UISymbolButton uiSymbolButton1;
        private Sunny.UI.UISymbolButton btnClose;
        private Sunny.UI.UILine uiLine1;
        private Sunny.UI.UICheckBox chk_status;
        private System.Windows.Forms.Label lblErrorMsg;
    }
}