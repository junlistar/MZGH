using System;

namespace Data.Entities
{
    public class Hosipital : BaseModel
    {

        public int no { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string short_name { get; set; }

        public int yb_serial { get; set; }
        public int report_sn { get; set; }

    }
}
