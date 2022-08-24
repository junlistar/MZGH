using Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface IPatientRepository : IRepositoryBase<Patient>
    {
        #region 扩展的dapper操作
         
        List<Patient> GetPatientByCard(string cardno);

        List<Patient> GetPatientByBarcode(string barcode);
        List<Patient> GetPatientByPatientId(string pid);

        List<Patient> GetPatientByTel(string tel);

        List<Patient> GetPatientBySfzId(string sfzid);
        int DeleteSocialNo(string sno);

        int UpdateUserYBInfo(string pid, string social_no, string yb_psn_no, string yb_insutype, string yb_insuplc_admdvs);

        int EditUserInfo(string pid, string sno, string hicno, string barcode, string name, string sex, string birthday, string tel,
             string home_district, string home_street, string occupation_type, string response_type, string charge_type, string marry_code, string relation_code, string relation_name, string opera);


        int GuaHao(string patient_id, string record_sn, string pay_string, int max_sn = 0, string opera = "");

        string GetNewPatientId();

        /// <summary>
        /// 获取最新机制号
        /// </summary>
        /// <returns></returns>
        string GetNewReceiptMaxSN();
         
        bool EditUserInfo(string jsonStr);


        #endregion
    }
}
