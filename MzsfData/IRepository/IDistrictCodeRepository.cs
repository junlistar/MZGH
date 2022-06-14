using MzsfData.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MzsfData.IRepository
{
    public interface IDistrictCodeRepository : IRepositoryBase<DistrictCode> 
    {
        #region 扩展的dapper操作
         
        List<DistrictCode> GetDistrictCodes();
         
        #endregion
    }
}
