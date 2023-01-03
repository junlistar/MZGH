namespace GuXHis.ClassLib
{
    partial class UserControl1
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtks = new Sunny.UI.UITextBox();
            this.uiButton1 = new Sunny.UI.UIButton();
            this.SuspendLayout();
            // 
            // txtks
            // 
            this.txtks.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtks.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtks.Location = new System.Drawing.Point(5, 5);
            this.txtks.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtks.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtks.Name = "txtks";
            this.txtks.ShowText = false;
            this.txtks.Size = new System.Drawing.Size(262, 30);
            this.txtks.Style = Sunny.UI.UIStyle.Custom;
            this.txtks.TabIndex = 15;
            this.txtks.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtks.Watermark = "";
            this.txtks.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txtks.TextChanged += new System.EventHandler(this.txtks_TextChanged);
            // 
            // uiButton1
            // 
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton1.Location = new System.Drawing.Point(274, 5);
            this.uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(100, 30);
            this.uiButton1.TabIndex = 16;
            this.uiButton1.Text = "uiButton1";
            this.uiButton1.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.txtks);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(620, 292);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UITextBox txtks;
        private Sunny.UI.UIButton uiButton1;
    }
}
