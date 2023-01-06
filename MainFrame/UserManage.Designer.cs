namespace MainFrame
{
    partial class UserManage
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
            this.uiTitlePanel1 = new Sunny.UI.UITitlePanel();
            this.tv_groups = new Sunny.UI.UITreeView();
            this.uiTitlePanel5 = new Sunny.UI.UITitlePanel();
            this.tv_func_select = new Sunny.UI.UITreeView();
            this.uiTitlePanel2 = new Sunny.UI.UITitlePanel();
            this.tv_users = new Sunny.UI.UITreeView();
            this.cms_user = new Sunny.UI.UIContextMenuStrip();
            this.cms_group = new Sunny.UI.UIContextMenuStrip();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiTitlePanel1.SuspendLayout();
            this.uiTitlePanel5.SuspendLayout();
            this.uiTitlePanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiTitlePanel1
            // 
            this.uiTitlePanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.uiTitlePanel1.Controls.Add(this.tv_groups);
            this.uiTitlePanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(238)))));
            this.uiTitlePanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(238)))));
            this.uiTitlePanel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTitlePanel1.Location = new System.Drawing.Point(4, 40);
            this.uiTitlePanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTitlePanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTitlePanel1.Name = "uiTitlePanel1";
            this.uiTitlePanel1.Padding = new System.Windows.Forms.Padding(0, 35, 0, 0);
            this.uiTitlePanel1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(0)))));
            this.uiTitlePanel1.ShowText = false;
            this.uiTitlePanel1.Size = new System.Drawing.Size(344, 632);
            this.uiTitlePanel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiTitlePanel1.StyleCustomMode = true;
            this.uiTitlePanel1.TabIndex = 20;
            this.uiTitlePanel1.Text = "用户组";
            this.uiTitlePanel1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.uiTitlePanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTitlePanel1.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(0)))));
            this.uiTitlePanel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // tv_groups
            // 
            this.tv_groups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tv_groups.ContextMenuStrip = this.cms_group;
            this.tv_groups.FillColor = System.Drawing.Color.White;
            this.tv_groups.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(238)))));
            this.tv_groups.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tv_groups.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.tv_groups.Location = new System.Drawing.Point(4, 40);
            this.tv_groups.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tv_groups.MinimumSize = new System.Drawing.Size(1, 1);
            this.tv_groups.Name = "tv_groups";
            this.tv_groups.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(0)))));
            this.tv_groups.ShowLines = true;
            this.tv_groups.ShowText = false;
            this.tv_groups.Size = new System.Drawing.Size(336, 585);
            this.tv_groups.Style = Sunny.UI.UIStyle.LayuiOrange;
            this.tv_groups.StyleCustomMode = true;
            this.tv_groups.TabIndex = 17;
            this.tv_groups.Text = "uiTreeView1";
            this.tv_groups.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.tv_groups.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.tv_groups.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_groups_AfterSelect);
            // 
            // uiTitlePanel5
            // 
            this.uiTitlePanel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.uiTitlePanel5.Controls.Add(this.uiLabel1);
            this.uiTitlePanel5.Controls.Add(this.tv_func_select);
            this.uiTitlePanel5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTitlePanel5.Location = new System.Drawing.Point(356, 40);
            this.uiTitlePanel5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTitlePanel5.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTitlePanel5.Name = "uiTitlePanel5";
            this.uiTitlePanel5.Padding = new System.Windows.Forms.Padding(0, 35, 0, 0);
            this.uiTitlePanel5.ShowText = false;
            this.uiTitlePanel5.Size = new System.Drawing.Size(382, 632);
            this.uiTitlePanel5.TabIndex = 23;
            this.uiTitlePanel5.Text = "系统选择";
            this.uiTitlePanel5.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.uiTitlePanel5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTitlePanel5.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // tv_func_select
            // 
            this.tv_func_select.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tv_func_select.CheckBoxes = true;
            this.tv_func_select.FillColor = System.Drawing.Color.White;
            this.tv_func_select.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tv_func_select.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.tv_func_select.Location = new System.Drawing.Point(4, 39);
            this.tv_func_select.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tv_func_select.MinimumSize = new System.Drawing.Size(1, 1);
            this.tv_func_select.Name = "tv_func_select";
            this.tv_func_select.ShowLines = true;
            this.tv_func_select.ShowText = false;
            this.tv_func_select.Size = new System.Drawing.Size(374, 586);
            this.tv_func_select.TabIndex = 0;
            this.tv_func_select.Text = "uiTreeView2";
            this.tv_func_select.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.tv_func_select.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiTitlePanel2
            // 
            this.uiTitlePanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiTitlePanel2.Controls.Add(this.tv_users);
            this.uiTitlePanel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTitlePanel2.Location = new System.Drawing.Point(746, 40);
            this.uiTitlePanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTitlePanel2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTitlePanel2.Name = "uiTitlePanel2";
            this.uiTitlePanel2.Padding = new System.Windows.Forms.Padding(0, 35, 0, 0);
            this.uiTitlePanel2.ShowText = false;
            this.uiTitlePanel2.Size = new System.Drawing.Size(383, 632);
            this.uiTitlePanel2.TabIndex = 24;
            this.uiTitlePanel2.Text = "用户";
            this.uiTitlePanel2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.uiTitlePanel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTitlePanel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // tv_users
            // 
            this.tv_users.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tv_users.ContextMenuStrip = this.cms_user;
            this.tv_users.FillColor = System.Drawing.Color.White;
            this.tv_users.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tv_users.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.tv_users.Location = new System.Drawing.Point(4, 40);
            this.tv_users.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tv_users.MinimumSize = new System.Drawing.Size(1, 1);
            this.tv_users.Name = "tv_users";
            this.tv_users.ShowLines = true;
            this.tv_users.ShowText = false;
            this.tv_users.Size = new System.Drawing.Size(375, 587);
            this.tv_users.TabIndex = 17;
            this.tv_users.Text = "uiTreeView1";
            this.tv_users.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.tv_users.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cms_user
            // 
            this.cms_user.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.cms_user.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cms_user.Name = "cms_user";
            this.cms_user.Size = new System.Drawing.Size(61, 4);
            this.cms_user.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cms_group
            // 
            this.cms_group.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.cms_group.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cms_group.Name = "cms_group";
            this.cms_group.Size = new System.Drawing.Size(61, 4);
            this.cms_group.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(332, 11);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(46, 23);
            this.uiLabel1.TabIndex = 1;
            this.uiLabel1.Text = "保存";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiLabel1.Click += new System.EventHandler(this.btnSaveMenu_Click);
            // 
            // UserManage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1133, 684);
            this.Controls.Add(this.uiTitlePanel2);
            this.Controls.Add(this.uiTitlePanel5);
            this.Controls.Add(this.uiTitlePanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserManage";
            this.Text = "用户权限管理";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.Load += new System.EventHandler(this.UserManage_Load);
            this.uiTitlePanel1.ResumeLayout(false);
            this.uiTitlePanel5.ResumeLayout(false);
            this.uiTitlePanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UITitlePanel uiTitlePanel1;
        private Sunny.UI.UITreeView tv_groups;
        private Sunny.UI.UITitlePanel uiTitlePanel5;
        private Sunny.UI.UITreeView tv_func_select;
        private Sunny.UI.UITitlePanel uiTitlePanel2;
        private Sunny.UI.UITreeView tv_users;
        private Sunny.UI.UIContextMenuStrip cms_user;
        private Sunny.UI.UIContextMenuStrip cms_group;
        private Sunny.UI.UILabel uiLabel1;
    }
}