using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzsf.ClassLib
{
    public class GHPayModel
    {
        public GHPayModel(int type, decimal je, string trade_no = "")
        {
            pay_type = type;
            pay_je = je;
            out_trade_no = trade_no;
        }
        public int pay_type { get; set; }
        public decimal pay_je { get; set; }

        public string out_trade_no { get; set; }
        public string type_name
        {
            get
            {
                return PayMethod.GetPayStringByEnumValue(pay_type);
            }
        }

    }
}
