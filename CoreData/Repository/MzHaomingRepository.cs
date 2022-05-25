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
            string ghsql = GetSqlByTag(220027);
             
            return  Select(ghsql);


        } 
    }
}
