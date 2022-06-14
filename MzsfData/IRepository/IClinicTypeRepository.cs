using MzsfData.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MzsfData.IRepository
{
    public interface IClinicTypeRepository : IRepositoryBase<ClinicType> 
    {
        #region 扩展的dapper操作


        List<ClinicType> GetClinicTypes();

        List<ClinicType> GetRequestTypes();
        #endregion
    }
}
