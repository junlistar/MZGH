using System;

namespace Data.Entities
{
    public class GhOpReceipt : BaseModel
    { 
        public string @operator { get; set; }
        public string current_no { get; set; }

        public string start_no { get; set; }
         
        public string end_no { get; set; }
        public DateTime happen_date { get; set; }
        public int step_length { get; set; }

        public string deleted_flag { get; set; }
        public string report_flag { get; set; }
        public string receipt_type { get; set; }



    }
}
