namespace MainFrame
{
    partial class TestForm
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
            this.appContainer1 = new MainFrame.AppContainer(this.components);
            this.SuspendLayout();
            // 
            // appContainer1
            // 
            this.appContainer1.AppFilename = "";
            this.appContainer1.AppProcess = null;
            this.appContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.appContainer1.Location = new System.Drawing.Point(0, 0);
            this.appContainer1.Name = "appContainer1";
            this.appContainer1.Size = new System.Drawing.Size(800, 450);
            this.appContainer1.TabIndex = 0;
            // 
            // Container
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.appContainer1);
            this.Name = "Container";
            this.Text = "Container";
            this.Initialize += new System.EventHandler(this.Container_Initialize);
            this.Load += new System.EventHandler(this.Container_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private AppContainer appContainer1;
    }
}