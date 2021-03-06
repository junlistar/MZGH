using System;

namespace Data.Entities.Mzsf
{
    public class MzVisit : BaseModel
    { 
        public string patient_id { get; set; }
        public int times { get; set; }
        public string visit_dept { get; set; }
        public string doctor_code { get; set; }
        public string visit_date { get; set; }  

        public string unit_name { get; set; } 
        public string doct_name { get; set; }
        public string name { get; set; }
    }

    public class VisitInfo : BaseModel
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
