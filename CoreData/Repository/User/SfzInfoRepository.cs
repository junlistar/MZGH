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
   
        public bool UpdateSfzInfo(string name ,string sex,string address,string home_address,string folk,string birthday,string card_no)
        {
            string selectSql = GetSqlByTag(221066);

            var para = new DynamicParameters();
            para.Add("@card_no", card_no);

            var _count = ExcuteScalar(selectSql, para);

            if (Convert.ToInt32(_count)>0)
            {
                //编辑
                selectSql = GetSqlByTag(221067);
            }
            else
            {
                //新增
                selectSql = GetSqlByTag(221068);
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
 
    }
}
