using Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface IGhOpReceiptRepository : IRepositoryBase<GhOpReceipt> 
    {
        #region 扩展的dapper操作


        List<GhOpReceipt> GetCurrentReceiptNo();


        #endregion
    }
}
