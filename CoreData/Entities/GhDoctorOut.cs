using System;

namespace Data.Entities
{
    public class GhDoctorOut : BaseModel
    { 
        public string doctor_id { get; set; }
         
        public DateTime begin_date { get; set; }
         
        public DateTime end_date { get; set; } 
         
    }
}
