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
            this.pnlSystem = new Sunny.UI.UIFlowLayoutPanel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.pnlColor = new Sunny.UI.UIFlowLayoutPanel();
            this.SuspendLayout();
            // 
            // pnlSystem
            // 
            this.pnlSystem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pnlSystem.BackColor = System.Drawing.Color.Transparent;
            this.pnlSystem.FillColor = System.Drawing.Color.Transparent;
            this.pnlSystem.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlSystem.Location = new System.Drawing.Point(815, 119);
            this.pnlSystem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlSystem.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlSystem.Name = "pnlSystem";
            this.pnlSystem.Padding = new System.Windows.Forms.Padding(2);
            this.pnlSystem.RectColor = System.Drawing.Color.Transparent;
            this.pnlSystem.ShowText = false;
            this.pnlSystem.Size = new System.Drawing.Size(334, 426);
            this.pnlSystem.Style = Sunny.UI.UIStyle.Custom;
            this.pnlSystem.StyleCustomMode = true;
            this.pnlSystem.TabIndex = 2;
            this.pnlSystem.Text = "uiFlowLayoutPanel1";
            this.pnlSystem.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlSystem.Visible = false;
            this.pnlSystem.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(23, 708);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(100, 23);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 3;
            this.uiLabel1.Text = "编辑子系统";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiLabel1.Click += new System.EventHandler(this.uiLabel1_Click);
            // 
            // pnlColor
            // 
            this.pnlColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlColor.BackColor = System.Drawing.Color.Transparent;
            this.pnlColor.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlColor.Location = new System.Drawing.Point(836, 14);
            this.pnlColor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlColor.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlColor.Name = "pnlColor";
            this.pnlColor.Padding = new System.Windows.Forms.Padding(2);
            this.pnlColor.RectColor = System.Drawing.Color.Transparent;
            this.pnlColor.ShowText = false;
            this.pnlColor.Size = new System.Drawing.Size(353, 54);
            this.pnlColor.Style = Sunny.UI.UIStyle.Custom;
            this.pnlColor.StyleCustomMode = true;
            this.pnlColor.TabIndex = 5;
            this.pnlColor.Text = "uiFlowLayoutPanel1";
            this.pnlColor.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlColor.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // Index
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1202, 743);
            this.Controls.Add(this.pnlColor);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.pnlSystem);
            this.Name = "Index";
            this.Style = Sunny.UI.UIStyle.Custom;
            this.StyleCustomMode = true;
            this.Text = "主页";
            this.Initialize += new System.EventHandler(this.Index_Initialize);
            this.Load += new System.EventHandler(this.Index_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIFlowLayoutPanel pnlSystem;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIFlowLayoutPanel pnlColor;
    }
}