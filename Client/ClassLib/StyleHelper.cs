using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sunny.UI;

namespace Client.ClassLib
{
    public class StyleHelper
    {

        public static void SetGridColor(UIDataGridView dgv)
        {
            dgv.StyleCustomMode = true;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.SkyBlue;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgv.GridColor = Color.PowderBlue;

            dgv.RowsDefaultCellStyle.SelectionBackColor = SessionHelper.dgv_row_seleced_color;
        }
    }
}
