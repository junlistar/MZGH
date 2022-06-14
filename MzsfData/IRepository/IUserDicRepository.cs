using MzsfData.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MzsfData.IRepository
{
    public interface IUserDicRepository : IRepositoryBase<UserDic> 
    {
        List<UserDic> GetUserDic();
    }
}
