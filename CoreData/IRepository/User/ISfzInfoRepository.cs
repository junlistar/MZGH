using Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface ISfzInfoRepository : IRepositoryBase<SfzInfo> 
    {
        #region 扩展的dapper操作

        List<SfzInfo> GetSfzInfoByPatientId(string pid);
        bool UpdateSfzInfo(string name, string sex, string address, string home_address, string folk, string birthday, string card_no);

        bool UpdateUserBaseInfo(string pid, string name, string sex, string marry_code, string birthday, string tel, string relation_name, string relation_code,
             string home_street, string opera);

        #endregion
    }
}
