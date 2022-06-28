using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    public class MzOrderVM
    {
        public string patient_id { get; set; }
        public string order_type { get; set; }

        public int order_no { get; set; }
        public string skin_test { get; set; }
        public string order_typename { get; set; }
        public string drug_cure { get; set; }
        public string bill_code { get; set; }
        public string group_no { get; set; }
        public string poision_flag { get; set; }
        public string caoyao_fu { get; set; }
        public string order_properties { get; set; }
        public string order_propertiesname { get; set; }

        public string title
        {
            get { return "处方" + order_no + ":" + order_typename; }
        }

    }

    public class MzVisitVM
    {
        public string patient_id { get; set; }
        public int times { get; set; }
        public string visit_dept { get; set; }
        public string doctor_code { get; set; }
        public string visit_date { get; set; }

        public string unit_name { get; set; }
        public string doct_name { get; set; }
    }
}
