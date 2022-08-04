using Dapper;
using Data.Entities;
using Data.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class FpDataRepository : RepositoryBase<FpData>, IFpDataRepository
    {

        public List<FpData> GetFpDatasByParams(string patient_id, int ledger_sn, string subsys_id)
        {
            string ghsql = GetSqlByTag("mzsf_fpdata_getbyparams");
             
            var para = new DynamicParameters();
            para.Add("@patient_id", patient_id);
            para.Add("@ledger_sn", ledger_sn);
            para.Add("@subsys_id", subsys_id);
            return Select(ghsql, para);
        }

        public bool AddFpData(string patient_id, int ledger_sn, string billBatchCode, string billNo, string random, string createTime, string billQRCode, string pictureUrl, string pictureNetUrl, string subsys_id)
        { 
            string insert_sql = GetSqlByTag("mzsf_fpdata_add");
            
            var para = new DynamicParameters();
            para.Add("@patient_id", patient_id);
            para.Add("@ledger_sn", ledger_sn);
            para.Add("@billBatchCode", billBatchCode);
            para.Add("@billNo", billNo);
            para.Add("@random", random);
            para.Add("@createTime", createTime);
            para.Add("@billQRCode", billQRCode);
            para.Add("@pictureUrl", pictureUrl);
            para.Add("@pictureNetUrl", pictureNetUrl);
            para.Add("@subsys_id", subsys_id);

            return Update(insert_sql, para) > 0;
        }
        
    }
}
