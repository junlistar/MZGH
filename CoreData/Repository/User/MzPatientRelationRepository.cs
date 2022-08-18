using Dapper;
using Data.Entities;
using Data.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class MzPatientRelationRepository : RepositoryBase<MzPatientRelation>, IMzPatientRelationRepository
    {


        public List<MzPatientRelation> GetMzPatientRelationByPatientId(string pid)
        {
            string sql = GetSqlByTag("mzgh_mzpatientrelation_getbypid");
            var para = new DynamicParameters();
            para.Add("@patient_id", pid);

            return Select(sql, para);
        }


        public bool UpdateMzPatientRelation(string patient_id, string relation_code, string sfz_id, string username, string sex, string tel, string opera, string birth, string address)
        {
            using (IDbConnection connection = DataBaseConfig.GetSqlConnection(DBConnectionEnum.Write))
            {
                IDbTransaction transaction = connection.BeginTransaction(); try
                {
                    var datas = GetMzPatientRelationByPatientId(patient_id);
                    string selectSql = "";
                    var para = new DynamicParameters();
                    if (datas.Count > 0)
                    {
                        //编辑
                        selectSql = GetSqlByTag("mzgh_mzpatientrelation_update");
                    }
                    else
                    {
                        //新增
                        selectSql = GetSqlByTag("mzgh_mzpatientrelation_add");
                    }
                    para.Add("@patient_id", patient_id);
                    para.Add("@relation_code", relation_code);
                    para.Add("@sfz_id", sfz_id);
                    para.Add("@username", username);
                    para.Add("@sex", sex);
                    para.Add("@tel", tel);
                    para.Add("@opera", opera);
                    para.Add("@birth", birth);
                    para.Add("@address", address);
                    para.Add("@update_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                    Update(selectSql, para);


                    //更新mz_patient_mi 关联信息
                    selectSql = "update mz_patient_mi set relation_name = @relation_name, relation_code = @relation_code where patient_id=@patient_id";
                    para = new DynamicParameters();
                    para.Add("@patient_id", patient_id);
                    para.Add("@relation_code", relation_code); 
                    para.Add("@relation_name", username);

                    Update(selectSql, para);

                    ////更新mz_patient_sfz 关联信息  
                    //selectSql = "update mz_patient_sfz set relative_code= @relative_code where patient_id=@patient_id";
                    //para = new DynamicParameters();
                    //para.Add("@patient_id", patient_id);
                    //para.Add("@relative_code", relation_code);
                    //Update(selectSql, para);

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
                        //para.Add("@patient_id", pid); 废弃

                        connection.Execute(sql, para, transaction);
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