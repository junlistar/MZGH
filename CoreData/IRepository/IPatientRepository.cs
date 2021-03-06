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

        int DeleteSocialNo(string sno);

        int UpdateUserYBInfo(string pid, string social_no, string yb_psn_no, string yb_insutype, string yb_insuplc_admdvs);

        int EditUserInfo(string pid, string sno, string hicno, string barcode, string name, string sex, string birthday, string tel,
             string home_district, string home_street, string occupation_type, string response_type, string charge_type, string opera);

        int EditUserInfoPage(string pid, string sno, string hicno, string barcode, string name, string sex, string birthday, string tel,
            string home_district, string home_street, string occupation_type, string response_type, string charge_type,
            string relation_name, int marrycode, string addition_no1, string employer_name, string opera);


        bool GuaHao(string patient_id, string record_sn, string pay_string, int max_sn = 0, string opera = "");

        string GetNewPatientId();

        /// <summary>
        /// 获取最新机制号
        /// </summary>
        /// <returns></returns>
        string GetNewReceiptMaxSN();


        #endregion
    }
}
