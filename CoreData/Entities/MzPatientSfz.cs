using System;

namespace Data.Entities
{
    [Serializable]
    public class MzPatientSfz : BaseModel
    {
        public string patient_id { get; set; }

        public string sfz_id { get; set; }

        //身份证信息
        public string name { get; set; }

        public string sex { get; set; }
        public string address { get; set; }
        public string home_address { get; set; }
        public string folk { get; set; }
        public string birthday { get; set; }
        public string card_no { get; set; }

        //医保卡信息
        public string psn_no { get; set; }
        public string psn_cert_type { get; set; }
        public string certno { get; set; }
        public string psn_name { get; set; }
        public string gend { get; set; }
        public string naty { get; set; }
        public string brdy { get; set; }
        public int age { get; set; }
    }
}
