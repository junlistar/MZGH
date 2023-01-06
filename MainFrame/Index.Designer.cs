namespace MainFrame
{
    partial class Index
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Index));
            this.pnlSystem = new Sunny.UI.UIFlowLayoutPanel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.progressBar = new Sunny.UI.UIProcessBar();
            this.pnlinstall = new Sunny.UI.UIPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSystem
            // 
            this.pnlSystem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pnlSystem.BackColor = System.Drawing.Color.Transparent;
            this.pnlSystem.FillColor = System.Drawing.Color.Transparent;
            this.pnlSystem.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlSystem.Location = new System.Drawing.Point(818, 354);
            this.pnlSystem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlSystem.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlSystem.Name = "pnlSystem";
            this.pnlSystem.Padding = new System.Windows.Forms.Padding(2);
            this.pnlSystem.RectColor = System.Drawing.Color.Transparent;
            this.pnlSystem.ShowText = false;
            this.pnlSystem.Size = new System.Drawing.Size(334, 155);
            this.pnlSystem.Style = Sunny.UI.UIStyle.Custom;
            this.pnlSystem.StyleCustomMode = true;
            this.pnlSystem.TabIndex = 2;
            this.pnlSystem.Text = "uiFlowLayoutPanel1";
            this.pnlSystem.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlSystem.Visible = false;
            this.pnlSystem.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(661, 341);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(511, 268);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(621, 615);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(568, 69);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.progressBar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.progressBar.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.progressBar.Location = new System.Drawing.Point(273, 286);
            this.progressBar.MinimumSize = new System.Drawing.Size(70, 3);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(651, 29);
            this.progressBar.Style = Sunny.UI.UIStyle.Custom;
            this.progressBar.TabIndex = 0;
            this.progressBar.Text = "uiProcessBar1";
            this.progressBar.Visible = false;
            this.progressBar.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // pnlinstall
            // 
            this.pnlinstall.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlinstall.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.pnlinstall.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.pnlinstall.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlinstall.Location = new System.Drawing.Point(484, 236);
            this.pnlinstall.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlinstall.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlinstall.Name = "pnlinstall";
            this.pnlinstall.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.pnlinstall.Size = new System.Drawing.Size(240, 42);
            this.pnlinstall.Style = Sunny.UI.UIStyle.Red;
            this.pnlinstall.TabIndex = 10;
            this.pnlinstall.Text = "正在安装...";
            this.pnlinstall.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlinstall.Visible = false;
            this.pnlinstall.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // Index
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1202, 743);
            this.Controls.Add(this.pnlinstall);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pnlSystem);
            this.Name = "Index";
            this.Style = Sunny.UI.UIStyle.Custom;
            this.StyleCustomMode = true;
            this.Text = "主页";
            this.Initialize += new System.EventHandler(this.Index_Initialize);
            this.Load += new System.EventHandler(this.Index_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIFlowLayoutPanel pnlSystem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Sunny.UI.UIProcessBar progressBar;
        private Sunny.UI.UIPanel pnlinstall;
    }
}