using Client.ClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    public class ElectBillModel
    {
         
     
    }

    public class ElectBillChargeItem
    {
        public int sortNo { get; set; }
        public string chargeCode { get; set; }
        public string chargeName { get; set; }
        public int number { get; set; }
        public string std { get; set; }
        public string amt { get; set; }
        public string selfAmt { get; set; }
        public string remark { get; set; }
    }
    public class ElectBillListDetail
    {
        public string name { get; set; }//药品名称
        public string std { get; set; }//单价
        public string number { get; set; }//数量
        public string amt { get; set; }//金额
        public string selfAmt { get; set; }//自费金额
         
    }

    public class PayChannelDetail {
        public string payChannelCode { get; set; }
        public string payChannelValue { get; set; }

    }
    public class ElectBillCommonResponse
    {

        public string data { get; set; }
        public string noise { get; set; }
        public string sign { get; set; }
    }
    public class ElectBillAddResponse
    {
        
        public string result { get; set; }
        public string message { get; set; }
    }

    public class FpData
    {
        public string billBatchCode { get; set; }
        public string billNo { get; set; }
        public string random { get; set; }
        public string createTime { get; set; }
        public string billQRCode { get; set; }
        public string pictureUrl { get; set; }
        public string pictureNetUrl { get; set; }
    }
}
