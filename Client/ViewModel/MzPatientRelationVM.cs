using Client.ClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    public class MzPatientRelationVM
    {
        public string patient_id { get; set; }

        public string relation_code { get; set; }

        public string sfz_id { get; set; }
        public DateTime? birth { get; set; }
        public string username { get; set; }
        public string sex { get; set; }
        public string tel { get; set; }
        public string opera { get; set; }
        public string update_date { get; set; }
        public string address { get; set; }
    }
}
