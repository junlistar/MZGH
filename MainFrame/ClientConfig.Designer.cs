namespace MainFrame
{
    partial class ClientConfig
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
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.txt_title = new Sunny.UI.UITextBox();
            this.txt_show_image = new Sunny.UI.UITextBox();
            this.txt_show_title = new Sunny.UI.UITextBox();
            this.txt_show_desc = new Sunny.UI.UITextBox();
            this.uiLine1 = new Sunny.UI.UILine();
            this.btnOk = new Sunny.UI.UISymbolButton();
            this.btnCancel = new Sunny.UI.UISymbolButton();
            this.SuspendLayout();
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(20, 68);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(156, 30);
            this.uiLabel1.TabIndex = 25;
            this.uiLabel1.Text = "客户端标题";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(16, 107);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(160, 23);
            this.uiLabel2.TabIndex = 26;
            this.uiLabel2.Text = "右下角展示图片";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(16, 142);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(160, 23);
            this.uiLabel3.TabIndex = 27;
            this.uiLabel3.Text = "右下角展示标题";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiLabel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.Location = new System.Drawing.Point(16, 177);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(160, 23);
            this.uiLabel4.TabIndex = 28;
            this.uiLabel4.Text = "右下角展示描述";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiLabel4.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txt_title
            // 
            this.txt_title.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_title.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_title.Location = new System.Drawing.Point(195, 68);
            this.txt_title.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_title.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_title.Name = "txt_title";
            this.txt_title.ShowText = false;
            this.txt_title.Size = new System.Drawing.Size(437, 29);
            this.txt_title.TabIndex = 29;
            this.txt_title.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_title.Watermark = "";
            this.txt_title.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txt_show_image
            // 
            this.txt_show_image.ButtonSymbol = 61717;
            this.txt_show_image.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_show_image.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_show_image.Location = new System.Drawing.Point(195, 104);
            this.txt_show_image.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_show_image.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_show_image.Name = "txt_show_image";
            this.txt_show_image.ShowButton = true;
            this.txt_show_image.ShowText = false;
            this.txt_show_image.Size = new System.Drawing.Size(437, 29);
            this.txt_show_image.TabIndex = 30;
            this.txt_show_image.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_show_image.Watermark = "";
            this.txt_show_image.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txt_show_image.ButtonClick += new System.EventHandler(this.txt_show_image_ButtonClick);
            // 
            // txt_show_title
            // 
            this.txt_show_title.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_show_title.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_show_title.Location = new System.Drawing.Point(195, 140);
            this.txt_show_title.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_show_title.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_show_title.Name = "txt_show_title";
            this.txt_show_title.ShowText = false;
            this.txt_show_title.Size = new System.Drawing.Size(437, 29);
            this.txt_show_title.TabIndex = 30;
            this.txt_show_title.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_show_title.Watermark = "";
            this.txt_show_title.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txt_show_desc
            // 
            this.txt_show_desc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_show_desc.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_show_desc.Location = new System.Drawing.Point(195, 176);
            this.txt_show_desc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_show_desc.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_show_desc.Multiline = true;
            this.txt_show_desc.Name = "txt_show_desc";
            this.txt_show_desc.ShowText = false;
            this.txt_show_desc.Size = new System.Drawing.Size(437, 97);
            this.txt_show_desc.TabIndex = 31;
            this.txt_show_desc.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_show_desc.Watermark = "";
            this.txt_show_desc.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLine1
            // 
            this.uiLine1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.uiLine1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine1.Location = new System.Drawing.Point(4, 305);
            this.uiLine1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(675, 15);
            this.uiLine1.TabIndex = 32;
            this.uiLine1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Location = new System.Drawing.Point(416, 326);
            this.btnOk.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 35);
            this.btnOk.TabIndex = 33;
            this.btnOk.Text = "保存";
            this.btnOk.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnOk.Click += new System.EventHandler(this.uiSymbolButton1_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(532, 326);
            this.btnCancel.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.Symbol = 61453;
            this.btnCancel.TabIndex = 34;
            this.btnCancel.Text = "取消";
            this.btnCancel.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ClientConfig
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(682, 378);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.uiLine1);
            this.Controls.Add(this.txt_show_desc);
            this.Controls.Add(this.txt_show_title);
            this.Controls.Add(this.txt_show_image);
            this.Controls.Add(this.txt_title);
            this.Controls.Add(this.uiLabel4);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.uiLabel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClientConfig";
            this.Text = "编辑系统信息";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.Load += new System.EventHandler(this.ClientConfig_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UITextBox txt_title;
        private Sunny.UI.UITextBox txt_show_image;
        private Sunny.UI.UITextBox txt_show_title;
        private Sunny.UI.UITextBox txt_show_desc;
        private Sunny.UI.UILine uiLine1;
        private Sunny.UI.UISymbolButton btnOk;
        private Sunny.UI.UISymbolButton btnCancel;
    }
}