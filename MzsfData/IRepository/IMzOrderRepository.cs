using MzsfData.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MzsfData.IRepository
{
    public interface IMzOrderRepository : IRepositoryBase<MzOrder> 
    {
        #region 扩展的dapper操作


        List<MzOrder> GetMzOrdersByPatientId(string patient_id,int times);
         

        #endregion
    }
}
