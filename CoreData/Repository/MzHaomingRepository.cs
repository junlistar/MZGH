using Dapper;
using Data.Entities;
using Data.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class MzHaomingRepository : RepositoryBase<MzHaoming>, IMzHaomingRepository
    {
   
        public List<MzHaoming> GetMzHaomings()
        {
            string ghsql = GetSqlByTag("zd_haoming_get"); 
            return  Select(ghsql); 
        } 
    }
}
