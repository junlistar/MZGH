using Client.ClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    public class GHPayModel
    {
        public GHPayModel(string type, decimal je,string trade_no="", string setlid = "")
        { 
            pay_type = type;
            pay_je = je;
            out_trade_no = trade_no;
            setl_id = setlid;
        }
        public string pay_type { get; set; }
        public decimal pay_je { get; set; }

        public string out_trade_no { get; set; }
        public string setl_id { get; set; }
        public string type_name
        {
            get
            {
                return PayMethod.GetPayStringByEnumValue(pay_type);
            }
        }

    }
}
