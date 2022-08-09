using System;

namespace Data.Entities
{
    public class MzPatientRelation : BaseModel
    { 
        public string patient_id { get; set; }
         
        public string relation_code { get; set; }
         
        public string sfz_id { get; set; }
        public string username { get; set; }
        public string sex { get; set; }
        public string tel { get; set; }
        public string opera { get; set; }
        public DateTime? birth { get; set; } 
        public string update_date { get; set; }
        public string address { get; set; }  

    }
}
