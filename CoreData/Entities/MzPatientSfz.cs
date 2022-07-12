using System;

namespace Data.Entities
{
    [Serializable]
    public class MzPatientSfz : BaseModel
    {
        public string patient_id { get; set; }

        public string sfz_id { get; set; }
        public string name { get; set; }

        public string sex { get; set; }
        public string address { get; set; }
        public string home_address { get; set; }
        public string folk { get; set; }
        public string birthday { get; set; }
        public string card_no { get; set; }

    }
}
