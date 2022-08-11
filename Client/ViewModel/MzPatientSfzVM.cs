using Client.ClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    public class MzPatientSfzVM
    {
        public string patient_id { get; set; }

        public string sfz_id { get; set; }
        public string relation_code { get; set; }
        public string relative_str
        {
            get
            {
                if (string.IsNullOrEmpty(relation_code))
                {
                    return "本人";
                }
                if (SessionHelper.relativeCodes!=null )
                { 
                    var _relativeCode = SessionHelper.relativeCodes.Where(p => p.code == relation_code).FirstOrDefault();
                    if (_relativeCode!=null)
                    {
                        return _relativeCode.name;
                    }
                }
                return relation_code;
            }
        }



        public string name { get; set; }

        public string sex { get; set; }
        public string address { get; set; }
        public string home_address { get; set; }
        public string folk { get; set; }
        public string birthday { get; set; }
        public string card_no { get; set; }
        //医保卡信息
        public string psn_no { get; set; }
        public string psn_cert_type { get; set; }
        public string psn_cert_type_str
        {
            get
            {
                switch (psn_cert_type)
                {
                    case "01": return "居民身份证（户口簿）";
                    case "90": return "社会保障卡";

                    default: return "其他身份证件";
                }
            }
        }
        public string certno { get; set; }
        public string psn_name { get; set; }
        public string gend { get; set; }
        public string naty { get; set; }
        public string brdy { get; set; }
        public int age { get; set; }
    }
}
