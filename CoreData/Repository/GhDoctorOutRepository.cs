using Dapper;
using Data.Entities;
using Data.IRepository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Data.Repository
{
    public class GhDoctorOutRepository : RepositoryBase<GhDoctorOut>, IGhDoctorOutRepository
    {

        public List<GhDoctorOut> GetGhDoctorOuts()
        {
            string ghsql = GetSqlByTag("mzgh_ghdoctorout_get");

            return Select(ghsql);
        }

        public List<GhDoctorOut> GetGhDoctorOutsByParams(string doctor_id, string date1)
        {
            string ghsql = GetSqlByTag("mzgh_ghdoctorout_getbydoct");

            var para = new DynamicParameters();
            para.Add("@doctor_id", "%" + doctor_id + "%");
            if (!string.IsNullOrEmpty(date1))
            {
                ghsql = GetSqlByTag("mzgh_ghdoctorout_getbyparam");
                para.Add("@begin_date", date1);
            }
           
            return Select(ghsql, para);
        }

        public bool UpdateGhDoctorOut(string jsonStr)
        {
            GhDoctorOut _mod = JsonConvert.DeserializeObject<GhDoctorOut>(jsonStr);
            using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
            { 
                var para = new DynamicParameters();  
                string sql = @"";
                if (string.IsNullOrEmpty(_mod.sn))
                {
                    _mod.sn = Guid.NewGuid().ToString();
                    sql = GetSqlByTag("mzgh_ghdoctorout_add");
                }
                else
                {
                    sql = GetSqlByTag("mzgh_ghdoctorout_edit");
                } 
                para.Add("@sn", _mod.sn); 
                para.Add("@doctor_id", _mod.doctor_id); 
                para.Add("@begin_date", _mod.begin_date); 
                para.Add("@end_date", _mod.end_date); 
                para.Add("@is_delete", _mod.is_delete);  

                return connection.Execute(sql, para) > 0;
            }

        }

    }
}
