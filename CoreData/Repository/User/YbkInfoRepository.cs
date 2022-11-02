
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
    public class YbkInfoRepository : RepositoryBase<YbkInfo>, IYbkInfoRepository
    {

        public bool UpdateYbkInfo(string psn_no, string psn_cert_type, string certno, string psn_name, string gend, string naty, string brdy, int age)
        {
            string selectSql = GetSqlByTag("mzgh_mzpatientybkinfo_checkadd");

            var para = new DynamicParameters();
            para.Add("@certno", certno);

            var _count = ExcuteScalar(selectSql, para);

            if (Convert.ToInt32(_count) > 0)
            {
                //编辑
                selectSql = GetSqlByTag("mzgh_mzpatientybkinfo_update");
            }
            else
            {
                //新增
                selectSql = GetSqlByTag("mzgh_mzpatientybkinfo_add");
            }
            para.Add("@psn_no", psn_no);
            para.Add("@psn_cert_type", psn_cert_type);
            para.Add("@psn_name", psn_name);
            para.Add("@gend", gend);
            para.Add("@naty", naty);
            para.Add("@brdy", brdy);
            para.Add("@age", age);

            Update(selectSql, para);

            return true;
        }

        public bool UpdateYbkInfoAll(string jsonStr)
        {
            try
            {
                YBResponse<UserInfoResponseModel> yBResponse = JsonConvert.DeserializeObject<YBResponse<UserInfoResponseModel>>(jsonStr);

                DynamicParameters para = new DynamicParameters();
                var dt_now = GetServerDateTime().ToString("yyyy-MM-dd HH:mm:ss");

                using (IDbConnection connection = DataBaseConfig.GetSqlConnection(DBConnectionEnum.Write))
                {
                    IDbTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        string sql = "";

                        if (yBResponse.output.insuinfo != null)
                        {
                            //删除旧数据，写入新数据
                            sql = GetSqlByTag("mzgh_mzpatientybkinsuinfo_del");

                            para.Add("@certno", yBResponse.output.baseinfo.certno);
                            connection.Execute(sql, para, transaction);

                            foreach (var item in yBResponse.output.insuinfo)
                            {
                                sql = GetSqlByTag("mzgh_mzpatientybkinsuinfo_add");
                                para = new DynamicParameters();
                                para.Add("@certno", yBResponse.output.baseinfo.certno);
                                para.Add("@balc", item.balc);
                                para.Add("@insutype", item.insutype);
                                para.Add("@psn_type", item.psn_type);
                                para.Add("@psn_insu_stas", item.psn_insu_stas);
                                para.Add("@psn_insu_date", item.psn_insu_date);
                                para.Add("@paus_insu_date", item.paus_insu_date);
                                para.Add("@cvlserv_flag", item.cvlserv_flag);
                                para.Add("@insuplc_admdvs", item.insuplc_admdvs);
                                para.Add("@emp_name", item.emp_name);

                                connection.Execute(sql, para, transaction);
                            }
                        }
                        if (yBResponse.output.idetinfo != null)
                        {
                            //删除旧数据，写入新数据
                            sql = GetSqlByTag("mzgh_mzpatientybkidetinfo_del");

                            para.Add("@certno", yBResponse.output.baseinfo.certno);
                            connection.Execute(sql, para, transaction);

                            foreach (var item in yBResponse.output.idetinfo)
                            {
                                sql = GetSqlByTag("");
                                para = new DynamicParameters();
                                para.Add("@certno", yBResponse.output.baseinfo.certno);
                                para.Add("@psn_idet_type", item.psn_idet_type);
                                para.Add("@psn_type_lv", item.psn_type_lv);
                                para.Add("@memo", item.memo);
                                para.Add("@begntime", item.begntime);
                                para.Add("@endtime", item.endtime);

                                connection.Execute(sql, para, transaction);
                            }

                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UserInfoResponseModel GetYbkDetailInfo(string certno)
        {
            try
            {

                using (IDbConnection connection = DataBaseConfig.GetSqlConnection())
                {

                    UserInfoResponseModel responseModel = new UserInfoResponseModel();

                    IDbTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        string sql = GetSqlByTag("mzgh_mzpatientybkinfo_get");
                        var para = new DynamicParameters();
                        para.Add("@certno", certno);
                        var info_list = connection.Query<BaseInfo>(sql, para, transaction);

                        sql = GetSqlByTag("mzgh_mzpatientybkinsuinfo_get");
                         
                        var insu_list = connection.Query<InsuInfo>(sql, para, transaction);

                        sql = GetSqlByTag("mzgh_mzpatientybkidetinfo_get");

                        var idt_list= connection.Query<IdetInfo>(sql, para, transaction);

                        responseModel.baseinfo = info_list.FirstOrDefault();
                        responseModel.insuinfo = insu_list.ToList();
                        responseModel.idetinfo = idt_list.ToList();

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                    return responseModel;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
