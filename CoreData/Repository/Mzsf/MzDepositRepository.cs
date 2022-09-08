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
            var sql = @"SELECT  
		   a.patient_id, 
			 a.receipt_no,
			   a.receipt_sn,
			   a.cash_opera,
			   a.cash_date,
			   a.charge_total,
			   a.ledger_sn,
			   a.charge_status status,
			   a.report_date,            
			   m.[name] cash_name, 
			   l.responce_group,
			   a.backfee_date
		FROM  mz_receipt a 
			 INNER JOIN mz_patient_mi t ON a.patient_id = t.patient_id
			 INNER JOIN a_employee_mi m ON a.cash_opera = m.emp_sn
			 INNER JOIN mz_detail_charge n ON a.patient_id = n.patient_id AND a.ledger_sn = n.ledger_sn
		     LEFT JOIN zd_responce_type l ON n.response_type = l.code 
		WHERE    a.patient_id =@patient_id 
	 			AND a.ledger_sn > 0   
		GROUP BY t.name, a.patient_id, n.times, t.social_no, t.p_bar_code, a.receipt_no, 
				a.receipt_sn, a.cash_opera, a.cash_date, a.charge_total, a.charge_status, 
				a.ledger_sn, a.charge_status, a.report_date, m.[name], l.responce_group,a.backfee_date
	  ORDER BY receipt_no,charge_total desc ";
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
