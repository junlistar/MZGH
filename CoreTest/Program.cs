using Data.Repository;
using System;

namespace CoreTest
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //var ds =  Data.Helpers.ConfigHelper.GetSectionValue("sql1");

            // var a = 1;
            //GhRefundRepository ghRefundRepository = new GhRefundRepository();
            //var listttt = ghRefundRepository.GetGhRefund("2022-04-22", "00029694400");


            //patient_id=000296936900&ledger_sn=3&cheque_type=12&item_no=3&charge=0.30&opera=00000
            // GhDepositRepository rep = new GhDepositRepository();
            // rep.Refund("000296936900", 3, "12","3",(decimal)0.30, "00000");

            //PatientRepository po = new PatientRepository();
            //po.TestDBConnection();
            //po.GuaHao("000296903300", "4396228", "1-11.9-202204221544463606,14-5-202204221544482643", "00000");

            //123456654323,,乔治,1,2022-04-25,13244445555,,,,01,01
            //po.EditUserInfo("", "421002199007181111", "", "", "李军", "1", "1990-07-18", "13122223333", "120301", "吾悦", "165", "06", "01");
            //EditUserInfo,,42100219900718351X,,,李军,1,1990 - 07 - 18,13122223333,120301,吾悦,165,06,01


            //CreateRequestRecord,2022-05-05,2022-05-06,3,-1,00000
            //BaseRequestRepository _baseRequestRepository = new BaseRequestRepository() ;
            //var list = _baseRequestRepository.GetBaseRequests("","","","","","3","","","");

            //GhRequestRepository rsp = new GhRequestRepository();
            //rsp.CreateRequestRecord("2022-05-24", "2022-05-24", "1", 1, "00040");

            //CreateRequestRecord,2022-05-24,2022-05-24,1,1,00040

            BaseRequestRepository baseRequestRepository = new BaseRequestRepository();
            baseRequestRepository.GetBaseRequestsByWeekDay("2022-05-30 00:00:00", "2022-05-30 23:59:59", "1", -1);
            // ?begin=&end=&weeks=3&day=-1

            //GhSearchRepository resp = new GhSearchRepository();
            //var list = resp.GhSearchList("2022-05-11", "%","%", "%", "%", "%", "a", "%", "任慧","%" );//GhSearchList,||  ||end

            //ReportDataFastRepository rdf = new ReportDataFastRepository();
            //var sql = rdf.GetSqlByTag(220001);

            //var ds = rdf.GetReportDataByCode("220001","test");


            //GetRequestsByDate,2022-05-30 00:00:00,2022-05-30 23:59:59 
            //CreateRequestRecord,,2022-05-30,1,1,00040
           // rsp.CreateRequestRecord("2022-05-30", "2022-05-30", "1", 1, "00040");
            Console.WriteLine("Hello World!");
        }
    }
}
