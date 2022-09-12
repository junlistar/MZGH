using System;

namespace Data.Entities
{
    public class GhDoctorOut : BaseModel
    { 
        public string sn { get; set; }
        public string doctor_id { get; set; }
        public string doctor_name { get; set; }

        public DateTime begin_date { get; set; }
         
        public DateTime end_date { get; set; } 

        public int is_delete { get; set; } 

    }
}
