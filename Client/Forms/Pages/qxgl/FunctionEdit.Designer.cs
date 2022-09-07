namespace Client.Forms.Pages.qxgl
{
    partial class FunctionEdit
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new Sunny.UI.UITextBox();
            this.uiLine1 = new Sunny.UI.UILine();
            this.btnCancel = new Sunny.UI.UISymbolButton();
            this.btnSave = new Sunny.UI.UISymbolButton();
            this.txtDesc = new Sunny.UI.UITextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxStatus = new Sunny.UI.UIComboBox();
            this.cbxFunctions = new Sunny.UI.UIComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.label1.Location = new System.Drawing.Point(78, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "功能名称：";
            // 
            // txtName
            // 
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtName.Location = new System.Drawing.Point(219, 84);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtName.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtName.Name = "txtName";
            this.txtName.ShowText = false;
            this.txtName.Size = new System.Drawing.Size(296, 41);
            this.txtName.TabIndex = 1;
            this.txtName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtName.Watermark = "请输入功能名称";
            this.txtName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txtName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyUp);
            // 
            // uiLine1
            // 
            this.uiLine1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiLine1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine1.Location = new System.Drawing.Point(9, 348);
            this.uiLine1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(609, 29);
            this.uiLine1.TabIndex = 10;
            this.uiLine1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(421, 397);
            this.btnCancel.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 34);
            this.btnCancel.StyleCustomMode = true;
            this.btnCancel.Symbol = 61534;
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "取消";
            this.btnCancel.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(312, 397);
            this.btnSave.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 34);
            this.btnSave.StyleCustomMode = true;
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "保存";
            this.btnSave.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtDesc
            // 
            this.txtDesc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDesc.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDesc.Location = new System.Drawing.Point(219, 144);
            this.txtDesc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDesc.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ShowText = false;
            this.txtDesc.Size = new System.Drawing.Size(296, 41);
            this.txtDesc.TabIndex = 14;
            this.txtDesc.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtDesc.Watermark = "请输入功能描述";
            this.txtDesc.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.label2.Location = new System.Drawing.Point(78, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 31);
            this.label2.TabIndex = 13;
            this.label2.Text = "功能描述：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.label3.Location = new System.Drawing.Point(78, 268);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 31);
            this.label3.TabIndex = 15;
            this.label3.Text = "启用状态：";
            // 
            // cbxStatus
            // 
            this.cbxStatus.DataSource = null;
            this.cbxStatus.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbxStatus.FillColor = System.Drawing.Color.White;
            this.cbxStatus.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxStatus.Items.AddRange(new object[] {
            "启用",
            "不启用"});
            this.cbxStatus.Location = new System.Drawing.Point(219, 263);
            this.cbxStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxStatus.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbxStatus.Name = "cbxStatus";
            this.cbxStatus.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbxStatus.Size = new System.Drawing.Size(296, 41);
            this.cbxStatus.TabIndex = 16;
            this.cbxStatus.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbxStatus.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // cbxFunctions
            // 
            this.cbxFunctions.DataSource = null;
            this.cbxFunctions.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbxFunctions.FillColor = System.Drawing.Color.White;
            this.cbxFunctions.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxFunctions.Items.AddRange(new object[] {
            "启用",
            "不启用"});
            this.cbxFunctions.Location = new System.Drawing.Point(219, 202);
            this.cbxFunctions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxFunctions.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbxFunctions.Name = "cbxFunctions";
            this.cbxFunctions.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbxFunctions.Size = new System.Drawing.Size(296, 41);
            this.cbxFunctions.TabIndex = 18;
            this.cbxFunctions.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbxFunctions.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.label4.Location = new System.Drawing.Point(78, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 31);
            this.label4.TabIndex = 17;
            this.label4.Text = "父级菜单：";
            // 
            // FunctionEdit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(615, 453);
            this.Controls.Add(this.cbxFunctions);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.uiLine1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FunctionEdit";
            this.StyleCustomMode = true;
            this.Text = "添加功能(按Enter保存，ESC退出)";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.Load += new System.EventHandler(this.FunctionEdit_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AddGroup_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Sunny.UI.UITextBox txtName;
        private Sunny.UI.UILine uiLine1;
        private Sunny.UI.UISymbolButton btnCancel;
        private Sunny.UI.UISymbolButton btnSave;
        private Sunny.UI.UITextBox txtDesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Sunny.UI.UIComboBox cbxStatus;
        private Sunny.UI.UIComboBox cbxFunctions;
        private System.Windows.Forms.Label label4;
    }
}