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

        public List<MzPatientSfz> GetDataBySfzId(string sfz_id)
        {
            string selectSql = GetSqlByTag(221078);

            var para = new DynamicParameters();

            para.Add("@sfz_id", sfz_id);

            return Select(selectSql, para);

        }

    }
}
