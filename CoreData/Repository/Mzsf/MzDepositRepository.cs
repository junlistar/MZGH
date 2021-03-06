using Dapper;
using Data.Entities.Mzsf;
using Data.IRepository.Mzsf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Data.Repository.Mzsf
{
    public class MzDepositRepository : RepositoryBase<MzDeposit>, IMzDepositRepository
    {
    
        public List<MzDeposit> GetMzDepositsByPatientId(string patient_id, int ledger_sn)
        { 
            string ghsql = GetSqlByTag(221020);
            var para = new DynamicParameters();

            para.Add("@patient_id", patient_id);
            para.Add("@ledger_sn", ledger_sn); 
            return Select(ghsql, para);
        } 
    }
}
