namespace MainFrame
{
    partial class AddSystemGroup
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
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.txt_groupcode = new Sunny.UI.UITextBox();
            this.txt_groupname = new Sunny.UI.UITextBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.txt_sort = new Sunny.UI.UITextBox();
            this.btnSave = new Sunny.UI.UISymbolButton();
            this.btnCancel = new Sunny.UI.UISymbolButton();
            this.SuspendLayout();
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(70, 77);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(117, 23);
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "系统分组代码";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(80, 123);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(107, 23);
            this.uiLabel2.TabIndex = 1;
            this.uiLabel2.Text = "系统分组名称";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txt_groupcode
            // 
            this.txt_groupcode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_groupcode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_groupcode.Location = new System.Drawing.Point(204, 77);
            this.txt_groupcode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_groupcode.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_groupcode.Name = "txt_groupcode";
            this.txt_groupcode.ShowText = false;
            this.txt_groupcode.Size = new System.Drawing.Size(219, 29);
            this.txt_groupcode.TabIndex = 2;
            this.txt_groupcode.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_groupcode.Watermark = "";
            this.txt_groupcode.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txt_groupname
            // 
            this.txt_groupname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_groupname.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_groupname.Location = new System.Drawing.Point(204, 120);
            this.txt_groupname.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_groupname.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_groupname.Name = "txt_groupname";
            this.txt_groupname.ShowText = false;
            this.txt_groupname.Size = new System.Drawing.Size(219, 29);
            this.txt_groupname.TabIndex = 3;
            this.txt_groupname.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_groupname.Watermark = "";
            this.txt_groupname.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(80, 159);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(107, 23);
            this.uiLabel3.TabIndex = 4;
            this.uiLabel3.Text = "排序号";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiLabel3.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // txt_sort
            // 
            this.txt_sort.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_sort.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_sort.Location = new System.Drawing.Point(204, 159);
            this.txt_sort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_sort.MinimumSize = new System.Drawing.Size(1, 16);
            this.txt_sort.Name = "txt_sort";
            this.txt_sort.ShowText = false;
            this.txt_sort.Size = new System.Drawing.Size(219, 29);
            this.txt_sort.TabIndex = 5;
            this.txt_sort.Text = "0";
            this.txt_sort.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_sort.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.txt_sort.Watermark = "";
            this.txt_sort.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(204, 215);
            this.btnSave.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "保存";
            this.btnSave.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(323, 215);
            this.btnCancel.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.Symbol = 61453;
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            this.btnCancel.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AddSystemGroup
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(502, 289);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txt_sort);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.txt_groupname);
            this.Controls.Add(this.txt_groupcode);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.uiLabel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddSystemGroup";
            this.Text = "编辑系统分组";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.Load += new System.EventHandler(this.AddSystemGroup_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UITextBox txt_groupcode;
        private Sunny.UI.UITextBox txt_groupname;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UITextBox txt_sort;
        private Sunny.UI.UISymbolButton btnSave;
        private Sunny.UI.UISymbolButton btnCancel;
    }
}