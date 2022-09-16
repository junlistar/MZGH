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
        List<GhDoctorOut> GetGhDoctorOutsByParams(string doctor_id, string date1);

        bool UpdateGhDoctorOut(string jsonStr);

        List<BaseRequest> GetExistGhrequest(string doctor_sn, string t1, string t2);


        #endregion
    }
}
