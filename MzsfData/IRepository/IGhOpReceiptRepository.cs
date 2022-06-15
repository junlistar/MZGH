using MzsfData.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MzsfData.IRepository
{
    public interface IGhOpReceiptRepository : IRepositoryBase<GhOpReceipt> 
    {
        #region 扩展的dapper操作


        List<GhOpReceipt> GetCurrentReceiptNo(string operate);


        #endregion
    }
}
