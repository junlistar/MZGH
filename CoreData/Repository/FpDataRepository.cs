using CoreData.Helpers;
using Dapper;
using Data.Entities;
using Data.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
                   // IDbTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        string sql = "fp_invEBillRegistration";

                        var para = new DynamicParameters();
                        para.Add("@patient_id", patient_id);
                        para.Add("@ledger_sn", ledger_sn);
                        para.Add("@admiss_times", admiss_times);

                        string adpsql = $"exec fp_invEBillRegistration '{patient_id}',{ledger_sn},{admiss_times}";

                        FPRegistration fPRegistration = new FPRegistration();
                        IDbCommand dbCommand = connection.CreateCommand();
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(adpsql, connection as SqlConnection); ;
                        DataSet ds = new DataSet();//创建DataSet实例
                        sqlDataAdapter.Fill(ds);

                        if (ds!=null && ds.Tables.Count>0)
                        {
                            fPRegistration.MainData = DataTableHelper.ToSingleModel<MainData>(ds.Tables[0]);
                            fPRegistration.PayChannelDetails = DataTableHelper.ToModels<PayChannelDetail>(ds.Tables[1]);
                            fPRegistration.ChargeDetails = DataTableHelper.ToModels<ChargeDetail>(ds.Tables[2]);
                        } 

                        return fPRegistration;
                    }
                    catch (Exception ex)
                    {
                       // transaction.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception)
            { 
                throw;
            }
        }
        public FPRegistration GetFPInvoiceEBillOutpatient(string patient_id, int ledger_sn, int admiss_times)
        {
            try
            {
                using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
                {
                    // IDbTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        string sql = "fp_invoiceEBillOutpatient";

                        var para = new DynamicParameters();
                        para.Add("@patient_id", patient_id);
                        para.Add("@ledger_sn", ledger_sn);
                        para.Add("@admiss_times", admiss_times);

                        string adpsql = $"exec fp_invoiceEBillOutpatient '{patient_id}',{ledger_sn},{admiss_times}";

                        FPRegistration fPRegistration = new FPRegistration();
                        IDbCommand dbCommand = connection.CreateCommand();
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(adpsql, connection as SqlConnection); ;
                        DataSet ds = new DataSet();//创建DataSet实例
                        sqlDataAdapter.Fill(ds);

                        if (ds != null && ds.Tables.Count > 0)
                        {
                            fPRegistration.MainData = DataTableHelper.ToSingleModel<MainData>(ds.Tables[0]);
                            fPRegistration.PayChannelDetails = DataTableHelper.ToModels<PayChannelDetail>(ds.Tables[1]);
                            fPRegistration.ChargeDetails = DataTableHelper.ToModels<ChargeDetail>(ds.Tables[2]);
                        }

                        return fPRegistration;
                    }
                    catch (Exception ex)
                    {
                        // transaction.Rollback();
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
