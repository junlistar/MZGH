using Dapper;
using MzsfData.Entities;
using MzsfData.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MzsfData.Repository
{
    public class MzVisitRepository : RepositoryBase<MzVisit>, IMzVisitRepository
    {
    
        public List<MzVisit> GetMzVisitsByDate(string patient_id, string begin,string end)
        {

            string ghsql = GetSqlByTag(221004);
            var para = new DynamicParameters();

            para.Add("@patient_id", patient_id);
            para.Add("@begin", begin);
            para.Add("@end", end);
            return Select(ghsql, para);
        } 
    }
}
