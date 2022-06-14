using System;

namespace MzsfData.Entities
{
    public class MzHaoming : BaseModel
    {  
         
        public string code { get; set; }
        public string name { get; set; }
        public string charge_type { get; set; }
        public string responce_type { get; set; }
        public string keyfield { get; set; } 

    }
}
