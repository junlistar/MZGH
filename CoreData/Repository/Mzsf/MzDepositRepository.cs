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
            string ghsql = GetSqlByTag("mzsf_mzdeposti_getbypid");
            var para = new DynamicParameters();

            para.Add("@patient_id", patient_id);
            para.Add("@ledger_sn", ledger_sn); 
            return Select(ghsql, para);
        }

        public List<MzOrderReceipt> GetDepositReceipts(string patient_id)
        {
            var sql = GetSqlByTag("mzsf_mzdeposit_print_get");
            using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
            {
                //IDbTransaction transaction = connection.BeginTransaction();

                var para = new DynamicParameters();

                para.Add("@patient_id", patient_id);

                return connection.Query<MzOrderReceipt>(sql, para).AsList();

            }
               
        }
    }
}
