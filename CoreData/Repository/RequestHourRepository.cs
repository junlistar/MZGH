using Dapper;
using Data.Entities;
using Data.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class RequestHourRepository : RepositoryBase<RequestHour>, IRequestHourRepository
    {
   
        public List<RequestHour> GetRequestHours()
        {
            string ghsql = GetSqlByTag(220064);
           
            return  Select(ghsql); 
        }
         
    }
}
