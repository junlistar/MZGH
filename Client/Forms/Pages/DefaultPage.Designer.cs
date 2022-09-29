namespace Client.Forms.Pages
{
    partial class DefaultPage
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
            this.gbxUnits = new Sunny.UI.UIFlowLayoutPanel();
            this.cdgv = new Sunny.UI.UIComboDataGridView();
            this.uiButton1 = new Sunny.UI.UIButton();
            this.SuspendLayout();
            // 
            // gbxUnits
            // 
            this.gbxUnits.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbxUnits.Location = new System.Drawing.Point(13, 14);
            this.gbxUnits.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbxUnits.MinimumSize = new System.Drawing.Size(1, 1);
            this.gbxUnits.Name = "gbxUnits";
            this.gbxUnits.Padding = new System.Windows.Forms.Padding(2);
            this.gbxUnits.ShowText = false;
            this.gbxUnits.Size = new System.Drawing.Size(1186, 527);
            this.gbxUnits.TabIndex = 0;
            this.gbxUnits.Text = "uiFlowLayoutPanel1";
            this.gbxUnits.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.gbxUnits.Visible = false;
            this.gbxUnits.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cdgv
            // 
            this.cdgv.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cdgv.FillColor = System.Drawing.Color.White;
            this.cdgv.FilterColumnName = "code";
            this.cdgv.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cdgv.Location = new System.Drawing.Point(145, 580);
            this.cdgv.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cdgv.MinimumSize = new System.Drawing.Size(63, 0);
            this.cdgv.Name = "cdgv";
            this.cdgv.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cdgv.ShowFilter = true;
            this.cdgv.Size = new System.Drawing.Size(150, 29);
            this.cdgv.TabIndex = 1;
            this.cdgv.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cdgv.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.cdgv.ButtonClick += new System.EventHandler(this.cdgv_ButtonClick);
            this.cdgv.Click += new System.EventHandler(this.cdgv_Click);
            // 
            // uiButton1
            // 
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton1.Location = new System.Drawing.Point(323, 580);
            this.uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(100, 35);
            this.uiButton1.TabIndex = 2;
            this.uiButton1.Text = "加载数据";
            this.uiButton1.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // DefaultPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1212, 807);
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.cdgv);
            this.Controls.Add(this.gbxUnits);
            this.KeyPreview = true;
            this.Name = "DefaultPage";
            this.PageIndex = 1000;
            this.Text = "欢迎";
            this.Initialize += new System.EventHandler(this.DefaultPage_Initialize);
            this.Load += new System.EventHandler(this.DefaultPage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIFlowLayoutPanel gbxUnits;
        private Sunny.UI.UIComboDataGridView cdgv;
        private Sunny.UI.UIButton uiButton1;
    }
}