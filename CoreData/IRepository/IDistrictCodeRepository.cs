using Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface IDistrictCodeRepository : IRepositoryBase<DistrictCode> 
    {
        #region 扩展的dapper操作
         
        List<DistrictCode> GetDistrictCodes();
         
        #endregion
    }
}
