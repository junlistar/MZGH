using Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface IGhDoctorOutRepository : IRepositoryBase<GhDoctorOut> 
    {
        #region 扩展的dapper操作


        List<GhDoctorOut> GetGhDoctorOuts();

        bool UpdateGhDoctorOut(string jsonStr);


        #endregion
    }
}
