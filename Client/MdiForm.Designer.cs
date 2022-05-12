namespace Client
{
    partial class MdiForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MdiForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.业务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGuahao = new System.Windows.Forms.ToolStripMenuItem();
            this.ghcx = new System.Windows.Forms.ToolStripMenuItem();
            this.jchbwh = new System.Windows.Forms.ToolStripMenuItem();
            this.schb = new System.Windows.Forms.ToolStripMenuItem();
            this.uiToolTip1 = new Sunny.UI.UIToolTip(this.components);
            this.pnlForm = new Sunny.UI.UIPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblMidhost = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlsInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.业务ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(2, 35);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1200, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 业务ToolStripMenuItem
            // 
            this.业务ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuGuahao,
            this.ghcx,
            this.jchbwh,
            this.schb});
            this.业务ToolStripMenuItem.Name = "业务ToolStripMenuItem";
            this.业务ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.业务ToolStripMenuItem.Text = "业务";
            // 
            // menuGuahao
            // 
            this.menuGuahao.Name = "menuGuahao";
            this.menuGuahao.Size = new System.Drawing.Size(148, 22);
            this.menuGuahao.Text = "挂号";
            this.menuGuahao.Click += new System.EventHandler(this.menuGuahao_Click);
            // 
            // ghcx
            // 
            this.ghcx.Name = "ghcx";
            this.ghcx.Size = new System.Drawing.Size(148, 22);
            this.ghcx.Text = "挂号查询";
            this.ghcx.Click += new System.EventHandler(this.ghcx_Click);
            // 
            // jchbwh
            // 
            this.jchbwh.Name = "jchbwh";
            this.jchbwh.Size = new System.Drawing.Size(148, 22);
            this.jchbwh.Text = "基础号表维护";
            this.jchbwh.Click += new System.EventHandler(this.jchbwh_Click);
            // 
            // schb
            // 
            this.schb.Name = "schb";
            this.schb.Size = new System.Drawing.Size(148, 22);
            this.schb.Text = "生成号表";
            this.schb.Click += new System.EventHandler(this.schb_Click);
            // 
            // uiToolTip1
            // 
            this.uiToolTip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.uiToolTip1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.uiToolTip1.OwnerDraw = true;
            this.uiToolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.uiToolTip1_Popup);
            // 
            // pnlForm
            // 
            this.pnlForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlForm.AutoSize = true;
            this.pnlForm.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.pnlForm.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.pnlForm.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlForm.Location = new System.Drawing.Point(2, 58);
            this.pnlForm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlForm.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.pnlForm.Size = new System.Drawing.Size(1200, 606);
            this.pnlForm.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.pnlForm.TabIndex = 3;
            this.pnlForm.Text = null;
            this.pnlForm.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.statusStrip1.Location = new System.Drawing.Point(2, 665);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1200, 26);
            this.statusStrip1.TabIndex = 5;
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
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MdiForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1204, 693);
            this.ControlBoxFillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(171)))), ((int)(((byte)(160)))));
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.menuStrip1);
            this.ExtendSymbol = 61693;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MdiForm";
            this.Padding = new System.Windows.Forms.Padding(2, 35, 2, 2);
            this.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.ShowDragStretch = true;
            this.ShowRadius = false;
            this.ShowTitleIcon = true;
            this.Style = Sunny.UI.UIStyle.LayuiGreen;
            this.Text = "门诊挂号子系统";
            this.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MdiForm_FormClosing);
            this.Load += new System.EventHandler(this.MdiForm_Load);
            this.Resize += new System.EventHandler(this.MdiForm_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 业务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuGuahao;
        private System.Windows.Forms.ToolStripMenuItem ghcx;
        private Sunny.UI.UIToolTip uiToolTip1;
        private Sunny.UI.UIPanel pnlForm;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslblName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel tsslblMidhost;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.ToolStripStatusLabel tlsInfo;
        protected System.Windows.Forms.ToolStripStatusLabel tsslblTime;
        private System.Windows.Forms.ToolStripMenuItem jchbwh;
        private System.Windows.Forms.ToolStripMenuItem schb;
    }
}