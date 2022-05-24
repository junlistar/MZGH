using Dapper;
using Data.Entities;
using Data.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class UserDicRepository : RepositoryBase<UserDic>, IUserDicRepository
    {

        public List<UserDic> GetUserDic()
        {
            string sql = "select * from a_employee_mi where deleted_flag=0  order by emp_sn";

            return Select(sql);

        }
         
    }
}
