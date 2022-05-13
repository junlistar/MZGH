namespace Client.Forms.Pages
{
    partial class UserInfoPage
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
            this.cbxhm = new Sunny.UI.UIComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtId = new Sunny.UI.UITextBox();
            this.txtbarcode = new Sunny.UI.UITextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtname = new Sunny.UI.UITextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtrelationname = new Sunny.UI.UITextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtsno = new Sunny.UI.UITextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txthicno = new Sunny.UI.UITextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtemployer_name = new Sunny.UI.UITextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtZhiye = new Sunny.UI.UITextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.uiTextBox15 = new Sunny.UI.UITextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtsbh = new Sunny.UI.UITextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtTel = new Sunny.UI.UITextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txthomestreet = new Sunny.UI.UITextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cbxsex = new Sunny.UI.UIComboBox();
            this.txthomedistrict = new Sunny.UI.UITextBox();
            this.cbxmarrycode = new Sunny.UI.UIComboBox();
            this.cbxShenfen = new Sunny.UI.UIComboBox();
            this.cbxFeibie = new Sunny.UI.UIComboBox();
            this.txtbirth = new Sunny.UI.UIDatePicker();
            this.pnlTitle = new Sunny.UI.UIPanel();
            this.btnSave = new Sunny.UI.UISymbolButton();
            this.btnReset = new Sunny.UI.UISymbolButton();
            this.btnExit = new Sunny.UI.UISymbolButton();
            this.lblTitle = new Sunny.UI.UILabel();
            this.label20 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.lblmsg = new Sunny.UI.UILabel();
            this.txtname.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "号名";
            // 
            // cbxhm
            // 
            this.cbxhm.DataSource = null;
            this.cbxhm.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbxhm.FillColor = System.Drawing.Color.White;
            this.cbxhm.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxhm.Location = new System.Drawing.Point(107, 122);
            this.cbxhm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxhm.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbxhm.Name = "cbxhm";
            this.cbxhm.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbxhm.Size = new System.Drawing.Size(205, 29);
            this.cbxhm.TabIndex = 1;
            this.cbxhm.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbxhm.SelectedIndexChanged += new System.EventHandler(this.cbxhm_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(336, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "病人ID码";
            // 
            // txtId
            // 
            this.txtId.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtId.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtId.Location = new System.Drawing.Point(418, 122);
            this.txtId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtId.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtId.Name = "txtId";
            this.txtId.ShowText = false;
            this.txtId.Size = new System.Drawing.Size(187, 29);
            this.txtId.TabIndex = 3;
            this.txtId.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtId.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtId_KeyUp);
            // 
            // txtbarcode
            // 
            this.txtbarcode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtbarcode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtbarcode.Location = new System.Drawing.Point(700, 122);
            this.txtbarcode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtbarcode.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtbarcode.Name = "txtbarcode";
            this.txtbarcode.ShowText = false;
            this.txtbarcode.Size = new System.Drawing.Size(158, 29);
            this.txtbarcode.TabIndex = 5;
            this.txtbarcode.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtbarcode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtbarcode_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(635, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "磁卡号";
            // 
            // txtname
            // 
            this.txtname.Controls.Add(this.label21);
            this.txtname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtname.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtname.Location = new System.Drawing.Point(107, 161);
            this.txtname.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtname.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtname.Name = "txtname";
            this.txtname.ShowText = false;
            this.txtname.Size = new System.Drawing.Size(205, 29);
            this.txtname.TabIndex = 7;
            this.txtname.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(206, 8);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(17, 21);
            this.label21.TabIndex = 40;
            this.label21.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "姓名";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(369, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 21);
            this.label5.TabIndex = 8;
            this.label5.Text = "身份";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(651, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 21);
            this.label6.TabIndex = 10;
            this.label6.Text = "费别";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(58, 202);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 21);
            this.label7.TabIndex = 12;
            this.label7.Text = "性别";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(369, 205);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 21);
            this.label8.TabIndex = 14;
            this.label8.Text = "生日";
            // 
            // txtrelationname
            // 
            this.txtrelationname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtrelationname.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtrelationname.Location = new System.Drawing.Point(700, 200);
            this.txtrelationname.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtrelationname.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtrelationname.Name = "txtrelationname";
            this.txtrelationname.ShowText = false;
            this.txtrelationname.Size = new System.Drawing.Size(158, 29);
            this.txtrelationname.TabIndex = 17;
            this.txtrelationname.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(620, 205);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 21);
            this.label9.TabIndex = 16;
            this.label9.Text = "家长姓名";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(58, 358);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 21);
            this.label10.TabIndex = 18;
            this.label10.Text = "来自";
            // 
            // txtsno
            // 
            this.txtsno.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtsno.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtsno.Location = new System.Drawing.Point(418, 239);
            this.txtsno.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtsno.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtsno.Name = "txtsno";
            this.txtsno.ShowText = false;
            this.txtsno.Size = new System.Drawing.Size(187, 29);
            this.txtsno.TabIndex = 21;
            this.txtsno.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(353, 241);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 21);
            this.label11.TabIndex = 20;
            this.label11.Text = "身份证";
            // 
            // txthicno
            // 
            this.txthicno.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txthicno.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txthicno.Location = new System.Drawing.Point(700, 239);
            this.txthicno.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txthicno.MinimumSize = new System.Drawing.Size(1, 16);
            this.txthicno.Name = "txthicno";
            this.txthicno.ShowText = false;
            this.txthicno.Size = new System.Drawing.Size(158, 29);
            this.txthicno.TabIndex = 23;
            this.txthicno.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(620, 241);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 21);
            this.label12.TabIndex = 22;
            this.label12.Text = "医疗证号";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(58, 280);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 21);
            this.label13.TabIndex = 20;
            this.label13.Text = "婚姻";
            // 
            // txtemployer_name
            // 
            this.txtemployer_name.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtemployer_name.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtemployer_name.Location = new System.Drawing.Point(418, 278);
            this.txtemployer_name.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtemployer_name.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtemployer_name.Name = "txtemployer_name";
            this.txtemployer_name.ShowText = false;
            this.txtemployer_name.Size = new System.Drawing.Size(440, 29);
            this.txtemployer_name.TabIndex = 23;
            this.txtemployer_name.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(337, 280);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(74, 21);
            this.label14.TabIndex = 22;
            this.label14.Text = "工作单位";
            // 
            // txtZhiye
            // 
            this.txtZhiye.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtZhiye.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtZhiye.Location = new System.Drawing.Point(107, 317);
            this.txtZhiye.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtZhiye.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtZhiye.Name = "txtZhiye";
            this.txtZhiye.ShowText = false;
            this.txtZhiye.Size = new System.Drawing.Size(205, 29);
            this.txtZhiye.TabIndex = 25;
            this.txtZhiye.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtZhiye.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtZhiye_KeyUp);
            this.txtZhiye.Leave += new System.EventHandler(this.txtZhiye_Leave);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(58, 319);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 21);
            this.label15.TabIndex = 24;
            this.label15.Text = "职业";
            // 
            // uiTextBox15
            // 
            this.uiTextBox15.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox15.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTextBox15.Location = new System.Drawing.Point(418, 317);
            this.uiTextBox15.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox15.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBox15.Name = "uiTextBox15";
            this.uiTextBox15.ShowText = false;
            this.uiTextBox15.Size = new System.Drawing.Size(187, 29);
            this.uiTextBox15.TabIndex = 27;
            this.uiTextBox15.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBox15.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(337, 317);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(74, 21);
            this.label16.TabIndex = 26;
            this.label16.Text = "合同单位";
            this.label16.Visible = false;
            // 
            // txtsbh
            // 
            this.txtsbh.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtsbh.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtsbh.Location = new System.Drawing.Point(700, 317);
            this.txtsbh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtsbh.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtsbh.Name = "txtsbh";
            this.txtsbh.ShowText = false;
            this.txtsbh.Size = new System.Drawing.Size(158, 29);
            this.txtsbh.TabIndex = 29;
            this.txtsbh.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(636, 319);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(58, 21);
            this.label17.TabIndex = 28;
            this.label17.Text = "社保号";
            // 
            // txtTel
            // 
            this.txtTel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTel.Location = new System.Drawing.Point(107, 239);
            this.txtTel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTel.MinimumSize = new System.Drawing.Size(1, 16);
            this.txtTel.Name = "txtTel";
            this.txtTel.ShowText = false;
            this.txtTel.Size = new System.Drawing.Size(205, 29);
            this.txtTel.TabIndex = 31;
            this.txtTel.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(58, 241);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(42, 21);
            this.label18.TabIndex = 30;
            this.label18.Text = "电话";
            // 
            // txthomestreet
            // 
            this.txthomestreet.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txthomestreet.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txthomestreet.Location = new System.Drawing.Point(418, 356);
            this.txthomestreet.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txthomestreet.MinimumSize = new System.Drawing.Size(1, 16);
            this.txthomestreet.Name = "txthomestreet";
            this.txthomestreet.ShowText = false;
            this.txthomestreet.Size = new System.Drawing.Size(440, 29);
            this.txthomestreet.TabIndex = 33;
            this.txthomestreet.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(336, 358);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(74, 21);
            this.label19.TabIndex = 32;
            this.label19.Text = "家庭住址";
            // 
            // cbxsex
            // 
            this.cbxsex.DataSource = null;
            this.cbxsex.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbxsex.FillColor = System.Drawing.Color.White;
            this.cbxsex.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxsex.Items.AddRange(new object[] {
            "男",
            "女",
            "不定"});
            this.cbxsex.Location = new System.Drawing.Point(107, 200);
            this.cbxsex.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxsex.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbxsex.Name = "cbxsex";
            this.cbxsex.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbxsex.Size = new System.Drawing.Size(205, 29);
            this.cbxsex.TabIndex = 34;
            this.cbxsex.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txthomedistrict
            // 
            this.txthomedistrict.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txthomedistrict.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txthomedistrict.Location = new System.Drawing.Point(107, 356);
            this.txthomedistrict.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txthomedistrict.MinimumSize = new System.Drawing.Size(1, 16);
            this.txthomedistrict.Name = "txthomedistrict";
            this.txthomedistrict.ShowText = false;
            this.txthomedistrict.Size = new System.Drawing.Size(205, 29);
            this.txthomedistrict.TabIndex = 19;
            this.txthomedistrict.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txthomedistrict.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txthomedistrict_KeyUp);
            this.txthomedistrict.Leave += new System.EventHandler(this.txthomedistrict_Leave);
            // 
            // cbxmarrycode
            // 
            this.cbxmarrycode.DataSource = null;
            this.cbxmarrycode.FillColor = System.Drawing.Color.White;
            this.cbxmarrycode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxmarrycode.Items.AddRange(new object[] {
            "已婚",
            "未婚",
            "丧偶",
            "离婚",
            "其他"});
            this.cbxmarrycode.Location = new System.Drawing.Point(107, 280);
            this.cbxmarrycode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxmarrycode.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbxmarrycode.Name = "cbxmarrycode";
            this.cbxmarrycode.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbxmarrycode.Size = new System.Drawing.Size(205, 29);
            this.cbxmarrycode.TabIndex = 35;
            this.cbxmarrycode.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxShenfen
            // 
            this.cbxShenfen.DataSource = null;
            this.cbxShenfen.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbxShenfen.FillColor = System.Drawing.Color.White;
            this.cbxShenfen.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxShenfen.Location = new System.Drawing.Point(418, 161);
            this.cbxShenfen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxShenfen.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbxShenfen.Name = "cbxShenfen";
            this.cbxShenfen.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbxShenfen.Size = new System.Drawing.Size(187, 29);
            this.cbxShenfen.TabIndex = 36;
            this.cbxShenfen.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxFeibie
            // 
            this.cbxFeibie.DataSource = null;
            this.cbxFeibie.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.cbxFeibie.FillColor = System.Drawing.Color.White;
            this.cbxFeibie.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxFeibie.Location = new System.Drawing.Point(700, 164);
            this.cbxFeibie.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxFeibie.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbxFeibie.Name = "cbxFeibie";
            this.cbxFeibie.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbxFeibie.Size = new System.Drawing.Size(158, 29);
            this.cbxFeibie.TabIndex = 35;
            this.cbxFeibie.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtbirth
            // 
            this.txtbirth.FillColor = System.Drawing.Color.White;
            this.txtbirth.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtbirth.Location = new System.Drawing.Point(418, 200);
            this.txtbirth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtbirth.MaxLength = 10;
            this.txtbirth.MinimumSize = new System.Drawing.Size(63, 0);
            this.txtbirth.Name = "txtbirth";
            this.txtbirth.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.txtbirth.ShowToday = true;
            this.txtbirth.Size = new System.Drawing.Size(187, 29);
            this.txtbirth.SymbolDropDown = 61555;
            this.txtbirth.SymbolNormal = 61555;
            this.txtbirth.TabIndex = 37;
            this.txtbirth.Text = "1900-01-01";
            this.txtbirth.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtbirth.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // pnlTitle
            // 
            this.pnlTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTitle.Controls.Add(this.btnSave);
            this.pnlTitle.Controls.Add(this.btnReset);
            this.pnlTitle.Controls.Add(this.btnExit);
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnlTitle.Location = new System.Drawing.Point(13, 14);
            this.pnlTitle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlTitle.MinimumSize = new System.Drawing.Size(1, 1);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(1180, 66);
            this.pnlTitle.TabIndex = 38;
            this.pnlTitle.Text = null;
            this.pnlTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(163, 14);
            this.btnSave.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.Symbol = 61639;
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "保存";
            this.btnSave.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReset
            // 
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReset.Location = new System.Drawing.Point(269, 14);
            this.btnReset.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 35);
            this.btnReset.Symbol = 61473;
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "重新";
            this.btnReset.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.Location = new System.Drawing.Point(375, 14);
            this.btnExit.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(107, 35);
            this.btnExit.Symbol = 61579;
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "退出";
            this.btnExit.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(45, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(112, 51);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "发新卡";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.Red;
            this.label20.Location = new System.Drawing.Point(315, 128);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(17, 21);
            this.label20.TabIndex = 39;
            this.label20.Text = "*";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.ForeColor = System.Drawing.Color.Red;
            this.label22.Location = new System.Drawing.Point(612, 125);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(17, 21);
            this.label22.TabIndex = 40;
            this.label22.Text = "*";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.ForeColor = System.Drawing.Color.Red;
            this.label23.Location = new System.Drawing.Point(865, 128);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(17, 21);
            this.label23.TabIndex = 41;
            this.label23.Text = "*";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.ForeColor = System.Drawing.Color.Red;
            this.label24.Location = new System.Drawing.Point(315, 167);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(17, 21);
            this.label24.TabIndex = 42;
            this.label24.Text = "*";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.ForeColor = System.Drawing.Color.Red;
            this.label25.Location = new System.Drawing.Point(315, 208);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(17, 21);
            this.label25.TabIndex = 43;
            this.label25.Text = "*";
            // 
            // lblmsg
            // 
            this.lblmsg.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblmsg.ForeColor = System.Drawing.Color.Red;
            this.lblmsg.Location = new System.Drawing.Point(107, 426);
            this.lblmsg.Name = "lblmsg";
            this.lblmsg.Size = new System.Drawing.Size(751, 23);
            this.lblmsg.Style = Sunny.UI.UIStyle.Custom;
            this.lblmsg.TabIndex = 44;
            this.lblmsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UserInfoPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1206, 613);
            this.Controls.Add(this.lblmsg);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.pnlTitle);
            this.Controls.Add(this.txtbirth);
            this.Controls.Add(this.cbxFeibie);
            this.Controls.Add(this.cbxShenfen);
            this.Controls.Add(this.cbxmarrycode);
            this.Controls.Add(this.cbxsex);
            this.Controls.Add(this.txthomestreet);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txtTel);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtsbh);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.uiTextBox15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtZhiye);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtemployer_name);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txthicno);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtsno);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txthomedistrict);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtrelationname);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtbarcode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxhm);
            this.Controls.Add(this.label1);
            this.Name = "UserInfoPage";
            this.PageIndex = 1005;
            this.Text = "UserInfoPage";
            this.Initialize += new System.EventHandler(this.UserInfoPage_Initialize);
            this.Load += new System.EventHandler(this.UserInfoPage_Load);
            this.txtname.ResumeLayout(false);
            this.txtname.PerformLayout();
            this.pnlTitle.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Sunny.UI.UIComboBox cbxhm;
        private System.Windows.Forms.Label label2;
        private Sunny.UI.UITextBox txtId;
        private Sunny.UI.UITextBox txtbarcode;
        private System.Windows.Forms.Label label3;
        private Sunny.UI.UITextBox txtname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private Sunny.UI.UITextBox txtrelationname;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private Sunny.UI.UITextBox txtsno;
        private System.Windows.Forms.Label label11;
        private Sunny.UI.UITextBox txthicno;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private Sunny.UI.UITextBox txtemployer_name;
        private System.Windows.Forms.Label label14;
        private Sunny.UI.UITextBox txtZhiye;
        private System.Windows.Forms.Label label15;
        private Sunny.UI.UITextBox uiTextBox15;
        private System.Windows.Forms.Label label16;
        private Sunny.UI.UITextBox txtsbh;
        private System.Windows.Forms.Label label17;
        private Sunny.UI.UITextBox txtTel;
        private System.Windows.Forms.Label label18;
        private Sunny.UI.UITextBox txthomestreet;
        private System.Windows.Forms.Label label19;
        private Sunny.UI.UIComboBox cbxsex;
        private Sunny.UI.UITextBox txthomedistrict;
        private Sunny.UI.UIComboBox cbxmarrycode;
        private Sunny.UI.UIComboBox cbxShenfen;
        private Sunny.UI.UIComboBox cbxFeibie;
        private Sunny.UI.UIDatePicker txtbirth;
        private Sunny.UI.UIPanel pnlTitle;
        private Sunny.UI.UISymbolButton btnSave;
        private Sunny.UI.UISymbolButton btnReset;
        private Sunny.UI.UISymbolButton btnExit;
        private Sunny.UI.UILabel lblTitle;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private Sunny.UI.UILabel lblmsg;
    }
}