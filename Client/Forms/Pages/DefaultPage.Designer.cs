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
            this.gbxUnits.Size = new System.Drawing.Size(1186, 691);
            this.gbxUnits.TabIndex = 0;
            this.gbxUnits.Text = "uiFlowLayoutPanel1";
            this.gbxUnits.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.gbxUnits.Visible = false;
            this.gbxUnits.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // DefaultPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1212, 807);
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
    }
}