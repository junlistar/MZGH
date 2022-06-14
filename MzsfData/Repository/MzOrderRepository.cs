using Dapper;
using MzsfData.Entities;
using MzsfData.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MzsfData.Repository
{
    public class MzOrderRepository : RepositoryBase<MzOrder>, IMzOrderRepository
    {
   
        public List<MzOrder> GetMzOrdersByPatientId(string patient_id, int times)
        {

            string ghsql = GetSqlByTag(221002);
            var para = new DynamicParameters();

            para.Add("@patient_id", patient_id);
            para.Add("@times", times);
            return Select(ghsql,para);  
        } 
         
    }
}
