using Dapper;
using MzsfData.Entities;
using MzsfData.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MzsfData.Repository
{
    public class ResponceTypeRepository : RepositoryBase<ResponceType>, IResponceTypeRepository
    {
   
        public List<ResponceType> GetResponceTypes()
        {
            string ghsql =GetSqlByTag(220025);
             
            return  Select(ghsql);


        }
         
    }
}
