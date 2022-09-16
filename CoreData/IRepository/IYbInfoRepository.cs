using Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface IYbInfoRepository : IRepositoryBase<BaseModel> 
    {
        #region 扩展的dapper操作

        bool AddYB1101(string jsonStr);

        bool AddYB2201(string jsonStr);

        bool AddYB2203(string jsonStr);

        bool AddYB2204(string jsonStr);

        bool AddYB2207(string jsonStr);

        bool AddYB2208(string patient_id, string admiss_times, string mdtrt_id);

        List<Insutype> GetInsutypes();

        List<MdtrtCertType> GetMdtrtCertTypes();

        List<MedType> GetMedTypes();

        List<DiagType> GetDiagTypes();

        List<IcdCode> GetIcdCodes();

        List<BirctrlType> GetBirctrlTypes();

        UserInfoResponseModel GetYjsUserInfo(string patient_id, int admiss_times);

        #endregion
    }
}
