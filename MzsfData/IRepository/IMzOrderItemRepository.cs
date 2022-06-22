using MzsfData.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MzsfData.IRepository
{
    public interface IMzOrderItemRepository : IRepositoryBase<MzOrderItem> 
    {
        #region 扩展的dapper操作


        List<MzOrderItem> GetMzOrderItem(string order_type, string py_code);


        #endregion
    }
}
