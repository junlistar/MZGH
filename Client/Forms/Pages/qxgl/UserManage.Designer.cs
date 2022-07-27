namespace Client.Forms.Pages.qxgl
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
            this.components = new System.ComponentModel.Container();
            this.pnlTitle = new Sunny.UI.UIPanel();
            this.btnSaveMenu = new Sunny.UI.UISymbolButton();
            this.btnReports = new Sunny.UI.UISymbolButton();
            this.btnFunctions = new Sunny.UI.UISymbolButton();
            this.btnExit = new Sunny.UI.UISymbolButton();
            this.lblTitle = new Sunny.UI.UILabel();
            this.tv_groups = new Sunny.UI.UITreeView();
            this.cms_group = new Sunny.UI.UIContextMenuStrip();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.uiTitlePanel1 = new Sunny.UI.UITitlePanel();
            this.uiTitlePanel2 = new Sunny.UI.UITitlePanel();
            this.tv_users = new Sunny.UI.UITreeView();
            this.cms_user = new Sunny.UI.UIContextMenuStrip();
            this.uiTitlePanel3 = new Sunny.UI.UITitlePanel();
            this.tv_functions = new Sunny.UI.UITreeView();
            this.cms_functions = new Sunny.UI.UIContextMenuStrip();
            this.uiTitlePanel4 = new Sunny.UI.UITitlePanel();
            this.tv_reports = new Sunny.UI.UITreeView();
            this.cms_reports = new Sunny.UI.UIContextMenuStrip();
            this.uiTitlePanel5 = new Sunny.UI.UITitlePanel();
            this.tv_func_select = new Sunny.UI.UITreeView();
            this.pnlTitle.SuspendLayout();
            this.uiTitlePanel1.SuspendLayout();
            this.uiTitlePanel2.SuspendLayout();
            this.uiTitlePanel3.SuspendLayout();
            this.uiTitlePanel4.SuspendLayout();
            this.uiTitlePanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTitle.Controls.Add(this.btnSaveMenu);
            this.pnlTitle.Controls.Add(this.btnReports);
            this.pnlTitle.Controls.Add(this.btnFunctions);
            this.pnlTitle.Controls.Add(this.btnExit);
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Controls.Add(this.uiTitlePanel3);
            this.pnlTitle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlTitle.Location = new System.Drawing.Point(13, 14);
            this.pnlTitle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlTitle.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(1344, 66);
            this.pnlTitle.TabIndex = 16;
            this.pnlTitle.Text = null;
            this.pnlTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlTitle.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnSaveMenu
            // 
            this.btnSaveMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveMenu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnSaveMenu.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnSaveMenu.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(203)))), ((int)(((byte)(83)))));
            this.btnSaveMenu.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnSaveMenu.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnSaveMenu.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSaveMenu.Location = new System.Drawing.Point(368, 3);
            this.btnSaveMenu.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSaveMenu.Name = "btnSaveMenu";
            this.btnSaveMenu.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnSaveMenu.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(203)))), ((int)(((byte)(83)))));
            this.btnSaveMenu.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnSaveMenu.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnSaveMenu.Size = new System.Drawing.Size(138, 60);
            this.btnSaveMenu.Style = Sunny.UI.UIStyle.Green;
            this.btnSaveMenu.StyleCustomMode = true;
            this.btnSaveMenu.Symbol = 61573;
            this.btnSaveMenu.TabIndex = 12;
            this.btnSaveMenu.Text = "保存菜单";
            this.btnSaveMenu.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSaveMenu.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnSaveMenu.Click += new System.EventHandler(this.btnSaveMenu_Click);
            // 
            // btnReports
            // 
            this.btnReports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReports.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnReports.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnReports.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(203)))), ((int)(((byte)(83)))));
            this.btnReports.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnReports.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnReports.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReports.Location = new System.Drawing.Point(869, 3);
            this.btnReports.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnReports.Name = "btnReports";
            this.btnReports.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnReports.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(203)))), ((int)(((byte)(83)))));
            this.btnReports.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnReports.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnReports.Size = new System.Drawing.Size(110, 58);
            this.btnReports.Style = Sunny.UI.UIStyle.Green;
            this.btnReports.StyleCustomMode = true;
            this.btnReports.Symbol = 61890;
            this.btnReports.TabIndex = 11;
            this.btnReports.Text = "报表";
            this.btnReports.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReports.Visible = false;
            this.btnReports.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnFunctions
            // 
            this.btnFunctions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFunctions.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnFunctions.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnFunctions.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(203)))), ((int)(((byte)(83)))));
            this.btnFunctions.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnFunctions.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnFunctions.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFunctions.Location = new System.Drawing.Point(753, 3);
            this.btnFunctions.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnFunctions.Name = "btnFunctions";
            this.btnFunctions.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnFunctions.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(203)))), ((int)(((byte)(83)))));
            this.btnFunctions.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnFunctions.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(152)))), ((int)(((byte)(32)))));
            this.btnFunctions.Size = new System.Drawing.Size(110, 58);
            this.btnFunctions.Style = Sunny.UI.UIStyle.Green;
            this.btnFunctions.StyleCustomMode = true;
            this.btnFunctions.Symbol = 61573;
            this.btnFunctions.TabIndex = 10;
            this.btnFunctions.Text = "功能";
            this.btnFunctions.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFunctions.Visible = false;
            this.btnFunctions.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnFunctions.Click += new System.EventHandler(this.btnFunctions_Click);
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnExit.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnExit.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.btnExit.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnExit.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnExit.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.Location = new System.Drawing.Point(512, 3);
            this.btnExit.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnExit.Name = "btnExit";
            this.btnExit.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnExit.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.btnExit.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnExit.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnExit.Size = new System.Drawing.Size(144, 60);
            this.btnExit.Style = Sunny.UI.UIStyle.Red;
            this.btnExit.StyleCustomMode = true;
            this.btnExit.Symbol = 61579;
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "退出";
            this.btnExit.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(45, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(134, 51);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "用户管理";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
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
            this.tv_groups.Size = new System.Drawing.Size(328, 553);
            this.tv_groups.Style = Sunny.UI.UIStyle.LayuiOrange;
            this.tv_groups.StyleCustomMode = true;
            this.tv_groups.TabIndex = 17;
            this.tv_groups.Text = "uiTreeView1";
            this.tv_groups.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.tv_groups.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.tv_groups.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_groups_AfterSelect);
            // 
            // cms_group
            // 
            this.cms_group.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.cms_group.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cms_group.Name = "cms_group";
            this.cms_group.Size = new System.Drawing.Size(61, 4);
            this.cms_group.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // uiTitlePanel1
            // 
            this.uiTitlePanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.uiTitlePanel1.Controls.Add(this.tv_groups);
            this.uiTitlePanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(238)))));
            this.uiTitlePanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(238)))));
            this.uiTitlePanel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTitlePanel1.Location = new System.Drawing.Point(13, 90);
            this.uiTitlePanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTitlePanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTitlePanel1.Name = "uiTitlePanel1";
            this.uiTitlePanel1.Padding = new System.Windows.Forms.Padding(0, 35, 0, 0);
            this.uiTitlePanel1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(0)))));
            this.uiTitlePanel1.ShowText = false;
            this.uiTitlePanel1.Size = new System.Drawing.Size(336, 600);
            this.uiTitlePanel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiTitlePanel1.StyleCustomMode = true;
            this.uiTitlePanel1.TabIndex = 19;
            this.uiTitlePanel1.Text = "用户组";
            this.uiTitlePanel1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.uiTitlePanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTitlePanel1.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(0)))));
            this.uiTitlePanel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiTitlePanel2
            // 
            this.uiTitlePanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiTitlePanel2.Controls.Add(this.tv_users);
            this.uiTitlePanel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTitlePanel2.Location = new System.Drawing.Point(747, 90);
            this.uiTitlePanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTitlePanel2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTitlePanel2.Name = "uiTitlePanel2";
            this.uiTitlePanel2.Padding = new System.Windows.Forms.Padding(0, 35, 0, 0);
            this.uiTitlePanel2.ShowText = false;
            this.uiTitlePanel2.Size = new System.Drawing.Size(610, 305);
            this.uiTitlePanel2.TabIndex = 20;
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
            this.tv_users.Size = new System.Drawing.Size(602, 260);
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
            // uiTitlePanel3
            // 
            this.uiTitlePanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.uiTitlePanel3.Controls.Add(this.tv_functions);
            this.uiTitlePanel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTitlePanel3.Location = new System.Drawing.Point(1066, 5);
            this.uiTitlePanel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTitlePanel3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTitlePanel3.Name = "uiTitlePanel3";
            this.uiTitlePanel3.Padding = new System.Windows.Forms.Padding(0, 35, 0, 0);
            this.uiTitlePanel3.ShowText = false;
            this.uiTitlePanel3.Size = new System.Drawing.Size(342, 87);
            this.uiTitlePanel3.TabIndex = 21;
            this.uiTitlePanel3.Text = "菜单列表";
            this.uiTitlePanel3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.uiTitlePanel3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTitlePanel3.Visible = false;
            this.uiTitlePanel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // tv_functions
            // 
            this.tv_functions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tv_functions.ContextMenuStrip = this.cms_functions;
            this.tv_functions.FillColor = System.Drawing.Color.White;
            this.tv_functions.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tv_functions.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.tv_functions.Location = new System.Drawing.Point(4, 39);
            this.tv_functions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tv_functions.MinimumSize = new System.Drawing.Size(1, 1);
            this.tv_functions.Name = "tv_functions";
            this.tv_functions.ShowLines = true;
            this.tv_functions.ShowText = false;
            this.tv_functions.Size = new System.Drawing.Size(334, 41);
            this.tv_functions.TabIndex = 0;
            this.tv_functions.Text = "uiTreeView2";
            this.tv_functions.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.tv_functions.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cms_functions
            // 
            this.cms_functions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.cms_functions.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cms_functions.Name = "cms_functions";
            this.cms_functions.Size = new System.Drawing.Size(61, 4);
            this.cms_functions.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiTitlePanel4
            // 
            this.uiTitlePanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiTitlePanel4.Controls.Add(this.tv_reports);
            this.uiTitlePanel4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTitlePanel4.Location = new System.Drawing.Point(747, 405);
            this.uiTitlePanel4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTitlePanel4.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTitlePanel4.Name = "uiTitlePanel4";
            this.uiTitlePanel4.Padding = new System.Windows.Forms.Padding(0, 35, 0, 0);
            this.uiTitlePanel4.ShowText = false;
            this.uiTitlePanel4.Size = new System.Drawing.Size(610, 280);
            this.uiTitlePanel4.TabIndex = 22;
            this.uiTitlePanel4.Text = "报表";
            this.uiTitlePanel4.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.uiTitlePanel4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTitlePanel4.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // tv_reports
            // 
            this.tv_reports.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tv_reports.ContextMenuStrip = this.cms_reports;
            this.tv_reports.FillColor = System.Drawing.Color.White;
            this.tv_reports.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tv_reports.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.tv_reports.Location = new System.Drawing.Point(4, 39);
            this.tv_reports.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tv_reports.MinimumSize = new System.Drawing.Size(1, 1);
            this.tv_reports.Name = "tv_reports";
            this.tv_reports.ShowLines = true;
            this.tv_reports.ShowText = false;
            this.tv_reports.Size = new System.Drawing.Size(602, 236);
            this.tv_reports.TabIndex = 0;
            this.tv_reports.Text = "uiTreeView3";
            this.tv_reports.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.tv_reports.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cms_reports
            // 
            this.cms_reports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.cms_reports.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cms_reports.Name = "cms_reports";
            this.cms_reports.Size = new System.Drawing.Size(61, 4);
            this.cms_reports.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiTitlePanel5
            // 
            this.uiTitlePanel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.uiTitlePanel5.Controls.Add(this.tv_func_select);
            this.uiTitlePanel5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTitlePanel5.Location = new System.Drawing.Point(357, 90);
            this.uiTitlePanel5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTitlePanel5.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTitlePanel5.Name = "uiTitlePanel5";
            this.uiTitlePanel5.Padding = new System.Windows.Forms.Padding(0, 35, 0, 0);
            this.uiTitlePanel5.ShowText = false;
            this.uiTitlePanel5.Size = new System.Drawing.Size(382, 600);
            this.uiTitlePanel5.TabIndex = 22;
            this.uiTitlePanel5.Text = "菜单选择";
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
            this.tv_func_select.Size = new System.Drawing.Size(374, 554);
            this.tv_func_select.TabIndex = 0;
            this.tv_func_select.Text = "uiTreeView2";
            this.tv_func_select.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.tv_func_select.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // UserManage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1370, 697);
            this.Controls.Add(this.uiTitlePanel5);
            this.Controls.Add(this.uiTitlePanel4);
            this.Controls.Add(this.uiTitlePanel2);
            this.Controls.Add(this.uiTitlePanel1);
            this.Controls.Add(this.pnlTitle);
            this.Name = "UserManage";
            this.PageIndex = 1502;
            this.Text = "UserManage";
            this.Initialize += new System.EventHandler(this.UserManage_Initialize);
            this.pnlTitle.ResumeLayout(false);
            this.uiTitlePanel1.ResumeLayout(false);
            this.uiTitlePanel2.ResumeLayout(false);
            this.uiTitlePanel3.ResumeLayout(false);
            this.uiTitlePanel4.ResumeLayout(false);
            this.uiTitlePanel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIPanel pnlTitle;
        private Sunny.UI.UISymbolButton btnReports;
        private Sunny.UI.UISymbolButton btnFunctions;
        private Sunny.UI.UISymbolButton btnExit;
        private Sunny.UI.UILabel lblTitle;
        private Sunny.UI.UITreeView tv_groups;
        private System.Windows.Forms.ImageList imageList1;
        private Sunny.UI.UITitlePanel uiTitlePanel1;
        private Sunny.UI.UITitlePanel uiTitlePanel2;
        private Sunny.UI.UITreeView tv_users;
        private Sunny.UI.UITitlePanel uiTitlePanel3;
        private Sunny.UI.UITitlePanel uiTitlePanel4;
        private Sunny.UI.UITreeView tv_functions;
        private Sunny.UI.UITreeView tv_reports;
        private Sunny.UI.UIContextMenuStrip cms_group;
        private Sunny.UI.UIContextMenuStrip cms_user;
        private Sunny.UI.UIContextMenuStrip cms_functions;
        private Sunny.UI.UIContextMenuStrip cms_reports;
        private Sunny.UI.UITitlePanel uiTitlePanel5;
        private Sunny.UI.UITreeView tv_func_select;
        private Sunny.UI.UISymbolButton btnSaveMenu;
    }
}