using Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface IMzPatientSfzRepository : IRepositoryBase<MzPatientSfz> 
    {
        #region 扩展的dapper操作


        List<MzPatientSfz> GetDataByPatientId(string patient_id);


        #endregion
    }
}
