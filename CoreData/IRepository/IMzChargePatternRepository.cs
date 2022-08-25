using Data.Entities;
using Data.Entities.Mzsf;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface IMzChargePatternRepository : IRepositoryBase<BaseModel> 
    {
        #region 扩展的dapper操作

        List<MzChargePattern> GetMzChargePatterns();

        List<MzChargePatternDetail> GetMzPatternDetails();

        #endregion
    }
}
