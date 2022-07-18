using Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface IUserDicRepository : IRepositoryBase<UserDic> 
    {
        List<UserDic> GetUserDic();

        List<RelativeCode> GetRelativeCodes();
    }
}
