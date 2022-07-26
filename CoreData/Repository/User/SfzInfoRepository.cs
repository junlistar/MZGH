using Dapper;
using Data.Entities;
using Data.IRepository;
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
             string home_street, string opera)
        {
            try
            {
                using (IDbConnection connection = DataBaseConfig.GetSqlConnection("write"))
                {
                    IDbTransaction transaction = connection.BeginTransaction();

                    try
                    {


                        string sql = @" update mz_patient_mi 
 set name=@name,home_tel=@home_tel,sex=@sex,marry_code=@marry_code,birthday=@birthday,
 relation_name=@relation_name,relation_code=@relation_code,home_street=@home_street,update_opera=@update_opera,update_date=getdate()
 where patient_id=@patient_id";

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
                        para.Add("@update_opera", opera);

                        connection.Execute(sql, para, transaction);

                        sql = @" update mz_patient_sfz set relative_code=@relative_code where patient_id=@patient_id";
                        para = new DynamicParameters();
                        para.Add("@relative_code", relation_code);
                        para.Add("@patient_id", pid);

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