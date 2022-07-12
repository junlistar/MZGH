using Dapper;
using Data.Entities;
using Data.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class MzPatientSfzRepository : RepositoryBase<MzPatientSfz>, IMzPatientSfzRepository
    {

        public List<MzPatientSfz> GetDataByPatientId(string patient_id)
        {
            string selectSql = @"select * from mz_patient_sfz
left join mz_patient_sfz_info on mz_patient_sfz.sfz_id= mz_patient_sfz_info.card_no
 where patient_id=@patient_id";

            var para = new DynamicParameters();

            para.Add("@patient_id", patient_id);

            return Select(selectSql, para);

        }

    }
}
