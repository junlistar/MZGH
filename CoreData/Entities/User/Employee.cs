using System;

namespace Data.Entities
{
    public class Employee : BaseModel
    { 
        public string emp_sn { get; set; }
        public string code { get; set; }

        public string name { get; set; }
        public string dept_sn { get; set; }

    }
}
