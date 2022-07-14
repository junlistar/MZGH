using Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface ISfzInfoRepository : IRepositoryBase<SfzInfo> 
    {
        #region 扩展的dapper操作


        bool UpdateSfzInfo(string name, string sex, string address, string home_address, string folk, string birthday, string card_no);


        #endregion
    }
}
