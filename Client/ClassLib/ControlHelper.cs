using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.ClassLib
{
    public static class ControlHelper
    {
        static ControlHelper()
        {
            IsLessWin7 = Environment.OSVersion.Version < new Version("6.2");
        }

        #region Win7滚动条不滚动的解决方案

        /// <summary>
        /// 是否小于win7系统
        /// </summary>
        public static bool IsLessWin7;

        /// <summary>
        /// 初始化Control使其可以滚动（用户任何控件内便可以滚动，如果动态新加的控件就没有效果）（BUG：有突然点击乱跳的问题，有弹出来的窗体关闭跳动的问题）
        /// </summary>
        /// <param name="panel"></param>
        public static void InitControlScroll(Control control)
        {
            //只在win7以下版本执行
            if (!IsLessWin7)
                return;

            control.Click += (obj, arg) => { control.Select(); };
            foreach (Control control2 in control.Controls)
            {
                control2.Click += (obj, arg) => { control2.Select(); };
                InitControlScroll(control2);
            }
        }

        /// <summary>
        /// 初始化Panel使其可以滚动（用户点击滚动条或Panel德空白区域便可以滚动）（BUG：有突然点击乱跳的问题，非全Panel效果不好）
        /// </summary>
        /// <param name="panel"></param>
        public static void InitPanelScroll(Panel panel)
        {
            //只在win7以下版本执行
            if (!IsLessWin7 && !panel.AutoScroll)
                return;

            panel.Click += (obj, arg) => { panel.Select(); };
            InitScroll(panel);

            foreach (Control control2 in panel.Controls)
            {
                if (control2 is Panel panel2)
                {
                    control2.Click += (obj, arg) => { control2.Select(); };
                    InitScroll(panel);

                    InitPanelScroll(panel2);
                }
            }
        }

        /// <summary>
        /// 初始化滚动条（用户点击滚动条便可以滚动）
        /// </summary>
        /// <param name="scrollableControl"></param>
        public static void InitScroll(ScrollableControl scrollableControl)
        {
            //只在win7以下版本执行
            if (!IsLessWin7)
                return;

            scrollableControl.Scroll += (obj, arg) => { scrollableControl.Select(); };
        }

        #endregion
    }
}
