using System; 
using System.Runtime.InteropServices;
using System.Data;

namespace MyMzghLib
{
//    [ComVisible(true)]
//    [Guid("43AF5852-448D-4FC3-98C5-54C8A835C68A")]
    public interface IMzghLib
    {
        void Initialize();
        void Dispose();

        DataTable GetUnit();
        DataTable GetGhData(string request_date, string ampm, string unit_sn = "%", string clinic_type = "%", string doctor_sn = "%", string group_sn = "%", string req_type = "01", string win_no = "%");
        DataTable GetUserInfo(string barcode);

        DataTable GetUserInfoByCard(string card);

        int EditUserInfo(string pid, string sno, string hicno, string barcode, string name, string sex, string birthday, string tel);
        DataTable GetCurrentReceiptNo();

        bool GuaHao(string patient_id, string record_sn);
        DataTable GetHaobie();
        DataTable GetHaoLie();

    }
}
