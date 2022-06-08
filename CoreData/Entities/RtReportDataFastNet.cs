using System;

namespace Data.Entities
{
    [Serializable]
    public class RtReportDataFastNet : BaseModel
    { 
        public int report_code { get; set; }
         
        public string short_name { get; set; }
         
        public string long_name { get; set; }
        public string report_sql { get; set; }
        public byte[] report_com { get; set; }
        public string report_flag { get; set; }
        public int datasetn { get; set; }

    }
}
