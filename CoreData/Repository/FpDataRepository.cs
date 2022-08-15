using CoreData.Helpers;
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
        public FPRegistration GetFPRegistrationData(string patient_id, int ledger_sn, int admiss_times)
        {
            try
            {
                using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
                {
                    IDbTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        string sql = "fp_invEBillRegistration";

                        var para = new DynamicParameters();
                        para.Add("@patient_id", patient_id);
                        para.Add("@ledger_sn", ledger_sn);
                        para.Add("@admiss_times", admiss_times);

                        FPRegistration fPRegistration = new FPRegistration();



                        var reader = connection.ExecuteReader(sql, para, transaction, null, CommandType.StoredProcedure);
                        int count = 0;
                        while (reader.Read())
                        {
                            DataTable table = new DataTable();
                            //DataSet ds = DataTableHelper.GetDataSet(reader);
                            table.Load(reader);
                            if (count == 0)
                            {
                                fPRegistration.MainData = DataTableHelper.ToSingleModel<MainData>(table);
                            }
                            else if (count == 1)
                            {
                                fPRegistration.PayChannelDetails = DataTableHelper.ToModels<PayChannelDetail>(table);
                            }
                            else
                            {
                                fPRegistration.ChargeDetails = DataTableHelper.ToModels<ChargeDetail>(table);

                            }
                        }

                        transaction.Commit();

                        return fPRegistration;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


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
