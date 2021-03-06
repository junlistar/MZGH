using MzsfData.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MzsfData.IRepository
{
    public interface IOccupationCodeRepository : IRepositoryBase<OccupationCode> 
    {
        #region 扩展的dapper操作
         
        List<OccupationCode> GetOccupationCodes();
         
        #endregion
    }
}
