﻿using Sunny.UI;

namespace GuxHis.Mzsf
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FHeaderAsideMainFooter));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblMidhost = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlsInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timerSignal = new System.Windows.Forms.Timer(this.components);
            this.timerlogout = new System.Windows.Forms.Timer(this.components);
            this.uiStyleManager1 = new Sunny.UI.UIStyleManager(this.components);
            this.uiContextMenuStrip1 = new Sunny.UI.UIContextMenuStrip();
            this.lblAbout = new System.Windows.Forms.LinkLabel();
            this.Footer.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Footer
            // 
            this.Footer.Controls.Add(this.lblAbout);
            this.Footer.Controls.Add(this.statusStrip1);
            this.Footer.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(178)))), ((int)(((byte)(181)))));
            this.Footer.Location = new System.Drawing.Point(250, 696);
            this.Footer.Size = new System.Drawing.Size(774, 24);
            this.Footer.Style = Sunny.UI.UIStyle.Custom;
            this.Footer.StyleCustomMode = true;
            // 
            // Aside
            // 
            this.Aside.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(95)))), ((int)(((byte)(145)))));
            this.Aside.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Aside.ExpandSelectFirst = false;
            this.Aside.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(95)))), ((int)(((byte)(145)))));
            this.Aside.ForeColor = System.Drawing.Color.White;
            this.Aside.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(146)))), ((int)(((byte)(151)))));
            this.Aside.Indent = 25;
            this.Aside.LineColor = System.Drawing.Color.Red;
            this.Aside.Margin = new System.Windows.Forms.Padding(10);
            this.Aside.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.Aside.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(146)))), ((int)(((byte)(151)))));
            this.Aside.ScrollBarHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(146)))), ((int)(((byte)(151)))));
            this.Aside.ScrollBarPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(146)))), ((int)(((byte)(151)))));
            this.Aside.ScrollFillColor = System.Drawing.Color.White;
            this.Aside.SecondBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(95)))), ((int)(((byte)(145)))));
            this.Aside.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(146)))), ((int)(((byte)(151)))));
            this.Aside.SelectedColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(146)))), ((int)(((byte)(151)))));
            this.Aside.SelectedForeColor = System.Drawing.Color.White;
            this.Aside.SelectedHighColor = System.Drawing.Color.White;
            this.Aside.ShowSecondBackColor = true;
            this.Aside.Size = new System.Drawing.Size(250, 575);
            this.Aside.Style = Sunny.UI.UIStyle.Custom;
            this.Aside.StyleCustomMode = true;
            this.Aside.MenuItemClick += new Sunny.UI.UINavMenu.OnMenuItemClick(this.Aside_MenuItemClick);
            // 
            // Header
            // 
            this.Header.Size = new System.Drawing.Size(1024, 110);
            this.Header.Style = Sunny.UI.UIStyle.Custom;
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
            // uiContextMenuStrip1
            // 
            this.uiContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiContextMenuStrip1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiContextMenuStrip1.Name = "uiContextMenuStrip1";
            this.uiContextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            this.uiContextMenuStrip1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiContextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.uiContextMenuStrip1_ItemClicked);
            // 
            // lblAbout
            // 
            this.lblAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAbout.AutoSize = true;
            this.lblAbout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblAbout.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblAbout.Location = new System.Drawing.Point(729, 0);
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.Size = new System.Drawing.Size(42, 21);
            this.lblAbout.TabIndex = 7;
            this.lblAbout.TabStop = true;
            this.lblAbout.Text = "关于";
            this.lblAbout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAbout_LinkClicked);
            // 
            // FHeaderAsideMainFooter
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1024, 720);
            this.CloseAskString = "";
            this.ExtendBox = true;
            this.ExtendMenu = this.uiContextMenuStrip1;
            this.ExtendSymbol = 362783;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FHeaderAsideMainFooter";
            this.ShowTitleIcon = true;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "门诊挂号系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 1024, 720);
            this.Load += new System.EventHandler(this.FHeaderAsideMainFooter_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FHeaderAsideMainFooter_KeyUp);
            this.Controls.SetChildIndex(this.Header, 0);
            this.Controls.SetChildIndex(this.Aside, 0);
            this.Controls.SetChildIndex(this.Footer, 0);
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
        private System.Windows.Forms.Timer timerSignal;
        private System.Windows.Forms.Timer timerlogout;
        private UIStyleManager uiStyleManager1;
        private UIContextMenuStrip uiContextMenuStrip1;
        private System.Windows.Forms.LinkLabel lblAbout;
    }
}