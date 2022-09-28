using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;
using log4net;
using System.Runtime.InteropServices;

namespace Client.Forms.Pages
{
    public partial class DefaultPage : UIPage
    {
        private static ILog log = LogManager.GetLogger(typeof(DefaultPage));//typeof放当前类
        public DefaultPage()
        {
            InitializeComponent();
        }

        private void DefaultPage_Initialize(object sender, EventArgs e)
        {
            try
            {
                BindButtons();
                this.BackgroundImage = Image.FromFile(Application.StartupPath + "/images/index.jpeg");
            }
            catch (Exception ex)
            {
                UIMessageTip.ShowError("加载背景图片失败！");
                log.Error(ex.ToString());
            }
            //UIButton btn1 = new UIButton();
            //btn1.Style = UIStyle.Green;
            //btn1.StyleCustomMode = true;
            //btn1.Text = "按钮"; 
            //btn1.Width = 86;
            //btn1.Height = 31; 

            //listBox1.Items.Add(btn1);
            //listBox1.Items.Add("212313123");
        }

        public void BindButtons()
        {
            gbxUnits.Clear();
            int btnWidth = 220;
            int btnHeight = 60;

            int textsize = 11;
            for (int i = 0; i < 100; i++)
            {
                UIButton btn1 = new UIButton();

                btn1.Style = UIStyle.LayuiGreen;
                btn1.StyleCustomMode = true;
                btn1.Width = btnWidth;
                btn1.Height = btnHeight;
                btn1.Text = "按钮" + (i +1);
                btn1.Tag = (i);

                if (btn1.Text.Length > textsize * 2)
                {
                    btn1.Text = btn1.Text.Substring(0, textsize) + "\r\n" + btn1.Text.Substring(textsize, textsize) + "\r\n" + btn1.Text.Substring(textsize * 2);
                }
                else if (btn1.Text.Length > textsize)
                {
                    btn1.Text = btn1.Text.Substring(0, textsize) + "\r\n" + btn1.Text.Substring(textsize);
                }
                //btn1.Click += btnks_Click;

                btn1.Enter += Btn1_Enter;
                btn1.Leave += Btn1_Leave;
                btn1.KeyUp += Btn1_KeyUp; ;
                btn1.KeyDown += Btn1_KeyDown;
                btn1.KeyPress += Btn1_KeyPress; ;

                gbxUnits.Add(btn1);
            }
        }

        private void Btn1_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show(e.KeyChar.ToString());
        }

        private void Btn1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                e.Handled = true;
            }
        }

        private void Btn1_Leave(object sender, EventArgs e)
        {
            var _btn = sender as UIButton;
            _btn.Style = UIStyle.LayuiGreen;
        }

        private void Btn1_Enter(object sender, EventArgs e)
        {
            var _btn = sender as UIButton;
            _btn.Style = UIStyle.Red;
            UIMessageTip.Show(_btn.Tag.ToString());
        }
        private void Btn1_KeyUp(object sender, KeyEventArgs e)
        {
            var _btn = sender as UIButton;
            int _index = Convert.ToInt32(_btn.Tag);
            var _list = gbxUnits.GetAllControls();



            //if (e.KeyCode == Keys.Enter)
            //{
            //    e.Handled = true;
            //}
            //else if (e.KeyCode == Keys.Down)
            //{
            //    if (_index + 1 + 5 < _list.Count)
            //    {
            //        _list[_index + 1 + 5].Focus();

            //    }
            //}
            //else if (e.KeyCode == Keys.Up)
            //{
            //    if (_index - 5 > 1)
            //    {
            //        _list[_index + 3 - 5].Focus();
            //    }
            //}
            //e.Handled = true;
        }



        // DLL调用注册
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        private static extern IntPtr GetFocus();
        /// <summary>
        /// 当前拥有焦点的控件
        /// </summary>
        /// <param name="formControl"></param>
        /// <returns></returns>
        public Control GetFocusedControl()
        {
            Control focusedControl = null;
            try
            {
                IntPtr focusedHandle = GetFocus();

                if (focusedHandle != IntPtr.Zero)
                {
                    focusedControl = Control.FromChildHandle(focusedHandle);
                }
            }
            catch { }

            return focusedControl;
        }
        //定义一个二位数组  存放TextBox控件
        TextBox[,] arr;
        private void DefaultPage_KeyDown(object sender, KeyEventArgs e)
        {
            ////首先获取当前焦点的控件
            //TextBox txt = (TextBox)GetFocusedControl();

            ////获取当前焦点控件的在数组中对应的位置  此值事先存放在控件的Tag属性中
            //int x = int.Parse(txt.Tag.ToString().Substring(0, 1));
            //int y = int.Parse(txt.Tag.ToString().Substring(1, 1));


        }

        private void DefaultPage_Load(object sender, EventArgs e)
        {

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Up || keyData == Keys.Down)//|| keyData == Keys.Left || keyData == Keys.Right
            {
                try
                {
                    List<Control> _list = new List<Control>();
                    foreach (var item in gbxUnits.GetAllControls().ToArray())
                    {
                        if (item is UIButton)
                            _list.Add(item);
                    }
                     
                    foreach (var item in _list)
                    {
                        if (item is UIButton)
                        {
                            var _btn = item as UIButton;
                            if (_btn.Style == UIStyle.Red)
                            {
                                int _index = Convert.ToInt32(_btn.Tag);


                                if (keyData == Keys.Down)
                                {
                                    if (_index  + 5 < _list.Count)
                                    {
                                        _list[_index  + 5].Focus();

                                    }
                                }
                                else if (keyData == Keys.Up)
                                {
                                    if (_index - 5 >= 0)
                                    {
                                        _list[_index  - 5].Focus();
                                    }
                                }
                                return true;
                                break;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                }


                

            }

            //if (keyData == (Keys.Shift | Keys.A))
            //{

            //}
            //else if (keyData == (Keys.Control | Keys.I))
            //{

            //}
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
