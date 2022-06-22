namespace Mzsf.Forms.Wedgit
{
    partial class ReadCika
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
            this.lblkahao = new Sunny.UI.UILabel();
            this.txtCode = new Sunny.UI.UITextBox();
            this.lblmsg = new Sunny.UI.UILabel();
            this.SuspendLayout();
            // 
            // lblkahao
            // 
            this.lblkahao.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblkahao.Location = new System.Drawing.Point(94, 90);
            this.lblkahao.Name = "lblkahao";
            this.lblkahao.Size = new System.Drawing.Size(85, 39);
            this.lblkahao.TabIndex = 0;
            this.lblkahao.Text = "卡号";
            this.lblkahao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblkahao.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txtCode
            // 
            this.txtCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCode.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCode.Location = new System.Drawing.Point(186, 80);
            this.txtCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCode.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtCode.Name = "txtCode";
            this.txtCode.ShowText = false;
            this.txtCode.Size = new System.Drawing.Size(340, 57);
            this.txtCode.TabIndex = 1;
            this.txtCode.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtCode.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txtCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyUp);
            // 
            // lblmsg
            // 
            this.lblmsg.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblmsg.Location = new System.Drawing.Point(182, 154);
            this.lblmsg.Name = "lblmsg";
            this.lblmsg.Size = new System.Drawing.Size(284, 23);
            this.lblmsg.TabIndex = 3;
            this.lblmsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblmsg.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // ReadCika
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(690, 203);
            this.Controls.Add(this.lblmsg);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblkahao);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReadCika";
            this.Text = "读磁卡";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.Load += new System.EventHandler(this.ReadCika_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UILabel lblkahao;
        private Sunny.UI.UITextBox txtCode;
        private Sunny.UI.UILabel lblmsg;
    }
}