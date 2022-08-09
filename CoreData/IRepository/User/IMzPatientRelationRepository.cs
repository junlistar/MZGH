using Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface IMzPatientRelationRepository : IRepositoryBase<MzPatientRelation> 
    {
        #region 扩展的dapper操作

        List<MzPatientRelation> GetMzPatientRelationByPatientId(string pid);
        bool UpdateMzPatientRelation(string patient_id, string relation_code, string sfz_id, string username, string sex, string tel, string opera, string birth, string address);

        bool UpdateUserBaseInfo(string pid, string name, string sex, string marry_code, string birthday, string tel, string relation_name, string relation_code,
             string home_street, string district, string responseType, string chargeType, string opera);

        #endregion
    }
}
