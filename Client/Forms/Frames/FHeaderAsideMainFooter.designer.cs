using Sunny.UI;

namespace Client
{
    partial class FHeaderAsideMainFooter
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblMidhost = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlsInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.uiSignal1 = new Sunny.UI.UISignal();
            this.timerSignal = new System.Windows.Forms.Timer(this.components);
            this.timerlogout = new System.Windows.Forms.Timer(this.components);
            this.Footer.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Footer
            // 
            this.Footer.Controls.Add(this.uiSignal1);
            this.Footer.Controls.Add(this.statusStrip1);
            this.Footer.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(178)))), ((int)(((byte)(181)))));
            this.Footer.Location = new System.Drawing.Point(250, 696);
            this.Footer.Size = new System.Drawing.Size(774, 24);
            this.Footer.Style = Sunny.UI.UIStyle.Custom;
            this.Footer.StyleCustomMode = true;
            // 
            // Aside
            // 
            this.Aside.BackColor = System.Drawing.Color.LightCoral;
            this.Aside.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Aside.FillColor = System.Drawing.Color.LightCoral;
            this.Aside.ForeColor = System.Drawing.Color.White;
            this.Aside.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(179)))), ((int)(((byte)(255)))));
            this.Aside.Indent = 25;
            this.Aside.LineColor = System.Drawing.Color.Red;
            this.Aside.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.Aside.ScrollFillColor = System.Drawing.Color.White;
            this.Aside.SecondBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.Aside.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.Aside.SelectedColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(190)))), ((int)(((byte)(172)))));
            this.Aside.SelectedColorGradient = true;
            this.Aside.SelectedForeColor = System.Drawing.Color.White;
            this.Aside.SelectedHighColor = System.Drawing.Color.White;
            this.Aside.Size = new System.Drawing.Size(250, 575);
            this.Aside.Style = Sunny.UI.UIStyle.Custom;
            this.Aside.MenuItemClick += new Sunny.UI.UINavMenu.OnMenuItemClick(this.Aside_MenuItemClick);
            // 
            // Header
            // 
            this.Header.Size = new System.Drawing.Size(1024, 110);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsslblName,
            this.toolStripStatusLabel3,
            this.tsslblMidhost,
            this.toolStripStatusLabel5,
            this.tsslblTime,
            this.tlsInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, -2);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(774, 26);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(60, 21);
            this.toolStripStatusLabel1.Text = "当前用户";
            // 
            // tsslblName
            // 
            this.tsslblName.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsslblName.Name = "tsslblName";
            this.tsslblName.Size = new System.Drawing.Size(60, 21);
            this.tsslblName.Text = "尼古拉斯";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(72, 21);
            this.toolStripStatusLabel3.Text = "应用服务器";
            // 
            // tsslblMidhost
            // 
            this.tsslblMidhost.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsslblMidhost.Name = "tsslblMidhost";
            this.tsslblMidhost.Size = new System.Drawing.Size(64, 21);
            this.tsslblMidhost.Text = "localhost";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(60, 21);
            this.toolStripStatusLabel5.Text = "当前时间";
            // 
            // tsslblTime
            // 
            this.tsslblTime.Name = "tsslblTime";
            this.tsslblTime.Size = new System.Drawing.Size(131, 21);
            this.tsslblTime.Text = "toolStripStatusLabel6";
            // 
            // tlsInfo
            // 
            this.tlsInfo.ForeColor = System.Drawing.Color.Red;
            this.tlsInfo.Name = "tlsInfo";
            this.tlsInfo.Size = new System.Drawing.Size(131, 21);
            this.tlsInfo.Text = "toolStripStatusLabel2";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // uiSignal1
            // 
            this.uiSignal1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uiSignal1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiSignal1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSignal1.Location = new System.Drawing.Point(735, 4);
            this.uiSignal1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSignal1.Name = "uiSignal1";
            this.uiSignal1.Size = new System.Drawing.Size(39, 16);
            this.uiSignal1.Style = Sunny.UI.UIStyle.Custom;
            this.uiSignal1.TabIndex = 7;
            this.uiSignal1.Text = "uiSignal1";
            this.uiSignal1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // timerSignal
            // 
            this.timerSignal.Interval = 1000;
            this.timerSignal.Tick += new System.EventHandler(this.timerSignal_Tick);
            // 
            // timerlogout
            // 
            this.timerlogout.Interval = 1000;
            this.timerlogout.Tick += new System.EventHandler(this.timerlogout_Tick);
            // 
            // FHeaderAsideMainFooter
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1024, 720);
            this.Name = "FHeaderAsideMainFooter";
            this.Text = "门诊挂号系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 1024, 720);
            this.Load += new System.EventHandler(this.FHeaderAsideMainFooter_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FHeaderAsideMainFooter_KeyUp);
            this.Footer.ResumeLayout(false);
            this.Footer.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslblName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel tsslblMidhost;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        protected System.Windows.Forms.ToolStripStatusLabel tsslblTime;
        public System.Windows.Forms.ToolStripStatusLabel tlsInfo;
        private System.Windows.Forms.Timer timer1;
        private UISignal uiSignal1;
        private System.Windows.Forms.Timer timerSignal;
        private System.Windows.Forms.Timer timerlogout;
    }
}