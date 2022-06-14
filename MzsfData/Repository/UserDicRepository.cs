using Dapper;
using MzsfData.Entities;
using MzsfData.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MzsfData.Repository
{
    public class UserDicRepository : RepositoryBase<UserDic>, IUserDicRepository
    {

        public List<UserDic> GetUserDic()
        {
            string sql =GetSqlByTag(220024);

            return Select(sql);

        }
         
    }
}
