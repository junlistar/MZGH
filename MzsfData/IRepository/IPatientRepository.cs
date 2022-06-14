using MzsfData.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MzsfData.IRepository
{
    public interface IPatientRepository : IRepositoryBase<Patient>
    {
        #region 扩展的dapper操作
         
        List<Patient> GetPatientByCard(string cardno);

        List<Patient> GetPatientByBarcode(string barcode);
        List<Patient> GetPatientByPatientId(string pid);
         

        #endregion
    }
}
