using Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface IYbkInfoRepository : IRepositoryBase<YbkInfo> 
    {
        #region 扩展的dapper操作


        bool UpdateYbkInfo(string psn_no, string psn_cert_type, string certno, string psn_name, string gend, string naty, string brdy, int age);

        bool UpdateYbkInfoAll(string jsonStr);

        UserInfoResponseModel GetYbkDetailInfo(string certno);

        #endregion
    }
}
