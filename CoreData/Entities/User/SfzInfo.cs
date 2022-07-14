using System;

namespace Data.Entities
{
    public class SfzInfo : BaseModel
    { 
        public string name { get; set; }
         
        public string sex { get; set; }
         
        public string address { get; set; }
        public string home_address { get; set; }
        public string folk { get; set; }
        public string birthday { get; set; }
        public string card_no { get; set; }
        public string img_path { get; set; } 

    }
}
