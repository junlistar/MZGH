using Dapper;
using MzsfData.Entities;
using MzsfData.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MzsfData.Repository
{
    public class PatientRepository : RepositoryBase<Patient>, IPatientRepository
    {


        ChargeItemRepository chargeItemResp = new ChargeItemRepository(); 


        public List<Patient> GetPatientByCard(string cardno)
        {
             
            string selectSql = GetSqlByTag(220002);

            var para = new DynamicParameters();
            para.Add("@cardno", cardno);

            return Select(selectSql, para);


        }
        public List<Patient> GetPatientById(string pid)
        {  
            string selectSql = GetSqlByTag(220003);

            var para = new DynamicParameters();
            para.Add("@patient_id", pid);

            return Select(selectSql, para);
        }
        public List<Patient> GetPatientByBarcode(string barcode)
        { 
            string selectSql = GetSqlByTag(220004);

            var para = new DynamicParameters();
            para.Add("@barcode", barcode);

            return Select(selectSql, para);
        }

        public List<Patient> GetPatientByPatientId(string pid)
        {
            string selectSql = GetSqlByTag(220005);// @"select * from mz_patient_mi a where a.patient_id=@patient_id ";
            if (pid.Length == 7)
            {
                pid = "000" + pid + "00";
            }
            var para = new DynamicParameters();
            para.Add("@patient_id", pid);

            return Select(selectSql, para);
        }
 
    }
}
