using Dapper;
using Data.Entities;
using Data.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class GhDoctorOutRepository : RepositoryBase<GhDoctorOut>, IGhDoctorOutRepository
    {
   
        public List<GhDoctorOut> GetGhDoctorOuts()
        {
            string ghsql = GetSqlByTag(220040);
             
            return  Select(ghsql);


        }
         
    }
}
