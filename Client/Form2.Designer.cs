namespace GuXHis
{
    partial class Form2
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
            this.uiComboDataGridView1 = new Sunny.UI.UIComboDataGridView();
            this.uiComboTreeView1 = new Sunny.UI.UIComboTreeView();
            this.userControl11 = new GuXHis.ClassLib.UserControl1();
            this.SuspendLayout();
            // 
            // uiComboDataGridView1
            // 
            this.uiComboDataGridView1.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.uiComboDataGridView1.FillColor = System.Drawing.Color.White;
            this.uiComboDataGridView1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiComboDataGridView1.Location = new System.Drawing.Point(76, 278);
            this.uiComboDataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiComboDataGridView1.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiComboDataGridView1.Name = "uiComboDataGridView1";
            this.uiComboDataGridView1.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiComboDataGridView1.ShowFilter = true;
            this.uiComboDataGridView1.Size = new System.Drawing.Size(282, 41);
            this.uiComboDataGridView1.StyleCustomMode = true;
            this.uiComboDataGridView1.TabIndex = 18;
            this.uiComboDataGridView1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiComboDataGridView1.Watermark = "";
            this.uiComboDataGridView1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiComboDataGridView1.ValueChanged += new Sunny.UI.UIComboDataGridView.OnValueChanged(this.uiComboDataGridView1_ValueChanged);
            this.uiComboDataGridView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.uiComboDataGridView1_KeyUp);
            this.uiComboDataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.uiComboDataGridView1_KeyPress);
            this.uiComboDataGridView1.TextChanged += new System.EventHandler(this.uiComboDataGridView1_TextChanged);
            this.uiComboDataGridView1.AutoValidateChanged += new System.EventHandler(this.uiComboDataGridView1_AutoValidateChanged);
            this.uiComboDataGridView1.BindingContextChanged += new System.EventHandler(this.uiComboDataGridView1_BindingContextChanged);
            // 
            // uiComboTreeView1
            // 
            this.uiComboTreeView1.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.uiComboTreeView1.FillColor = System.Drawing.Color.White;
            this.uiComboTreeView1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiComboTreeView1.Location = new System.Drawing.Point(76, 231);
            this.uiComboTreeView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiComboTreeView1.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiComboTreeView1.Name = "uiComboTreeView1";
            this.uiComboTreeView1.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiComboTreeView1.Size = new System.Drawing.Size(150, 29);
            this.uiComboTreeView1.TabIndex = 19;
            this.uiComboTreeView1.Text = "uiComboTreeView1";
            this.uiComboTreeView1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiComboTreeView1.Watermark = "";
            this.uiComboTreeView1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // userControl11
            // 
            this.userControl11.Location = new System.Drawing.Point(153, 28);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(280, 58);
            this.userControl11.TabIndex = 0;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.uiComboTreeView1);
            this.Controls.Add(this.uiComboDataGridView1);
            this.Controls.Add(this.userControl11);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ClassLib.UserControl1 userControl11;
        private Sunny.UI.UIComboDataGridView uiComboDataGridView1;
        private Sunny.UI.UIComboTreeView uiComboTreeView1;
    }
}