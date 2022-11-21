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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("门诊业务");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("住院业务");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("医技业务");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("数据查询");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("系统维护");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("字典维护");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Index));
            this.pnlSystem = new Sunny.UI.UIFlowLayoutPanel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.navMenu = new Sunny.UI.UINavMenu();
            this.uiImageButton2 = new Sunny.UI.UIImageButton();
            this.uiButton1 = new Sunny.UI.UIButton();
            this.uiImageButton1 = new Sunny.UI.UIImageButton();
            ((System.ComponentModel.ISupportInitialize)(this.uiImageButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiImageButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSystem
            // 
            this.pnlSystem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pnlSystem.BackColor = System.Drawing.Color.Transparent;
            this.pnlSystem.FillColor = System.Drawing.Color.Transparent;
            this.pnlSystem.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlSystem.Location = new System.Drawing.Point(250, 119);
            this.pnlSystem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlSystem.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlSystem.Name = "pnlSystem";
            this.pnlSystem.Padding = new System.Windows.Forms.Padding(2);
            this.pnlSystem.RectColor = System.Drawing.Color.Transparent;
            this.pnlSystem.ShowText = false;
            this.pnlSystem.Size = new System.Drawing.Size(778, 531);
            this.pnlSystem.Style = Sunny.UI.UIStyle.Custom;
            this.pnlSystem.StyleCustomMode = true;
            this.pnlSystem.TabIndex = 2;
            this.pnlSystem.Text = "uiFlowLayoutPanel1";
            this.pnlSystem.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlSystem.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(23, 708);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(100, 23);
            this.uiLabel1.TabIndex = 3;
            this.uiLabel1.Text = "编辑子系统";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiLabel1.Click += new System.EventHandler(this.uiLabel1_Click);
            // 
            // navMenu
            // 
            this.navMenu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.navMenu.BackColor = System.Drawing.SystemColors.Window;
            this.navMenu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.navMenu.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.navMenu.FillColor = System.Drawing.Color.Orange;
            this.navMenu.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.navMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.navMenu.FullRowSelect = true;
            this.navMenu.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.navMenu.ItemHeight = 50;
            this.navMenu.LineColor = System.Drawing.Color.Red;
            this.navMenu.Location = new System.Drawing.Point(70, 221);
            this.navMenu.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.navMenu.Name = "navMenu";
            treeNode1.Name = "节点0";
            treeNode1.Text = "门诊业务";
            treeNode2.Name = "节点1";
            treeNode2.Text = "住院业务";
            treeNode3.Name = "节点2";
            treeNode3.Text = "医技业务";
            treeNode4.Name = "节点3";
            treeNode4.Text = "数据查询";
            treeNode5.Name = "节点4";
            treeNode5.Text = "系统维护";
            treeNode6.Name = "节点5";
            treeNode6.Text = "字典维护";
            this.navMenu.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6});
            this.navMenu.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.navMenu.ScrollBarHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.navMenu.ScrollBarPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.navMenu.ScrollFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.navMenu.SecondBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.navMenu.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.navMenu.SelectedColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.navMenu.SelectedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.navMenu.SelectedHighColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.navMenu.ShowLines = false;
            this.navMenu.Size = new System.Drawing.Size(183, 300);
            this.navMenu.Style = Sunny.UI.UIStyle.Green;
            this.navMenu.StyleCustomMode = true;
            this.navMenu.TabIndex = 5;
            this.navMenu.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.navMenu.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.navMenu.MenuItemClick += new Sunny.UI.UINavMenu.OnMenuItemClick(this.navMenu_MenuItemClick);
            // 
            // uiImageButton2
            // 
            this.uiImageButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiImageButton2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiImageButton2.Image = global::MainFrame.Properties.Resources.login_bg;
            this.uiImageButton2.Location = new System.Drawing.Point(195, 76);
            this.uiImageButton2.Name = "uiImageButton2";
            this.uiImageButton2.Size = new System.Drawing.Size(100, 69);
            this.uiImageButton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.uiImageButton2.TabIndex = 8;
            this.uiImageButton2.TabStop = false;
            this.uiImageButton2.Text = "uiImageButton2";
            this.uiImageButton2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.uiImageButton2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiButton1
            // 
            this.uiButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("uiButton1.BackgroundImage")));
            this.uiButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton1.Location = new System.Drawing.Point(58, 76);
            this.uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.uiButton1.Size = new System.Drawing.Size(103, 69);
            this.uiButton1.TabIndex = 7;
            this.uiButton1.Text = "uiButton1";
            this.uiButton1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.uiButton1.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiImageButton1
            // 
            this.uiImageButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiImageButton1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiImageButton1.Image = global::MainFrame.Properties.Resources._1;
            this.uiImageButton1.ImageOffset = new System.Drawing.Point(120, 5);
            this.uiImageButton1.Location = new System.Drawing.Point(70, 560);
            this.uiImageButton1.Name = "uiImageButton1";
            this.uiImageButton1.Size = new System.Drawing.Size(64, 64);
            this.uiImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.uiImageButton1.StyleCustomMode = true;
            this.uiImageButton1.TabIndex = 6;
            this.uiImageButton1.TabStop = false;
            this.uiImageButton1.Text = "123";
            this.uiImageButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiImageButton1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // Index
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1202, 743);
            this.Controls.Add(this.uiImageButton2);
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.uiImageButton1);
            this.Controls.Add(this.navMenu);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.pnlSystem);
            this.Name = "Index";
            this.Text = "主页";
            this.Initialize += new System.EventHandler(this.Index_Initialize);
            this.Load += new System.EventHandler(this.Index_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uiImageButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiImageButton1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIFlowLayoutPanel pnlSystem;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UINavMenu navMenu;
        private Sunny.UI.UIImageButton uiImageButton1;
        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UIImageButton uiImageButton2;
    }
}