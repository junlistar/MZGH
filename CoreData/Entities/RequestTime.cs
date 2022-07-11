using System;

namespace Data.Entities
{
    public class RequestTime : BaseModel
    {  
        public TimeSpan end_time { get; set; }
        public TimeSpan start_time { get; set; }
        public string ampm { get; set; }
        public int Section_number { get; set; }
        public string Section_number_comment { get; set; }
        
    }
}
