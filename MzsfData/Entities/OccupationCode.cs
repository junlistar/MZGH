using System;

namespace MzsfData.Entities
{
    public class OccupationCode : BaseModel
    {  
         
        public string code { get; set; }
        public string name { get; set; }
        public string py_code { get; set; }
        public string d_code { get; set; }
        public string flag { get; set; }
        public string group_code { get; set; }
        public string tcmms_code { get; set; }

    }
}
