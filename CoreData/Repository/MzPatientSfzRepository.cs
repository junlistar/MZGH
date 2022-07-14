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
            string selectSql = GetSqlByTag(221078);

            var para = new DynamicParameters();

            para.Add("@patient_id", patient_id);

            return Select(selectSql, para);

        }

    }
}
