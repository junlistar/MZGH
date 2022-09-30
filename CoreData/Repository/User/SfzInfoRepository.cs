using Dapper;
using Data.Entities;
using Data.IRepository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class SfzInfoRepository : RepositoryBase<SfzInfo>, ISfzInfoRepository
    {


        public List<SfzInfo> GetSfzInfoByPatientId(string pid)
        {
            string sql = GetSqlByTag("mzgh_mzpatientsfzinfo_getbypid");
            var para = new DynamicParameters();
            para.Add("@pid", pid);

            return Select(sql, para);
        }
        public bool UpdateSfzInfo(string name, string sex, string address, string home_address, string folk, string birthday, string card_no)
        {
            string selectSql = GetSqlByTag("mzgh_mzpatientsfzinfo_get");

            var para = new DynamicParameters();
            para.Add("@card_no", card_no);

            var _count = ExcuteScalar(selectSql, para);

            if (Convert.ToInt32(_count) > 0)
            {
                //编辑
                selectSql = GetSqlByTag("mzgh_mzpatientsfzinfo_update");
            }
            else
            {
                //新增
                selectSql = GetSqlByTag("mzgh_mzpatientsfzinfo_add");
            }
            para.Add("@name", name);
            para.Add("@sex", sex);
            para.Add("@address", address);
            para.Add("@home_address", address);
            para.Add("@birthday", birthday);
            para.Add("@folk", folk);
            para.Add("@cardno", card_no);

            Update(selectSql, para);

            return true;
        }

        public bool UpdateUserBaseInfo(string pid, string name, string sex, string marry_code, string birthday, string tel, string relation_name, string relation_code,
             string home_street, string district, string responseType, string chargeType, string opera)
        {
            try
            {
                using (IDbConnection connection = DataBaseConfig.GetSqlConnection(DBConnectionEnum.Write))
                {
                    IDbTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        string sql = GetSqlByTag("mzgh_mzpatient_update_relation");

                        var para = new DynamicParameters();
                        para.Add("@patient_id", pid);
                        para.Add("@name", name);
                        para.Add("@home_tel", tel);
                        para.Add("@sex", sex);
                        para.Add("@marry_code", marry_code);
                        para.Add("@birthday", birthday);
                        para.Add("@relation_name", relation_name);
                        para.Add("@relation_code", relation_code);
                        para.Add("@home_street", home_street);
                        para.Add("@home_district", district);
                        para.Add("@response_type", responseType);
                        para.Add("@charge_type", chargeType);
                        para.Add("@update_opera", opera);

                        connection.Execute(sql, para, transaction);

                        //sql = GetSqlByTag("mzgh_mzpatientsfz_update_relation");
                        //para = new DynamicParameters();
                        //para.Add("@relative_code", relation_code);
                        //para.Add("@patient_id", pid); 

                        //connection.Execute(sql, para, transaction);
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public bool UpdateUserBaseInfo(string jsonStr)
        {
            try
            {
                Serilog.Log.Debug(jsonStr);
                
                Patient patient = JsonConvert.DeserializeObject<Patient>(jsonStr);
                using (IDbConnection connection = DataBaseConfig.GetSqlConnection(DBConnectionEnum.Write))
                {
                    IDbTransaction transaction = connection.BeginTransaction();
                    
                    try
                    {
                        string sql = GetSqlByTag("mzgh_mzpatient_update_relation");
                       
                        var para = new DynamicParameters();
                        para.Add("@patient_id", patient.patient_id);
                        para.Add("@name", patient.name); 
                        para.Add("@home_tel", patient.home_tel);
                        para.Add("@hic_no", patient.hic_no);
                        para.Add("@sex", patient.sex);
                        para.Add("@marry_code", patient.marry_code);
                        para.Add("@birthday", patient.birthday);
                        para.Add("@relation_name", patient.relation_name);
                        para.Add("@relation_code", patient.relation_code);
                        para.Add("@home_street", patient.home_street);
                        para.Add("@home_district", patient.home_district);
                        para.Add("@response_type", patient.response_type);
                        para.Add("@charge_type", patient.charge_type);
                        para.Add("@employer_name", patient.employer_name);
                        para.Add("@occupation_type", patient.occupation_type);
                        para.Add("@update_opera", patient.update_opera);

                        connection.Execute(sql, para, transaction);

                        //sql = GetSqlByTag("mzgh_mzpatientsfz_update_relation");
                        //para = new DynamicParameters();
                        //para.Add("@relative_code", relation_code);
                        //para.Add("@patient_id", pid); 

                        //connection.Execute(sql, para, transaction);
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}