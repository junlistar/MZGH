using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public class FpConfig : BaseModel
    {  
         
        public string url { get; set; }
        public string appkey { get; set; }
        public string appid { get; set; }
        public string placeCode_mz { get; set; }
        public string placeCode_zy { get; set; }
        public string batchNo { get; set; } 

    }
     
}
