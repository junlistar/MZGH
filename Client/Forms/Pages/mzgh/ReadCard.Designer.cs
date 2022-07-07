namespace Client
{
    partial class ReadCard
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
            this.components = new System.ComponentModel.Container();
            this.uiWaitingBar1 = new Sunny.UI.UIWaitingBar();
            this.lblInfo = new Sunny.UI.UILabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblmsg = new Sunny.UI.UILabel();
            this.SuspendLayout();
            // 
            // uiWaitingBar1
            // 
            this.uiWaitingBar1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiWaitingBar1.Location = new System.Drawing.Point(102, 146);
            this.uiWaitingBar1.MinimumSize = new System.Drawing.Size(70, 23);
            this.uiWaitingBar1.Name = "uiWaitingBar1";
            this.uiWaitingBar1.Size = new System.Drawing.Size(582, 23);
            this.uiWaitingBar1.TabIndex = 0;
            this.uiWaitingBar1.Text = "uiWaitingBar1";
            this.uiWaitingBar1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // lblInfo
            // 
            this.lblInfo.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInfo.Location = new System.Drawing.Point(231, 90);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(290, 43);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "请将卡片放置在读卡器上";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblInfo.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblmsg
            // 
            this.lblmsg.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblmsg.Location = new System.Drawing.Point(237, 190);
            this.lblmsg.Name = "lblmsg";
            this.lblmsg.Size = new System.Drawing.Size(284, 23);
            this.lblmsg.TabIndex = 2;
            this.lblmsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblmsg.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // ReadCard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(783, 295);
            this.Controls.Add(this.lblmsg);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.uiWaitingBar1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReadCard";
            this.Text = "读卡(按ESC退出)";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 783, 295);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReadCard_FormClosed);
            this.Load += new System.EventHandler(this.ReadCard_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ReadCard_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIWaitingBar uiWaitingBar1;
        private Sunny.UI.UILabel lblInfo;
        private System.Windows.Forms.Timer timer1;
        private Sunny.UI.UILabel lblmsg;
    }
}