using Dapper;
using MzsfData.Entities;
using MzsfData.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MzsfData.Repository
{
    public class CprChargesRepository : RepositoryBase<CprCharges>, ICprChargesRepository
    {
   
        public List<CprCharges> GetCprCharges(string patient_id, int times, string charge_status)
        {

            string ghsql = GetSqlByTag(221003);
            var para = new DynamicParameters();

            para.Add("@patient_id", patient_id);
            para.Add("@times", times);
            para.Add("@charge_status", charge_status);
            return Select(ghsql,para);  
        } 
         
    }
}
