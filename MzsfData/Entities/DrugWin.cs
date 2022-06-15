using System;

namespace MzsfData.Entities
{
    public class DrugWin : BaseModel
    { 
        public string window_no { get; set; }
         
        public string order_code { get; set; }
         
        public string group_no { get; set; }
        public int current_count { get; set; }
        public int team_no { get; set; }
        public int deleted_flag { get; set; }
        public string dept_name { get; set; }

    }
}
