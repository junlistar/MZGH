using System;

namespace Data.Entities
{
    public class RequestHour : BaseModel
    {  
        public int end_hour { get; set; }
        public int start_hour { get; set; }
        public string code { get; set; }
        public string name { get; set; }

    }
}
