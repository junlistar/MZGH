using MzsfData.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MzsfData.IRepository
{
    public interface IMzVisitRepository : IRepositoryBase<MzVisit> 
    {
        #region 扩展的dapper操作
         
        List<MzVisit> GetMzVisitsByDate(string patient_id, string begin, string end);

        List<MzVisit> CreateVisitRecord(string haoming_code, string patient_id, int times, int expertflag, string unit_sn, string doctor_sn);

        #endregion
    }
}
