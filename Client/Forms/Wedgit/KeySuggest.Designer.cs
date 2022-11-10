namespace Client.Forms.Wedgit
{
    partial class KeySuggest
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
            this.txtKeySearch = new Sunny.UI.UITextBox();
            this.lstunits = new Sunny.UI.UIListBox();
            this.SuspendLayout();
            // 
            // txtKeySearch
            // 
            this.txtKeySearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtKeySearch.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtKeySearch.Location = new System.Drawing.Point(17, 46);
            this.txtKeySearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtKeySearch.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtKeySearch.Name = "txtKeySearch";
            this.txtKeySearch.ShowText = false;
            this.txtKeySearch.Size = new System.Drawing.Size(305, 29);
            this.txtKeySearch.TabIndex = 3;
            this.txtKeySearch.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtKeySearch.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txtKeySearch.TextChanged += new System.EventHandler(this.txtKeySearch_TextChanged);
            this.txtKeySearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtKeySearch_KeyUp);
            // 
            // lstunits
            // 
            this.lstunits.FillColor = System.Drawing.Color.White;
            this.lstunits.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lstunits.Location = new System.Drawing.Point(17, 84);
            this.lstunits.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstunits.MinimumSize = new System.Drawing.Size(1, 1);
            this.lstunits.Name = "lstunits";
            this.lstunits.Padding = new System.Windows.Forms.Padding(2);
            this.lstunits.ShowText = false;
            this.lstunits.Size = new System.Drawing.Size(305, 180);
            this.lstunits.TabIndex = 4;
            this.lstunits.Text = "uiListBox1";
            this.lstunits.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.lstunits.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lstunits_KeyUp);
            //this.lstunits.ItemClick += new System.EventHandler(this.lstunits_ItemClick);
            // 
            // KeySuggest
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(340, 280);
            this.Controls.Add(this.lstunits);
            this.Controls.Add(this.txtKeySearch);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KeySuggest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "筛选科室";
            this.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(95)))), ((int)(((byte)(145)))));
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 340, 280);
            this.Load += new System.EventHandler(this.KeySuggest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public Sunny.UI.UITextBox txtKeySearch;
        private Sunny.UI.UIListBox lstunits;
    }
}