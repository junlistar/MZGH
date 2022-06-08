using System;

namespace Data.Entities
{
    [Serializable]
    public class RtReportParamFastNet : BaseModel
    { 
        public int report_code { get; set; }
         
        public string param_name { get; set; }
         
        public string param_label { get; set; }
        public string param_type { get; set; }
        public string param_defaultvalue { get; set; }
        public int sqltag { get; set; }
        public int sort_no { get; set; } 
        public string datasql { get; set; }
        public string mul_choice { get; set; }

    }
}
