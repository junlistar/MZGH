using System;
namespace Data.Entities.Mzsf
{
    public class MzOrder : BaseModel
    { 
        public string patient_id { get; set; }
        public string order_type { get; set; }

        public string order_no { get; set; }
        public string skin_test { get; set; }
        public string order_typename { get; set; }
        public string drug_cure { get; set; }
        public string bill_code { get; set; }
        public string group_no { get; set; }
        public string poision_flag { get; set; }
        public string caoyao_fu { get; set; }
        public string order_properties { get; set; }
        public string order_propertiesname { get; set; } 
         
    }
}
